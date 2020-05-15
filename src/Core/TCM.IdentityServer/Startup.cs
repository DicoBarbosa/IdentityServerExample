// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TCM.IdentityServer.Core;
using TCM.IdentityServer.Core.Repositories;
using TCM.IdentityServer.Data;
using TCM.IdentityServer.Data.Repositories;

namespace TCM.IdentityServer
{
    public class Startup
    {
        public IWebHostEnvironment Environment { get; }
        public IConfiguration Configuration { get; }

        public Startup(IWebHostEnvironment environment, IConfiguration configuration)
        {
            Environment = environment;
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<IdentityServerContext>(
                options => options.UseSqlServer(
                    Configuration.GetConnectionString("IdentityServerConnection")));

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IClaimRepository, ClaimRepository>();
            services.AddTransient<ILoginRepository, LoginRepository>();
            services.AddTransient<ISecretRepository, SecretRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            var builder = services.AddIdentityServer()
                .AddInMemoryIdentityResources(Config.Ids)
                .AddInMemoryApiResources(Config.Apis)
                .AddInMemoryClients(Config.Clients);

            builder.AddSigningCredential(LoadCertificateFromStore());

            //builder.AddProfileService<LocalUserProfileService>();

        }

        public void Configure(IApplicationBuilder app)
        {
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // uncomment if you want to add MVC
            app.UseStaticFiles();
            app.UseRouting();

            app.UseIdentityServer();

            // uncomment, if you want to add MVC
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }

        public X509Certificate2 LoadCertificateFromStore()
        {
            string thumbPrint = Configuration.GetSection("CertThumbPrint").Value;

            using var store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            store.Open(OpenFlags.ReadOnly);
            var certCollection = store.Certificates.Find(X509FindType.FindByThumbprint,
                thumbPrint, true);
            if (certCollection.Count == 0)
            {
                throw new Exception("The specified certificate wasn't found.");
            }
            return certCollection[0];
        }
    }
}