using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarPoolingApplication.Models;

namespace CarPoolingApplication.Services
{
    public class TripServices
    {
        public string ShowTripOffer(User user)
        {
            string tripOffers = "";

            for (int i = 0; i < user.TripOffers.Count; i++)
            {
                TripOffer Trip = user.TripOffers[i];
                tripOffers += "\n\n" + Trip.TripOfferId + " | Driver : " + Trip.Driver + " | " + Trip.Date + " | " + Trip.Time + " | " + Trip.Source + " to " + Trip.Destination + " | " + Trip.Distance + "kms | " + Trip.Car.CarModel + " | " + Trip.Car.CarNumber + " | Total Seats : " + Trip.TotalSeats + " | Seats Left : " + Trip.SeatsLeft + " | Total Cost : " + Trip.TotalCost;
            }


            return tripOffers;
        }

        public string SearchTrips(List<User> users, string date, string source, string destination)
        {
            string tripOffers = "";
            int tripCount = 0;
            foreach (var user in users)
            {
                for (int i = 0; i < user.TripOffers.Count; i++)
                {
                    TripOffer Trip = user.TripOffers[i];
                    if (Trip.Date == date && Trip.Source == source && Trip.Destination == destination)
                    {
                        tripCount++;
                        tripOffers += "\n\n" + Trip.TripOfferId + " | Driver : " + Trip.Driver + " | " + Trip.Date + " | " + Trip.Time + " | " + Trip.Source + " to " + Trip.Destination + " | " + Trip.Distance + "kms | " + Trip.Car.CarModel + " | " + Trip.Car.CarNumber + " | Total Seats : " + Trip.TotalSeats + " | Seats Left : " + Trip.SeatsLeft + " | Total Cost : " + Trip.TotalCost;
                    }
                }
            }
            if (tripCount == 0)
            {
                tripOffers = "No trips found!!";
            }

            return tripOffers;

        }

        public void JoinRequest(List<User> users, string tripId, int index)
        {
            for (int i = 0; i < users.Count; i++)
            {
                User user = (User)users[i];
                foreach (TripOffer Trip in user.TripOffers)
                {
                    if (Trip.TripOfferId == tripId)
                    {
                        users[i].TripRequests.Add(new TripRequest(users[i].Username, users[index].Username, tripId));
                        users[index].TripRequests.Add(new TripRequest(users[i].Username, users[index].Username, tripId));
                        break;
                    }
                }

            }

        }

        public string GetTripOfferId(User user)
        {

            return user.TripOffers[user.TripOffers.Count - 1].TripOfferId;
        }

        public string RequestsReceived(User user, string username)
        {
            string Requests = "";
            int requestCount = 0;
            for (int i = 0; i < user.TripRequests.Count; i++)
            {
                TripRequest Request = user.TripRequests[i];
                if (Request.TripCreater == username)
                {
                    requestCount++;
                    Requests += "\nRequest ID : " + Request.RequestId + " For " + Request.TripId + " by " + Request.TripPassenger;
                }
            }



            if (requestCount == 0)
            {
                Requests = "No Requests Found!";
            }

            return Requests;
        }

        public string RequestsMade(User user, string username)
        {
            string Requests = "";
            int requestCount = 0;

            for (int i = 0; i < user.TripRequests.Count; i++)
            {
                TripRequest Request = user.TripRequests[i];
                if (Request.TripPassenger == username)
                {
                    requestCount++;
                    Requests += "\nRequest ID : " + Request.RequestId + " For " + Request.TripId + " by " + Request.TripPassenger;
                }
            }


            if (requestCount == 0)
            {
                Requests = "No Requests Found!";
            }

            return Requests;

        }

        public void ApproveBooking(List<User> users, User user, string requestId)
        {
            string tripPassenger = null;
            int passengerIndex;
            string tripId = null;

            foreach (var TripRequest in user.TripRequests)
            {
                if (TripRequest.RequestId == requestId)
                {
                    tripId = TripRequest.TripId;
                    tripPassenger = TripRequest.TripPassenger;
                }
            }

            passengerIndex = users.FindIndex(item => item.Username == tripPassenger);

            for (int i = 0; i < user.TripOffers.Count; i++)
            {
                TripOffer tripOffer = user.TripOffers[i];
                if (tripOffer.TripOfferId == tripId)
                {
                    tripOffer.SeatsOccupied++;
                    tripOffer.SeatsLeft--;

                    user.Bookings.Add(new TripBooking(tripOffer.TripOfferId, tripOffer.Date, tripOffer.Time, tripOffer.Source, tripOffer.Destination, tripOffer.Distance, tripOffer.TotalCost, tripOffer.CostPerHead, user.Username));
                    users[passengerIndex].Bookings.Add(new TripBooking(tripOffer.TripOfferId, tripOffer.Date, tripOffer.Time, tripOffer.Source, tripOffer.Destination, tripOffer.Distance, tripOffer.CostPerHead, tripOffer.CostPerHead, user.Username));

                    if (tripOffer.SeatsLeft == 0)
                    {
                        user.TripOffers.Remove(tripOffer);
                    }
                }
            }
        }

        public string ViewBookings(User user)
        {
            string bookings = null;

            foreach (var booking in user.Bookings)
            {
                bookings += "\n" + booking.TripOfferId + " | Trip Creator : " + booking.Driver + " | " + booking.Date + " | " + booking.Time + " | " + booking.Source + " to " + booking.Destination + " | " + booking.Distance + "kms | " + booking.CostPerHead + " INR";
            }

            return bookings;
        }
    }
}
