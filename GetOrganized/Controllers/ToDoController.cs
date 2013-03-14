using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GetOrganized.Models;

namespace GetOrganized.Controllers
{
    public class ToDoController : Controller
    {
        //
        // GET: /ToDo/

        public ActionResult Index()
        {
            ViewData.Model = ToDo.ThingsToBeDone;
            return View();
        }

        //
        // GET: /ToDo/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /ToDo/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ToDo/Create

        [HttpPost]
        public ActionResult Create(ToDo toDo)
        {
            try
            {
                // TODO: Add insert logic here
                ToDo.ThingsToBeDone.Add(toDo);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /ToDo/Edit/5
 
        public ActionResult Edit(string title)
        {
            ViewData.Model = ToDo.ThingsToBeDone.Find(todo => todo.Title == title);
            return View();
        }

        //
        // POST: /ToDo/Edit/5

        [HttpPost]
        public ActionResult Edit(string oldTitle, ToDo item)
        {
            try
            {
                // TODO: Add update logic here
                ToDo.ThingsToBeDone.RemoveAll(aToDo => aToDo.Title == oldTitle);
                ToDo.ThingsToBeDone.Add(item);
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /ToDo/Delete/5
 
        public ActionResult Delete(string title)
        {
            ToDo.ThingsToBeDone.RemoveAll(todo => todo.Title == title);

            return RedirectToAction("Index");
        }

        //
        // POST: /ToDo/Delete/5

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
