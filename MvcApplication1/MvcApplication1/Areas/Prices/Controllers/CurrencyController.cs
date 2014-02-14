using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PriceDataLib;

namespace MvcApplication1.Areas.Prices.Controllers
{
    public class CurrencyController : Controller
    {
        private PriceEntities db = new PriceEntities();

        //
        // GET: /Prices/Currency/

        public ActionResult Index()
        {
            return View(db.Currencies.ToList());
        }

        //
        // GET: /Prices/Currency/Details/5

        public ActionResult Details(int id = 0)
        {
            Currency currency = db.Currencies.Find(id);
            if (currency == null)
            {
                return HttpNotFound();
            }
            return View(currency);
        }

        //
        // GET: /Prices/Currency/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Prices/Currency/Create

        [HttpPost]
        public ActionResult Create(Currency currency)
        {
            if (ModelState.IsValid)
            {
                db.Currencies.Add(currency);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(currency);
        }

        //
        // GET: /Prices/Currency/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Currency currency = db.Currencies.Find(id);
            if (currency == null)
            {
                return HttpNotFound();
            }
            return View(currency);
        }

        //
        // POST: /Prices/Currency/Edit/5

        [HttpPost]
        public ActionResult Edit(Currency currency)
        {
            if (ModelState.IsValid)
            {
                db.Entry(currency).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(currency);
        }

        //
        // GET: /Prices/Currency/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Currency currency = db.Currencies.Find(id);
            if (currency == null)
            {
                return HttpNotFound();
            }
            return View(currency);
        }

        //
        // POST: /Prices/Currency/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Currency currency = db.Currencies.Find(id);
            db.Currencies.Remove(currency);
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