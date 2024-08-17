using AutoMapper;
using Company.Project.Core.AppServices;
using Company.Project.Core.ValueObjects;
using Company.Project.ProductDomain.Data.DBContext;
using Company.Project.ProductDomain.DTO;
using Company.Project.ProductDomain.Repository;
using System;
using System.Collections.Generic;

namespace Company.Project.ProductDomain.AppServices
{
    
    public class EventAppService : AppService, IEventAppService
    {
        private IMapper mapper;
        private IEventRepository eventRepository;
        /// <summary>
        /// Dependency Injection
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="eventRepository"></param>
        public EventAppService(IMapper mapper, IEventRepository eventRepository)
        {
            this.mapper = mapper;
            this.eventRepository = eventRepository;
        }
        public OperationResult<EventDTO> Create(EventDTO item)
        {
            Events newEvent = mapper.Map<EventDTO, Events>(item);
            eventRepository.CreateEvent(newEvent);
            return null;
        }
        public List<EventDTO> MyEvents(string email)
        {
            var response= eventRepository.MyEvents(email);
            var result = mapper.Map<List<Events>,List< EventDTO >> (response);
            return result;
        }
        /*public void UpdateEvent(EventDTO newEvent)
        {
            EventRepository.UpdateEvent(newEvent);
        }*/
    }
}
