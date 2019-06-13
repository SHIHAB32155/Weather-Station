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
    public class TemperaturesController : Controller
    {
        private WeatherDBContext db = new WeatherDBContext();

        // GET: Temperatures
        public ActionResult Index()
        {
            return View(db.Temperatures.ToList());
        }

        // GET: Temperatures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Temperature temperature = db.Temperatures.Find(id);
            if (temperature == null)
            {
                return HttpNotFound();
            }
            return View(temperature);
        }

        // GET: Temperatures/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Temperatures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Location,Day,Hour,DegreeTemperature,DewPoint")] Temperature temperature)
        {
            if (ModelState.IsValid)
            {
                db.Temperatures.Add(temperature);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(temperature);
        }

        // GET: Temperatures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Temperature temperature = db.Temperatures.Find(id);
            if (temperature == null)
            {
                return HttpNotFound();
            }
            return View(temperature);
        }

        // POST: Temperatures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Location,Day,Hour,DegreeTemperature,DewPoint")] Temperature temperature)
        {
            if (ModelState.IsValid)
            {
                db.Entry(temperature).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(temperature);
        }

        // GET: Temperatures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Temperature temperature = db.Temperatures.Find(id);
            if (temperature == null)
            {
                return HttpNotFound();
            }
            return View(temperature);
        }

        // POST: Temperatures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Temperature temperature = db.Temperatures.Find(id);
            db.Temperatures.Remove(temperature);
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
