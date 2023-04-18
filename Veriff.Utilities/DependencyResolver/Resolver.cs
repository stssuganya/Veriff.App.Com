using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Veriff.Core.IRepository;
using Veriff.Core.IServices;
using Veriff.Resources;
using Veriff.Service;

namespace Veriff.Utilities.DependencyResolver
{
    public class Resolver
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            #region HttpContextAccessor
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            #endregion

            #region Services
            services.AddScoped<IVeriffService, VeriffService>();
            #endregion

            #region Respository
            services.AddScoped<IVeriffRepository, VeriffRepository>();
            #endregion
        }

    }
}

