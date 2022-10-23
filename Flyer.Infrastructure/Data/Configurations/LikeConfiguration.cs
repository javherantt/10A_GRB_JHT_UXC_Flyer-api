using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Flyer.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Flyer.Infraestructure.Data.Configurations
{
    
    public class LikeConfiguration : IEntityTypeConfiguration<Like>
    {
        public void Configure(EntityTypeBuilder<Like> builder)
        {
            builder.Property<int>("Id")
                       .ValueGeneratedOnAdd()
                       .HasColumnType("int")
                       .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            builder.Property<DateTime>("CreateAt")
                .HasColumnType("datetime2");

            builder.Property<int?>("CreatedBy")
                .HasColumnType("int");

            builder.Property<int>("PostId")
                .HasColumnType("int");

            builder.Property<bool>("Status")
                .HasColumnType("bit");

            builder.Property<DateTime?>("UpdateAt")
                .HasColumnType("datetime2");

            builder.Property<int?>("UpdatedBy")
                .HasColumnType("int");

            builder.Property<int?>("UserId")
                .HasColumnType("int");

            builder.Property<int>("likes")
                .HasColumnType("int");

            builder.HasKey("Id");

            builder.HasIndex("PostId");

            builder.HasIndex("UserId");

            builder.ToTable("Like");

            builder.HasOne("Flyer.Domain.Entities.Post", "Post")
                       .WithMany("Like")
                       .HasForeignKey("PostId")
                       .OnDelete(DeleteBehavior.Cascade)
                       .IsRequired();

            builder.HasOne("Flyer.Domain.Entities.User", "User")
                .WithMany()
                .HasForeignKey("UserId");

            

        }
    }
}
