using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL1
{
    public class User
    {
        private int id;
        private string firstname;
        private string lastname;
        private string email;
        private string password;
        private string birthdate;
        private bool sex;

        public User()
        {
        }

        public User(int id, string firstname, string lastname, string email, string password, string birthdate, bool sex)
        {
            this.Id = id;
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Email = email;
            this.Password = password;
            this.Birthdate = birthdate;
            this.Sex = sex;
        }

        public int Id { get => id; set => id = value; }
        public string Firstname { get => firstname; set => firstname = value; }
        public string Lastname { get => lastname; set => lastname = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string Birthdate { get => birthdate; set => birthdate = value; }
        public bool Sex { get => sex; set => sex = value; }
    }
}