using FoodOrder.Application.Soups.Commands.CreateSoup;
using FoodOrder.Application.Soups.Commands.DeleteSoup;
using FoodOrder.Application.Soups.Commands.UpdateSoup;
using FoodOrder.Application.Soups.Queries.GetSoupDetails;
using FoodOrder.Application.Soups.Queries.GetSoupList;
using FoodOrder.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FoodOrder.WebApi.Controllers
{
	[ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/{version:apiVersion}/[controller]")]
	public class SoupController : BaseController
	{
        /// <summary>
		/// Gets the list of soup
		/// </summary>
		/// <remarks>
		/// Sample request:
		/// GET /soup
		/// </remarks>
		/// <returns>Returns SoupListVm</returns>
		/// <response code="200">Success</response>
		[HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<SoupListVm>> GetAllSoup()
        {
            var query = new GetSoupListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
		/// Gets the soup by id
		/// </summary>
		/// <remarks>
		/// Sample request:
		/// GET /soup/D34D349E-43B8-429E-BCA4-793C932FD580
		/// </remarks>
		/// <param name="id">soup id (guid)</param>
		/// <returns>Returns SoupDetailsVm</returns>
		/// <response code="200">Success</response>
		[HttpGet("{id}", Name = "GetSoupById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<SoupDetailsVm>> GetSoupById(Guid id)
        {
            var query = new GetSoupDetailsQuery()
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
		/// Creates the soup
		/// </summary>
		/// <remarks>
		/// Sample request:
		/// POST /soup
		/// {
		///     "Name": "Saltwort",
		///     "Price": 120
		/// }
		/// </remarks>
		/// <param name="createSoupDto">СreateSoupDto object</param>
		/// <returns>Returns id (guid)</returns>
		/// <response code="200">Success</response>
		/// <response code="401">If the user is unauthorized</response>
		[HttpPost]
    [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Guid>> CreateSoup(CreateSoupDto createSoupDto)
        {
            var command = Mapper.Map<CreateSoupCommand>(createSoupDto);
            var soupId = await Mediator.Send(command);
            return Ok(soupId);
        }

		/// <summary>
		/// Updates the soup
		/// </summary>
		/// <remarks>
		/// Sample request:
		/// PUT /soup/88DEB432-062F-43DE-8DCD-8B6EF79073D3
		/// {
		///    "Price": 110,
		///    "name": "Borscht"
		/// }
		/// </remarks>
		/// <param name="updateSoupDto">UpdateSoupDto object</param>
		/// <param name="id">Soup id (guid)</param>
		/// <returns>Returns NoContent</returns>
		/// <response code="204">Success</response>
		/// <response code="401">If the user is unauthorized</response>
		[HttpPut("{id}")]
    [Authorize]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		public async Task<IActionResult> UpdateSoup(Guid id, UpdateSoupDto updateSoupDto)
        {
            var command = Mapper.Map<UpdateSoupCommand>(updateSoupDto);
            command.Id = id;
            await Mediator.Send(command);
            return NoContent();
        }

		/// <summary>
		/// Deletes the soup by id
		/// </summary>
		/// <remarks>
		/// Sample request:
		/// DELETE /soup/88DEB432-062F-43DE-8DCD-8B6EF79073D3
		/// </remarks>
		/// <param name="id">Id of the soup (guid)</param>
		/// <returns>Returns NoContent</returns>
		/// <response code="204">Success</response>
		/// <response code="401">If the user is unauthorized</response>
		[HttpDelete("{id}")]
    [Authorize]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		public async Task<IActionResult> DeleteSoup(Guid id)
        {
            var command = new DeleteSoupCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
