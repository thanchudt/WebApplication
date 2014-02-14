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
    public class ItemTypeController : Controller
    {
        private PriceEntities db = new PriceEntities();

        //
        // GET: /Prices/ItemType/

        public ActionResult Index()
        {
            var itemtypes = db.ItemTypes.Include(i => i.ItemType2);
            return View(itemtypes.ToList());
        }

        //
        // GET: /Prices/ItemType/Details/5

        public ActionResult Details(int id = 0)
        {
            ItemType itemtype = db.ItemTypes.Find(id);
            if (itemtype == null)
            {
                return HttpNotFound();
            }
            return View(itemtype);
        }

        //
        // GET: /Prices/ItemType/Create

        public ActionResult Create()
        {
            ViewBag.ParentId = new SelectList(db.ItemTypes, "Id", "Type");
            return View();
        }

        //
        // POST: /Prices/ItemType/Create

        [HttpPost]
        public ActionResult Create(ItemType itemtype)
        {
            if (ModelState.IsValid)
            {
                db.ItemTypes.Add(itemtype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ParentId = new SelectList(db.ItemTypes, "Id", "Type", itemtype.ParentId);
            return View(itemtype);
        }

        //
        // GET: /Prices/ItemType/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ItemType itemtype = db.ItemTypes.Find(id);
            if (itemtype == null)
            {
                return HttpNotFound();
            }
            ViewBag.ParentId = new SelectList(db.ItemTypes, "Id", "Type", itemtype.ParentId);
            return View(itemtype);
        }

        //
        // POST: /Prices/ItemType/Edit/5

        [HttpPost]
        public ActionResult Edit(ItemType itemtype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemtype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ParentId = new SelectList(db.ItemTypes, "Id", "Type", itemtype.ParentId);
            return View(itemtype);
        }

        //
        // GET: /Prices/ItemType/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ItemType itemtype = db.ItemTypes.Find(id);
            if (itemtype == null)
            {
                return HttpNotFound();
            }
            return View(itemtype);
        }

        //
        // POST: /Prices/ItemType/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemType itemtype = db.ItemTypes.Find(id);
            db.ItemTypes.Remove(itemtype);
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