using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangageCoffee.DTO
{
    public class Class_product
    {
        private int id;
        private string name_Product;
        private double price;
        private double quantity;
        private string category;
        private string status;
        private int createdBy;
        private double originalPrice;
        private string imagePath;

        public Class_product()
        {

        }

        public Class_product(int id, string name_Product, double price, double quantity, string category, string status, int createdBy, double originalPrice, string imagePath)
        {
            this.id = id;
            this.name_Product = name_Product;
            this.price = price;
            this.quantity = quantity;
            this.category = category;
            this.status = status;
            this.createdBy = createdBy;
            this.originalPrice = originalPrice;
            this.imagePath = imagePath;
        }

        public int Id { get => id; set => id = value; }
        public string Name_Product { get => name_Product; set => name_Product = value; }
        public double Price { get => price; set => price = value; }
        public double Quantity { get => quantity; set => quantity = value; }
        public string Category { get => category; set => category = value; }
        public string Status { get => status; set => status = value; }
        public int CreatedBy { get => createdBy; set => createdBy = value; }
        public double OriginalPrice { get => originalPrice; set => originalPrice = value; }
        public string ImagePath { get => imagePath; set => imagePath = value; }
    }
}
