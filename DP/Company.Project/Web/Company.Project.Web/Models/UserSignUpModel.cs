using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Project.Web.Models
{
    /// <summary>
    /// Implements Domain Logic by handling the data passed between the database and UI
    /// Model for Signing Up new users
    /// </summary>
    public class UserSignUpModel
    {
        
        public string Email { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public int IsDelete { get; set; }
        public string Usertype { get; set; }
    }
}
