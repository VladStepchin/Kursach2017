using HiQPdf;
using KursachV4.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KursachV4.Controllers.Proxy
{
    public class RenderView: Controller, IRenderView
    {
        string viewName;
        object model;
        ControllerContext controllerContext;

        public RenderView() { }

        public RenderView(string viewName, object model, ControllerContext controllerContext)
        {
            KursachV4Context db = new KursachV4Context();

            List<VIPProvider> VIPProviders = db.VIPProviders.ToList();

            this.viewName = viewName;
            this.model = model;
            this.controllerContext = controllerContext;
            RenderViewAsString(viewName,model,controllerContext);
        }

        public string RenderViewAsString(string viewName, object model, ControllerContext controllerContext)
        {
            // create a string writer to receive the HTML code
            StringWriter stringWriter = new StringWriter();

            // get the view to render
            ViewEngineResult viewResult = ViewEngines.Engines.FindView(controllerContext,
                      viewName, null);
            // create a context to render a view based on a model
            ViewContext viewContext = new ViewContext(
                controllerContext,
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


        [HttpGet]
        public ActionResult ConvertHtmlPageToPdf(string viewName, object model, ControllerContext controllerContext)
        {
            KursachV4Context db = new KursachV4Context();

            List<VIPProvider> VIPProviders = db.VIPProviders.ToList();

            // get the HTML code of this view
            string htmlToConvert = RenderViewAsString(viewName, model, controllerContext);

            // the base URL to resolve relative images and css
            String thisPageUrl = "http://localhost:4240/Provider/ConvertHtmlPageToPdf";
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
            fileResult.FileDownloadName = "MetalList.pdf";

            return File(pdfBuffer, "application/pdf", "ProvidersList.pdf");
        } 
    }
}