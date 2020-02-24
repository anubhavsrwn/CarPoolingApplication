using System;
using System.Collections.Generic;
using System.Text;

namespace CarPoolingApplication.Models
{
    public class TripOffer
    {
        public string TripOfferId { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public double Distance { get; set; }
        public Car Car;
        public int TotalSeats { get; set; }
        public int SeatsOccupied { get; set; }
        public int SeatsLeft { get; set; }
        public decimal TotalCost { get; set; }
        public decimal CostPerHead { get; set; }
        public string Driver { get; set; }


        public TripOffer(string date, string time, string source, string destination, double distance, string carModel, string carNumber, int totalSeats, decimal totalCost, string driver)
        {
            this.Date = date;
            this.Time = time;
            this.Source = source;
            this.Destination = destination;
            this.Distance = distance;
            Car = new Car(carModel, carNumber, totalSeats);
            this.TotalSeats = totalSeats;
            this.SeatsOccupied = 1;
            this.SeatsLeft = TotalSeats - SeatsOccupied;
            this.TotalCost = totalCost;
            this.CostPerHead = TotalCost / TotalSeats;
            this.Driver = driver;
            TripOfferId = "TRIP" + DateTime.Now.ToString("mmss");
        }



    }
}
