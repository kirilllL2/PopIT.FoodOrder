using FoodOrder.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodOrder.Persistence.EntityTypeConfigurations
{
	public class OrderConfiguration : IEntityTypeConfiguration<Order>
	{
		public void Configure(EntityTypeBuilder<Order> builder)
		{
			builder.ToTable("Orders");

			builder.HasKey(o => o.Id);
			builder.HasIndex(o => o.Id);

			builder.Property(o => o.UserId)
				.IsRequired();

			builder.Property(o => o.OrderTime)
				.IsRequired();

			builder.HasOne(o => o.Beverage)
				.WithMany(b => b.Orders)
				.HasForeignKey(o => o.BeverageId);

			builder.HasOne(o => o.Garnish)
				.WithMany(g => g.Orders)
				.HasForeignKey(o => o.GarnishId);

			builder.HasOne(o => o.Meat)
				.WithMany(m => m.Orders)
				.HasForeignKey(o => o.MeatId);

			builder.HasOne(o => o.Soup)
				.WithMany(s => s.Orders)
				.HasForeignKey(o => o.SoupId);
		}
	}
}
