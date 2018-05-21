using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lecture.DAL;
using Lecture.Models;

namespace Lecture.Controllers
{
    public class PersonController : Controller
    {
        private IStorage _storage;

        public PersonController(IStorage storage)
        {
            _storage = storage;
        }
        // GET: Person
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Index(string search = null)
        {
            List<Person> list;

            if (!String.IsNullOrEmpty(search))
            {
                list =  _storage.Persons.Where(p => p.FirstName.IndexOf(search) != -1 || p.LastName.IndexOf(search) != -1).ToList<Person>();
            }
            else
            {
                list = _storage.Persons;
            }
           

            return View(list);
        }

        // GET: Person/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Person/Create
        [HttpPost]
        public ActionResult Create(Person p)
        {
            try
            {
                _storage.Add(p);

                return RedirectToRoute(new
                {
                    controller = "Person",
                    action = "Index"

                });

            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Edit/5
        public PartialViewResult Edit(int id)
        {
            return PartialView( _storage.Get(id));
        }

        // POST: Person/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Person p)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _storage.Edit(id, p);
                }
                else
                {
                    return PartialView("Edit", p);
                }
                return Json(new { redirectTo = Url.Action("Index") });

            }
            catch
            {
                return PartialView(p);
            }
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Person/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
