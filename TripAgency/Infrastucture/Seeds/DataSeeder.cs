using DataAccessLayer.Context;
using DataAccessLayer.Enum;
using Domain.Common;
using Domain.Entities.ApplicationEntities;
using Domain.Entities.IdentityEntities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Infrastructure.Seeds
{
    public class DataSeeder(
        ApplicationDbContext context,
        RoleManager<ApplicationRole> roleManeger,
        IdentityAppDbContext identityAppDbContext,
        UserManager<ApplicationUser> userManager)
    {
        private readonly ApplicationDbContext _context = context;
        private readonly IdentityAppDbContext _identityAppDbContext = identityAppDbContext;
        private readonly UserManager<ApplicationUser> _userManager = userManager;
        private readonly RoleManager<ApplicationRole> _roleManeger = roleManeger;
        public void SeedDataAsync()
        {
            var shouldUpdateContext = false;


            if (shouldUpdateContext)
            {
                shouldUpdateContext = false;
                _context.SaveChanges();
            }

            if (!_identityAppDbContext.Users.Any(u => u.Email == DefaultSetting.DefaultAdminOne))
            {
                var newUser = new ApplicationUser()
                {
                    Email = DefaultSetting.DefaultAdminOne,
                    UserName = DefaultSetting.DefaultAdminOne,
                    PhoneNumber = DefaultSetting.DefaultAdminOnePhone,
                    PhoneNumberConfirmed = true
                };

                var isCreated = _userManager.CreateAsync(newUser, DefaultSetting.DefaultAdminPassword).GetAwaiter().GetResult();
                if (isCreated.Succeeded)
                {
                    _userManager.AddToRoleAsync(newUser, DefaultSetting.AdminRoleName).GetAwaiter().GetResult();
                    var code = _userManager.GenerateEmailConfirmationTokenAsync(newUser).GetAwaiter().GetResult();
                    _userManager.ConfirmEmailAsync(newUser, code).GetAwaiter().GetResult();

                }
            }
            if (!_identityAppDbContext.Users.Any(u => u.Email == DefaultSetting.DefaultPublicRelationAccount))
            {
                var newUser = new ApplicationUser()
                {
                    Email = DefaultSetting.DefaultPublicRelationAccount,
                    UserName = DefaultSetting.DefaultPublicRelationAccount,
                    PhoneNumber = DefaultSetting.DefaultPublicRelationPhone,
                    PhoneNumberConfirmed = true
                };

                var isCreated = _userManager.CreateAsync(newUser, DefaultSetting.DefaultPublicRelationPassword).GetAwaiter().GetResult();
                if (isCreated.Succeeded)
                {
                    _userManager.AddToRoleAsync(newUser, DefaultSetting.PublicRelationRoleName).GetAwaiter().GetResult();
                    var code = _userManager.GenerateEmailConfirmationTokenAsync(newUser).GetAwaiter().GetResult();
                    _userManager.ConfirmEmailAsync(newUser, code).GetAwaiter().GetResult();

                }
            }
            if (!_identityAppDbContext.Users.Any(u => u.PhoneNumber == DefaultSetting.DefaultEmployeePhone))
            {
                var newUser = new ApplicationUser()
                {
                    Email = DefaultSetting.DefaultEmployeePhone,
                    UserName = DefaultSetting.DefaultEmployeePhone,
                    PhoneNumber = DefaultSetting.DefaultEmployeePhone,
                    PhoneNumberConfirmed = true
                };

                var isCreated = _userManager.CreateAsync(newUser, DefaultSetting.DefaultPublicRelationPassword).GetAwaiter().GetResult();
                if (isCreated.Succeeded)
                {
                    _userManager.AddToRoleAsync(newUser, DefaultSetting.EmployeeRoleName).GetAwaiter().GetResult();
                    var code = _userManager.GenerateEmailConfirmationTokenAsync(newUser).GetAwaiter().GetResult();
                    _userManager.ConfirmEmailAsync(newUser, code).GetAwaiter().GetResult();
                }
            }

            if (shouldUpdateContext)
            {
                shouldUpdateContext = false;
                _context.SaveChanges();
            }
        }
    }

}
