using FoodOrder.Domain.Entities;
using FoodOrder.Persistence;
using Microsoft.EntityFrameworkCore;
using System;

namespace FoodOrder.Tests.Common
{
	public class FoodOrderContextFactory
	{
		public static Guid UserIdForUpdate = Guid.NewGuid();
		public static Guid UserIdForDelete = Guid.NewGuid();

		public static Guid EntityIdForDelete = Guid.NewGuid();
		public static Guid EntityIdForUpdate = Guid.NewGuid();

		public static FoodOrderDbContext Create()
		{
			var options = new DbContextOptionsBuilder<FoodOrderDbContext>()
				.UseInMemoryDatabase(Guid.NewGuid().ToString())
				.Options;

			var context = new FoodOrderDbContext(options);
			context.Database.EnsureCreated();
			context.Beverages.AddRange(
				new Beverage
				{
					Id = Guid.Parse("FCEC3D45-F4BE-4852-A809-5465737DD0B3"),
					Name = "Name1",
					Price = 100
				},
				new Beverage
				{
					Id = Guid.Parse("E6CA7680-B1FB-4221-BC55-B45955B22071"),
					Name = "Name2",
					Price = 200
				},
				new Beverage
				{
					Id = EntityIdForDelete,
					Name = "NameDelete",
					Price = 30
				},
				new Beverage
				{
					Id = EntityIdForUpdate,
					Name = "NameUpdate",
					Price = 40
				}
			);
			context.Garnishes.AddRange(
				new Garnish
				{
					Id = Guid.Parse("FCEC3D45-F4BE-4852-A809-5465737DD0B3"),
					Name = "Name1",
					Price = 100
				},
				new Garnish
				{
					Id = Guid.Parse("E6CA7680-B1FB-4221-BC55-B45955B22071"),
					Name = "Name2",
					Price = 200
				},
				new Garnish
				{
					Id = EntityIdForDelete,
					Name = "NameDelete",
					Price = 30
				},
				new Garnish
				{
					Id = EntityIdForUpdate,
					Name = "NameUpdate",
					Price = 40
				}
			);
			context.Meats.AddRange(
				new Meat
				{
					Id = Guid.Parse("FCEC3D45-F4BE-4852-A809-5465737DD0B3"),
					Name = "Name1",
					Price = 100
				},
				new Meat
				{
					Id = Guid.Parse("E6CA7680-B1FB-4221-BC55-B45955B22071"),
					Name = "Name2",
					Price = 200
				},
				new Meat
				{
					Id = EntityIdForDelete,
					Name = "NameDelete",
					Price = 30
				},
				new Meat
				{
					Id = EntityIdForUpdate,
					Name = "NameUpdate",
					Price = 40
				}
			);
			context.Soups.AddRange(
				new Soup
				{
					Id = Guid.Parse("FCEC3D45-F4BE-4852-A809-5465737DD0B3"),
					Name = "Name1",
					Price = 100
				},
				new Soup
				{
					Id = Guid.Parse("E6CA7680-B1FB-4221-BC55-B45955B22071"),
					Name = "Name2",
					Price = 200
				},
				new Soup
				{
					Id = EntityIdForDelete,
					Name = "NameDelete",
					Price = 30
				},
				new Soup
				{
					Id = EntityIdForUpdate,
					Name = "NameUpdate",
					Price = 40
				}
			);
			context.Orders.AddRange(
				new Order
				{
					Id = Guid.Parse("6E263BC8-D4CB-418E-ABBF-54420CBCE5C8"),
					UserId = UserIdForUpdate,
					BeverageId = Guid.Parse("E6CA7680-B1FB-4221-BC55-B45955B22071"),
					GarnishId = Guid.Parse("FCEC3D45-F4BE-4852-A809-5465737DD0B3"),
					MeatId = Guid.Parse("E6CA7680-B1FB-4221-BC55-B45955B22071"),
					SoupId = Guid.Parse("FCEC3D45-F4BE-4852-A809-5465737DD0B3"),
					IsCompleted = false,
					OrderTime = DateTime.Today
				},
				new Order
				{
					Id = Guid.Parse("B9C42CA1-DB50-4D20-85B8-092B0DEB3681"),
					UserId = UserIdForDelete,
					BeverageId = Guid.Parse("FCEC3D45-F4BE-4852-A809-5465737DD0B3"),
					GarnishId = Guid.Parse("E6CA7680-B1FB-4221-BC55-B45955B22071"),
					MeatId = Guid.Parse("FCEC3D45-F4BE-4852-A809-5465737DD0B3"),
					SoupId = Guid.Parse("E6CA7680-B1FB-4221-BC55-B45955B22071"),
					IsCompleted = true,
					OrderTime = DateTime.Today
				},
				new Order
				{
					Id = Guid.Parse("AF635200-0205-41BF-9EB1-D4D8398A223D"),
					UserId = UserIdForDelete,
					BeverageId = Guid.Parse("A864C2E3-D547-49BD-BC91-8EBFA4700282"),
					GarnishId = Guid.Parse("A864C2E3-D547-49BD-BC91-8EBFA4700282"),
					MeatId = Guid.Parse("A864C2E3-D547-49BD-BC91-8EBFA4700282"),
					SoupId = Guid.Parse("A864C2E3-D547-49BD-BC91-8EBFA4700282"),
					IsCompleted = false,
					OrderTime = DateTime.Today
				}
			);
			context.SaveChanges();

			return context;
		}

		public static void Destroy(FoodOrderDbContext context)
		{
			context.Database.EnsureDeleted();
			context.Dispose();
		}
	}
}
