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
    public class ImageController : Controller
    {
        private VoyageContext db = new VoyageContext();

        // GET: /Image/
        public ActionResult Index()
        {
            var images = db.Images.Include(i => i.ScenicSpot);
            return View(images.ToList());
        }

        // GET: /Image/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Image image = db.Images.Find(id);
            if (image == null)
            {
                return HttpNotFound();
            }
            return View(image);
        }

        // GET: /Image/Create
        public ActionResult Create()
        {
            ViewBag.ScenicSpotId = new SelectList(db.ScenicSpots, "ScenicSpotId", "ScenicSpotName");
            return View();
        }

        // POST: /Image/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ImageFilename,ScenicSpotId")] Image image)
        {
            if (ModelState.IsValid)
            {
                db.Images.Add(image);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ScenicSpotId = new SelectList(db.ScenicSpots, "ScenicSpotId", "ScenicSpotName", image.ScenicSpotId);
            return View(image);
        }

        // GET: /Image/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Image image = db.Images.Find(id);
            if (image == null)
            {
                return HttpNotFound();
            }
            ViewBag.ScenicSpotId = new SelectList(db.ScenicSpots, "ScenicSpotId", "ScenicSpotName", image.ScenicSpotId);
            return View(image);
        }

        // POST: /Image/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ImageFilename,ScenicSpotId")] Image image)
        {
            if (ModelState.IsValid)
            {
                db.Entry(image).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ScenicSpotId = new SelectList(db.ScenicSpots, "ScenicSpotId", "ScenicSpotName", image.ScenicSpotId);
            return View(image);
        }

        // GET: /Image/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Image image = db.Images.Find(id);
            if (image == null)
            {
                return HttpNotFound();
            }
            return View(image);
        }

        // POST: /Image/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Image image = db.Images.Find(id);
            db.Images.Remove(image);
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
