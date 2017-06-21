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
    public class ArraivingController : Controller
    {
        private KursachV4Context db = new KursachV4Context();

        //
        // GET: /Arraiving/
        public ActionResult Index()
        {
            var arraivings = db.Arraivings.Include(a => a.Provider).Include(a => a.Scrap).Include(a => a.Store);
            return View(arraivings);
        }

        //
        // GET: /Arraiving/Details/5

        public ActionResult Details(int id = 0)
        {
            Arraiving arraiving = db.Arraivings.Find(id);
            if (arraiving == null)
            {
                return HttpNotFound();
            }
            return View(arraiving);
        }

        //
        // GET: /Arraiving/Create

        public ActionResult Create()
        {
            ViewBag.ProviderId = new SelectList(db.Providers, "Id", "Surname");
            ViewBag.ScrapId = new SelectList(db.Scraps, "Id", "Title");
            ViewBag.StoreId = new SelectList(db.Stores, "Id", "Name");
            return View();
        }

        //
        // POST: /Arraiving/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Arraiving arraiving)
        {
            if (ModelState.IsValid)
            {

                DetailsOfArraivedMetal tmp1 = new DetailsOfArraivedMetal();
                Scrap sc = new Scrap();
                sc = db.Scraps.ToList().Where(x => x.Id ==arraiving.ScrapId).FirstOrDefault();
                tmp1.Id = new Random().Next();
                tmp1.Cost = arraiving.Cost;
                tmp1.Density = sc.Density;
                tmp1.Description = sc.Description;
                tmp1.ScrapId = sc.Id;
                db.DetailsOfArraivedMetal.Add(tmp1);

                if (arraiving.Cost > 150 && arraiving.Amount > 100)
                {
                    Provider pr = new Provider();
                    pr = db.Providers.ToList().Where(x => x.Id == arraiving.ProviderId).FirstOrDefault();
                    VIPProvider tmp = new VIPProvider();
                    tmp.Id = new Random().Next().ToString();
                    tmp.Address = pr.Address;
                    tmp.Amount = arraiving.Amount;
                    tmp.Name = pr.Name;
                    tmp.PassportCode = pr.PassportCode;
                    tmp.Surname = pr.Surname;
                    tmp.Telephone = pr.Telephone;
                    db.VIPProviders.Add(tmp);
                    db.SaveChanges();
                }
                db.Arraivings.Add(arraiving);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProviderId = new SelectList(db.Providers, "Id", "Surname", arraiving.ProviderId);
            ViewBag.ScrapId = new SelectList(db.Scraps, "Id", "Title", arraiving.ScrapId);
            ViewBag.StoreId = new SelectList(db.Stores, "Id", "Name", arraiving.StoreId);
            return View(arraiving);
        }

        //
        // GET: /Arraiving/Edit/5

        [HttpGet]
        public ActionResult GetDetailsOfArraivedMetal()
        {
            List<DetailsOfArraivedMetal> DetailsOfArraivedMetal = db.DetailsOfArraivedMetal.ToList();

            return View(DetailsOfArraivedMetal);
        }

        public ActionResult Edit(int id = 0)
        {
            Arraiving arraiving = db.Arraivings.Find(id);
            if (arraiving == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProviderId = new SelectList(db.Providers, "Id", "Surname", arraiving.ProviderId);
            ViewBag.ScrapId = new SelectList(db.Scraps, "Id", "Title", arraiving.ScrapId);
            ViewBag.StoreId = new SelectList(db.Stores, "Id", "Name", arraiving.StoreId);
            return View(arraiving);
        }

        //
        // POST: /Arraiving/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Arraiving arraiving)
        {
            if (ModelState.IsValid)
            {
                db.Entry(arraiving).State = EntityState.Modified;
                db.SaveChanges();
                if (arraiving.Cost > 150 && arraiving.Amount > 100)
                {
                    Provider pr = new Provider();
                    pr = db.Providers.ToList().Where(x => x.Id == arraiving.ProviderId).FirstOrDefault();
                    VIPProvider tmp = new VIPProvider();
                    tmp.Id = new Random().Next().ToString();
                    tmp.Address = pr.Address;
                    tmp.Amount = arraiving.Amount;
                    tmp.Name = pr.Name;
                    tmp.PassportCode = pr.PassportCode;
                    tmp.Surname = pr.Surname;
                    tmp.Telephone = pr.Telephone;
                    db.VIPProviders.Add(tmp);
                    db.SaveChanges();
                }
                db.Arraivings.Add(arraiving);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProviderId = new SelectList(db.Providers, "Id", "Surname", arraiving.ProviderId);
            ViewBag.ScrapId = new SelectList(db.Scraps, "Id", "Title", arraiving.ScrapId);
            ViewBag.StoreId = new SelectList(db.Stores, "Id", "Name", arraiving.StoreId);
            return View(arraiving);
        }

        //
        // GET: /Arraiving/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Arraiving arraiving = db.Arraivings.Find(id);
            if (arraiving == null)
            {
                return HttpNotFound();
            }
            return View(arraiving);
        }

        //
        // POST: /Arraiving/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Arraiving arraiving = db.Arraivings.Find(id);
            db.Arraivings.Remove(arraiving);
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