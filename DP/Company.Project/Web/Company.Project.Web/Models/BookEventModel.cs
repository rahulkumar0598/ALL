using Company.Project.ProductDomain.Data.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Project.Web.Models
{
    /// <summary>
    /// Implements Domain Logic by handling the data passed between the database and UI
    /// Model for Event Details
    /// </summary>
    public class BookEventModel
    {
       
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
