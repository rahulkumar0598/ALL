using Company.Project.Core.AppServices;
using Company.Project.Core.ValueObjects;
using Company.Project.ProductDomain.AppServices.DTOs;
using Company.Project.ProductDomain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Project.ProductDomain.AppServices
{
    public interface IEventAppService : IAppService
    {
        OperationResult<EventDTO> Create(EventDTO item);
        List<EventDTO> MyEvents(string email);
        //void UpdateEvent(EventDTO newEvent);


    }
}
