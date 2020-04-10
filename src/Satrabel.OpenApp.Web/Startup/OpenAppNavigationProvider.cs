﻿using Abp.Application.Navigation;
using Abp.Authorization;
using Abp.Localization;
using Satrabel.OpenApp.Authorization;

namespace Satrabel.OpenApp.Web.Startup
{
    /// <summary>
    /// This class defines menus for the application.
    /// </summary>
    public class OpenAppNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(new MenuItemDefinition(
                        "Admin",
                        L("Admin"),
                        icon: "menu"
                        )
                    .AddItem(
                        new MenuItemDefinition(
                            PageNames.Tenants,
                            L("Tenants"),
                            url: "/Crud#/OpenApp/tenant",
                            icon: "layers",
                            permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Tenants)
                        )
                        )
                    .AddItem(
                        new MenuItemDefinition(
                            PageNames.Users,
                            L("Users"),
                            url: "/Crud#/OpenApp/user",
                            icon: "people",
                            permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Users)
                        )
                    )
                    .AddItem(
                        new MenuItemDefinition(
                            PageNames.Roles,
                            L("Roles"),
                            url: "/Crud#/OpenApp/role",
                            icon: "shield",
                            permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Roles)
                                )
                    )
                    .AddItem(
                        new MenuItemDefinition(
                            PageNames.Languages,
                            L("Languages"),
                            url: "/Crud#/OpenApp/language",
                            icon: "globe",
                            permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Languages)
                                )
                    )
                    .AddItem(
                        new MenuItemDefinition(
                            PageNames.Localizations,
                            L("Localizations"),
                            url: "/Localization#/",
                            icon: "grid",
                            permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Localizations)
                                )
                    )
                );

            context.Manager.Menus.Add("TopMenu", new MenuDefinition("TopMenu", L("TopMenu")));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, OpenAppConsts.LocalizationSourceName);
        }
    }
}
