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
    internal class RestaurantConfiguration : IEntityTypeConfiguration<Resturant>
    {
        public void Configure(EntityTypeBuilder<Resturant> builder)
        {
            builder.Property(R => R.Name).IsRequired().HasMaxLength(60);
            builder.Property(R => R.Description).IsRequired().HasMaxLength(300);
            builder.Property(R => R.PictureUrl).IsRequired();
        }
    }
}
