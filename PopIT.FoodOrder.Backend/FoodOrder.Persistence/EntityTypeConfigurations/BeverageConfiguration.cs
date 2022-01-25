using FoodOrder.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodOrder.Persistence.EntityTypeConfigurations
{
	public class BeverageConfiguration : IEntityTypeConfiguration<Beverage>
	{
		public void Configure(EntityTypeBuilder<Beverage> builder)
		{
			builder.ToTable("Beverages");

			builder.HasKey(b => b.Id);
			builder.HasIndex(b => b.Id).IsUnique();

			builder.Property(b => b.Name)
				.IsRequired();
		}
	}
}
