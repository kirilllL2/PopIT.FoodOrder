using FoodOrder.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodOrder.Persistence.EntityTypeConfigurations
{
	public class MeatConfiguration : IEntityTypeConfiguration<Meat>
	{
		public void Configure(EntityTypeBuilder<Meat> builder)
		{
			builder.ToTable("Meats");

			builder.HasKey(m => m.Id);
			builder.HasIndex(m => m.Id).IsUnique();

			builder.Property(m => m.Name)
				.IsRequired();
		}
	}
}
