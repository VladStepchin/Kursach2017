using HiQPdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KursachV4.Controllers.Decorator
{
    public class RenderPDF: Controller, IRenderPDF
    {
        public string RenderViewAsString(string viewName, object model, ControllerContext ControllerContext)
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

        public ActionResult ConvertHtmlPageToPdf(string viewName, object model, ControllerContext controllerContext)
        {
            // get the HTML code of this view
            string htmlToConvert = RenderViewAsString(viewName, model, controllerContext);

            // the base URL to resolve relative images and css
            String thisPageUrl = "http://localhost:4240/Consumption/ConvertHtmlPageToPdf";
            String baseUrl = thisPageUrl.Substring(0, thisPageUrl.Length -
                "Home/ConvertThisPageToPdf".Length);

            // instantiate the HiQPdf HTML to PDF converter
            HtmlToPdf htmlToPdfConverter = new HtmlToPdf();

            //hide the button in the created PDF
            //htmlToPdfConverter.HiddenHtmlElements = new string[] 
            //           { "#convertThisPageButtonDiv" };

            // render the HTML code as PDF in memory
            byte[] pdfBuffer = htmlToPdfConverter.ConvertHtmlToMemory(htmlToConvert, baseUrl);

            // send the PDF file to browser
            FileResult fileResult = new FileContentResult(pdfBuffer, "application/pdf");
            fileResult.FileDownloadName = "ConsumptionList.pdf";

            return File(pdfBuffer, "application/pdf", "ScrapList.pdf");
        }
    }
}