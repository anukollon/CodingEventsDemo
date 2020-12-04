using CodingEventsDemo.Data;
using CodingEventsDemo.Models;
using CodingEventsDemo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEventsDemo.Controllers
{
    public class EventCategoryController:Controller
    {
        private EventDbContext context;

        public EventCategoryController(EventDbContext dbContext)
        {
            context = dbContext;
        }
        public IActionResult Index()
        {
            //List<Event> events = new List<Event>(EventData.GetAll());
            List<EventCategory> eventCategories = context.EventCategories.ToList();
            return View(eventCategories);
        }

        public IActionResult Create()
        {
            AddEventCategoryViewModel addEventCategoryViewModel = new AddEventCategoryViewModel();

            return View(addEventCategoryViewModel);
        }
        [HttpPost]
        [Route("/EventCategory/Create")]
        public IActionResult ProcessEventCategoryForm(AddEventCategoryViewModel addEventCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                EventCategory newCategory = new EventCategory
                {
                    Name = addEventCategoryViewModel.Name,
                };

                // EventData.Add(newEvent);
                context.EventCategories.Add(newCategory);
                context.SaveChanges();

                return Redirect("/EventCategory");
            }

            return View(addEventCategoryViewModel);
        }
    }
}
