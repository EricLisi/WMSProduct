using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing; 

namespace KGMFramework.WebApp
{
    public class MvcApplication : System.Web.HttpApplication
    { 
        void Application_Start(object sender, EventArgs e)
        {
            AreaRegistration.RegisterAllAreas(); 
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
 
    }
}
