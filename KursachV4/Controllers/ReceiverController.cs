using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KursachV4.Models;

namespace KursachV4.Controllers
{
    public class ReceiverController : Controller
    {
        private KursachV4Context db = new KursachV4Context();

        //
        // GET: /Receiver/

        public ActionResult Index()
        {
            return View(db.Receivers.ToList());
        }

        //
        // GET: /Receiver/Details/5

        public ActionResult Details(int id = 0)
        {
            Receiver receiver = db.Receivers.Find(id);
            if (receiver == null)
            {
                return HttpNotFound();
            }
            return View(receiver);
        }

        //
        // GET: /Receiver/Create

        public ActionResult Create()
        {
            return View();
        }
        //
        // POST: /Receiver/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Receiver receiver)
        {
            if (ModelState.IsValid)
            {
                db.Receivers.Add(receiver);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(receiver);
        }

        //
        // GET: /Receiver/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Receiver receiver = db.Receivers.Find(id);
            if (receiver == null)
            {
                return HttpNotFound();
            }
            return View(receiver);
        }

        //
        // POST: /Receiver/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Receiver receiver)
        {
            if (ModelState.IsValid)
            {
                db.Entry(receiver).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(receiver);
        }

        //
        // GET: /Receiver/Delete/5

        [Authorize]
        public ActionResult Delete(int id = 0)
        {
            Receiver receiver = db.Receivers.Find(id);

            if (receiver == null)
            {
                return HttpNotFound();
            }
            return View(receiver);
        }

        //
        // POST: /Receiver/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Receiver receiver = db.Receivers.Find(id);
            db.Receivers.Remove(receiver);
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