using System;
using System.Collections.Generic;
using System.Text;
using CarPoolingApplication.Models;

namespace CarPoolingApplication.Services
{
    public class UserServices
    {

        public int ValidateUser(List<User> Users, string username, string password)
        {
            int index = Users.FindIndex(item => item.Username == username && item.Password == password);
            return index;
        }

        public string GetUserName(List<User> users, int index)
        {
            return users[index].Username;
        }

        public bool ValidateUserName(List<User> Users, string username)
        {
            int index = Users.FindIndex(item => item.Username == username);

            if (index == -1)
                return true;
            else
                return false;
        }
    }
}
