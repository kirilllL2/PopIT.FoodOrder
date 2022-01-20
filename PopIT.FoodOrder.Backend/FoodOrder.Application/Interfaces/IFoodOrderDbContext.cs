using FoodOrder.Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace FoodOrder.Application.Interfaces
{
	public interface IFoodOrderDbContext
	{
		DbSet<Meat> Meats { get; set; }
		DbSet<Soup> Soups { get; set; }
		DbSet<Garnish> Garnishes { get; set; }
		DbSet<Beverage> Beverages { get; set; }
		DbSet<Order> Orders { get; set; }

		Task<int> SaveChangesAsync(CancellationToken cancellationToken);
	}
}
