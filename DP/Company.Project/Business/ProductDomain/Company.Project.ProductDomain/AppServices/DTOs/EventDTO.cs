using Company.Project.ProductDomain.Data.DBContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Project.ProductDomain.DTO
{
    /// <summary>
    /// DTO for events of Reading Event
    /// </summary>
   public  class EventDTO
    {
        /// <summary>
        /// get or set the Date of the event
        /// </summary>
        public DateTime DateOfEvent { get; set; }
        public string Title { get; set; }
        public string EventLocation { get; set; }
        public int EventType { get; set; }
        public TimeSpan StartTime { get; set; }
        public int Duration { get; set; }
        public string EventDescription { get; set; }
        public string Otherdetails { get; set; }
        public int IsDelete { get; set; }
        public string InviteUsers { get; set; }
        public int Eventid { get; set; }
        public string Creator { get; set; }

        public virtual ICollection<Comments> Comments { get; set; }
        public virtual ICollection<InviteUser> InviteUser { get; set; }
    }
}
