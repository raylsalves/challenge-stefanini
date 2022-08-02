using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stefanini.Challenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini.Challenge.Infra.Data.Mappings
{
    public class PersonMapping : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Person");
            builder.HasKey(person => person.Id);
            builder.HasOne(person => person.City).WithMany(city => city.Persons)
                .HasForeignKey(person => person.CityId).OnDelete(DeleteBehavior.NoAction);
            builder.Property(person => person.Name).HasMaxLength(300);
            builder.Property(person => person.CPF).HasMaxLength(11);
            builder.Property(person => person.Age).HasMaxLength(3);
        }
    }
}
