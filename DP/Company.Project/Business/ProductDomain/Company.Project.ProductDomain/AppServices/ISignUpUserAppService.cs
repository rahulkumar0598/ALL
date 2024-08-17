using Company.Project.Core.ValueObjects;
using Company.Project.ProductDomain.AppServices.DTOs;
using Company.Project.ProductDomain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Project.ProductDomain.AppServices
{
    public interface ISignUpUserAppService
    {
        OperationResult<UserSignUpDTO> Create(UserSignUpDTO item);
    }
}
