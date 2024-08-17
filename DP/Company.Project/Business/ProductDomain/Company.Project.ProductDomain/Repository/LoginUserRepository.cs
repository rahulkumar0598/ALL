using Company.Project.ProductDomain.Data.DBContext;
using Company.Project.ProductDomain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Company.Project.ProductDomain.Repository
{
   public  class LoginUserRepository:ILoginUserRepository
    {
        private BooksContext objBooksContext;
        public LoginUserRepository(BooksContext objBooksContext)
        {
            this.objBooksContext = objBooksContext;
        }
        /// <summary>
        /// Validation of Registered users
        /// </summary>
        /// <param name="UserDetails"></param>
        /// <returns></returns>
        public bool LoginUser(UserLoginDTO UserDetails)
        {
            var validOrNot = objBooksContext.Users.Where(x => x.Email == UserDetails.Email && x.UserPassword == UserDetails.UserPassword).FirstOrDefault();
            if (validOrNot != null)
                return true;
            else
                return false;

        }
    }
}
