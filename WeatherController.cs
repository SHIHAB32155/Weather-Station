using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Weather_Station_MVC_6.WeatherData;

namespace Weather_Station_MVC_6.Controllers
{
    public class WeatherController : Controller
    {
        public static List<Weather> Weathers { get; set; }
        // GET: Weather
        public ActionResult Index()
        {
            return View(Weathers);
        }

        // GET: Weather/Details/5
        public ActionResult Details(int id)
        {
            var weather = Weathers.FirstOrDefault(x => x.Id == id);
            return View(weather);
        }

        // GET: Weather/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Weather/Create
        [HttpPost]
        public ActionResult Create(Weather weatherModel)
        {
            try
            {
                int id = Weathers.Max(x => x.Id);
                weatherModel.Id = ++id;
                Weathers.Add(weatherModel);
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Weather/Edit/5
        public ActionResult Edit(int id)
        {
            var weather = Weathers.FirstOrDefault(x => x.Id == id);
            return View(weather);
        }

        // POST: Weather/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Weather weatherModel)
        {
            try
            {
                var weather = Weathers.FirstOrDefault(x => x.Id == id);
                weather.Location = weatherModel.Location;
                weather.Day = weatherModel.Day;
                weather.Temperatures = weatherModel.Temperatures;
                weather.Humiditys = weatherModel.Humiditys;
                weather.WindSpeeds = weatherModel.WindSpeeds;
                weather.FogCalculations = weatherModel.FogCalculations;

                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Weather/Delete/5
        public ActionResult Delete(int id)
        {
            var weather = Weathers.FirstOrDefault(x => x.Id == id);
            return View(weather);
        }

        // POST: Weather/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Weather weatherModel)
        {
            try
            {
                var weather = Weathers.FirstOrDefault(x => x.Id == id);
                weather.Location = weatherModel.Location;
                weather.Day = weatherModel.Day;
                weather.Temperatures = weatherModel.Temperatures;
                weather.Humiditys = weatherModel.Humiditys;
                weather.WindSpeeds = weatherModel.WindSpeeds;
                weather.FogCalculations = weatherModel.FogCalculations;
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
