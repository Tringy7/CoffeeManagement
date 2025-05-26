using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangageCoffee.DTO
{
    public class Class_Menu
    {
        private int item_id;
        private string name;
        private string description;
        private double price;
        private string category;
        private string status;
        private int discount;
        private int createdBy;
        private string imagePath;
        public Class_Menu()
        {

        }

        public Class_Menu(int item_id, string name, string description, double price, string category, string status, int discount, int createdBy, string imagePath)
        {
            this.item_id = item_id;
            this.name = name;
            this.description = description;
            this.price = price;
            this.category = category;
            this.status = status;
            this.discount = discount;
            this.createdBy = createdBy;
            this.imagePath = imagePath;
        }

        public int Item_id { get => item_id; set => item_id = value; }
        public string Name { get => name; set => name = value; }
        public double Price { get => price; set => price = value; }
        public string Category { get => category; set => category = value; }
        public int Discount { get => discount; set => discount = value; }
        public int CreatedBy { get => createdBy; set => createdBy = value; }
        public string Description { get => description; set => description = value; }
        public string Status { get => status; set => status = value; }
        public string ImagePath { get => imagePath; set => imagePath = value; }
    }
}
