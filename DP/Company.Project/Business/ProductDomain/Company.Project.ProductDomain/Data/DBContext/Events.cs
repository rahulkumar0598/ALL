using System;
using System.Collections.Generic;

namespace Company.Project.ProductDomain.Data.DBContext
{
    public partial class Events
    {
        public Events()
        {
            Comments = new HashSet<Comments>();
            InviteUser = new HashSet<InviteUser>();
        }

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
