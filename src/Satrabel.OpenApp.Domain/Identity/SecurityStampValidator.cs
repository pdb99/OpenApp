﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Abp.Authorization;
using Satrabel.OpenApp.Authorization.Roles;
using Satrabel.OpenApp.Authorization.Users;
using Satrabel.OpenApp.MultiTenancy;
using Microsoft.Extensions.Logging;

namespace Satrabel.OpenApp.Identity
{
    public class SecurityStampValidator : AbpSecurityStampValidator<Tenant, Role, User>
    {
        public SecurityStampValidator(
            IOptions<SecurityStampValidatorOptions> options, 
            SignInManager signInManager,
            ISystemClock systemClock,
             ILoggerFactory loggerFactory) 
            : base(
                  options, 
                  signInManager, 
                  systemClock,
                  loggerFactory
                  )
        {
        }
    }
}