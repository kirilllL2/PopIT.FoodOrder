using FoodOrder.Application.Soups.Commands.CreateSoup;
using FoodOrder.Application.Soups.Commands.DeleteSoup;
using FoodOrder.Application.Soups.Commands.UpdateSoup;
using FoodOrder.Application.Soups.Queries.GetSoupDetails;
using FoodOrder.Application.Soups.Queries.GetSoupList;
using FoodOrder.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FoodOrder.WebApi.Controllers
{
	[Route("api/[controller]")]
	public class SoupController : BaseController
	{
        [HttpGet]
        public async Task<ActionResult<SoupListVm>> GetAllSoup()
        {
            var query = new GetSoupListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}", Name = "GetSoupById")]
        public async Task<ActionResult<SoupDetailsVm>> GetSoupById(Guid id)
        {
            var query = new GetSoupDetailsQuery()
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Guid>> CreateSoup(CreateSoupDto createSoupDto)
        {
            var command = Mapper.Map<CreateSoupCommand>(createSoupDto);
            var soupId = await Mediator.Send(command);
            return Ok(soupId);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateSoup(Guid id, UpdateSoupDto updateSoupDto)
        {
            var command = Mapper.Map<UpdateSoupCommand>(updateSoupDto);
            command.Id = id;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
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
