using Flyer.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Flyer.Infraestructure.Data.Configurations
{
    

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property<int>("Id")
                       .ValueGeneratedOnAdd()
                       .HasColumnType("int")
                       .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            builder.Property<DateTime>("CreateAt")
                .HasColumnType("datetime2");

            builder.Property<int?>("CreatedBy")
                .HasColumnType("int");

            builder.Property<string>("Email")
                .HasColumnType("nvarchar(max)");

            builder.Property<string>("Image")
                .HasColumnType("nvarchar(max)");

            builder.Property<string>("Password")
                .HasColumnType("nvarchar(max)");

            builder.Property<string>("Role")
                .HasColumnType("nvarchar(max)");

            builder.Property<bool>("Status")
                .HasColumnType("bit");

            builder.Property<DateTime?>("UpdateAt")
                .HasColumnType("datetime2");

            builder.Property<int?>("UpdatedBy")
                .HasColumnType("int");

            builder.Property<string>("Username")
                .HasColumnType("nvarchar(max)");

            builder.HasKey("Id");

            builder.ToTable("User");
        }
    }
}
