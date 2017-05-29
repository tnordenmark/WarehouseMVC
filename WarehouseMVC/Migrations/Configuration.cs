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
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WarehouseMVC.DataAccess.StoreContext context)
        {
            context.Items.AddOrUpdate(
                i => i.ArticleNumber,
                new StockItem { ArticleNumber = 1000, Name = "Stor h�st", Price = 30000, ShelfPosition = "A1", Quantity = 10, Description = "Mycket stor h�st" },
                new StockItem { ArticleNumber = 2000, Name = "Liten h�st", Price = 20000, ShelfPosition = "B1", Quantity = 20, Description = "Mycket liten h�st" }
                );
        }
    }
}
