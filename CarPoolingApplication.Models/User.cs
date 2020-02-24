using System;
using System.Linq;
using System.Collections.Generic;

namespace CarPoolingApplication.Models
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public List<TripOffer> TripOffers = new List<TripOffer>();
        public List<TripRequest> TripRequests = new List<TripRequest>();
        public List<TripBooking> Bookings = new List<TripBooking>();


        public User(string username, string Password)
        {
            this.Username = username;
            this.Password = Password;
        }
    }
}
