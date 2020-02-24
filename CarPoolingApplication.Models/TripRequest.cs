using System;
using System.Collections.Generic;
using System.Text;

namespace CarPoolingApplication.Models
{
    public class TripRequest
    {
        public string RequestId { get; set; }
        public string TripCreater { get; set; }
        public string TripPassenger { get; set; }
        public string TripId { get; set; }

        public TripRequest(string tripCreater, string tripPassenger, string tripId)
        {
            TripCreater = tripCreater;
            TripPassenger = tripPassenger;
            TripId = tripId;
            RequestId = "REQ" + DateTime.Now.ToString("mmss");
        }

    }
}
