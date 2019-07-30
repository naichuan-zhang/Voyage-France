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
    public class PaymentRecordController : Controller
    {
        private VoyageContext db = new VoyageContext();

        public ActionResult BookTicket(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ScenicSpotPaymentRecordViewModel vm = new ScenicSpotPaymentRecordViewModel();

            vm.ScenicSpot = from s in db.ScenicSpots where id == s.ScenicSpotId select s;
            //vm.PaymentRecord = from p in db.PaymentRecords
            //                   join s in db.ScenicSpots
            //                   on p.ScenicSpotId equals s.ScenicSpotId
            //                   select new
            //                   {
            //                       p.ScenicSpotId = id,
            //                       p.Money = s.TicketPrice,
            //                       p.PurchaseDate = 
            //                   };


            
            //if (vm.City == null)
            //{
            //    return HttpNotFound();
            //}
            return View(vm);
        }

        // GET: /PaymentRecord/
        public ActionResult Index()
        {
            var paymentrecords = db.PaymentRecords.Include(p => p.User);
            return View(paymentrecords.ToList());
        }

        // GET: /PaymentRecord/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentRecord paymentrecord = db.PaymentRecords.Find(id);
            if (paymentrecord == null)
            {
                return HttpNotFound();
            }
            return View(paymentrecord);
        }

        // GET: /PaymentRecord/Create
        public ActionResult Create()
        {
            ViewBag.Username = new SelectList(db.Users, "Username", "Password");
            return View();
        }

        // POST: /PaymentRecord/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,Username,ScenicSpotId,Money,PurchaseDate")] PaymentRecord paymentrecord)
        {
            if (ModelState.IsValid)
            {
                db.PaymentRecords.Add(paymentrecord);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Username = new SelectList(db.Users, "Username", "Password", paymentrecord.Username);
            return View(paymentrecord);
        }

        // GET: /PaymentRecord/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentRecord paymentrecord = db.PaymentRecords.Find(id);
            if (paymentrecord == null)
            {
                return HttpNotFound();
            }
            ViewBag.Username = new SelectList(db.Users, "Username", "Password", paymentrecord.Username);
            return View(paymentrecord);
        }

        // POST: /PaymentRecord/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,Username,ScenicSpotId,Money,PurchaseDate")] PaymentRecord paymentrecord)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paymentrecord).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Username = new SelectList(db.Users, "Username", "Password", paymentrecord.Username);
            return View(paymentrecord);
        }

        // GET: /PaymentRecord/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentRecord paymentrecord = db.PaymentRecords.Find(id);
            if (paymentrecord == null)
            {
                return HttpNotFound();
            }
            return View(paymentrecord);
        }

        // POST: /PaymentRecord/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PaymentRecord paymentrecord = db.PaymentRecords.Find(id);
            db.PaymentRecords.Remove(paymentrecord);
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
