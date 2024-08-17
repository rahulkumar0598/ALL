using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Project.ProductDomain.DTO
{
    /// <summary>
    /// DTO for Signing Up of new Users
    /// </summary>
    public class UserSignUpDTO
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public int IsDelete { get; set; }
        public string Usertype { get; set; }
    }
}
