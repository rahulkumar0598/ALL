using AutoMapper;
using Company.Project.ProductDomain.AppServices.DTOs;
using Company.Project.ProductDomain.DTO;
using Company.Project.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Project.Web.Mapper
{
    public class WebMappingProfile : Profile
    {
        /// <summary>
        /// Mapping and reverse mapping of model to Dto for smooth transfer of data between layers 
        /// </summary>
        public WebMappingProfile() : base("WebMappingProfile")
        {
            CreateMap<ProductViewModel, ProductDTO>().ReverseMap();
            CreateMap<BookEventModel, EventDTO>().ReverseMap();
            CreateMap<UserLoginModel, UserLoginDTO>().ReverseMap();
            CreateMap<UserSignUpModel, UserSignUpDTO>().ReverseMap();
        }
    }
}
