using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL1
{
    public class Cart
    {
        private int idUser;
        private int idProduct;
        private int quantity;

        public Cart()
        {
        }

        public Cart(int idUser, int idProduct, int quantity)
        {
            this.IdUser = idUser;
            this.IdProduct = idProduct;
            this.Quantity = quantity;
        }

        public int IdUser { get => idUser; set => idUser = value; }
        public int IdProduct { get => idProduct; set => idProduct = value; }
        public int Quantity { get => quantity; set => quantity = value; }
    }
}