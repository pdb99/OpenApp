﻿using System;
using Satrabel.Starter.Web.Startup;

namespace Satrabel.Starter.Web
{
    public class AppConsts
    {
        /// <summary>
        /// this version nummer will be compared to the one in the file \app_data\appversion.txt
        /// if there is a difference then the database migrations will be run
        /// </summary>
        public static readonly Version AppVersion = new Version(1,3);

        /// <summary>
        /// returns the full path (c:\\hostingfolder\\websitefolder) without trailing slash
        /// </summary>
        public static readonly string WwwRootPath = Satrabel.OpenApp.Web.WebContentDirectoryFinder.CalculateContentRootFolder(typeof(WebMvcModule).Assembly);
        public const string LocalizationSourceName = "App";
        public const string ConnectionStringName = "Default";
        public const bool MultiTenancyEnabled = true;
        public const string MetaTitle = "OpenApp Starter Spa";
        public const string MetaDescription = "";
        public const string FooterLinkUrl = "https://github.com/sachatrauwaen/OpenApp";
        public const string FooterLinkText = "OpenApp Platform";
        public const string FooterCopyright = "by Satrabel";
    }
}