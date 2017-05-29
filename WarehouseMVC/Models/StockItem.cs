﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WarehouseMVC.Models
{
    public class StockItem
    {
        [Key]
        public int ArticleNumber { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ShelfPosition { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
    }
}