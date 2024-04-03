using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Homework_Product.Models
{
    public class Product
    {
        static int unicId = 0;
        public int Id { get; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }

        public string ImagePath {  get; }

        public Product(string name, decimal cost, string description, string imagePath)
        {
            unicId++;
            Id = unicId;
            Name = name;
            Cost = cost;
            Description = description;
            ImagePath = imagePath;
        }

        public override string ToString()
        {
            return $"ID: {Id}\n{Name}\n{Cost} $";
        }
    }
}
