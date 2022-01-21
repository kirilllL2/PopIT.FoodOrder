using System;
using System.Threading.Tasks;
using AutoMapper;
using FoodOrder.Application.Meats.Commands.CreateMeat;
using FoodOrder.Application.Meats.Commands.DeleteMeat;
using FoodOrder.Application.Meats.Commands.UpdateMeat;
using FoodOrder.Application.Meats.Queries.GetMeatDetails;
using FoodOrder.Application.Meats.Queries.GetMeatList;
using FoodOrder.WebApi.Models;
using Microsoft.AspNetCore.Mvc;


namespace FoodOrder.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class MeatController : BaseController
    {
        private readonly IMapper _mapper;

        public MeatController(IMapper mapper) => _mapper = mapper;
        
        [HttpGet]
        public async Task<ActionResult<MeatListVm>> GetAllMeats()
        {
            var query = new GetMeatListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        
        [HttpGet("{id}", Name = "GetMeatById")]
        public async Task<ActionResult<MeatDetailsVm>> GetMeatById(Guid id)
        {
            var query = new GetMeatDetailsQuery()
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        
        [HttpPost]
        public async Task<ActionResult<Guid>> CreateMeat(CreateMeatDto createNoteDto)
        {
            var command = _mapper.Map<CreateMeatCommand>(createNoteDto);
            var noteId = await Mediator.Send(command);
            return Ok(noteId);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMeat(Guid id, UpdateMeatDto updateMeatDto)
        {
            var command = _mapper.Map<UpdateMeatCommand>(updateMeatDto);
            command.Id = id;
            await Mediator.Send(command);
            return NoContent();
        }
        
        [HttpDelete("{id}")]
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