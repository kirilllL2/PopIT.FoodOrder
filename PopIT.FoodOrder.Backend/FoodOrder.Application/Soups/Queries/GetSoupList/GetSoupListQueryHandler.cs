using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FoodOrder.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FoodOrder.Application.Soups.Queries.GetSoupList
{
    public class GetSoupListQueryHandler : IRequestHandler<GetSoupListQuery, SoupListVm>
    {
        private readonly IFoodOrderDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetSoupListQueryHandler(IFoodOrderDbContext dbContext, IMapper mapper) => 
            (_dbContext, _mapper) = (dbContext, mapper);
        
        public async Task<SoupListVm> Handle(GetSoupListQuery request, CancellationToken cancellationToken)
        {
            var soups = await _dbContext.Soups
                .ProjectTo<SoupLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new SoupListVm() { Soups = soups };
        }
    }
}