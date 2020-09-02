USE master
DROP DATABASE [Budget_CMS]
GO
CREATE DATABASE [Budget_CMS]
GO
DROP DATABASE Budget
GO

CREATE DATABASE Budget
GO

USE Budget

CREATE TABLE [dbo].[User] (
    [Id] INT NOT NULL IDENTITY(1,1)
        CONSTRAINT PK_User PRIMARY KEY
    ,[FirstName] VARCHAR(200) NOT NULL
    ,[MiddleName] VARCHAR(200) NOT NULL
    ,[LastName] VARCHAR(200) NOT NULL
    ,[LockoutEnd] DATETIMEOFFSET NULL
    ,[TwoFactorEnabled] BIT NOT NULL
    ,[PhoneNumberConfirmed] BIT NOT NULL
    ,[PhoneNumber] VARCHAR(200) NULL
    ,[ConcurrencyStamp] VARCHAR(200) NOT NULL
    ,[SecurityStamp] VARCHAR(200) NOT NULL
    ,[PasswordHash] VARCHAR(200) NOT NULL
    ,[EmailConfirmed] BIT NOT NULL
    ,[NormalizedEmail] VARCHAR(200) NULL
    ,[Email] VARCHAR(200) NOT NULL
    ,[UserName] VARCHAR(200) NOT NULL
    ,[NormalizedUserName] VARCHAR(200) NOT NULL
    ,[LockoutEnabled] BIT NOT NULL
    ,[AccessFailedCount] INT NOT NULL
    ,[Created] DATETIMEOFFSET NOT NULL
    ,[Modified] DATETIMEOFFSET NOT NULL
)

CREATE TABLE [dbo].[UserClaim] (
    [Id] INT NOT NULL IDENTITY(1,1)
        CONSTRAINT PK_UserClaim PRIMARY KEY
    ,[UserId] INT NOT NULL
        CONSTRAINT FK_UserClaim_User
        REFERENCES [dbo].[User]
    ,[ClaimType] VARCHAR(80) NOT NULL
    ,[ClaimValue] VARCHAR(80) NOT NULL
)

CREATE TABLE [dbo].[UserLogin](
    [Id] INT NOT NULL IDENTITY(1,1)
        CONSTRAINT PK_UserLogin PRIMARY KEY
    ,[LoginProvider] VARCHAR(200) NOT NULL
    ,[ProviderKey] VARCHAR(200) NOT NULL
    ,[ProviderDisplayName] VARCHAR(200) NOT NULL
    ,[UserId] INT NOT NULL
        CONSTRAINT FK_UserLogin_User
        REFERENCES [dbo].[User]
)

CREATE TABLE [dbo].[UserToken] (
    [Id] INT NOT NULL IDENTITY(1,1)
        CONSTRAINT PK_UserToken PRIMARY KEY
    ,[UserId] INT NOT NULL
        CONSTRAINT FK_UserToken_User
        REFERENCES [dbo].[User]
    ,[LoginProvider] VARCHAR(200) NOT NULL
    ,[Value] VARCHAR(200) NOT NULL
)

CREATE TABLE [Role] (
    [Id] INT IDENTITY(1,1)
        CONSTRAINT PK_Role PRIMARY KEY
    ,[Name] VARCHAR(200) NOT NULL
    ,[Description] VARCHAR(200) NOT NULL
    ,[NormalizedName] VARCHAR(200) NOT NULL
    ,[ConcurrencyStamp] VARCHAR(200) NOT NULL
)

CREATE TABLE [UserRole] (
    [Id] INT IDENTITY(1,1)
        CONSTRAINT PK_UserRole PRIMARY KEY
    ,[UserId] INT NOT NULL
        CONSTRAINT FK_UserRole_User
        REFERENCES [dbo].[User]
    ,[RoleId] INT NOT NULL
        CONSTRAINT FK_UserRole_Role
        REFERENCES [dbo].[Role]
)

CREATE TABLE [RoleClaim] (
    [Id] INT NOT NULL IDENTITY(1,1)
        CONSTRAINT PK_RoleClaim PRIMARY KEY
    ,[RoleId] INT NOT NULL
        CONSTRAINT FK_RoleClaim_Role
        REFERENCES [dbo].[Role]
    ,[ClaimType] VARCHAR(200) NOT NULL
    ,[ClaimValue] VARCHAR(200) NOT NULL
)



        --//
        --// Summary:
        --//     Gets or sets the identifier for this role claim.
        --public virtual int Id { get; set; }
        --//
        --// Summary:
        --//     Gets or sets the of the primary key of the role associated with this claim.
        --public virtual TKey RoleId { get; set; }
        --//
        --// Summary:
        --//     Gets or sets the claim type for this claim.
        --public virtual string ClaimType { get; set; }
        --//
        --// Summary:
        --//     Gets or sets the claim value for this claim.
        --public virtual string ClaimValue { get; set; }

        SELECT * FROM dbo.[User]