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
    public class FogCalculationsController : Controller
    {
        private WeatherDBContext db = new WeatherDBContext();

        // GET: FogCalculations
        public ActionResult Index()
        {
            return View(db.Fahrenheits.ToList());
        }

        // GET: FogCalculations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FogCalculation fogCalculation = db.Fahrenheits.Find(id);
            if (fogCalculation == null)
            {
                return HttpNotFound();
            }
            return View(fogCalculation);
        }

        // GET: FogCalculations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FogCalculations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Location,Day,SkyCondition,CurrentTemp,DewPoint")] FogCalculation fogCalculation)
        {
            if (ModelState.IsValid)
            {
                db.Fahrenheits.Add(fogCalculation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fogCalculation);
        }

        // GET: FogCalculations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FogCalculation fogCalculation = db.Fahrenheits.Find(id);
            if (fogCalculation == null)
            {
                return HttpNotFound();
            }
            return View(fogCalculation);
        }

        // POST: FogCalculations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Location,Day,SkyCondition,CurrentTemp,DewPoint")] FogCalculation fogCalculation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fogCalculation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fogCalculation);
        }

        // GET: FogCalculations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FogCalculation fogCalculation = db.Fahrenheits.Find(id);
            if (fogCalculation == null)
            {
                return HttpNotFound();
            }
            return View(fogCalculation);
        }

        // POST: FogCalculations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FogCalculation fogCalculation = db.Fahrenheits.Find(id);
            db.Fahrenheits.Remove(fogCalculation);
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
