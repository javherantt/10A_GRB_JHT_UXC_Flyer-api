using Flyer.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Flyer.Infraestructure.Data.Configurations
{
    
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.Property<int>("Id")
                       .ValueGeneratedOnAdd()
                       .HasColumnType("int")
                       .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            builder.Property<DateTime>("CreateAt")
                .HasColumnType("datetime2");

            builder.Property<int?>("CreatedBy")
                .HasColumnType("int");

            builder.Property<string>("Name")
                .HasColumnType("nvarchar(max)");

            builder.Property<bool>("Status")
                .HasColumnType("bit");

            builder.Property<DateTime?>("UpdateAt")
                .HasColumnType("datetime2");

            builder.Property<int?>("UpdatedBy")
                .HasColumnType("int");

            builder.HasKey("Id");

            builder.ToTable("Tag");
        }
    }
}
