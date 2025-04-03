//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using TicketBooking.Application.DTOs;
//using TicketBooking.Application.Interface;
//using TicketBooking.Demo;

//namespace TicketBooking.Application.Services
//{
//    public class EventService
//    {
//        private readonly IEventRepository _eventRepository;
//        private readonly IEventCategoryRepository _eventCategoryRepository;

//        public EventService(IEventRepository eventRepository, IEventCategoryRepository eventCategoryRepository)
//        {
//            _eventRepository = eventRepository;
//            _eventCategoryRepository = eventCategoryRepository;
//        }

//        // Add a new event (resolving EventCategoryId from EventCategoryName)
//        public async Task<EventDto> AddEvent(CreateEventDto createEventDto)
//        {
//            // Resolve EventCategoryId
//            var category = await _eventCategoryRepository.GetEventCategoryByName(createEventDto.EventCategoryName);
//            if (category == null)
//            {
//                throw new KeyNotFoundException($"Event category '{createEventDto.EventCategoryName}' not found.");
//            }

//            // Map CreateEventDto to Event entity
//            var eventEntity = new Event
//            {
//                Name = createEventDto.Name,
//                Description = createEventDto.Description,
//                Date = createEventDto.Date,
//                Venue = createEventDto.Venue,
//                AvailableSeats = createEventDto.AvailableSeats,
//                Price = createEventDto.Price,
//                EventCategoryId = category.Id
//            };

//            // Save to the database
//            var createdEvent = await _eventRepository.AddEvent(eventEntity);

//            // Map back to EventDto
//            return new EventDto
//            {
//                Id = createdEvent.Id,
//                Name = createdEvent.Name,
//                Description = createdEvent.Description,
//                Date = createdEvent.Date,
//                Venue = createdEvent.Venue,
//                AvailableSeats = createdEvent.AvailableSeats,
//                Price = createdEvent.Price,
//                EventCategoryName = category.EventCategoryName
//            };
//        }

//        public async Task<EventDto> UpdateEvent(int id, CreateEventDto createEventDto)
//        {
//            // Fetch the existing event by ID
//            var eventEntity = await _eventRepository.GetEventById(id);
//            if (eventEntity == null) return null;

//            // Resolve EventCategoryId only if EventCategoryName is provided
//            if (!string.IsNullOrWhiteSpace(createEventDto.EventCategoryName))
//            {
//                var category = await _eventCategoryRepository.GetEventCategoryByName(createEventDto.EventCategoryName);
//                if (category == null)
//                {
//                    throw new KeyNotFoundException($"Event category '{createEventDto.EventCategoryName}' not found.");
//                }
//                eventEntity.EventCategoryId = category.Id; // Update EventCategoryId
//            }

//            // Update fields only if they are provided in CreateEventDto
//            if (!string.IsNullOrWhiteSpace(createEventDto.Name))
//                eventEntity.Name = createEventDto.Name;

//            if (!string.IsNullOrWhiteSpace(createEventDto.Description))
//                eventEntity.Description = createEventDto.Description;

//            if (createEventDto.Date != default)
//                eventEntity.Date = createEventDto.Date;

//            if (!string.IsNullOrWhiteSpace(createEventDto.Venue))
//                eventEntity.Venue = createEventDto.Venue;

//            if (createEventDto.AvailableSeats > 0)
//                eventEntity.AvailableSeats = createEventDto.AvailableSeats;

//            if (createEventDto.Price > 0)
//                eventEntity.Price = createEventDto.Price;

//            // Save the updated entity
//            await _eventRepository.UpdateEvent(eventEntity);

//            // Fetch EventCategoryName for the updated entity
//            var eventCategory = await _eventCategoryRepository.GetEventCategoryById(eventEntity.EventCategoryId);

//            // Map to EventDto and return
//            return new EventDto
//            {
//                Id = eventEntity.Id,
//                Name = eventEntity.Name,
//                Description = eventEntity.Description,
//                Date = eventEntity.Date,
//                Venue = eventEntity.Venue,
//                AvailableSeats = eventEntity.AvailableSeats,
//                Price = eventEntity.Price,
//                EventCategoryName = eventCategory?.EventCategoryName
//            };
//        }


//        // Delete an event by ID
//        public async Task<bool> DeleteEvent(int id)
//        {
//            return await _eventRepository.DeleteEvent(id);
//        }

//        // Get a specific event by ID
//        public async Task<EventDto> GetEventById(int id)
//        {
//            var eventEntity = await _eventRepository.GetEventById(id);
//            if (eventEntity == null) return null;

//            var category = await _eventCategoryRepository.GetEventCategoryById(eventEntity.EventCategoryId);

//            return new EventDto
//            {
//                Id = eventEntity.Id,
//                Name = eventEntity.Name,
//                Description = eventEntity.Description,
//                Date = eventEntity.Date,
//                Venue = eventEntity.Venue,
//                AvailableSeats = eventEntity.AvailableSeats,
//                Price = eventEntity.Price,
//                EventCategoryName = category?.EventCategoryName
//            };
//        }

//        // Get all events
//        public async Task<IEnumerable<EventDto>> GetEvents()
//        {
//            var events = await _eventRepository.GetEvents();
//            var eventDtos = new List<EventDto>();

//            foreach (var eventEntity in events)
//            {
//                var category = await _eventCategoryRepository.GetEventCategoryById(eventEntity.EventCategoryId);
//                eventDtos.Add(new EventDto
//                {
//                    Id = eventEntity.Id,
//                    Name = eventEntity.Name,
//                    Description = eventEntity.Description,
//                    Date = eventEntity.Date,
//                    Venue = eventEntity.Venue,
//                    AvailableSeats = eventEntity.AvailableSeats,
//                    Price = eventEntity.Price,
//                    EventCategoryName = category?.EventCategoryName
//                });
//            }

//            return eventDtos;
//        }

//        // Get all event categories
//        public async Task<IEnumerable<EventCategoryDto>> GetEventCategories()
//        {
//            var categories = await _eventCategoryRepository.GetEventCategories();

//            return categories.Select(c => new EventCategoryDto
//            {
//                Id = c.Id,
//                Name = c.EventCategoryName
//            }).ToList();
//        }
//    }
//}
