using System;
using System.Collections.Generic;

namespace Company.Project.ProductDomain.DBContext
{
    public partial class Comments
    {
        public int CommentNo { get; set; }
        public int? EventId { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }
        public int? IsDelete { get; set; }
        public DateTime? CommentDateTime { get; set; }
    }
}
