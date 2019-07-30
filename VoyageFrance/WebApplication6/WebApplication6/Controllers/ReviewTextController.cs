using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication6.Models;
using WebApplication6.DAL;

namespace WebApplication6.Controllers
{
    public class ReviewTextController : Controller
    {
        private VoyageContext db = new VoyageContext();

        // GET: /ReviewText/
        public ActionResult Index()
        {
            return View(db.ReviewTexts.ToList());
        }

        // GET: /ReviewText/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReviewText reviewtext = db.ReviewTexts.Find(id);
            if (reviewtext == null)
            {
                return HttpNotFound();
            }
            return View(reviewtext);
        }

        // GET: /ReviewText/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /ReviewText/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ReviewId,ReviewTextDetails")] ReviewText reviewtext)
        {
            if (ModelState.IsValid)
            {
                db.ReviewTexts.Add(reviewtext);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reviewtext);
        }

        // GET: /ReviewText/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReviewText reviewtext = db.ReviewTexts.Find(id);
            if (reviewtext == null)
            {
                return HttpNotFound();
            }
            return View(reviewtext);
        }

        // POST: /ReviewText/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ReviewId,ReviewTextDetails")] ReviewText reviewtext)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reviewtext).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reviewtext);
        }

        // GET: /ReviewText/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReviewText reviewtext = db.ReviewTexts.Find(id);
            if (reviewtext == null)
            {
                return HttpNotFound();
            }
            return View(reviewtext);
        }

        // POST: /ReviewText/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReviewText reviewtext = db.ReviewTexts.Find(id);
            db.ReviewTexts.Remove(reviewtext);
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
