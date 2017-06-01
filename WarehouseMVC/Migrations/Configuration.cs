namespace WarehouseMVC.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WarehouseMVC.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WarehouseMVC.DataAccess.StoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(WarehouseMVC.DataAccess.StoreContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Items.AddOrUpdate(
                new StockItem
                {
                    ArticleNumber = "H2365",
                    Name = "Large horse",
                    Category = ProductCategory.Horses,
                    ShelfPosition = "H1",
                    Quantity = 10,
                    Price = 30000,
                    Description = "Very large horse. For maximum stamina and speed."
                },
                new StockItem
                {
                    ArticleNumber = "H1623",
                    Name = "Medium horse",
                    Category = ProductCategory.Horses,
                    ShelfPosition = "H2",
                    Quantity = 15,
                    Price = 25000,
                    Description = "Medium sized horse. Just the right size."
                },
                new StockItem
                {
                    ArticleNumber = "H7645",
                    Name = "Small horse",
                    Category = ProductCategory.Horses,
                    ShelfPosition = "H3",
                    Quantity = 20,
                    Price = 20000,
                    Description = "Very tiny horse. For the penny wise equestrian."
                },
                new StockItem
                {
                    ArticleNumber = "A5687",
                    Name = "Keyring",
                    Category = ProductCategory.Accessories,
                    ShelfPosition = "A7",
                    Quantity = 200,
                    Price = 39,
                    Description = "Extremely beautiful keyring in the shape of a horse."
                },
                new StockItem
                {
                    ArticleNumber = "C6667",
                    Name = "Riding helmet",
                    Category = ProductCategory.Clothing,
                    ShelfPosition = "C1",
                    Quantity = 40,
                    Price = 599,
                    Description = "Proper head protection is the key for any serious equestrian."
                },
                new StockItem
                {
                    ArticleNumber = "F1112",
                    Name = "Oats",
                    Category = ProductCategory.Food,
                    ShelfPosition = "F3",
                    Quantity = 150,
                    Price = 199,
                    Description = "Premium oats for any hungry horse."
                },
                new StockItem
                {
                    ArticleNumber = "F1354",
                    Name = "Carrots",
                    Category = ProductCategory.Food,
                    ShelfPosition = "F2",
                    Quantity = 100,
                    Price = 19.90m,
                    Description = "Carrots are tasty."
                },
                new StockItem
                {
                    ArticleNumber = "C8865",
                    Name = "Riding boots",
                    Category = ProductCategory.Clothing,
                    ShelfPosition = "C7",
                    Quantity = 50,
                    Price = 1299.90m,
                    Description = "Because leather is the best!"
                },
                new StockItem
                {
                    ArticleNumber = "A4587",
                    Name = "Bathtub",
                    Category = ProductCategory.Accessories,
                    ShelfPosition = "A3",
                    Quantity = 5,
                    Price = 4990,
                    Description = "Horse sized bathtub well suited for teaching horses to swim."
                }
            );
        }
    }
}
