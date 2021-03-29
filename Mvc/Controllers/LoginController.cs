using Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            //var model = new Admin();
            //var users = GetAllUsers();
            //model.User = GetSelectListItems(users);
            var list = new List<string>() { "Admin", "Customer" };
            ViewBag.list = list;
            return View();
        }

        [HttpPost]
        public ActionResult Authorize(Mvc.Models.Admin adminModel)
        {
            using (LoginDataBaseEntities db = new LoginDataBaseEntities())
            {
                //customerModel.Email = "liammiller@gmail.com";
                //customerModel.Password = "Liammiller@123";

                var valueCheck = adminModel.UserCheck;
                var emailCheck = adminModel.AdminEmail;
                var passwordCheck = adminModel.AdminPassword;

                if(valueCheck == "Admin")
                {
                    var adminDetails = db.Admins.Where(x => x.AdminEmail == adminModel.AdminEmail && x.AdminPassword == adminModel.AdminPassword).FirstOrDefault();

                    bool answer = adminDetails == null ? true : false;

                    if (adminDetails == null)
                    {
                        adminModel.LoginErrorMessage = "Wrong username or password.";
                        return View("Index", adminModel);
                    }

                    else
                    {
                        Session["adminId"] = adminDetails.AdminId;
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    var customerDetails = db.Customers.Where(x => x.Email == adminModel.AdminEmail && x.Password == adminModel.AdminPassword).FirstOrDefault();

                    bool answer = customerDetails == null ? true : false;

                    if (customerDetails == null)
                    {
                        adminModel.LoginErrorMessage = "Wrong username or password.";
                        return View("Index", adminModel);
                    }

                    else
                    {
                        Session["customerId"] = customerDetails.CustID;
                        return RedirectToAction("Index", "Order");
                    }
                }
            }

        }

        public ActionResult LogOut()
        {
            Session["adminId"] = null;
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public ActionResult Test(Admin admin)
        {
            if(ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            var list = new List<string>() { "Admin", "Customer" };
            ViewBag.list = list;
            return View();
        }

    }
}