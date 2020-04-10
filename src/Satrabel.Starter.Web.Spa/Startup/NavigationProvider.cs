﻿using Abp.Application.Navigation;
using Abp.Authorization;
using Abp.Localization;
using Satrabel.OpenApp;
using Satrabel.Starter.Web.Authorization;

namespace Satrabel.Starter.Web.Startup
{
    /// <summary>
    /// This class defines menus for the application.
    /// </summary>
    public class NavigationProvider : Abp.Application.Navigation.NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                 .AddItem(
                    new MenuItemDefinition(
                        PageNames.Home,
                        L("Home"),
                        url: "",
                        icon: "home",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Home)
                        )
                    )
                 .AddItem(
                    new MenuItemDefinition(
                        PageNames.Home,
                        L("Demos"),
                        url: "-",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Home)
                        )

                .AddItem(
                    new MenuItemDefinition(
                        PageNames.Home,
                        L("ClientApp"),
                        url: "/App/Demo1",
                        icon: "question",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Home)
                        )
                )
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.Home,
                        L("About"),
                        url: "/About",
                        icon: "question",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_About)
                        )
                    )
                )
                ;
            context.Manager.MainMenu.Items.MoveMenuItemToBottom("Admin");

            context.Manager.Menus["TopMenu"]
                .AddItem(
                   new MenuItemDefinition(
                       PageNames.Home,
                       L("Users"),
                       url: "/Crud#/OpenApp/user",
                       icon: "people",
                       permissionDependency: new SimplePermissionDependency(Satrabel.OpenApp.Authorization.PermissionNames.Pages_Users),
                       customData: "Users"
                   )
                );
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, AppConsts.LocalizationSourceName);
        }
    }
}
