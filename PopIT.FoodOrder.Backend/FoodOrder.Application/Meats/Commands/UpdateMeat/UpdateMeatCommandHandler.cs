using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FoodOrder.Application.Common.Exceptions;
using FoodOrder.Application.Interfaces;
using FoodOrder.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FoodOrder.Application.Meats.Commands.UpdateMeat
{
    public class UpdateMeatCommandHandler : IRequestHandler<UpdateMeatCommand>
    {
        private readonly IFoodOrderDbContext _dbContext;
        private readonly IMapper _mapper;

        public UpdateMeatCommandHandler(IFoodOrderDbContext dbContext,
            IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);
        
        public async Task<Unit> Handle(UpdateMeatCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Meats.FirstOrDefaultAsync(note =>
                    note.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new EntityIdNotFoundException(nameof(Meat), request.Id);
            }

            _mapper.Map(request, entity);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}