// ==============================================================================================================================
// Author                : Ivan Hidalgo. 
// Assembly              : Team.Products.API
// Summary               : Manages Spring context.
// Framework Version     : 4.5.2
// Company               : Team International
// ==============================================================================================================================
// <copyright file="SpringResolver.cs" company="Team International">
//      Copyright (C) 2019 Team International
// </copyright>
// ==============================================================================================================================

using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using NLog;
using Spring.Context;


namespace Team.Products.API
{
    public class SpringResolver : IDependencyResolver
    {

        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        protected IApplicationContext context;

        public SpringResolver(IApplicationContext context)
        {
            Logger.Debug("Loads Spring context");
            if (context == null)
                throw new ArgumentNullException("Contexto de Spring sin inicializar");

            this.context = context;
        }

       public  IDependencyScope BeginScope()
        {
            return new SpringResolver(context);
        }

        public object GetService(Type serviceType)
        {
            Logger.Debug("Gets object from spring context ");
            IDictionary<string, object> objectInstanceDictionary = null;
            try
            {
                objectInstanceDictionary = context.GetObjectsOfType(serviceType);
                return objectInstanceDictionary.ContainsKey(serviceType.Name) ? objectInstanceDictionary[serviceType.Name] : null;
            }
            catch (Exception)
            {
                Logger.Warn("Not Found Object from Spring context. Returns Null by default.");
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            Logger.Debug("Gets object from spring context ");
            IDictionary<string, object> objectInstanceDictionary = null;
            try
            {
                objectInstanceDictionary = context.GetObjectsOfType(serviceType);
                return objectInstanceDictionary!=null ? objectInstanceDictionary.Values : new List<object>();
            }
            catch (Exception)
            {
                Logger.Warn("Not Found Object from Spring context. Returns Null by default.");
                return new List<object>();
            }
        }

        public void Dispose()
        {
            Logger.Debug("Destroys the spring context");
            //context.Dispose();
        }
    }
}