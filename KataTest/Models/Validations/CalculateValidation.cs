using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KataTest.Models.Validations
{
    public class CalculateValidation : IEntityTypeConfiguration<Calculation>
    {
        public void Configure(EntityTypeBuilder<Calculation> builder)
        {
            builder.HasKey(x => x.id);
            builder.Property(x => x.id)
                .ValueGeneratedOnAdd();
            builder.Property(x => x.FristNumber)
                .IsRequired();
            builder.Property(x => x.SecondNumer)
            .IsRequired();
            builder.Property(x => x.Result)
            .IsRequired();
        }
    }
}
