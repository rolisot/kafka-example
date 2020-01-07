using AutoMapper;
using Kafka.Domain.Contracts;
using Kafka.Domain.Entities;

namespace Kafka.Producer.API.Mapping
{
    public class RequestToDomainProfile : Profile
    {
        public RequestToDomainProfile()
        {
            
            CreateMap<OrderContract, Order>();
            CreateMap<OrderItemContract, OrderItem>();
        }
    }
}