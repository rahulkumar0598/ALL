using Company.Project.ProductDomain.Data.DBContext;
using Company.Project.ProductDomain.DTO;
using System.Collections.Generic;
using System.Linq;


namespace Company.Project.ProductDomain.Repository
{
    /// <summary>
    /// Repository for Event details
    /// </summary>
    public class EventRepository : IEventRepository
    {
        private BooksContext objBooksContext;
        public EventRepository(BooksContext objBooksContext)
        {
            this.objBooksContext = objBooksContext;
        }
        public void CreateEvent(Events itemEvent)
        {

            objBooksContext.Events.Add(itemEvent);
            objBooksContext.SaveChanges();
        }

        public List<Events> MyEvents(string email)
        {
            var response = objBooksContext.Events.Where(x => x.Creator.Equals(email)).ToList();
            // List<EventDTO> result = objBooksContext.Events.Select(x => new EventDTO()
            /* {
                 Eventid = x.Eventid,
                 Title = x.Title,
                 Duration = x.Duration,
                 EventDescription = x.EventDescription,
                 DateOfEvent = x.DateOfEvent,
                 EventLocation = x.EventLocation,
                 StartTime = x.StartTime,
                 EventType = x.EventType,
                 Otherdetails = x.Otherdetails,
                 InviteUsers = x.InviteUsers,
                 Creator = x.Creator
             }).ToList().Where(x => x.Creator.Equals(email)).ToList();*/
            return response;

        }
     /*   public void UpdateEvent(EventDTO editBook)
        {
            Events oldEvent = objBooksContext.Events.Find(editBook.Eventid);
            oldEvent.Title = editBook.Title;
            oldEvent.DateOfEvent = editBook.DateOfEvent;
            objBooksContext.SaveChanges();

        }*/



    }
}
