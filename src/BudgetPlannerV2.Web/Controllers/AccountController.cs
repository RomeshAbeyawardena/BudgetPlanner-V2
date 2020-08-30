using AutoMapper;
using BudgetPlannerV2.Domains.Data;
using BudgetPlannerV2.Domains.Exceptions;
using BudgetPlannerV2.Domains.ViewModels;
using DNI.Core.Contracts;
using DNI.Core.Services.Extensions;
using DNI.Core.Services.Handlers;
using DNI.Core.Contracts.Providers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using BudgetPlannerV2.Broker.Extensions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BudgetPlannerV2.Web.Controllers
{
    public class AccountController : DefaultController
    {
        public AccountController(IExceptionHandler exceptionHandler,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IModelEncryptionProvider modelEncryptionProvider,
            IMapper mapper)
        {
            this.exceptionHandler = exceptionHandler;
            this.userManager = userManager;
            this.signInManager = signInManager;

            this.modelEncryptionProvider = modelEncryptionProvider;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromForm] RegisterViewModel registerViewModel)
        {
            var encryptedRegisterViewModel = modelEncryptionProvider.Encrypt(registerViewModel);
            return await exceptionHandler.TryAsync<RegisterViewModel, IActionResult>(encryptedRegisterViewModel, async (user) =>
            {
                if (!ModelState.IsValid)
                {
                    throw new UserRegistrationException();
                }

                if (await userManager.FindByEmailAsync(user.EmailAddress) != null)
                {
                    throw new UserRegistrationException("Email address already in use");

                }

                var mappedUser = mapper.Map<User>(user);
                mappedUser.PasswordHash = userManager.PasswordHasher.HashPassword(mappedUser, user.Password);

                var result = await userManager.CreateAsync(mappedUser);

                if (!result.Succeeded)
                {
                    throw new UserRegistrationException(result.Errors, "Errors occurred");
                }

                return Ok(modelEncryptionProvider
                    .Decrypt(await userManager.FindByEmailAsync(user.EmailAddress)));
            }, async (exception) =>
            {
                await Task.CompletedTask;
                var userRegistrationException = exception as UserRegistrationException;

                if (!string.IsNullOrEmpty(exception.Message))
                {
                    ModelState.AddModelError("", exception.Message);
                }

                CaptureIdentityErrorsIntoModelState(ModelState, userRegistrationException.Errors);

                return BadRequest(ModelState);
            }, t => t.DescribeType<UserRegistrationException>());
        }

        [HttpGet]
        [Route("{emailAddress}")]
        public IActionResult Confirm([FromRoute] string emailAddress)
        {
            return View(new ConfirmViewModel { EmailAddress = emailAddress });
        }

        [HttpPost]
        [Route("{emailAddress}")]
        public async Task<IActionResult> Confirm([FromForm] ConfirmViewModel confirmViewModel)
        {
            if (ModelState.IsValid)
            {
                var encryptedUser = modelEncryptionProvider.Encrypt(confirmViewModel);

                var foundUser = await userManager.FindByEmailAsync(encryptedUser.EmailAddress);
                return await exceptionHandler.TryAsync<User, IActionResult>(foundUser, async(user) =>
                {

                    if (user == null || await userManager.IsEmailConfirmedAsync(user))
                    {
                        throw new UserRegistrationException("User not found or has already been verified");
                    }

                    if (await userManager.CheckPasswordAsync(user, confirmViewModel.Password) == false)
                    {
                        throw new UserRegistrationException("Email address or password invalid");
                    }
                    var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                    return Ok(Convert.ToBase64String(token.GetBytes(Encoding.UTF8).ToArray()));
                }, async(exception) => {
                    await Task.CompletedTask;
                    ModelState.AddModelError("", exception.Message);
                    return View(confirmViewModel);
                }, type => type.DescribeType<UserRegistrationException>());
            }

            return View(confirmViewModel);
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpGet]
        [Route("{userToken}:{securityToken}")]
        public async Task<IActionResult> Verify([FromRoute]string userToken, [FromRoute] string securityToken)
        {
            
            return await exceptionHandler.TryAsync<string, IActionResult>(securityToken, async (token) =>
            {
                var secureToken = Convert.FromBase64String(token).GetString(Encoding.UTF8);

                if (!ModelState.IsValid)
                {
                    throw new UserRegistrationException();
                }

                var user = await userManager.FindBySecurityTokenAsync(userToken);

                if (user == null)
                {
                    throw new UserRegistrationException($"Account with security token {token} not found");
                }

                if (await userManager.IsEmailConfirmedAsync(user))
                {
                    throw new UserRegistrationException("Account already verified");
                }

                var result = await userManager.ConfirmEmailAsync(user, secureToken);

                if (!result.Succeeded)
                {
                    throw new UserRegistrationException(result.Errors, "Unable to validate token");
                }

                return Ok("Account has been verified");
            }, async (exception) =>
            {
                await Task.CompletedTask;
                var userRegistrationException = exception as UserRegistrationException;

                if (!string.IsNullOrEmpty(exception.Message))
                {
                    ModelState.AddModelError("", exception.Message);
                }

                return BadRequest(ModelState);
            }, t => t.DescribeType<UserRegistrationException>());
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromForm] LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var encryptedUser = modelEncryptionProvider.Encrypt(loginViewModel);

                var user = await userManager.FindByEmailAsync(encryptedUser.EmailAddress);

                return await exceptionHandler.TryAsync<User, IActionResult>(user, async (user) =>
                {
                    if (user == null)
                    {
                        throw new NullReferenceException("Email address or password invalid");
                    }

                    if (!await userManager.IsEmailConfirmedAsync(user))
                    {
                        throw new UserLoginException(user, "Email address not confirmed");
                    }

                    if (await userManager.IsLockedOutAsync(user))
                    {
                        throw new UserLoginException(user, "Account locked out");
                    }

                    if (await userManager.CheckPasswordAsync(user, loginViewModel.Password) == false)
                    {
                        await userManager.AccessFailedAsync(user);
                        throw new UserLoginException(user, "Email address or password invalid");
                    }

                    await signInManager.SignInAsync(user, loginViewModel.PersistUserSecurity, nameof(Login));

                    return View(loginViewModel);
                }, async (exception) =>
                {
                    await Task.CompletedTask;
                    ModelState.AddModelError("", exception.Message);
                    return View(loginViewModel);
                },
                exceptionTypes: t => t
                    .DescribeType<NullReferenceException>()
                    .DescribeType<UserLoginException>());
            }
            return View(loginViewModel);
        }

        private void CaptureIdentityErrorsIntoModelState(ModelStateDictionary modelState, IEnumerable<IdentityError> errors)
        {
            if (errors != null && errors.Any())
            {
                foreach (var error in errors)
                {
                    modelState.AddModelError("", string.Format("{0}: {1}", error.Code, error.Description));
                }
            }
        }

        private readonly IExceptionHandler exceptionHandler;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IModelEncryptionProvider modelEncryptionProvider;
        private readonly IMapper mapper;
    }

}
