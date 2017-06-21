using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KursachV4.Models;
using HiQPdf;
using System.IO;
using KursachV4.Controllers.Decorator;

namespace KursachV4.Controllers
{
    public class ConsumptionController : Controller
    {
        private KursachV4Context db = new KursachV4Context();

        //
        // GET: /Consumption/

        public ActionResult Index()
        {
            var consumptions = db.Consumptions.Include(c => c.Receiver).Include(c => c.Scrap).Include(c => c.Store);
            return View(consumptions.ToList());
        }

        //
        // GET: /Consumption/Details/5

        public ActionResult Details(int id = 0)
        {
            Consumption consumption = db.Consumptions.Find(id);
            if (consumption == null)
            {
                return HttpNotFound();
            }
            return View(consumption);
        }

        //
        // GET: /Consumption/Create

        public ActionResult Create()
        {
            ViewBag.ReceiverId = new SelectList(db.Receivers, "Id", "FirmTitle");
            ViewBag.ScrapId = new SelectList(db.Scraps, "Id", "Title");
            ViewBag.StoreId = new SelectList(db.Stores, "Id", "Name");
            return View();
        }

        //
        // POST: /Consumption/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Consumption consumption)
        {
            if (ModelState.IsValid)
            {
                db.Consumptions.Add(consumption);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ReceiverId = new SelectList(db.Receivers, "Id", "FirmTitle", consumption.ReceiverId);
            ViewBag.ScrapId = new SelectList(db.Scraps, "Id", "Title", consumption.ScrapId);
            ViewBag.StoreId = new SelectList(db.Stores, "Id", "Name", consumption.StoreId);
            return View(consumption);
        }

        //
        // GET: /Consumption/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Consumption consumption = db.Consumptions.Find(id);
            if (consumption == null)
            {
                return HttpNotFound();
            }
            ViewBag.ReceiverId = new SelectList(db.Receivers, "Id", "FirmTitle", consumption.ReceiverId);
            ViewBag.ScrapId = new SelectList(db.Scraps, "Id", "Title", consumption.ScrapId);
            ViewBag.StoreId = new SelectList(db.Stores, "Id", "Name", consumption.StoreId);
            return View(consumption);
        }

        //
        // POST: /Consumption/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Consumption consumption)
        {
            if (ModelState.IsValid)
            {
                db.Entry(consumption).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ReceiverId = new SelectList(db.Receivers, "Id", "FirmTitle", consumption.ReceiverId);
            ViewBag.ScrapId = new SelectList(db.Scraps, "Id", "Title", consumption.ScrapId);
            ViewBag.StoreId = new SelectList(db.Stores, "Id", "Name", consumption.StoreId);
            return View(consumption);
        }

        //
        // GET: /Consumption/Delete/5

        [Authorize]
        public ActionResult Delete(int id = 0)
        {
            Consumption consumption = db.Consumptions.Find(id);
            if (consumption == null)
            {
                return HttpNotFound();
            }
            return View(consumption);
        }

        //
        // POST: /Consumption/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Consumption consumption = db.Consumptions.Find(id);
            db.Consumptions.Remove(consumption);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult ConvertHtmlPageToPdf()
        {
            IRenderPDF renderPDF = new ExtendedRenderPDF(new RenderPDF());

            return renderPDF.ConvertHtmlPageToPdf("Index", db.Consumptions, ControllerContext);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}