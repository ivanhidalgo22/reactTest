using System;

namespace Team.Products.API
{
    public class Global : System.Web.HttpApplication
    {
        private const string HTTP_SERVER_HEADER = "Server";
        protected void Application_Start(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Removing excessive headers. Users don't need to see this.
        /// </summary>
        protected void Application_PreSendRequestHeaders()
        {
            Response.Headers.Remove(HTTP_SERVER_HEADER);
        }

    }
}