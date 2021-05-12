// <copyright file="EnvExtensions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ConfigShared
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Hosting;

    /// <summary>
    ///  Extension class configures additional test environments.
    /// </summary>
    public static class EnvExtensions
    {
        // https://docs.microsoft.com/en-us/aspnet/core/fundamentals/environments
        // ASP.NET Core reads the environment variable ASPNETCORE_ENVIRONMENT
        // at application startup and stores that value in
        // IHostingEnvironment.EnvironmentName. ASPNETCORE_ENVIRONMENT can be
        // set to any value, but three values are supported by the framework:
        // Development, Staging, and Production. If ASPNETCORE_ENVIRONMENT
        // isn't set, it will default to Production.

        // extended to Local, SIT, Development, UAT, Staging, and Production
        // we will use Local, SIT, Development, UAT, and Production
        // from cmd run command below
        // set ASPNETCORE_ENVIRONMENT=Local on your machine
        private const string Local = "Local";
        private const string UAT = "UAT";
        private const string SIT = "SIT";

        /// <summary>
        /// Enviroment bool.
        /// </summary>
        /// <param name="env.IsEnvironment">Sets the bool to UAT.</param>
        /// <returns>environment.</returns>
        public static bool IsUAT(this IWebHostEnvironment env)
        {
            return env.IsEnvironment(UAT);
        }

        /// <summary>
        /// Enviroment bool.
        /// </summary>
        /// <param name="env.IsEnvironment">hosting env.</param>
        /// <returns>environment.</returns>
        public static bool IsSIT(this IWebHostEnvironment env)
        {
            return env.IsEnvironment(SIT);
        }

        /// <summary>
        /// Enviroment bool.
        /// </summary>
        /// <param name="env.IsEnvironment">Sets the bool to Local.</param>
        /// <returns>environment.</returns>
        public static bool IsLocal(this IWebHostEnvironment env)
        {
            return env.IsEnvironment(Local);
        }
    }
}
