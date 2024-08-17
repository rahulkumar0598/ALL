using AutoMapper;
using Company.Project.Core.ValueObjects;
using Company.Project.ProductDomain.AppServices;
using Company.Project.ProductDomain.AppServices.DTOs;
using Company.Project.ProductDomain.DTO;
using Company.Project.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Project.Web.Controllers
{
    /// <summary>
    /// Controller for Login of Users in Reading Event Website to access personalized contents
    /// </summary>
    public class LoginUser : Controller
    {
        private IMapper mapper;
        private ILoginUserAppService loginCreate;
        /// <summary>
        /// Dependency Injection
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="loginCreate"></param>
        public LoginUser(IMapper mapper, ILoginUserAppService loginCreate)
        {
            this.mapper = mapper;
            this.loginCreate = loginCreate;
        }

        /// <summary>
        /// VChecking whether the Login is valid or not
        /// </summary>
        /// <param name="isSucess"></param>
        /// <returns></returns>
        public IActionResult LoginPage(bool isSucess = false)
        {
            ViewBag.IsSucess = isSucess;
            return View();
        }
        [HttpPost]
        public IActionResult LoginPage(UserLoginModel LoginTheUser)
        {
            //For admin to access any user's content
            UserLoginDTO newUser = mapper.Map<UserLoginModel, UserLoginDTO>(LoginTheUser);
            if (newUser.Email == "myadmin@bookevents.com" && newUser.UserPassword == "admin")
            {
                HttpContext.Session.SetString("Email", newUser.Email);
                return RedirectToAction();
            }
            bool user = loginCreate.Create(newUser);
            if (user == true)
            {
                HttpContext.Session.SetString("Email", newUser.Email);
                return RedirectToAction("Event", "BookEvent");
            }
            else
            {
                ViewBag.IsSucess = true;
                return View();
            }
            

        }

        /// <summary>
        /// action method for Logging out of the website redirecting to main page
        /// </summary>
        /// <returns></returns>
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("NewIndex", "Home");
        }
    }
}
