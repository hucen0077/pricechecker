using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace PrickCheckerSolutions
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            //code that runs when unhandled exception occurs
            using (var _error = new PrickCheckerSolutions.Data.pricecheckerEntities())
            {
                var err = Server.GetLastError();
                var newError = new PrickCheckerSolutions.Data.Error();
                newError.DateLogged = DateTime.Now;
                newError.Message = err.Message;
                newError.Resolved = false;
                newError.StackTrace = err.StackTrace;
                newError.URL = Request.Url.ToString();

                _error.Errors.Add(newError);
                _error.SaveChanges();
            }

            //redirect to error page
            //this is a test comment
        }


    }
}
