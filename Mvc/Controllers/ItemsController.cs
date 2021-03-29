using Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Mvc.Controllers
{
    public class ItemsController : Controller
    {
        // GET: Items
        public ActionResult Index()
        {
            IEnumerable<mvcItemModel> itemList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Items").Result;
            itemList = response.Content.ReadAsAsync<IEnumerable<mvcItemModel>>().Result;
            return View(itemList);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new mvcItemModel());
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Items/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcItemModel>().Result);
            }
        }
        [HttpPost]
        public ActionResult AddOrEdit(mvcItemModel item)
        {
            if (item.ItemId == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Items", item).Result;
                TempData["SuccessMessage"] = "New Item Saved Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Items/" + item.ItemId.ToString(), item).Result;
                TempData["SuccessMessage"] = "Item Updated Successfully";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Items/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Item Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}