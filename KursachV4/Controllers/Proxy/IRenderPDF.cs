using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace KursachV4.Controllers
{
    interface IRenderView
    {
        ActionResult ConvertHtmlPageToPdf(string viewName, object model, ControllerContext controllerContext);
    }
}
