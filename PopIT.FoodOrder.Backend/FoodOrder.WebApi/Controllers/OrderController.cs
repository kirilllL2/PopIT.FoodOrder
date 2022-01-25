using System;
using System.Threading.Tasks;
using FoodOrder.Application.Orders.Commands.CompleteOrder;
using FoodOrder.Application.Orders.Commands.CreateOrder;
using FoodOrder.Application.Orders.Queries.GetOrderDetails;
using FoodOrder.Application.Orders.Queries.GetOrderList;
using FoodOrder.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrder.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/{version:apiVersion}/[controller]")]
    public class OrderController : BaseController
    {
        /// <summary>
        /// Gets the list of orders
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /orders
        /// </remarks>
        /// <returns>Returns OrdersListVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<OrderListVm>> GetAllOrders()
        {
            var query = new GetOrderListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the order by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /order/D34D349E-43B8-429E-BCA4-793C932FD580
        /// </remarks>
        /// <param name="id">Order id (guid)</param>
        /// <returns>Returns OrderDetailsVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpGet("{id}", Name = "GetOrderById")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<OrderDetailsVm>> GetOrderById(Guid id)
        {
            var query = new GetOrderDetailsQuery
            {
                Id = id,
                UserId = UserId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Creates the order
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /order
        /// {
        ///     "BeverageId": "B48F5A9E-769D-45D8-9A77-346380E880FD",
        ///     "GarnishId": "AE9B8C14-3A86-435E-AA35-2EA2B3AC72E0",
        ///     "MeatId": "912C55EF-9BC8-42BA-8A06-2ABA9FC78415",
        ///     "SoupId": "0047821C-F667-42E6-9DEA-C268FC098EB4"
        /// }
        /// </remarks>
        /// <param name="createOrderDto">СreateOrderDto object</param>
        /// <returns>Returns id (guid)</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Guid>> CreateOrder(CreateOrderDto createOrderDto)
        {
            var command = Mapper.Map<CreateOrderCommand>(createOrderDto);
            command.UserId = UserId;
            var orderId = await Mediator.Send(command);
            return Ok(orderId);
        }


        /// <summary>
        /// Marks the order as completed
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /order/88DEB432-062F-43DE-8DCD-8B6EF79073D3/complete
        /// </remarks>
        /// <param name="id">Order id (guid)</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpPut("{id}/complete")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Guid>> CompletedOrder(Guid id)
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