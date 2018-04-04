using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lab11.Model;

namespace Lab11.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(int startYear, int endYear)
        {
            //Redirects to the result method and passes an anon object with two ints
            return RedirectToAction("Results", new { startYear, endYear });
        }

        public IActionResult Results(int startYear, int endYear)
        {
            TimePerson person = new TimePerson();

            return View(person.GetPersons(startYear, endYear));
        }
    }
}
