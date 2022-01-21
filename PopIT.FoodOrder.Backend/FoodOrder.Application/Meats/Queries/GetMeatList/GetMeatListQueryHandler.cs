using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FoodOrder.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FoodOrder.Application.Meats.Queries.GetMeatList
{
    public class GetMeatListQueryHandler : IRequestHandler<GetMeatListQuery, MeatListVm>
    {
        private readonly IFoodOrderDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetMeatListQueryHandler(IFoodOrderDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<MeatListVm> Handle(GetMeatListQuery request, CancellationToken cancellationToken)
        {
            var meats = await _dbContext.Meats
                .ProjectTo<MeatLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new MeatListVm { Meats = meats };
        }
    }
}