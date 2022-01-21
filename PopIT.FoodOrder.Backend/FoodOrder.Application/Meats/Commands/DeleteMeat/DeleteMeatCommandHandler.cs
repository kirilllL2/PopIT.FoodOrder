using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FoodOrder.Application.Common.Exceptions;
using FoodOrder.Application.Interfaces;
using FoodOrder.Domain.Entities;
using MediatR;

namespace FoodOrder.Application.Meats.Commands.DeleteMeat
{
    public class DeleteMeatCommandHandler : IRequestHandler<DeleteMeatCommand>
    {
        private readonly IFoodOrderDbContext _dbContext;
        private readonly IMapper _mapper;

        public DeleteMeatCommandHandler(IFoodOrderDbContext dbContext,
            IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<Unit> Handle(DeleteMeatCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Meats
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                throw new EntityIdNotFoundException(nameof(Meat), request.Id);
            }

            _dbContext.Meats.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}