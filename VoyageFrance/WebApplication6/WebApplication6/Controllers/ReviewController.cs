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
    public class ReviewController : Controller
    {
        private VoyageContext db = new VoyageContext();

        public ActionResult Comment()
        {
            return View();
        }

        // GET: /Review/
        public ActionResult Index()
        {
            var reviews = db.Reviews.Include(r => r.ScenicSpot);
            return View(reviews.ToList());
        }

        // GET: /Review/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        // GET: /Review/Create
        public ActionResult Create()
        {
            ViewBag.ScenicSpotId = new SelectList(db.ScenicSpots, "ScenicSpotId", "ScenicSpotName");
            return View();
        }

        // POST: /Review/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ReviewId,ScenicSpotId,ScenicSpotDetails,QualityRating,ReviewDate")] Review review)
        {
            if (ModelState.IsValid)
            {
                db.Reviews.Add(review);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ScenicSpotId = new SelectList(db.ScenicSpots, "ScenicSpotId", "ScenicSpotName", review.ScenicSpotId);
            return View(review);
        }

        // GET: /Review/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            ViewBag.ScenicSpotId = new SelectList(db.ScenicSpots, "ScenicSpotId", "ScenicSpotName", review.ScenicSpotId);
            return View(review);
        }

        // POST: /Review/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ReviewId,ScenicSpotId,ScenicSpotDetails,QualityRating,ReviewDate")] Review review)
        {
            if (ModelState.IsValid)
            {
                db.Entry(review).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ScenicSpotId = new SelectList(db.ScenicSpots, "ScenicSpotId", "ScenicSpotName", review.ScenicSpotId);
            return View(review);
        }

        // GET: /Review/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        // POST: /Review/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Review review = db.Reviews.Find(id);
            db.Reviews.Remove(review);
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
