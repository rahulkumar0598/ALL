//using Company.Project.ProductDomain.Business.ProductDomain.Company.Project.ProductDomain.Data.DBContext;
using Company.Project.ProductDomain.Data.DBContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Project.ProductDomain.Repository
{
    public interface ISignUpUserRepository
    {
        void CreateUser(Users itemUser);
    }
}
