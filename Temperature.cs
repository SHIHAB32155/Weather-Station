using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Weather_Station_MVC_6.WeatherData
{
    public class Temperature
    {
        public Temperature()
        {
            Humidities = new List<Humidity>();
            WindSpeeds = new List<WindSpeed>();
            FogCalculations = new List<FogCalculation>();
        }

        public int Id { get; set; }
        public string Location { get; set; }
        public string Day { get; set; }
        public decimal Hour { get; set; }
        public decimal DegreeTemperature { get; set; }
        public decimal DewPoint { get; set; }


        public List<Humidity> Humidities { get; set; }
        public List<WindSpeed> WindSpeeds { get; set; }
        public List<FogCalculation> FogCalculations { get; set; }
    }
}