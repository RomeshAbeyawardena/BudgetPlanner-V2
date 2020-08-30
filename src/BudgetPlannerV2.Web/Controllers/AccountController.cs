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

namespace BudgetPlannerV2.Web.Controllers
{
    public class AccountController : DefaultController
    {
        public AccountController(IExceptionHandler exceptionHandler,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IPasswordHasher<User> passwordHasher,
            IModelEncryptionProvider modelEncryptionProvider,
            IMapper mapper)
        {
            this.exceptionHandler = exceptionHandler;
            this.userManager = userManager;
            this.signInManager = signInManager;
            //userManager.PasswordHasher = passwordHasher;
            
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
            }, async(exception) => { 
                await Task.CompletedTask;
                var userRegistrationException = exception as UserRegistrationException;

                if(!string.IsNullOrEmpty(exception.Message))
                { 
                    ModelState.AddModelError("", exception.Message);
                }

                if (userRegistrationException.Errors != null && userRegistrationException.Errors.Any())
                {
                    foreach(var error in userRegistrationException.Errors)
                    { 
                        ModelState.AddModelError("", string.Format("{0}: {1}", error.Code, error.Description));
                    }   
                }

                return BadRequest(ModelState);
            }, t => t.DescribeType<UserRegistrationException>());
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromForm] LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(loginViewModel.EmailAddress);

                return await exceptionHandler.TryAsync<User, IActionResult>(user, async (user) =>
                {
                    if (user == null)
                    {
                        throw new NullReferenceException("Email address or password invalid");
                    }

                    if (await userManager.IsEmailConfirmedAsync(user))
                    {
                        throw new UserLoginException(user, "Email address not confirmed");
                    }

                    if (await userManager.IsLockedOutAsync(user))
                    {
                        throw new UserLoginException(user, "Account locked out");
                    }

                    if (await userManager.CheckPasswordAsync(user, loginViewModel.Password) == false)
                    {
                        throw new UserLoginException(user, "Email address or password invalid");
                    }

                    await signInManager.SignInAsync(user, loginViewModel.PersistUserSecurity, nameof(Login));

                    return View(loginViewModel);
                }, async (exception) =>
                {
                    ModelState.AddModelError("", exception.Message);
                    return View(loginViewModel);
                },
                exceptionTypes: t => t
                    .DescribeType<NullReferenceException>()
                    .DescribeType<UserLoginException>());
            }
            return View(loginViewModel);
        }

        private readonly IExceptionHandler exceptionHandler;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IModelEncryptionProvider modelEncryptionProvider;
        private readonly IMapper mapper;
    }

}
