using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SpexE_Comm.Factory;
using SpexE_Comm.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpexE_Comm.Admin
{
    public class DependencyContainer
    {
        public static void ServicesFactoryHelper(IServiceCollection services, IConfiguration configuration)
        {
            #region Services

            services.AddMvc();
            //services.AddSingleton<SpexE_CommContext, SpexE_CommContext>();
            services.TryAddSingleton<Microsoft.AspNetCore.Http.IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IEncryptionService, EncryptionService>();

            #endregion

            #region Factory



            #endregion
        }
    }
}
