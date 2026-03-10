using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            PersonManager mgr = new PersonManager(Properties.Settings.Default.ConStr);
            PeopleViewModel vm = new PeopleViewModel();
            vm.People = mgr.GetPeople();
            return View(vm);
        }

        public ActionResult AddPerson()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(string firstName, string lastName, int age)
        {
            PersonManager mgr = new PersonManager(Properties.Settings.Default.ConStr);
            mgr.AddPerson(firstName, lastName, age);

            return Redirect("/home");
        }
    }
}