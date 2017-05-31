using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WarehouseMVC.Models;
using WarehouseMVC.DataAccess;
using System.Data.Entity;

namespace WarehouseMVC.Repositories
{
    public class StoreRepository
    {
        private StoreContext db;

        #region Constructors
        public StoreRepository()
        {
            db = new StoreContext();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Get item by article number.
        /// </summary>
        /// <param name="articleNo">Article number</param>
        /// <returns>Item with the specified article number.</returns>
        public StockItem GetItem(string articleNo)
        {
            return db.Items.Where(i => i.ArticleNumber == articleNo).FirstOrDefault();
        }

        /// <summary>
        /// Get item by id.
        /// </summary>
        /// <param name="id">Database id</param>
        /// <returns>Item with the specified id.</returns>
        public StockItem GetItem(int id)
        {
            return db.Items.Where(i => i.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// Get list of all items in the storage.
        /// </summary>
        /// <returns>List of all items in the storage.</returns>
        public List<StockItem> GetAllItems()
        {
            return db.Items.ToList();
        }

        /// <summary>
        /// Search by product name.
        /// </summary>
        /// <param name="search">Search key</param>
        /// <returns>List of search results.</returns>
        public List<StockItem> SearchByName(string search)
        {
            return db.Items.Where(i => i.Name.Contains(search) || search == null).ToList();
        }

        /// <summary>
        /// Search by description.
        /// </summary>
        /// <param name="search">Search key</param>
        /// <returns>List of search results.</returns>
        public List<StockItem> SearchByDescription(string search)
        {
            return db.Items.Where(i => i.Description.Contains(search)).ToList();
        }

        /// <summary>
        /// Search by article number.
        /// </summary>
        /// <param name="search">Search key</param>
        /// <returns>List of search results.</returns>
        public List<StockItem> SearchByArticleNo(string search)
        {
            return db.Items.Where(i => i.ArticleNumber == search).ToList();
        }

        /// <summary>
        /// Search by price.
        /// </summary>
        /// <param name="search">Search key</param>
        /// <returns>List of search results.</returns>
        public List<StockItem> SearchByPrice(decimal search)
        {
            return db.Items.Where(i => i.Price < search).ToList();
        }

        /// <summary>
        /// Search by product name or price lower than.
        /// </summary>
        /// <param name="search">Search key</param>
        /// <returns>List of search results.</returns>
        public List<StockItem> SearchByNameOrPrice(string search)
        {
            // Make sure price is lower than zero by default
            decimal price = -1;

            try
            {
                // Try parsing search string as a decimal
                price = decimal.Parse(search);
            }
            catch
            {
                // If search did not parse successfully as a decimal,
                // search by name
                return db.Items.Where(i => i.Name.Contains(search)).ToList();
            }

            // If search did parse successfully as a decimal, search by price
            return db.Items.Where(i => i.Price < price).ToList();
        }

        /// <summary>
        /// Edit an item in the database.
        /// </summary>
        /// <param name="item"></param>
        public void EditItem(StockItem item)
        {
            // Set object state to Modified
            db.Entry(item).State = EntityState.Modified;

            // Commit actual changes
            db.SaveChanges();
        }

        /// <summary>
        /// Add item object to the database.
        /// </summary>
        /// <param name="item">Item object to add</param>
        public void AddItem(StockItem item)
        {
            // Set object state as Added
            db.Entry(item).State = EntityState.Added;

            // Commit actual changes
            db.SaveChanges();
        }

        /// <summary>
        /// Add item to the database.
        /// </summary>
        /// <param name="articleNumber">Article number</param>
        /// <param name="name">Product name</param>
        /// <param name="category">Product category</param>
        /// <param name="price">Price</param>
        /// <param name="shelfPosition">Shelf position in storage</param>
        /// <param name="quantity">Available quantity</param>
        /// <param name="description">Product description</param>
        public void AddItem(string articleNumber, string name, ProductCategory category, decimal price, string shelfPosition, int quantity, string description)
        {
            db.Items.Add(
                new StockItem
                {
                    ArticleNumber = articleNumber,
                    Name = name,
                    Category = category,
                    Price = price,
                    ShelfPosition = shelfPosition,
                    Quantity = quantity,
                    Description = description
                }
            );
        }

        /// <summary>
        /// Remove item from database using Entity States.
        /// </summary>
        /// <param name="id">Id of item i nthe database</param>
        public void RemoveItem(int id)
        {
            // Set object state to deleted
            db.Entry(db.Items.Where(i => i.Id == id).FirstOrDefault()).State = EntityState.Deleted;
            
            // Commit actual delete
            db.SaveChanges();
        }
        #endregion
    }
}