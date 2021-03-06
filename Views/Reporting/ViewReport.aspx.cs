using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SMSYSTEM.Views.Reporting
{
    public class WebFormController : Controller { }

    public static class WebFormMVCUtil
    {

        public static void RenderPartial(string partialName, object model)
        {
            //get a wrapper for the legacy WebForm context
            var httpCtx = new HttpContextWrapper(System.Web.HttpContext.Current);

            //create a mock route that points to the empty controller
            var rt = new RouteData();
            rt.Values.Add("controller", "WebFormController");

            //create a controller context for the route and http context
            var ctx = new ControllerContext(
                new RequestContext(httpCtx, rt), new WebFormController());

            //find the partial view using the viewengine
            var view = ViewEngines.Engines.FindPartialView(ctx, partialName).View;

            //create a view context and assign the model
            var vctx = new ViewContext(ctx, view,
                new ViewDataDictionary { Model = model },
                new TempDataDictionary(),TextWriter.Null);

            //render the partial view
            view.Render(vctx, System.Web.HttpContext.Current.Response.Output);
        }

    }
    public partial class Report : System.Web.Mvc.ViewPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}