using System;
using System.Collections.Generic;

namespace Company.Project.ProductDomain.Data.DBContext
{
    public partial class Users
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public int IsDelete { get; set; }
        public string Usertype { get; set; }
    }
}
