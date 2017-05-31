using System.Collections.Generic;
using System.Web.Mvc;
using WarehouseMVC.Models;
using WarehouseMVC.Repositories;

namespace WarehouseMVC.Controllers
{
    public class StoreController : Controller
    {
        // Create instance of repository
        private StoreRepository store = new StoreRepository();
        
        // GET: Store/Index
        public ActionResult Index(string option, string search)
        {
            // Handle radio button options for search
            if(option == "Name")
            {
                return View(store.SearchByName(search));
            }
            else if(option == "ArticleNo")
            {
                return View(store.SearchByArticleNo(search));
            }
            else if(option == "Price")
            {
                try
                {
                    return View(store.SearchByPrice(decimal.Parse(search)));
                }
                catch
                {
                    // Return empty list if search was not successfully parsed
                    // to a decimal, which means numbers where not entered
                    return View(new List<StockItem>());
                }
            }
            return View(store.GetAllItems());
        }

        // GET: Store/Details
        public ActionResult Details(int id)
        {
            if(store.GetItem(id) != null)
            {
                return View(store.GetItem(id));
            }

            return RedirectToAction("Index", "Store");
        }

        // GET: Shop/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Shop/Create
        [HttpPost]
        public ActionResult Create(StockItem item)
        {
            store.AddItem(item);
            return RedirectToAction("Index");
        }

        // GET: Store/Edit
        public ActionResult Edit(int id)
        {
            if (store.GetItem(id) != null)
            {
                return View(store.GetItem(id));
            }

            return RedirectToAction("Index");
        }

        // POST: Store/Edit
        [HttpPost]
        public ActionResult Edit(Models.StockItem item)
        {
            store.EditItem(item);
            return RedirectToAction("Index");
        }

        // GET: Store/Delete
        public ActionResult Delete(int id)
        {
            store.RemoveItem(id);
            return RedirectToAction("Index");
        }

        // GET: Store/About
        public ActionResult About()
        {
            return View();
        }

        // GET: Store/Contact
        public ActionResult Contact()
        {
            return View();
        }
    }
}