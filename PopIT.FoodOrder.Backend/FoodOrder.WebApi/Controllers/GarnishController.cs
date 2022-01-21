using FoodOrder.Application.Garnishes.Commands.CreateGarnish;
using FoodOrder.Application.Garnishes.Commands.DeleteGarnish;
using FoodOrder.Application.Garnishes.Commands.UpdateGarnish;
using FoodOrder.Application.Garnishes.Queries.GetGarnishDetails;
using FoodOrder.Application.Garnishes.Queries.GetGarnishList;
using FoodOrder.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FoodOrder.WebApi.Controllers
{
	[Route("api/[controller]")]
	public class GarnishController : BaseController
	{
        [HttpGet]
        public async Task<ActionResult<GarnishListVm>> GetAllGarnishes()
        {
            var query = new GetGarnishListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}", Name = "GetGarnishById")]
        public async Task<ActionResult<GarnishDetailsVm>> GetGarnishById(Guid id)
        {
            var query = new GetGarnishDetailsQuery()
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Guid>> CreateGarnish(CreateGarnishDto createGarnishDto)
        {
            var command = Mapper.Map<CreateGarnishCommand>(createGarnishDto);
            var garnishId = await Mediator.Send(command);
            return Ok(garnishId);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateGarnish(Guid id, UpdateGarnishDto updateGarnishDto)
        {
            var command = Mapper.Map<UpdateGarnishCommand>(updateGarnishDto);
            command.Id = id;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
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
