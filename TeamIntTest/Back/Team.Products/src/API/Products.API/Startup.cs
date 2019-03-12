// ==============================================================================================================================
// Author                : Ivan Hidalgo. 
// Assembly              : Team.Products.API
// Summary               : Controls Spring context and Application controllers.
// Framework Version     : 4.5.2
// Company               : Team International
// ==============================================================================================================================
// <copyright file="Startup.cs" company="Team International">
//      Copyright (C) 2019 Team International
// </copyright>
// ==============================================================================================================================

using Microsoft.Owin.Cors;
using Owin;
using System.Linq;
using System.Web.Http;
using Spring.Context;
using Spring.Context.Support;
using System.Web.Http.Dependencies;
using Newtonsoft.Json.Serialization;
using System.Threading.Tasks;
using System.Web.Cors;
using System.Configuration;
using Team.Products.API.Swagger;

namespace Team.Products.API
{
    /// <summary>
    /// Start up class.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Cors Parameter.
        /// </summary>
        public const string PARAMETER_CORS = "Cors";

        /// <summary>
        /// Cors Separator Character.
        /// </summary>
        public const char PARAMETER_CORS_SEPARATOR = ';';

        /// <summary>
        /// Loads Default Configuration.
        /// </summary>
        /// <param name="app">App Builder.</param>
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            AllowCors(app);
            config.DependencyResolver = GetSpringResolver();
            SwaggerConfiguration.Register(config);
            app.UseWebApi(config);
            SetJsonCamelCaseFormatter(config);
        }

        /// <summary>
        /// Allows Cors API.
        /// </summary>
        /// <param name="app">App Builder.</param>
        public void AllowCors(IAppBuilder app)
        {
            var corsPolicy = new CorsPolicy
            {
                AllowAnyMethod = true,
                AllowAnyHeader = true
            };

            var origins = ConfigurationManager.AppSettings.Get("cors");
            if (origins != null)
            {
                foreach (var origin in origins.Split(PARAMETER_CORS_SEPARATOR))
                {
                    corsPolicy.Origins.Add(origin);
                }
            }
            else
            {
                corsPolicy.AllowAnyOrigin = true;
            }

            var corsOptions = new CorsOptions
            {
                PolicyProvider = new CorsPolicyProvider
                {
                    PolicyResolver = context => Task.FromResult(corsPolicy)
                }
            };

            app.UseCors(corsOptions);
        }

        /// <summary>
        /// Set up the API in order to return the JSON response by applying Camel Case-Notation.
        /// </summary>
        /// <param name="config"></param>
        private static void SetJsonCamelCaseFormatter(HttpConfiguration config)
        {
            var jsonFormatter = config.Formatters.OfType<System.Net.Http.Formatting.JsonMediaTypeFormatter>().FirstOrDefault();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }

        /// <summary>
        /// Loads dependencies by using Spring' container.
        /// </summary>
        /// <returns>SpringReolver Instance.</returns>
        private IDependencyResolver GetSpringResolver()
        {
            IApplicationContext context = ContextRegistry.GetContext();
            return new SpringResolver(context);
        }




    }
}