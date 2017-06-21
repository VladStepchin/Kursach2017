using HiQPdf;
using KursachV4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KursachV4.Controllers.Proxy
{
    public class ProxyRenderView: IRenderView
    {  
        string viewName;
        object model;
        ControllerContext controllerContext;

        RenderView renderView;

        public ProxyRenderView(string viewName, object model, ControllerContext controllerContext)
        {
            KursachV4Context db = new KursachV4Context();

            List<VIPProvider> VIPProviders = db.VIPProviders.ToList();

            this.viewName = viewName;
            this.model = model;
            this.controllerContext = controllerContext;
        }


        public ActionResult ConvertHtmlPageToPdf(string viewName, object model, ControllerContext controllerContext)
        {
            if (renderView == null) {
                renderView = new RenderView(viewName, model, controllerContext);
            }

            return renderView.ConvertHtmlPageToPdf(viewName, model, controllerContext);
        } 
    }
}