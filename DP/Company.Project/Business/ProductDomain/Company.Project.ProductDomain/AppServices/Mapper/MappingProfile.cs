using AutoMapper;
using Company.Project.ProductDomain.AppServices.DTOs;
using Company.Project.ProductDomain.Data.DBContext;
//using Company.Project.ProductDomain.Business.ProductDomain.Company.Project.ProductDomain.Data.DBContext;
using Company.Project.ProductDomain.Domain;
using Company.Project.ProductDomain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Project.ProductDomain.AppServices.Mapper
{
    /// <summary>
    /// Mapping Profile
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Mapping of DTO to data from DBContext
        /// </summary>
        public MappingProfile() : base("MappingProfile")
        {
            CreateMap<ProductDTO, Product>().ReverseMap();
            CreateMap<EventDTO, Events>().ReverseMap();
            CreateMap<UserSignUpDTO, Users>().ReverseMap();
        }
    }
}
