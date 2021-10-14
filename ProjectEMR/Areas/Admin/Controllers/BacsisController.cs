using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectEMR.Models;

namespace ProjectEMR.Areas.Admin.Controllers
{
    public class BacsisController : Controller
    {
        private projectcapEntities db = new projectcapEntities();

        // GET: Admin/Bacsis
        public ActionResult Index()
        {
            return View(db.Bacsis.ToList());
        }

        // GET: Admin/Bacsis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bacsi bacsi = db.Bacsis.Find(id);
            if (bacsi == null)
            {
                return HttpNotFound();
            }
            return View(bacsi);
        }

        // GET: Admin/Bacsis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Bacsis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Bacsi bacsi)
        {
            if (ModelState.IsValid)
            {
                db.Bacsis.Add(bacsi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bacsi);
        }

        // GET: Admin/Bacsis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bacsi bacsi = db.Bacsis.Find(id);
            if (bacsi == null)
            {
                return HttpNotFound();
            }
            return View(bacsi);
        }

        // POST: Admin/Bacsis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Bacsi bacsi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bacsi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bacsi);
        }

        // GET: Admin/Bacsis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bacsi bacsi = db.Bacsis.Find(id);
            if (bacsi == null)
            {
                return HttpNotFound();
            }
            return View(bacsi);
        }

        // POST: Admin/Bacsis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bacsi bacsi = db.Bacsis.Find(id);
            db.Bacsis.Remove(bacsi);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
