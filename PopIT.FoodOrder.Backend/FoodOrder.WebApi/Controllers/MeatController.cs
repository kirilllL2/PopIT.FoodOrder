using System;
using System.Threading.Tasks;
using AutoMapper;
using FoodOrder.Application.Meats.Commands.CreateMeat;
using FoodOrder.Application.Meats.Commands.DeleteMeat;
using FoodOrder.Application.Meats.Commands.UpdateMeat;
using FoodOrder.Application.Meats.Queries.GetMeatDetails;
using FoodOrder.Application.Meats.Queries.GetMeatList;
using FoodOrder.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace FoodOrder.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/{version:apiVersion}/[controller]")]
    public class MeatController : BaseController
    {
        /// <summary>
        /// Gets the list of meats
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /meat
        /// </remarks>
        /// <returns>Returns MeatListVm</returns>
        /// <response code="200">Success</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<MeatListVm>> GetAllMeats()
        {
            var query = new GetMeatListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the meat by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /meat/D34D349E-43B8-429E-BCA4-793C932FD580
        /// </remarks>
        /// <param name="id">Meat id (guid)</param>
        /// <returns>Returns MeatDetailsVm</returns>
        /// <response code="200">Success</response>
        [HttpGet("{id}", Name = "GetMeatById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<MeatDetailsVm>> GetMeatById(Guid id)
        {
            var query = new GetMeatDetailsQuery()
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Creates the meat
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /meat
        /// {
        ///     "Name": "steak",
        ///     "Price": 180
        /// }
        /// </remarks>
        /// <param name="createMeatDto">CreateMeatDto object</param>
        /// <returns>Returns id (guid)</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Guid>> CreateMeat(CreateMeatDto createMeatDto)
        {
            var command = Mapper.Map<CreateMeatCommand>(createMeatDto);
            var meatId = await Mediator.Send(command);
            return Ok(meatId);
        }

        /// <summary>
        /// Updates the meat
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /meat/88DEB432-062F-43DE-8DCD-8B6EF79073D3
        /// {
        ///    "Price": 170,
        ///    "name": "pork"
        /// }
        /// </remarks>
        /// <param name="updateMeatDto">UpdateMeatDto object</param>
        /// <param name="id">Meat id (guid)</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> UpdateMeat(Guid id, UpdateMeatDto updateMeatDto)
        {
            var command = Mapper.Map<UpdateMeatCommand>(updateMeatDto);
            command.Id = id;
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Deletes the meat by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /meat/88DEB432-062F-43DE-8DCD-8B6EF79073D3
        /// </remarks>
        /// <param name="id">Id of the meat (guid)</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> DeleteMeat(Guid id)
        {
            var command = new DeleteMeatCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}