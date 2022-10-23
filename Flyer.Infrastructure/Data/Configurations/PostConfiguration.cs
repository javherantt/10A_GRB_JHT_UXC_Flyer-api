using Flyer.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Flyer.Infraestructure.Data.Configurations
{
    
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.Property<int>("Id")
                       .ValueGeneratedOnAdd()
                       .HasColumnType("int")
                       .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            builder.Property<DateTime>("CreateAt")
                .HasColumnType("datetime2");

            builder.Property<int?>("CreatedBy")
                .HasColumnType("int");

            builder.Property<string>("Description")
                .HasColumnType("nvarchar(max)");

            builder.Property<string>("Filename")
                .HasColumnType("nvarchar(max)");

            builder.Property<bool>("Status")
                .HasColumnType("bit");

            builder.Property<int>("TagId")
                .HasColumnType("int");

            builder.Property<string>("Title")
                .HasColumnType("nvarchar(max)");

            builder.Property<DateTime?>("UpdateAt")
                .HasColumnType("datetime2");

            builder.Property<int?>("UpdatedBy")
                .HasColumnType("int");

            builder.Property<int>("UserId")
                .HasColumnType("int");

            builder.Property<int>("Views")
                .HasColumnType("int");

            builder.Property<DateTime>("timestamp")
                .HasColumnType("datetime2");

            builder.HasKey("Id");

            builder.HasIndex("TagId");

            builder.HasIndex("UserId");

            builder.ToTable("Post");

            builder.HasOne("Flyer.Domain.Entities.Tag", "Tag")
                       .WithMany("Post")
                       .HasForeignKey("TagId")
                       .OnDelete(DeleteBehavior.Cascade)
                       .IsRequired();

            builder.HasOne("Flyer.Domain.Entities.User", "User")
                .WithMany("Post")
                .HasForeignKey("UserId")
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

           
        }
    }
}
