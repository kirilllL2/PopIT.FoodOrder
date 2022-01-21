using System;
using System.Threading.Tasks;
using FoodOrder.Application.Orders.Commands.CompleteOrder;
using FoodOrder.Application.Orders.Commands.CreateOrder;
using FoodOrder.Application.Orders.Queries.GetOrderDetails;
using FoodOrder.Application.Orders.Queries.GetOrderList;
using FoodOrder.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrder.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class OrderController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<OrderListVm>> GetAllOrders()
        {
            var query = new GetOrderListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderListVm>> GetOrderById(Guid id)
        {
            var query = new GetOrderDetailsQuery
            {
                Id = id,
                UserId = UserId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateOrder(CreateOrderDto createOrderDto)
        {
            var command = Mapper.Map<CreateOrderCommand>(createOrderDto);
            command.UserId = UserId;
            var orderId = await Mediator.Send(command);
            return Ok(orderId);
        }
        
        [HttpPut("{id}/completed")]
        public async Task<ActionResult<Guid>> CreateOrder(Guid id)
        {
            var command = new CompleteOrderCommand()
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}