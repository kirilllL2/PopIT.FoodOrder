using FoodOrder.Application.Beverages.Commands.CreateBeverage;
using FoodOrder.Application.Beverages.Commands.DeleteBeverage;
using FoodOrder.Application.Beverages.Commands.UpdateBeverage;
using FoodOrder.Application.Beverages.Queries.GetBeverageDetails;
using FoodOrder.Application.Beverages.Queries.GetBeverageList;
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
	public class BeverageController : BaseController
	{
		/// <summary>
		/// Gets the list of beverages
		/// </summary>
		/// <remarks>
		/// Sample request:
		/// GET /beverage
		/// </remarks>
		/// <returns>Returns BeverageListVm</returns>
		/// <response code="200">Success</response>
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<BeverageListVm>> GetAllBeverages()
		{
			var query = new GetBeverageListQuery();
			var vm = await Mediator.Send(query);
			return Ok(vm);
		}

		/// <summary>
		/// Gets the beverage by id
		/// </summary>
		/// <remarks>
		/// Sample request:
		/// GET /beverage/D34D349E-43B8-429E-BCA4-793C932FD580
		/// </remarks>
		/// <param name="id">Beverage id (guid)</param>
		/// <returns>Returns BeverageDetailsVm</returns>
		/// <response code="200">Success</response>
		[HttpGet("{id}", Name = "GetBeverageById")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<BeverageDetailsVm>> GetBeverageById(Guid id)
		{
			var query = new GetBeverageDetailsQuery()
			{
				Id = id
			};
			var vm = await Mediator.Send(query);
			return Ok(vm);
		}

		/// <summary>
		/// Creates the beverage
		/// </summary>
		/// <remarks>
		/// Sample request:
		/// POST /beverage
		/// {
		///     "Name": "water",
		///     "Price": 10
		/// }
		/// </remarks>
		/// <param name="createBeverageDto">СreateBeverageDto object</param>
		/// <returns>Returns id (guid)</returns>
		/// <response code="200">Success</response>
		/// <response code="401">If the user is unauthorized</response>
    [HttpPost]
		[Authorize]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		public async Task<ActionResult<Guid>> CreateBeverage(CreateBeverageDto createBeverageDto)
		{
			var command = Mapper.Map<CreateBeverageCommand>(createBeverageDto);
			var beverageId = await Mediator.Send(command);
			return Ok(beverageId);
		}

		/// <summary>
		/// Updates the beverage
		/// </summary>
		/// <remarks>
		/// Sample request:
		/// PUT /beverage/88DEB432-062F-43DE-8DCD-8B6EF79073D3
		/// {
		///    "Price": 110,
		///    "name": "Cognac"
		/// }
		/// </remarks>
		/// <param name="updateBeverageDto">UpdateBeverageDto object</param>
		/// <param name="id">Beverage id (guid)</param>
		/// <returns>Returns NoContent</returns>
		/// <response code="204">Success</response>
		/// <response code="401">If the user is unauthorized</response>
		[HttpPut("{id}")]
    [Authorize]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		public async Task<IActionResult> UpdateBeverage(Guid id, UpdateBeverageDto updateBeverageDto)
		{
			var command = Mapper.Map<UpdateBeverageCommand>(updateBeverageDto);
			command.Id = id;
			await Mediator.Send(command);
			return NoContent();
		}

		/// <summary>
		/// Deletes the beverage by id
		/// </summary>
		/// <remarks>
		/// Sample request:
		/// DELETE /beverage/88DEB432-062F-43DE-8DCD-8B6EF79073D3
		/// </remarks>
		/// <param name="id">Id of the beverage (guid)</param>
		/// <returns>Returns NoContent</returns>
		/// <response code="204">Success</response>
		/// <response code="401">If the user is unauthorized</response>
		[HttpDelete("{id}")]
    [Authorize]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		public async Task<IActionResult> DeleteBeverage(Guid id)
		{
			var command = new DeleteBeverageCommand
			{
				Id = id
			};
			await Mediator.Send(command);
			return NoContent();
		}
	}
}
