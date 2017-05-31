using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WarehouseMVC.DataAccess
{
    public class StoreContext : DbContext
    {
        // Properties
        public DbSet<Models.StockItem> Items { get; set; }

        // Constructor
        public StoreContext()
            : base("DefaultConnection")
        {

        }
    }
}