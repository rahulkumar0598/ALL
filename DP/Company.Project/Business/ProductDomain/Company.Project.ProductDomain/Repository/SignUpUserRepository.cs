//using Company.Project.ProductDomain.Business.ProductDomain.Company.Project.ProductDomain.Data.DBContext;
using Company.Project.ProductDomain.Data.DBContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Project.ProductDomain.Repository
{
    public class SignUpUserRepository : ISignUpUserRepository
    {
        private BooksContext objBooksContext;
        public SignUpUserRepository(BooksContext objBooksContext)
        {
            this.objBooksContext = objBooksContext;
        }
        /// <summary>
        /// Storing the data of new user
        /// </summary>
        /// <param name="itemUser"></param>
        public void CreateUser(Users itemUser)
        {
            itemUser.Usertype = "2800";
            objBooksContext.Users.Add(itemUser);
            objBooksContext.SaveChanges();
        }
    }
}
