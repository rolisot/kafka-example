using System.Threading.Tasks;
using AutoMapper;
using Kafka.Domain.Contracts;
using Kafka.Domain.Entities;
using Kafka.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kafka.Producer.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProducerController : ControllerBase
    {
        private readonly IOrderProducerService OrderService;

        private readonly IMapper Mapper;

        public ProducerController(IOrderProducerService orderService, IMapper mapper)
        {
            OrderService = orderService;
            Mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(typeof(string), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Post([FromBody] OrderContract contract)
        {
            var order = Mapper.Map<Order>(contract);
            return Created("", await OrderService.AddOrder(order));
        }
    }
}