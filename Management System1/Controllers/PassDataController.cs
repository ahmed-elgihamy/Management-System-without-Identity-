using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;

namespace Management_System1.Controllers
{
    public class PassDataController : Controller
    {
        public IActionResult SetSessiton()
        {

            HttpContext.Session.SetString("name", "Ahmed Mahmoud");
            HttpContext.Session.SetInt32("age", 23);
            return Content("Save Data");
        }

        public IActionResult GetSessiton()
        {

            string name = HttpContext.Session.GetString("name");
            int? age = HttpContext.Session.GetInt32("age");
            return Content(name + " " + age);
        }

        public IActionResult SetCookies()
        {
            CookieOptions cop = new CookieOptions();
            cop.Expires = DateTimeOffset.Now.AddDays(1); 
            Response.Cookies.Append("name", "PD");
            Response.Cookies.Append("age", "23",cop);
            return Content("save cookies");
        }


        public IActionResult GetCookies()
        {
         string name =   Request.Cookies["name"];

            return Content(name);


        }

    }
}