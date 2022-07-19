using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL1
{
    public class Contact
    {
        private int idUser;
        private int orderNumber;
        private string phoneNumber;
        private string address;
        private bool isDefault;

        public Contact()
        {
        }

        public Contact(int idUser, int orderNumber, string phoneNumber, string address, bool isDefault)
        {
            this.IdUser = idUser;
            this.OrderNumber = orderNumber;
            this.PhoneNumber = phoneNumber;
            this.Address = address;
            this.IsDefault = isDefault;
        }

        public int IdUser { get => idUser; set => idUser = value; }
        public int OrderNumber { get => orderNumber; set => orderNumber = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Address { get => address; set => address = value; }
        public bool IsDefault { get => isDefault; set => isDefault = value; }
    }
}