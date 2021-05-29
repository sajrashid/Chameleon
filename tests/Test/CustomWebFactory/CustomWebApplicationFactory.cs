﻿using Chameleon.Shared;
using Microsoft.AspNetCore.Mvc.Testing;
using Chameleon.Server;
using System;
using System.Threading.Tasks;
using Xunit;
using System.Text.Json;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.Extensions.Logging;
using Test;

namespace Test
{
    public class CustomWebApplicationFactory<TStartup>
         : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            
                builder.ConfigureServices(services =>
                {
                    var descriptor = services.SingleOrDefault(
                        d => d.ServiceType ==
                            typeof(DbContextOptions<SQLiteDBContext>));

                    services.Remove(descriptor);


                    services.AddDbContext<SQLiteDBContext>();

                  var sp = services.BuildServiceProvider();
                    using (var scope = sp.CreateScope())
                    {
                        var scopedServices = scope.ServiceProvider;
                        var db = scopedServices.GetRequiredService<SQLiteDBContext>();
                        var logger = scopedServices
                        .GetRequiredService<ILogger<CustomWebApplicationFactory<TStartup>>>();
                        db.Database.EnsureCreated();

                        try
                        {
                           
                            Utilities.InitializeDbForTests(db);
                        }
                        catch (Exception ex)
                        {
                            logger.LogError(ex, "An error occurred seeding the " +
                                "database with test messages. Error: {Message}", ex.Message);
                        }
                    }
                });
        }
    }
}