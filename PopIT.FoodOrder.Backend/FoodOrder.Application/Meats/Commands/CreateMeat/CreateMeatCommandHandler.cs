using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FoodOrder.Application.Interfaces;
using FoodOrder.Domain.Entities;
using MediatR;

namespace FoodOrder.Application.Meats.Commands.CreateMeat
{
    public class CreateMeatCommandHandler : IRequestHandler<CreateMeatCommand, Guid>
    {
        private readonly IFoodOrderDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateMeatCommandHandler(IFoodOrderDbContext dbContext,
            IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);
        
        public async Task<Guid> Handle(CreateMeatCommand request, CancellationToken cancellationToken)
        {
            var meat = _mapper.Map<Meat>(request);

            await _dbContext.Meats.AddAsync(meat, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return meat.Id;
        }
    }
}