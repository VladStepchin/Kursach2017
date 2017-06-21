using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KursachV4.Controllers.Decorator
{
    public class DecoratorRenderPDF : Controller, IRenderPDF
    {
        public RenderPDF renderPDF;

        public DecoratorRenderPDF(){}

        public DecoratorRenderPDF(RenderPDF renderPDF)
        {
            this.renderPDF = renderPDF;
        }
        public string RenderViewAsString(string viewName, object model, ControllerContext controllerContext)
        {
            return renderPDF.RenderViewAsString(viewName, model, controllerContext);
        }

        public ActionResult ConvertHtmlPageToPdf(string viewName, object model, ControllerContext controllerContext)
        {
            return renderPDF.ConvertHtmlPageToPdf(viewName, model, controllerContext);
        }

    }
}