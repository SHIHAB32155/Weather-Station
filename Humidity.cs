using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Weather_Station_MVC_6.WeatherData
{
    public class Humidity
    {
        [Key]
        public int Id { get; set; }
        public string Location { get; set; }
        public string Day { get; set; }
        public decimal ChillSpeed { get; set; }
        public int Degree_Id { get; set; }

        [ForeignKey(nameof(Degree_Id))]

        public Temperature Temperatures { get; set; }

        [NotMapped]
        public bool IsDeleted { get; set; }
    }
}