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
using KursachV4.Controllers.Proxy;

namespace KursachV4.Controllers
{
    public class ProviderController : Controller
    {
        private KursachV4Context db = new KursachV4Context();

        //
        // GET: /Provider/
       
        public ActionResult Index()
        {
            return View(db.Providers.ToList());
        }

        //
        // GET: /Provider/Details/5

        public ActionResult Details(int id = 0)
        {
            Provider provider = db.Providers.Find(id);
            if (provider == null)
            {
                return HttpNotFound();
            }
            return View(provider);
        }

        //
        // GET: /Provider/Create

        public ActionResult VIPProdivers()
        {
            List<VIPProvider> VIPProviders = db.VIPProviders.ToList();

            return View(VIPProviders);
        }

        [HttpGet]
        public ActionResult ConvertHtmlPageToPdf()
        {
            List<VIPProvider> VIPProviders = db.VIPProviders.ToList();

            IRenderView renderView = new ProxyRenderView("VIPProdivers", VIPProviders, ControllerContext);

            return renderView.ConvertHtmlPageToPdf("VIPProdivers", VIPProviders, ControllerContext);
        } 

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Provider/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Provider provider)
        {
            if (ModelState.IsValid)
            {
                db.Providers.Add(provider);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(provider);
        }

        //
        // GET: /Provider/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Provider provider = db.Providers.Find(id);
            if (provider == null)
            {
                return HttpNotFound();
            }
            return View(provider);
        }

        //
        // POST: /Provider/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Provider provider)
        {
            if (ModelState.IsValid)
            {
                db.Entry(provider).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(provider);
        }

        //
        // GET: /Provider/Delete/5

        [Authorize]
        public ActionResult Delete(int id = 0)
        {
            Provider provider = db.Providers.Find(id);
            if (provider == null)
            {
                return HttpNotFound();
            }
            return View(provider);
        }

        //
        // POST: /Provider/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Provider provider = db.Providers.Find(id);
            db.Providers.Remove(provider);
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