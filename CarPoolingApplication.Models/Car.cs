using System;
using System.Collections.Generic;
using System.Text;

namespace CarPoolingApplication.Models
{
    public class Car
    {
        public string CarModel { get; set; }
        public string CarNumber { get; set; }
        public int SeatingCapacity { get; set; }

        public Car(string carModel, string carNumber, int seatingCapacity)
        {
            this.CarModel = carModel;
            this.CarNumber = carNumber;
            this.SeatingCapacity = seatingCapacity;
        }
    }
}
