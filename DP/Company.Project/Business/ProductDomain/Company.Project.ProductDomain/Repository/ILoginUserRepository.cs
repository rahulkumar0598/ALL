using Company.Project.ProductDomain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Project.ProductDomain.Repository
{
     public interface ILoginUserRepository
    {
        bool LoginUser(UserLoginDTO item);
    }
}
