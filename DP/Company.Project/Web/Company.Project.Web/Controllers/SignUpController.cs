using AutoMapper;
using Company.Project.ProductDomain.AppServices;
using Company.Project.ProductDomain.AppServices.DTOs;
using Company.Project.ProductDomain.DTO;
using Company.Project.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Project.Web.Controllers
{
    /// <summary>
    /// controller for registering new user 
    /// </summary>
    public class SignUp : Controller
    {
        private IMapper mapper;
        private ISignUpUserAppService signUpInterface;
        public IActionResult SignUpPage()
        {
            return View();
        }
        public SignUp(IMapper mapper, ISignUpUserAppService signUpInterface)
        {
            this.mapper = mapper;
            this.signUpInterface = signUpInterface;
        }

        /// <summary>
        /// Getting details and storing in database using mapping
        /// </summary>
        /// <param name="SignUpTheUser"></param>
        /// <returns></returns>
        public IActionResult SignUpDetails(UserSignUpModel SignUpTheUser)
        {
            UserSignUpDTO newUser = mapper.Map<UserSignUpModel, UserSignUpDTO>(SignUpTheUser);
            signUpInterface.Create(newUser);

            return View("SignUp");
        }
    }
}
