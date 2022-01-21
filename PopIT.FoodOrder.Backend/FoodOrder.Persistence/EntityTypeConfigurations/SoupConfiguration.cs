using FoodOrder.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodOrder.Persistence.EntityTypeConfigurations
{
	public class SoupConfiguration : IEntityTypeConfiguration<Soup>
	{
		public void Configure(EntityTypeBuilder<Soup> builder)
		{
			builder.ToTable("Soups");

			builder.HasKey(s => s.Id);
			builder.HasIndex(s => s.Id).IsUnique();

			builder.Property(s => s.Name)
				.IsRequired();
		}
	}
}
