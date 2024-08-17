using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Project.ProductDomain.DTO
{
    /// <summary>
    /// DTO for login of registered user
    /// </summary>
    public class UserLoginDTO
    {
        public string Email { get; set; }
        public string UserPassword { get; set; }
    }
}
