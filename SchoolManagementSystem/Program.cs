using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SchoolManagementSystem.Data.Repositories;
using SchoolManagementSystem.Forms;
using SchoolManagementSystem.Services;
using System;
using System.Windows.Forms;

namespace SchoolManagementSystem
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // Dependency Injection setup
            var host = CreateHostBuilder().Build();

            // Get the main form from the service provider
            var formService = host.Services.GetRequiredService<StudentSearchEngine>();

            // Run the application with the main form
            Application.Run(formService);
        }

        static IHostBuilder CreateHostBuilder() => Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    // Database configuration
                    services.AddDbContext<Data.DbContext>((provider, options) =>
                    {
                        var config = provider.GetRequiredService<IConfiguration>();
                        options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
                    });

                    // Repository configuration
                    services.AddTransient<ICountryRepository, CountryRepository>();
                    services.AddTransient<ISchoolRepository, SchoolRepository>();
                    services.AddTransient<IStudentRepository, StudentRepository>();

                    // Services configuration
                    services.AddTransient<ICountryService, CountryService>();
                    services.AddTransient<ISchoolService, SchoolService>();
                    services.AddTransient<IStudentService, StudentService>();

                    // Forms configuration
                    services.AddTransient<StudentSearchEngine>();
                });

    }
}