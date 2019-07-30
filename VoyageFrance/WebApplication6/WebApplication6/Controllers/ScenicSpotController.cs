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
using WebApplication6.ViewModels;

namespace WebApplication6.Controllers
{
    public class ScenicSpotController : Controller
    {
        private VoyageContext db = new VoyageContext();

        public ActionResult searchShow(string searchKeyword)
        {
            var scenicspot = from s in db.ScenicSpots select s;
            if (!String.IsNullOrEmpty(searchKeyword))
            {
                scenicspot = scenicspot.Where(s => s.ScenicSpotName.Contains(searchKeyword));
            }
            //var scenicspots = db.ScenicSpots.Include(s => s.City);
            return View(scenicspot);
        }

        public ActionResult Show(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CityScenicSpotViewModel vm2 = new CityScenicSpotViewModel();

            //vm.City = from c in db.Cities where c.CityId == id select c;
            vm2.ScenicSpot = from s in db.ScenicSpots
                            where s.ScenicSpotId == id 
                            select s;
            vm2.Review = from r in db.Reviews
                         join s in db.ScenicSpots
                         on r.ScenicSpotId equals s.ScenicSpotId
                         where r.ScenicSpotId == id
                         select r;

            if (vm2.ScenicSpot == null)
            {
                return HttpNotFound();
            }

            return View(vm2);
        }

        // GET: /ScenicSpot/
        public ActionResult Index()
        {
            return View(db.ScenicSpots.ToList());
        }

        [Authorize]
        public ActionResult AddPaymentRecord(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScenicSpot scenicspot = db.ScenicSpots.Find(id);

            decimal price = scenicspot.TicketPrice;
            DateTime purchaseDate = DateTime.Now;
            PaymentRecord pr = new PaymentRecord();
            pr.Money = price;
            pr.PurchaseDate = purchaseDate;
            pr.ScenicSpotId = (int)id;
            db.PaymentRecords.Add(pr);
            db.SaveChanges();

            if (scenicspot == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("../Review/Comment");
        }

        // GET: /ScenicSpot/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScenicSpot scenicspot = db.ScenicSpots.Find(id);
            if (scenicspot == null)
            {
                return HttpNotFound();
            }
            return View(scenicspot);
        }

        // GET: /ScenicSpot/Create
        public ActionResult Create()
        {
            ViewBag.CityId = new SelectList(db.Cities, "CityId", "CityName");
            return View();
        }

        // POST: /ScenicSpot/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ScenicSpotId,ScenicSpotName,ScenicSpotDetails,TicketPrice,OpeningHour,ClosingHour,CityId")] ScenicSpot scenicspot)
        {
            if (ModelState.IsValid)
            {
                db.ScenicSpots.Add(scenicspot);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(db.Cities, "CityId", "CityName", scenicspot.CityId);
            return View(scenicspot);
        }

        // GET: /ScenicSpot/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScenicSpot scenicspot = db.ScenicSpots.Find(id);
            if (scenicspot == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityId = new SelectList(db.Cities, "CityId", "CityName", scenicspot.CityId);
            return View(scenicspot);
        }

        // POST: /ScenicSpot/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ScenicSpotId,ScenicSpotName,ScenicSpotDetails,TicketPrice,OpeningHour,ClosingHour,CityId")] ScenicSpot scenicspot)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scenicspot).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityId = new SelectList(db.Cities, "CityId", "CityName", scenicspot.CityId);
            return View(scenicspot);
        }

        // GET: /ScenicSpot/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScenicSpot scenicspot = db.ScenicSpots.Find(id);
            if (scenicspot == null)
            {
                return HttpNotFound();
            }
            return View(scenicspot);
        }

        // POST: /ScenicSpot/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ScenicSpot scenicspot = db.ScenicSpots.Find(id);
            db.ScenicSpots.Remove(scenicspot);
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
