using AutoMapper;
using Company.Project.Core.AppServices;
using Company.Project.Core.ValueObjects;
using Company.Project.ProductDomain.AppServices.DTOs;
//using Company.Project.ProductDomain.Business.ProductDomain.Company.Project.ProductDomain.Data.DBContext;
using Company.Project.ProductDomain.Data.DBContext;
using Company.Project.ProductDomain.DTO;
using Company.Project.ProductDomain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Project.ProductDomain.AppServices
{
    public class SignUpUserAppService : AppService, ISignUpUserAppService
    {
        private IMapper mapper;
        private ISignUpUserRepository signUpRepo;
        public SignUpUserAppService(IMapper mapper, ISignUpUserRepository signUpRepo)
        {
            this.mapper = mapper;
            this.signUpRepo = signUpRepo;
        }
        public OperationResult<UserSignUpDTO> Create(UserSignUpDTO item)
        {
            Users newUser = mapper.Map<UserSignUpDTO, Users>(item);
            signUpRepo.CreateUser(newUser);
            return null;
        }
    }
}
