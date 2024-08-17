using AutoMapper;
using Company.Project.ProductDomain.AppServices;
using Company.Project.ProductDomain.AppServices.DTOs;
using Company.Project.ProductDomain.DTO;
using Company.Project.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Project.Web.Controllers
{
    /// <summary>
    /// Controller for controlling all the events taking place in the book reading events like creating, displaying events
    /// </summary>
    public class BookEventController : Controller
    {
        /// <summary>
        /// For mapping purpose
        /// </summary>
        private IMapper mapper;
        private IEventAppService eventInterface;

        /// <summary>
        /// Dependency injection 
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="eventinterface"></param>
        public BookEventController(IMapper mapper, IEventAppService eventinterface)
        {
            this.mapper = mapper;
            this.eventInterface = eventinterface;
        }

        /// <summary>
        /// Calling Views
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateEvent()
        {
            return View();
        }

        /// <summary>
        /// post method for transferring data and mapping of DTO with model
        /// </summary>
        /// <param name="EventForBook"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateEvent(BookEventModel EventForBook)
        {
            EventForBook.Creator = HttpContext.Session.GetString("EmailId");
            EventDTO newEvent = mapper.Map<BookEventModel, EventDTO>(EventForBook);
            eventInterface.Create(newEvent);
            return View("CreateEventmsg");
        }
        [HttpPost]
       /* public IActionResult EditEvent(BookEventModel editBook)
        {
            EventDTO newEvent = new EventDTO();
            newEvent.Title = editBook.Title;
            newEvent.DateOfEvent = editBook.DateOfEvent;
            newEvent.Eventid = int.Parse(HttpContext.Session.GetString("Eventid"));
            eventInterface.UpdateEvent(newEvent);
            return View();

        }*/
        public IActionResult MyEvents(BookEventModel EventForBook)
        {
            ViewBag.emailId = HttpContext.Session.GetString("EmailId");
            ViewBag.MyEvents = ListAllEvents();
            return View();
        }
        /// <summary>
        /// Listing all the events stored in database
        /// </summary>
        /// <returns></returns>
        public List<BookEventModel> ListAllEvents()
        {
            List<BookEventModel> result = new List<BookEventModel>();
            var email = HttpContext.Session.GetString("EmailId");
            List<EventDTO> store = eventInterface.MyEvents(email);
            foreach (var x in store)
            {
                BookEventModel showEvent = new BookEventModel();
                showEvent.DateOfEvent = x.DateOfEvent;
                showEvent.EventDescription = x.EventDescription;
                showEvent.Duration = x.Duration;
                showEvent.InviteUsers = x.InviteUsers;
                showEvent.EventLocation = x.EventLocation;
                showEvent.Otherdetails = x.Otherdetails;
                showEvent.StartTime = x.StartTime;
                showEvent.Title = x.Title;
                showEvent.EventType = x.EventType;
                showEvent.Eventid = x.Eventid;
                result.Add(showEvent);
            }
            return result;

        }

     

        public IActionResult Event()
        {
            return View();
        }
        public IActionResult PastEvents()
        {
            ViewBag.PastEvents = ListAllEvents();
            return View();
        }
        public IActionResult UpcomingEvents()
        {
            ViewBag.UpComingEvents = ListAllEvents();
            return View();
        }


    }
}
