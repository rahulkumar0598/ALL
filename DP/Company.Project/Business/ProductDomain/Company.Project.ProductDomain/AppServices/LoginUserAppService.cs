using AutoMapper;
using Company.Project.Core.AppServices;
using Company.Project.Core.ValueObjects;
using Company.Project.ProductDomain.AppServices.DTOs;
using Company.Project.ProductDomain.DTO;
using Company.Project.ProductDomain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Project.ProductDomain.AppServices
{
    public class LoginUserAppService : AppService, ILoginUserAppService
    {
        private IMapper mapper;
        private ILoginUserRepository loginrepo;
        public LoginUserAppService(IMapper mapper, ILoginUserRepository loginrepo)
        {
            this.mapper = mapper;
            this.loginrepo = loginrepo;
        }
        public bool Create(UserLoginDTO item)
        {
            bool result = loginrepo.LoginUser(item);
            return result;
        }
    }
}
