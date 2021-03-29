using Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Mvc.Controllers
{
    public class CustomersController : Controller
    {
        
        // GET: Customers
        public ActionResult Index()
        {
            IEnumerable<mvcCustomerModel> customerList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Customers").Result;
            customerList = response.Content.ReadAsAsync<IEnumerable<mvcCustomerModel>>().Result;
            return View(customerList);
        }
      
        public ActionResult AddOrEdit(int id = 0)
        {
            if(id == 0)
            return View(new mvcCustomerModel());
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Customers/"+id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcCustomerModel>().Result);
            }
        }
        [HttpPost]
        public ActionResult AddOrEdit(mvcCustomerModel customer)
        {
            if(customer.CustID == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Customers", customer).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Customers/" + customer.CustID.ToString(), customer).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Customers/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}