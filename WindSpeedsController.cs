using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Weather_Station_MVC_6.WeatherData;

namespace Weather_Station_MVC_6.Controllers
{
    public class WindSpeedsController : Controller
    {
        private WeatherDBContext db = new WeatherDBContext();

        // GET: WindSpeeds
        public ActionResult Index()
        {
            return View(db.Winds.ToList());
        }

        // GET: WindSpeeds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WindSpeed windSpeed = db.Winds.Find(id);
            if (windSpeed == null)
            {
                return HttpNotFound();
            }
            return View(windSpeed);
        }

        // GET: WindSpeeds/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WindSpeeds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Location,Day,Hour,Velocity")] WindSpeed windSpeed)
        {
            if (ModelState.IsValid)
            {
                db.Winds.Add(windSpeed);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(windSpeed);
        }

        // GET: WindSpeeds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WindSpeed windSpeed = db.Winds.Find(id);
            if (windSpeed == null)
            {
                return HttpNotFound();
            }
            return View(windSpeed);
        }

        // POST: WindSpeeds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Location,Day,Hour,Velocity")] WindSpeed windSpeed)
        {
            if (ModelState.IsValid)
            {
                db.Entry(windSpeed).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(windSpeed);
        }

        // GET: WindSpeeds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WindSpeed windSpeed = db.Winds.Find(id);
            if (windSpeed == null)
            {
                return HttpNotFound();
            }
            return View(windSpeed);
        }

        // POST: WindSpeeds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WindSpeed windSpeed = db.Winds.Find(id);
            db.Winds.Remove(windSpeed);
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
