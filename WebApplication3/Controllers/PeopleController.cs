using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class PeopleController : Controller
    {
        // GET: People
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

        [HttpPost]
        public ActionResult Delete(int id)
        {
            PersonManager mgr = new PersonManager(Properties.Settings.Default.ConStr);
            mgr.DeletePerson(id);
            return Redirect("/home");
        }

        public ActionResult Edit(int id)
        {
            PersonManager mgr = new PersonManager(Properties.Settings.Default.ConStr);
            PeopleViewModel vm = new PeopleViewModel();
            vm.Person = mgr.GetPerson(id);
            return View(vm);
        }

        [HttpPost]
        public ActionResult UpdatePerson(int id, string firstName, string lastName, int age)
        {
            PersonManager mgr = new PersonManager(Properties.Settings.Default.ConStr);
            mgr.UpdatePerson(id, firstName, lastName, age);
            return Redirect("/home");
        }
    }
}