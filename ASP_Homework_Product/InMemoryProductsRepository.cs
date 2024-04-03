using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using ASP_Homework_Product.Models;

namespace ASP_Homework_Product
{
    public class InMemoryProductsRepository : IProductsRepository
    {
        List<Product> products = new List<Product>
        {
            new Product("Elden ring", Convert.ToDecimal(49.89), "Epic adventure set in a world of dark fantasy and mysteries, where players explore a vast open world, battle colossal enemies, and uncover the secrets of ancient history, created in collaboration between Hidetaka Miyazaki and George R. R. Martin.", "/images/elden-ring.jpg"),
            new Product("Minecraft", Convert.ToDecimal(29.99), "Sandbox game where players can explore, create, and survive in a blocky, procedurally-generated world, limited only by their imagination!", "/images/minecraft.jpg"),
            new Product("Cyberpunk 2077", Convert.ToDecimal(35.49), "Open-world action RPG set in the dystopian future of Night City, offering players a gritty narrative-driven experience with deep character customization and immersive cybernetic enhancements.", "/images/cyberpunk-2077.jpg"),
            new Product("Lethal Company", Convert.ToDecimal(4.85), "A co-op horror about scavenging at abandoned moons to sell scrap to the Company.", "/images/lethal-company.jpg"),
            new Product("Valheim", Convert.ToDecimal(5.39), "Cooperative survival game set in a procedurally-generated world inspired by Norse mythology, where players must gather resources, build shelters, craft equipment, and battle mythical creatures to prove their worth to the gods.", "/images/valheim.jpg"),
            new Product("Terraria", Convert.ToDecimal(2.89), "2D sandbox adventure game offering endless exploration, crafting, and combat in procedurally generated worlds, where players can build, mine, fight, and uncover hidden treasures alone or with friends", "/images/terraria.jpg"),
            new Product("God of War: Ragnarok", Convert.ToDecimal(67.99), "Epic action-adventure game that continues the journey of Kratos and Atreus, delving deeper into Norse mythology as they confront new gods and face the impending apocalypse, promising intense combat, emotional storytelling, and stunning visuals.", "/images/god-of-war-ragnarok.jpg"),
            new Product("GTA VI", 0, "Upcoming open-world action-adventure game set in a sprawling, modern metropolis, offering players unprecedented freedom to explore, engage in criminal activities, and navigate a richly detailed narrative filled with satire and social commentary.", "/images/gta-6.jpg")
        };

        public List<Product> Products
        {
            get { return products; }
            set { products = value; }
        }

        public List<Product> GetProducts()
        {
            return Products;
        }

        public Product TryGetById(int id)
        {
            return Products.FirstOrDefault(product => product.Id == id);
        }

        public void Remove(Product product)
        {
            products.Remove(product);
        }

        public void Add(Product product)
        {
            products.Add(product);
        }

        public void Edit(int productId, string name, decimal cost, string description)
        {
            var product = products.FirstOrDefault(product => product.Id == productId);
            product.Name = name;
            product.Cost = cost;
            product.Description = description;
        }
    }

    public interface IProductsRepository
    {
        List<Product> Products { get; set; }

        List<Product> GetProducts();

        Product TryGetById(int id);

        void Remove(Product product);

        void Add(Product product);

        void Edit(int productId, string name, decimal cost, string description);
    }
}
