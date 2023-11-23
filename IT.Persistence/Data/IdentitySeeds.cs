using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IT.Domain;
using Microsoft.AspNetCore.Identity;

namespace IT.Persistence.Data {
    public static class IdentitySeeds {
        public static async Task SystemUserSeeds(UserManager<SystemUser> userManager) {
            if(userManager.Users.Any()) {
                return;
            }

            var users = new List<SystemUser> {
                new SystemUser {
                    DisplayName = "Administrator",
                    UserName = "Administrator",
                    Email = "administrator@example.com",
                },
                new SystemUser {
                    DisplayName = "Service Administrator",
                    UserName = "ServiceAdministrator",
                    Email = "serviceadmin@example.com"
                }
            };

            foreach(var user in users) {
                await userManager.CreateAsync(user, "Pa$$w0rd");
                await  userManager.AddToRoleAsync(user, SystemUserRoles.Role_SysAdmin);
            }
        }

        public static async Task SystemUserRoleSeeds(RoleManager<IdentityRole> roleManager) {
            if(!await roleManager.RoleExistsAsync(SystemUserRoles.Role_Client_Manager)) {
                await roleManager.CreateAsync(new IdentityRole(SystemUserRoles.Role_Client_Manager));
            }
            if(!await roleManager.RoleExistsAsync(SystemUserRoles.Role_Client_User)) {
                await roleManager.CreateAsync(new IdentityRole(SystemUserRoles.Role_Client_User));
            }
            if(!await roleManager.RoleExistsAsync(SystemUserRoles.Role_SysUser_Manager)) {
                await roleManager.CreateAsync(new IdentityRole(SystemUserRoles.Role_SysUser_Manager));
            }
            if(!await roleManager.RoleExistsAsync(SystemUserRoles.Role_SysUser)) {
                await roleManager.CreateAsync(new IdentityRole(SystemUserRoles.Role_SysUser));
            }
            if(!await roleManager.RoleExistsAsync(SystemUserRoles.Role_SysAdmin)) {
                await roleManager.CreateAsync(new IdentityRole(SystemUserRoles.Role_SysAdmin));
            }
        }
    }
}