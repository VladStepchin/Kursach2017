using HiQPdf;
using KursachV4.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KursachV4.Controllers.Decorator
{
    public class ExtendedRenderPDF : DecoratorRenderPDF
    {
        public ExtendedRenderPDF(RenderPDF renderPDF)
        {
            this.renderPDF = renderPDF;
                
        }
        public  string RenderViewAsString(string viewName, object model, ControllerContext ControllerContext)
        {
            // create a string writer to receive the HTML code
            StringWriter stringWriter = new StringWriter();

            // get the view to render
            ViewEngineResult viewResult = ViewEngines.Engines.FindView(ControllerContext,
                      viewName, null);
            // create a context to render a view based on a model
            ViewContext viewContext = new ViewContext(
                ControllerContext,
                viewResult.View,
                new ViewDataDictionary(model),
                new TempDataDictionary(),
                stringWriter
            );

            // render the view to a HTML code
            viewResult.View.Render(viewContext, stringWriter);

            // return the HTML code
            return stringWriter.ToString();
        }

        public void usefullMethod() { 
            //some usefull functionality

        }
        public ActionResult ConvertHtmlPageToPdf(string viewName, object model, ControllerContext controllerContext)
        {
            return base.ConvertHtmlPageToPdf(viewName, model, controllerContext);
        }
    }
}