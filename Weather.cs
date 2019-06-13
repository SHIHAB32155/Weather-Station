using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Weather_Station_MVC_6.WeatherData
{
    public class Weather
    {
        [Key]
        public int Id { get; set; }
        public string Location { get; set; }
        public string Day { get; set; }
        public Temperature Temperatures { get; set; }
        public Humidity Humiditys { get; set; }
        public WindSpeed WindSpeeds { get; set; }
        public FogCalculation FogCalculations { get; set; }
    }
}