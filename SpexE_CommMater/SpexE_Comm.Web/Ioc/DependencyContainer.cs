using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SpexE_Comm.Data.Data;
using SpexE_Comm.Factory;
using SpexE_Comm.Factory.Factory;
using SpexE_Comm.Service;
using SpexE_Comm.Service.Services;
using SpexE_Comm.Web.Helper.CurrentUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpexE_Comm.Web.Ioc
{
    public class DependencyContainer
    {
        public static void ServicesFactoryHelper(IServiceCollection services, IConfiguration configuration)
        {
            #region Services

            services.AddMvc();
            //services.AddSingleton<SpexE_CommContext, SpexE_CommContext>();
            services.TryAddSingleton<Microsoft.AspNetCore.Http.IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IMembershipService, MembershipService>();
            services.AddSingleton<IEncryptionService, EncryptionService>();
            services.AddSingleton<ICommonService, CommonService>();
            services.AddSingleton<ISmService, SmsService>();
            services.AddSingleton<IFirebaseCloudStorageService, FirebaseCloudStorageService>();
            //services.AddSingleton<SpexE_CommContext, SpexE_CommContext>();

            #endregion

            #region Factory

            services.AddSingleton<IMembershipFactory, MembershipFactory>();

            #endregion

            #region Helper

            services.AddSingleton<ICurrentUser, CurrentUser>();

            #endregion
        }
    }
}
