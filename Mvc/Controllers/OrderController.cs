using Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Mvc.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            IEnumerable<mvcItemModel> itemList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Items").Result;
            itemList = response.Content.ReadAsAsync<IEnumerable<mvcItemModel>>().Result;
            return View(itemList);
        }

        public ActionResult AddToCart()
        {
            return View();
        }
    }
}