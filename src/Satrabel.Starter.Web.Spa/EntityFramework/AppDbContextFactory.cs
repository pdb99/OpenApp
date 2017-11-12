﻿using Satrabel.OpenApp.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Satrabel.OpenApp;
using Satrabel.Starter.Web;

namespace Satrabel.Starter.EntityFramework
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            AppDbContextConfigurer.Configure(builder, configuration.GetConnectionString(Web.AppConsts.ConnectionStringName));

            return new AppDbContext(builder.Options);
        }
    }
}