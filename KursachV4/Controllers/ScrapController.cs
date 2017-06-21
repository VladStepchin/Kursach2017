using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KursachV4.Models;
using System.IO;
using HiQPdf;

namespace KursachV4.Controllers
{
    public class ScrapController : Controller
    {
        private KursachV4Context db = new KursachV4Context();

        //
        // GET: /Scrap/

        public ActionResult Index()
        {
            var scraps = db.Scraps.Include(s => s.Store);
            return View(scraps.ToList());
        }

        [HttpGet]
        public ActionResult ConvertHtmlPageToPdf()
        {

            Singleton single  = Singleton.Initialize();

            // get the HTML code of this view
            string htmlToConvert = single.RenderViewAsString("Index", db.Scraps, ControllerContext);

            // the base URL to resolve relative images and css
            String thisPageUrl = this.ControllerContext.HttpContext.Request.Url.AbsoluteUri;
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

            return File(pdfBuffer, "application/pdf", "ScrapList.pdf");
        } 

        public ActionResult Details(int id = 0)
        {
            Scrap scrap = db.Scraps.Find(id);
            if (scrap == null)
            {
                return HttpNotFound();
            }
            return View(scrap);
        }

        //
        // GET: /Scrap/Create

        public ActionResult Create()
        {
            ViewBag.StoreId = new SelectList(db.Stores, "Id", "Name");
            return View();
        }

        //
        // POST: /Scrap/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Scrap scrap)
        {
            if (ModelState.IsValid)
            {
                db.Scraps.Add(scrap);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StoreId = new SelectList(db.Stores, "Id", "Name", scrap.StoreId);
            return View(scrap);
        }

        //
        // GET: /Scrap/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Scrap scrap = db.Scraps.Find(id);
            if (scrap == null)
            {
                return HttpNotFound();
            }
            ViewBag.StoreId = new SelectList(db.Stores, "Id", "Name", scrap.StoreId);
            return View(scrap);
        }

        //
        // POST: /Scrap/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Scrap scrap)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scrap).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StoreId = new SelectList(db.Stores, "Id", "Name", scrap.StoreId);
            return View(scrap);
        }

        //
        // GET: /Scrap/Delete/5

        [Authorize]
        public ActionResult Delete(int id = 0)
        {
            Scrap scrap = db.Scraps.Find(id);
            if (scrap == null)
            {
                return HttpNotFound();
            }
            return View(scrap);
        }

        //
        // POST: /Scrap/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Scrap scrap = db.Scraps.Find(id);
            db.Scraps.Remove(scrap);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}