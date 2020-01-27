using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using UsersRepoWebAPI_MVCApp.Models;

namespace UsersRepoWebAPI_MVCApp.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            IEnumerable<mvcUsersModel> usersList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Users").Result;
            usersList = response.Content.ReadAsAsync<IEnumerable<mvcUsersModel>>().Result;
            return View(usersList);
        }
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new mvcUsersModel());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Users/"+id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcUsersModel>().Result);
            }
        }
        [HttpPost]
        public ActionResult AddOrEdit(mvcUsersModel user)
        {
            if (user.id == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Users", user).Result;
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Users/"+user.id, user).Result;
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Users/"+id.ToString()).Result;
            return RedirectToAction("Index");
        }
    }
}