using System;
using System.Collections.Generic;
using System.Text;

namespace CarPoolingApplication.Models
{
    public class TripBooking
    {
        public string TripOfferId { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public double Distance { get; set; }
        public decimal CostPerHead { get; set; }
        public string Driver { get; set; }

        public TripBooking(string tripOfferId, string date, string time, string source, string destination, double distance, decimal totalCost, decimal costPerHead, string driver)
        {
            TripOfferId = tripOfferId;
            Date = date;
            Time = time;
            Source = source;
            Destination = destination;
            Distance = distance;
            CostPerHead = costPerHead;
            Driver = driver;
        }
    }
}
