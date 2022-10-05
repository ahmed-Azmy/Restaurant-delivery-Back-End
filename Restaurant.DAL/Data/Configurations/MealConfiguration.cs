using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DAL.Data.Configurations
{
    internal class MealConfiguration : IEntityTypeConfiguration<Meal>
    {
        public void Configure(EntityTypeBuilder<Meal> builder)
        {
            builder.Property(P => P.Name).IsRequired().HasMaxLength(60);
            builder.Property(P => P.Details).IsRequired().HasMaxLength(300);
            builder.Property(P => P.Price).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(P => P.PictureUrl).IsRequired();
        }
    }
}
