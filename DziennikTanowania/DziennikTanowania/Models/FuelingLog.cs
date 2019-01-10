using System;
using System.Collections.Generic;
using System.Text;
using DziennikTanowania.Helpers;
using DziennikTanowania.Services;
using DziennikTanowania.ViewModels;
using SQLite;

namespace DziennikTanowania.Models
{
    
    [Table("FuelingLog")]
    public class FuelingLog 
    {
        private decimal _totalPrice;
        
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int ActualMileage { get; set; }
        public double AmountOfRefueledFuel { get; set; }
        public decimal PricePerLiter { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Today;
        public bool RefuealingToFull { get; set; }
        public decimal TotalPrice
        {
            get => _totalPrice;
            set
            {
                _totalPrice = (decimal)AmountOfRefueledFuel * PricePerLiter;
            }
        }
        public int DistanceFromLastRefueling { get; set; }
        public double MilesPerLiter { get; set; }
        
        


    }

    
}
