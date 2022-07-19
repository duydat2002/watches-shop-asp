using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL1
{
    public class Product
    {
        private int id;
        private string name;
        private double price;
        private float discount;
        private string desc;
        private string alts;
        private float size;
        private string color;
        private float stars;
        private string type;
        private int qty;

        public Product()
        {
        }

        public Product(int id, string name, double price, float discount, string desc, string alts, float size, string color, float stars, string type, int qty)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
            this.Discount = discount;
            this.Desc = desc;
            this.Alts = alts;
            this.Size = size;
            this.Color = color;
            this.Stars = stars;
            this.Type = type;
            this.Qty = qty;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public double Price { get => price; set => price = value; }
        public float Discount { get => discount; set => discount = value; }
        public string Desc { get => desc; set => desc = value; }
        public string Alts { get => alts; set => alts = value; }
        public float Size { get => size; set => size = value; }
        public string Color { get => color; set => color = value; }
        public float Stars { get => stars; set => stars = value; }
        public string Type { get => type; set => type = value; }
        public int Qty { get => qty; set => qty = value; }
    }
}