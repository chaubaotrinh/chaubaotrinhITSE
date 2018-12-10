/* 
 * Student: Chau Trinh
 * Class: ITSE 1430
 * Lab 5: Event Planner
 * Date: 10 Dec 2018
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventPlanner.Memory;
using EventPlanner.Mvc.App_Start;
using EventPlanner.Mvc.Models;

namespace EventPlanner.Mvc.Controllers
{
    public class EventController : Controller
    {
        public EventController()
        {
            _database = DatabaseFactory.Database;
            
        }

        // GET: Event
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult My()
        {
            var criteria = new EventCriteria();
            criteria.IncludePrivate = true;
           
            var items = from i in _database.GetAll(criteria)
                        where i.IsPublic == false && i.EndDate >= DateTime.Today
                        orderby i.StartDate
                        select i;

            return View(items.Select(i => new model(i)));

        }

        [HttpGet]
        public ActionResult Public()
        {
            var criteria = new EventCriteria();
            criteria.IncludePublic = true;

            var items = from i in _database.GetAll(criteria)
                        where i.IsPublic == true && i.EndDate >= DateTime.Today
                        orderby i.StartDate
                        select i;

            return View(items.Select(i => new model(i)));
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var existing = _database.Get(id);
            if (existing == null)
                return HttpNotFound();

            return View(new model(existing));

        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new model();
            model.StartDate = DateTime.Today;
            model.EndDate = DateTime.Today;

            return View(model);
        }
        [HttpPost] 
        public ActionResult Create( model model )
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var item = model.ToDomain();

                    _database.Add(item);
                    if (item.IsPublic == true)
                        return RedirectToAction("Public");
                    else
                        return RedirectToAction("My");

                } catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                }
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Edit( int id )
        {
            var existing = _database.Get(id);
            if (existing == null)
                return HttpNotFound();
            
            return View(new model(existing));
        }
        [HttpPost]
        public ActionResult Edit( model model, EventCriteria criteria)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var item = model.ToDomain();
                    
                    var existing = _database.GetAll(criteria).FirstOrDefault(i => i.Id == model.Id);

                    _database.Update(model.Id, item);

                    if (item.IsPublic == true)
                        return RedirectToAction("Public");
                    else
                        return RedirectToAction("My");

                } catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                };
            };

            return View(model);
        }

        [HttpGet]
        public ActionResult Delete( int id) 
        {
            
            var existing = _database.Get(id);
            if (existing == null)
                return HttpNotFound();

            return View(new model(existing));
        }

        [HttpPost]
        public ActionResult Delete( model model, EventCriteria criteria )
        {
            try
            {
                var existing = _database.GetAll(criteria).FirstOrDefault(i => i.Id == model.Id);
             
                _database.Remove(model.Id);

                 if (model.IsPublic == true)
                    return RedirectToAction("Public");
                else
                    return RedirectToAction("My");

            } catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);  
            }

            return View(model);

        }


        private readonly IEventDatabase _database;
       

    }
}