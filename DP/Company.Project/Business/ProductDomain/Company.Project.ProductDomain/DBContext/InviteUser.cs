using System;
using System.Collections.Generic;

namespace Company.Project.ProductDomain.DBContext
{
    public partial class InviteUser
    {
        public int InviteId { get; set; }
        public int? EventId { get; set; }
        public string Email { get; set; }
        public int? IsDelete { get; set; }
    }
}
