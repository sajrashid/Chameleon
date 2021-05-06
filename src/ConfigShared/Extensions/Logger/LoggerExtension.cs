// <copyright file="LoggerExtension.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ConfigShared.Extensions.Logger
{
    using System;
    using System.IO;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Serilog;

    /// <summary>
    /// LoggerExtension static class.
    /// </summary>
    public static class LoggerExtension
    {
        /// <summary>
        /// logger config.
        /// </summary>
        /// <param name="services">services.</param>
        /// <returns>>services.</returns>
        public static IServiceCollection AddLoggerConfig(this IServiceCollection services)
        {
            services.AddLogging(loggingBuilder =>
             loggingBuilder.AddSerilog(dispose: true));

            var loggerServices = new ServiceCollection()
               .AddLogging(builder =>
               {
                   builder.AddSerilog();
               });

            return services;
        }

        /// <summary>
        /// logger config.
        /// </summary>
        /// <param name="app">app.</param>
        /// <param name="env">services.</param>
        /// <returns>app services.</returns>
        public static IApplicationBuilder UseLoggerConfig(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            var callingAppName = env.ApplicationName;

            var logfileFolder = "logs\\" + callingAppName;

            if (env.IsDevelopment())
            {
              // logfiles save in %windir%/log
              //  var windir = Environment.GetEnvironmentVariable("WinDir");
              //  var callingAppName = env.ApplicationName;
              //  var logfileFolder = string.Empty;
              // local machine for dev work logfiles save to c:\windows\logs\AppName
              //  logfileFolder = (windir + "\\logs\\" + callingAppName);
              //  logfileFolder = ( "\\logs\\" + callingAppName);
                bool isFolderCreated = Directory.Exists(logfileFolder);
                if (!isFolderCreated)
                {
                    Directory.CreateDirectory(logfileFolder);
                }
            }

            if (env.IsLocal())
            {
            }

            if (env.IsDevelopment())
            {
            }

            if (env.IsSIT())
            {
            }

            if (env.IsUAT())
            {
            }

            if (env.IsProduction())
            {
            }

            // add serilog https://github.com/serilog/serilog-extensions-logging
            // https://github.com/serilog/serilog-extensions-logging/blob/dev/samples/Sample/Program.cs
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.File(logfileFolder + "\\log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            var startTime = DateTimeOffset.UtcNow;

            Log.Logger.Information("Started at {StartTime} and 0x{Hello:X} is hex of 42", startTime, 42);

            return app;
        }
    }
}