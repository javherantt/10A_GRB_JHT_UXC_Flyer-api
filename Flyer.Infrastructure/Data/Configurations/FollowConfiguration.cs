using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Flyer.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Flyer.Infraestructure.Data.Configurations
{
    
    public class FollowConfiguration : IEntityTypeConfiguration<Follow>
    {
        public void Configure(EntityTypeBuilder<Follow> builder)
        {
            builder.Property(e => e.Id)
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            builder.Property(e => e.CreateAt)
                .HasColumnType("datetime2");

            builder.Property(e => e.CreatedBy)
                .HasColumnType("int");

            builder.Property(e => e.Status)
                .HasColumnType("bit");

            builder.Property(e => e.UpdateAt)
                .HasColumnType("datetime2");

            builder.Property(e => e.UpdatedBy)
                .HasColumnType("int");

            builder.Property(e => e.UserId)
                .HasColumnType("int");

            builder.Property(e => e.followed)
                .HasColumnType("nvarchar(max)");

            builder.HasKey("Id");

            builder.HasIndex("UserId");

            builder.ToTable("Follow");

            builder.HasOne(e => e.User)
                        .WithMany(e => e.Follow)
                        .HasForeignKey(e => e.UserId)
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

            
        }
    }
}
