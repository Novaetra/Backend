﻿using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using EntityFramework.DynamicFilters;
using Novaetra.Backend.Authorization;
using Novaetra.Backend.EntityFramework;
using Novaetra.Backend.MultiTenancy;
using Novaetra.Backend.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novaetra.Backend.Migrations.Data
{
    public class InitialDataBuilder
    {
        public void Build(BackendDbContext context)
        {
            context.DisableAllFilters();
            CreateUserAndRoles(context);
        }

        private void CreateUserAndRoles(BackendDbContext context)
        {
            //Admin role for tenancy owner
            Role adminRoleForTenancyOwner = context.Roles.FirstOrDefault(r => r.TenantId == null && r.Name == "Admin");
            if (adminRoleForTenancyOwner == null)
            {
                adminRoleForTenancyOwner = context.Roles.Add(new Role(null, "Admin", "Admin"));
                context.SaveChanges();
            }

            //Admin user for tenancy owner
            User adminUserForTenancyOwner = context.Users.FirstOrDefault(u => u.TenantId == null && u.UserName == "admin");
            if (adminUserForTenancyOwner == null)
            {
                adminUserForTenancyOwner = context.Users.Add(
                    new User
                    {
                        TenantId = null,
                        UserName = "admin",
                        Name = "System",
                        Surname = "Administrator",
                        EmailAddress = "admin@aspnetboilerplate.com",
                        IsEmailConfirmed = true,
                        Password = "AM4OLBpptxBYmM79lGOX9egzZk3vIQU3d/gFCJzaBjAPXzYIK3tQ2N7X4fcrHtElTw==" //123qwe
                    });

                context.SaveChanges();

                context.UserRoles.Add(new UserRole(null, adminUserForTenancyOwner.Id, adminRoleForTenancyOwner.Id));

                context.SaveChanges();
            }

            //Default tenant
            Tenant defaultTenant = context.Tenants.FirstOrDefault(t => t.TenancyName == "Default");
            if (defaultTenant == null)
            {
                defaultTenant = context.Tenants.Add(new Tenant("Default", "Default"));
                context.SaveChanges();
            }

            //Admin role for 'Default' tenant
            Role adminRoleForDefaultTenant = context.Roles.FirstOrDefault(r => r.TenantId == defaultTenant.Id && r.Name == "Admin");
            if (adminRoleForDefaultTenant == null)
            {
                adminRoleForDefaultTenant = context.Roles.Add(new Role(defaultTenant.Id, "Admin", "Admin"));
                context.SaveChanges();

                //Permission definitions for Admin of 'Default' tenant
                context.Permissions.Add(new RolePermissionSetting { TenantId = defaultTenant.Id, RoleId = adminRoleForDefaultTenant.Id, Name = "CanDeleteAnswers", IsGranted = true });
                context.Permissions.Add(new RolePermissionSetting { TenantId = defaultTenant.Id, RoleId = adminRoleForDefaultTenant.Id, Name = "CanDeleteQuestions", IsGranted = true });
                context.SaveChanges();
            }

            //User role for 'Default' tenant
            Role userRoleForDefaultTenant = context.Roles.FirstOrDefault(r => r.TenantId == defaultTenant.Id && r.Name == "User");
            if (userRoleForDefaultTenant == null)
            {
                userRoleForDefaultTenant = context.Roles.Add(new Role(defaultTenant.Id, "User", "User"));
                context.SaveChanges();

                //Permission definitions for User of 'Default' tenant
                context.Permissions.Add(new RolePermissionSetting { TenantId = defaultTenant.Id, RoleId = userRoleForDefaultTenant.Id, Name = "CanCreateQuestions", IsGranted = true });
                context.SaveChanges();
            }

            //Admin for 'Default' tenant
            User adminUserForDefaultTenant = context.Users.FirstOrDefault(u => u.TenantId == defaultTenant.Id && u.UserName == "admin");
            if (adminUserForDefaultTenant == null)
            {
                adminUserForDefaultTenant = context.Users.Add(
                    new User
                    {
                        TenantId = defaultTenant.Id,
                        UserName = "admin",
                        Name = "System",
                        Surname = "Administrator",
                        EmailAddress = "admin@aspnetboilerplate.com",
                        IsEmailConfirmed = true,
                        Password = "AM4OLBpptxBYmM79lGOX9egzZk3vIQU3d/gFCJzaBjAPXzYIK3tQ2N7X4fcrHtElTw==" //123qwe
                    });
                context.SaveChanges();

                context.UserRoles.Add(new UserRole(defaultTenant.Id, adminUserForDefaultTenant.Id, adminRoleForDefaultTenant.Id));
                context.UserRoles.Add(new UserRole(defaultTenant.Id, adminUserForDefaultTenant.Id, userRoleForDefaultTenant.Id));
                context.SaveChanges();

                //var question1 = context.Questions.Add(
                //    new Question(
                //        "What's the answer of ultimate question of life the universe and everything?",
                //        "What's the answer of ultimate question of life the universe and everything? Please answer this question!"
                //        )
                //    );
                //context.SaveChanges();

                //question1.CreatorUserId = adminUserForDefaultTenant.Id;
                //context.SaveChanges();
            }

            //User 'Emre' for 'Default' tenant
            User emreUserForDefaultTenant = context.Users.FirstOrDefault(u => u.TenantId == defaultTenant.Id && u.UserName == "emre");
            if (emreUserForDefaultTenant == null)
            {
                emreUserForDefaultTenant = context.Users.Add(
                    new User
                    {
                        TenantId = defaultTenant.Id,
                        UserName = "emre",
                        Name = "Yunus Emre",
                        Surname = "Kalkan",
                        EmailAddress = "emre@aspnetboilerplate.com",
                        IsEmailConfirmed = true,
                        Password = "AM4OLBpptxBYmM79lGOX9egzZk3vIQU3d/gFCJzaBjAPXzYIK3tQ2N7X4fcrHtElTw==" //123qwe
                    });
                context.SaveChanges();

                context.UserRoles.Add(new UserRole(defaultTenant.Id, emreUserForDefaultTenant.Id, userRoleForDefaultTenant.Id));
                context.SaveChanges();

                //var question2 = context.Questions.Add(
                //    new Question(
                //        "Jquery content replacement not working within my function",
                //        @"What I am trying to achieve, and I am nearly there, is the user clicks on a checkbox and it turns green (Checkbox-active class). However, I also want the text/content of the clicked element to change to ""Activated"" and then reverts back to the original text when clicked again or on a sibling."
                //        )
                //    );
                //context.SaveChanges();

                //question2.CreatorUserId = emreUserForDefaultTenant.Id;
                //context.SaveChanges();
            }
        }
    }
}
