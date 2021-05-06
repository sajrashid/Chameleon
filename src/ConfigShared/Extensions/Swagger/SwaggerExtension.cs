// <copyright file="SwaggerExtension.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ConfigShared.Extensions.Swagger
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// SwaggerExtension.
    /// </summary>
    public static class SwaggerExtension
    {
        /// <summary>
        /// Static Swagger Service.
        /// </summary>
        /// <param name="services">Swagger Service param.</param>
        /// <returns>app.</returns>
        public static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
        {
            services.AddSwaggerGen();
            return services;
        }

        /// <summary>
        /// Static Swagger Service.
        /// </summary>
        /// <param name="app">config.</param>
        /// <returns>app.</returns>
        public static IApplicationBuilder UseSwaggerConfig(this IApplicationBuilder app)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            return app;
        }
    }
}
