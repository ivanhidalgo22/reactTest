// ==============================================================================================================================
// Author                : Ivan Hidalgo. 
// Assembly              : Team.Products.API.Swagger
// Summary               : Swagger Configuration file.
// Framework Version     : 4.5.2
// Company               : Team International
// ==============================================================================================================================
// <copyright file="SwaggerConfiguration.cs" company="Team International">
//      Copyright (C) 2019 Team International
// </copyright>
// ==============================================================================================================================


namespace Team.Products.API.Swagger
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using Swashbuckle.Application;

    /// <summary>   
    /// Makes API documentation by using swagger framework.
    /// </summary>
    public class SwaggerConfiguration
    {

        /// <summary>
        /// Makes API documentation.
        /// </summary>
        /// <param name="config">API's configuration instance.</param>
        public static void Register(HttpConfiguration config)
        {
            config
                 .EnableSwagger(c =>
                 {
                     c.SingleApiVersion("v1", "Product Service - Product.API")
                         .Description("Restful Service for getting a products collection.")
                         .TermsOfService("This API was built by Ivan Hidalgo")
                        .License(lc => lc
                                     .Name("Team International")
                                     .Url("https://www.teaminternational.com/"));

                     c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

                     c.PrettyPrint();

                     c.IncludeXmlComments(System.String.Format(@"{0}\bin\Team.Products.API.xml", AppDomain.CurrentDomain.BaseDirectory));

                     c.DescribeAllEnumsAsStrings();
                    
                 })
             .EnableSwaggerUi(c =>
             {
                 c.DisableValidator();
              
             });
        }
    }
}