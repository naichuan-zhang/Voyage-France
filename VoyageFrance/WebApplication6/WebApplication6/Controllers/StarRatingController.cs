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
    public class StarRatingController : Controller
    {
        private VoyageContext db = new VoyageContext();

        // GET: /StarRating/
        public ActionResult Index()
        {
            var starratings = db.StarRatings.Include(s => s.ScenicSpot).Include(s => s.User);
            return View(starratings.ToList());
        }

        // GET: /StarRating/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StarRating starrating = db.StarRatings.Find(id);
            if (starrating == null)
            {
                return HttpNotFound();
            }
            return View(starrating);
        }

        // GET: /StarRating/Create
        public ActionResult Create()
        {
            ViewBag.ScenicSpotId = new SelectList(db.ScenicSpots, "ScenicSpotId", "ScenicSpotName");
            ViewBag.Username = new SelectList(db.Users, "Username", "Password");
            return View();
        }

        // POST: /StarRating/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,ScenicSpotId,Username,RatingDate,Star")] StarRating starrating)
        {
            if (ModelState.IsValid)
            {
                db.StarRatings.Add(starrating);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ScenicSpotId = new SelectList(db.ScenicSpots, "ScenicSpotId", "ScenicSpotName", starrating.ScenicSpotId);
            ViewBag.Username = new SelectList(db.Users, "Username", "Password", starrating.Username);
            return View(starrating);
        }

        // GET: /StarRating/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StarRating starrating = db.StarRatings.Find(id);
            if (starrating == null)
            {
                return HttpNotFound();
            }
            ViewBag.ScenicSpotId = new SelectList(db.ScenicSpots, "ScenicSpotId", "ScenicSpotName", starrating.ScenicSpotId);
            ViewBag.Username = new SelectList(db.Users, "Username", "Password", starrating.Username);
            return View(starrating);
        }

        // POST: /StarRating/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,ScenicSpotId,Username,RatingDate,Star")] StarRating starrating)
        {
            if (ModelState.IsValid)
            {
                db.Entry(starrating).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ScenicSpotId = new SelectList(db.ScenicSpots, "ScenicSpotId", "ScenicSpotName", starrating.ScenicSpotId);
            ViewBag.Username = new SelectList(db.Users, "Username", "Password", starrating.Username);
            return View(starrating);
        }

        // GET: /StarRating/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StarRating starrating = db.StarRatings.Find(id);
            if (starrating == null)
            {
                return HttpNotFound();
            }
            return View(starrating);
        }

        // POST: /StarRating/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StarRating starrating = db.StarRatings.Find(id);
            db.StarRatings.Remove(starrating);
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
