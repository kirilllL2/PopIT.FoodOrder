using FoodOrder.Application.Garnishes.Commands.CreateGarnish;
using FoodOrder.Application.Garnishes.Commands.DeleteGarnish;
using FoodOrder.Application.Garnishes.Commands.UpdateGarnish;
using FoodOrder.Application.Garnishes.Queries.GetGarnishDetails;
using FoodOrder.Application.Garnishes.Queries.GetGarnishList;
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
	public class GarnishController : BaseController
	{
    /// <summary>
    /// Gets the list of garnishes
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// GET /garnish
    /// </remarks>
    /// <returns>Returns GarnishListVm</returns>
    /// <response code="200">Success</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<GarnishListVm>> GetAllGarnishes()
    {
        var query = new GetGarnishListQuery();
        var vm = await Mediator.Send(query);
        return Ok(vm);
    }

    /// <summary>
		/// Gets the garnish by id
		/// </summary>
		/// <remarks>
		/// Sample request:
		/// GET /garnish/D34D349E-43B8-429E-BCA4-793C932FD580
		/// </remarks>
		/// <param name="id">Garnish id (guid)</param>
		/// <returns>Returns GarnishDetailsVm</returns>
		/// <response code="200">Success</response>
		[HttpGet("{id}", Name = "GetGarnishById")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<GarnishDetailsVm>> GetGarnishById(Guid id)
    {
        var query = new GetGarnishDetailsQuery()
        {
            Id = id
        };
        var vm = await Mediator.Send(query);
        return Ok(vm);
    }


        
      /// <summary>
      /// Creates the garnish
      /// </summary>
      /// <remarks>
      /// Sample request:
      /// POST /garnish
      /// {
      ///     "Name": "potato",
      ///     "Price": 90
      /// }
      /// </remarks>
      /// <param name="createGarnishDto">СreateGarnishDto object</param>
      /// <returns>Returns id (guid)</returns>
      /// <response code="200">Success</response>
      /// <response code="401">If the user is unauthorized</response>
      [HttpPost]
      [Authorize]
      [ProducesResponseType(StatusCodes.Status200OK)]
      [ProducesResponseType(StatusCodes.Status401Unauthorized)]
      public async Task<ActionResult<Guid>> CreateGarnish(CreateGarnishDto createGarnishDto)
      {
          var command = Mapper.Map<CreateGarnishCommand>(createGarnishDto);
          var garnishId = await Mediator.Send(command);
          return Ok(garnishId);
      }

		/// <summary>
		/// Updates the garnish
		/// </summary>
		/// <remarks>
		/// Sample request:
		/// PUT /garnish/88DEB432-062F-43DE-8DCD-8B6EF79073D3
		/// {
		///    "Price": 100,
		///    "name": "noodles"
		/// }
		/// </remarks>
		/// <param name="updateGarnishDto">UpdateGarnishDto object</param>
		/// <param name="id">Garnish id (guid)</param>
		/// <returns>Returns NoContent</returns>
		/// <response code="204">Success</response>
		/// <response code="401">If the user is unauthorized</response>
		[HttpPut("{id}")]
    [Authorize]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		public async Task<IActionResult> UpdateGarnish(Guid id, UpdateGarnishDto updateGarnishDto)
        {
            var command = Mapper.Map<UpdateGarnishCommand>(updateGarnishDto);
            command.Id = id;
            await Mediator.Send(command);
            return NoContent();
        }

		/// <summary>
		/// Deletes the garnish by id
		/// </summary>
		/// <remarks>
		/// Sample request:
		/// DELETE /garnish/88DEB432-062F-43DE-8DCD-8B6EF79073D3
		/// </remarks>
		/// <param name="id">Id of the garnish (guid)</param>
		/// <returns>Returns NoContent</returns>
		/// <response code="204">Success</response>
		/// <response code="401">If the user is unauthorized</response>
		[HttpDelete("{id}")]
    [Authorize]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		public async Task<IActionResult> DeleteGarnish(Guid id)
        {
            var command = new DeleteGarnishCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
