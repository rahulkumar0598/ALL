using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Project.Web.Models
{
    /// <summary>
    /// Implements Domain Logic by handling the data passed between the database and UI
    /// Model for Login purpose
    /// </summary>
    public class UserLoginModel
    {
        
        public string Email { get; set; }
        public string UserPassword { get; set; }
    }
}
