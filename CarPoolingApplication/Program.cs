using System;
using System.Collections.Generic;
using CarPoolingApplication.Models;
using CarPoolingApplication.Services;

namespace CarPoolingApplication
{
    class Program
    {
        static UserServices UserServices = new UserServices();
        static TripServices TripServices = new TripServices();
        static List<User> Users = new List<User>();

        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Main Menu : ");
            Console.WriteLine("1. Log In.");
            Console.WriteLine("2. Sign Up");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    {
                        Console.Clear();
                        string username;
                        string password;

                        Console.WriteLine("Enter User Name : ");
                        username = Console.ReadLine();

                        Console.WriteLine("Enter Password : ");
                        password = Console.ReadLine();

                        int index;
                        index = UserServices.ValidateUser(Users, username, password);

                        if (index == -1)
                        {
                            Console.WriteLine("Invalid Credentials");
                            Console.ReadKey();
                            Menu();
                        }

                        UserMenu(index);
                        break;
                    }
                case 2:
                    {
                        SignUp();
                        Menu();
                        break;
                    }
            }

        }

        static void SignUp()
        {
            Console.Clear();
            string username;
            string password;
            Console.WriteLine("Enter User Name : ");
            username = Console.ReadLine();

            if (UserServices.ValidateUserName(Users, username) == false)
            {
                Console.WriteLine("Username Already Exists!!");
                Console.WriteLine("Try Again with a different username.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Enter Password : ");
            password = Console.ReadLine();
            Users.Add(new User(username, password));
        }

        static void UserMenu(int index)
        {
            Console.Clear();
            Console.WriteLine("Logged in as " + UserServices.GetUserName(Users, index));
            Console.WriteLine("User Menu : ");
            Console.WriteLine("1. Create a Trip Offer.");
            Console.WriteLine("2. Search for a Trip.");
            Console.WriteLine("3. See all offers made by you. ");
            Console.WriteLine("4. See Requests for your Offer.");
            Console.WriteLine("5. See Requests made by you to join other rides.");
            Console.WriteLine("6. See Bookings");
            Console.WriteLine("7. Logout");
            Console.WriteLine("Enter your Choice : ");
            int choice = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            switch (choice)
            {
                case 1:
                    {
                        string date;
                        string time;
                        string source;
                        string destination;
                        double distance;
                        string carModel;
                        string carNumber;
                        int totalSeats;
                        decimal totalCost;

                        Console.WriteLine("Enter Date for the trip (DD/MM/YYYY)");
                        date = Console.ReadLine();
                        Console.WriteLine("Enter Time for the Trip (hh:mm)");
                        time = Console.ReadLine();
                        Console.WriteLine("Enter Source");
                        source = Console.ReadLine();
                        Console.WriteLine("Enter Destination");
                        destination = Console.ReadLine();
                        Console.WriteLine("Enter Distance in kms ");
                        distance = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Enter Car Model");
                        carModel = Console.ReadLine();
                        Console.WriteLine("Enter Car Number");
                        carNumber = Console.ReadLine();
                        Console.WriteLine("Enter Total Seats Available");
                        totalSeats = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Total Estimated Cost");
                        totalCost = Convert.ToDecimal(Console.ReadLine());
                        Users[index].TripOffers.Add(new TripOffer(date, time, source, destination, distance, carModel, carNumber, totalSeats, totalCost, Users[index].Username));
                        string TripId = TripServices.GetTripOfferId(Users[index]);
                        Console.WriteLine("Your TripOfferID is : " + TripId);
                        Console.WriteLine("Trip Created!");
                        Console.ReadKey();
                        UserMenu(index);
                        break;
                    }

                case 2:
                    {
                        string date;
                        string source;
                        string destination;
                        Console.WriteLine("Enter Date (DD/MM/YYYY): ");
                        date = Console.ReadLine();
                        Console.WriteLine("Enter Source : ");
                        source = Console.ReadLine();
                        Console.WriteLine("Enter Destination : ");
                        destination = Console.ReadLine();
                        string TripList = TripServices.SearchTrips(Users, date, source, destination);
                        if (TripList == "No trips found!!")
                        {
                            Console.WriteLine(TripList);
                            Console.ReadKey();
                            UserMenu(index);
                        }
                        Console.WriteLine(TripList);
                        Console.WriteLine("Enter the Trip ID for the trip you are intested in : ");
                        string tripId = Console.ReadLine();
                        TripServices.JoinRequest(Users, tripId, index);
                        Console.WriteLine("Request Created!!");
                        Console.ReadKey();
                        UserMenu(index);
                        break;

                    }

                case 3:
                    Console.WriteLine(TripServices.ShowTripOffer(Users[index]));
                    Console.ReadKey();
                    UserMenu(index);
                    break;

                case 4:
                    string requestList;
                    requestList = TripServices.RequestsReceived(Users[index], Users[index].Username);
                    if (requestList == "No Requests Found!")
                    {
                        Console.WriteLine(requestList);
                        UserMenu(index);
                    }
                    Console.WriteLine(requestList);
                    Console.WriteLine("Enter RequestId for the request you want to approve : ");
                    string requestId = Console.ReadLine();
                    TripServices.ApproveBooking(Users, Users[index], requestId);
                    Console.ReadKey();
                    UserMenu(index);
                    break;

                case 5:
                    Console.WriteLine(TripServices.RequestsMade(Users[index], Users[index].Username));
                    Console.ReadKey();
                    UserMenu(index);
                    break;

                case 6:
                    TripServices.ViewBookings(Users[index]);
                    break;

                case 7:
                    Menu();
                    break;

                default:
                    UserMenu(index);
                    break;
            }

        }
    }
}