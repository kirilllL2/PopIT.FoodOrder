using FoodOrder.Application.Beverages.Commands.CreateBeverage;
using FoodOrder.Application.Beverages.Commands.DeleteBeverage;
using FoodOrder.Application.Beverages.Commands.UpdateBeverage;
using FoodOrder.Application.Beverages.Queries.GetBeverageDetails;
using FoodOrder.Application.Beverages.Queries.GetBeverageList;
using FoodOrder.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FoodOrder.WebApi.Controllers
{
	[Route("api/[controller]")]
	public class BeverageController : BaseController
	{
        [HttpGet]
        public async Task<ActionResult<BeverageListVm>> GetAllBeverages()
        {
            var query = new GetBeverageListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}", Name = "GetBeverageById")]
        public async Task<ActionResult<BeverageDetailsVm>> GetBeverageById(Guid id)
        {
            var query = new GetBeverageDetailsQuery()
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateBeverage(CreateBeverageDto createBeverageDto)
        {
            var command = Mapper.Map<CreateBeverageCommand>(createBeverageDto);
            var noteId = await Mediator.Send(command);
            return Ok(noteId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBeverage(Guid id, UpdateBeverageDto updateBeverageDto)
        {
            var command = Mapper.Map<UpdateBeverageCommand>(updateBeverageDto);
            command.Id = id;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
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
