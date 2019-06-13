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
    public class HumiditiesController : Controller
    {
        private WeatherDBContext db = new WeatherDBContext();

        // GET: Humidities
        public ActionResult Index()
        {
            var humidities = db.Humidities.Include(h => h.Temperatures);
            return View(humidities.ToList());
        }

        // GET: Humidities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Humidity humidity = db.Humidities.Find(id);
            if (humidity == null)
            {
                return HttpNotFound();
            }
            return View(humidity);
        }

        // GET: Humidities/Create
        public ActionResult Create()
        {
            ViewBag.Degree_Id = new SelectList(db.Temperatures, "Id", "Location");
            return View();
        }

        // POST: Humidities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Location,Day,ChillSpeed,Degree_Id")] Humidity humidity)
        {
            if (ModelState.IsValid)
            {
                db.Humidities.Add(humidity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Degree_Id = new SelectList(db.Temperatures, "Id", "Location", humidity.Degree_Id);
            return View(humidity);
        }

        // GET: Humidities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Humidity humidity = db.Humidities.Find(id);
            if (humidity == null)
            {
                return HttpNotFound();
            }
            ViewBag.Degree_Id = new SelectList(db.Temperatures, "Id", "Location", humidity.Degree_Id);
            return View(humidity);
        }

        // POST: Humidities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Location,Day,ChillSpeed,Degree_Id")] Humidity humidity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(humidity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Degree_Id = new SelectList(db.Temperatures, "Id", "Location", humidity.Degree_Id);
            return View(humidity);
        }

        // GET: Humidities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Humidity humidity = db.Humidities.Find(id);
            if (humidity == null)
            {
                return HttpNotFound();
            }
            return View(humidity);
        }

        // POST: Humidities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Humidity humidity = db.Humidities.Find(id);
            db.Humidities.Remove(humidity);
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
