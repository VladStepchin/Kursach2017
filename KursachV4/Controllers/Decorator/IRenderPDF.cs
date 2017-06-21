using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace KursachV4.Controllers.Decorator
{
    interface IRenderPDF
    {
        string RenderViewAsString(string viewName, object model, ControllerContext ControllerContext);

        ActionResult ConvertHtmlPageToPdf(string viewName, object model, ControllerContext controllerContext);     
    }
}
