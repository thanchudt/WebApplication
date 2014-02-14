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
    public class PriceController : Controller
    {
        private PriceEntities db = new PriceEntities();

        //
        // GET: /Prices/Price/

        public ActionResult Index()
        {
            var prices = db.Prices.Include(p => p.Currency).Include(p => p.Item).Include(p => p.UserProfile);
            return View(prices.ToList());
        }

        //
        // GET: /Prices/Price/Details/5

        public ActionResult Details(int id = 0)
        {
            Price price = db.Prices.Find(id);
            if (price == null)
            {
                return HttpNotFound();
            }
            return View(price);
        }

        //
        // GET: /Prices/Price/Create

        public ActionResult Create()
        {
            ViewBag.CurrencyId = new SelectList(db.Currencies, "Id", "Name");
            ViewBag.ItemId = new SelectList(db.Items, "Id", "Name");
            ViewBag.UploadByUserId = new SelectList(db.UserProfiles, "UserId", "UserName");
            return View();
        }

        //
        // POST: /Prices/Price/Create

        [HttpPost]
        public ActionResult Create(Price price)
        {
            if (ModelState.IsValid)
            {
                db.Prices.Add(price);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CurrencyId = new SelectList(db.Currencies, "Id", "Name", price.CurrencyId);
            ViewBag.ItemId = new SelectList(db.Items, "Id", "Name", price.ItemId);
            ViewBag.UploadByUserId = new SelectList(db.UserProfiles, "UserId", "UserName", price.UploadByUserId);
            return View(price);
        }

        //
        // GET: /Prices/Price/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Price price = db.Prices.Find(id);
            if (price == null)
            {
                return HttpNotFound();
            }
            ViewBag.CurrencyId = new SelectList(db.Currencies, "Id", "Name", price.CurrencyId);
            ViewBag.ItemId = new SelectList(db.Items, "Id", "Name", price.ItemId);
            ViewBag.UploadByUserId = new SelectList(db.UserProfiles, "UserId", "UserName", price.UploadByUserId);
            return View(price);
        }

        //
        // POST: /Prices/Price/Edit/5

        [HttpPost]
        public ActionResult Edit(Price price)
        {
            if (ModelState.IsValid)
            {
                db.Entry(price).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CurrencyId = new SelectList(db.Currencies, "Id", "Name", price.CurrencyId);
            ViewBag.ItemId = new SelectList(db.Items, "Id", "Name", price.ItemId);
            ViewBag.UploadByUserId = new SelectList(db.UserProfiles, "UserId", "UserName", price.UploadByUserId);
            return View(price);
        }

        //
        // GET: /Prices/Price/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Price price = db.Prices.Find(id);
            if (price == null)
            {
                return HttpNotFound();
            }
            return View(price);
        }

        //
        // POST: /Prices/Price/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Price price = db.Prices.Find(id);
            db.Prices.Remove(price);
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