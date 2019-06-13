using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Weather_Station_MVC_6.WeatherData
{
    public class WeatherDBContext : DbContext
    {
        public WeatherDBContext() : base()
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Temperature> Temperatures { get; set; }
        public virtual DbSet<Humidity> Humidities { get; set; }
        public virtual DbSet<WindSpeed> Winds { get; set; }
        public virtual DbSet<FogCalculation> Fahrenheits { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Temperature>()
                 .HasMany(e => e.Humidities)
                 .WithRequired(e => e.Temperatures)
                 .HasForeignKey(e => e.Degree_Id);
        }

        public System.Data.Entity.DbSet<Weather_Station_MVC_6.WeatherData.Weather> Weathers { get; set; }
    }
}