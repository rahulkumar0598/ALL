using Company.Project.ProductDomain.AppServices.DTOs;
//using Company.Project.ProductDomain.Business.ProductDomain.Company.Project.ProductDomain.Data.DBContext;
using Company.Project.ProductDomain.Data.DBContext;
using Company.Project.ProductDomain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Project.ProductDomain.Repository
{
    /// <summary>
    /// Interface for event repository
    /// </summary>
    public interface IEventRepository
    {
        void CreateEvent(Events itemEvent);
        List<Events> MyEvents(string email);
       // void UpdateEvent(EventDTO eventDetails);



    }
}
