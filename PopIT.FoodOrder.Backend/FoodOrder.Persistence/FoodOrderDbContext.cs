using FoodOrder.Application.Interfaces;
using FoodOrder.Domain.Entities;
using FoodOrder.Persistence.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace FoodOrder.Persistence
{
	public class FoodOrderDbContext : DbContext, IFoodOrderDbContext
	{
		public FoodOrderDbContext(DbContextOptions<FoodOrderDbContext> options)
			: base(options) { }

		public DbSet<Meat> Meats { get; set; }
		public DbSet<Soup> Soups { get; set; }
		public DbSet<Garnish> Garnishes { get; set; }
		public DbSet<Beverage> Beverages { get; set; }
		public DbSet<Order> Orders { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.ApplyConfiguration(new OrderConfiguration());
			base.OnModelCreating(builder);
		}
	}
}
