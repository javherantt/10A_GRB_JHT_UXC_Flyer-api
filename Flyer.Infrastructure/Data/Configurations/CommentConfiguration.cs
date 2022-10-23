using Flyer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Flyer.Infraestructure.Data.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(e => e.Id)
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            builder.Property(e => e.CreateAt)
                .HasColumnType("datetime2");

            builder.Property(e => e.CreatedBy)
                .HasColumnType("int");

            builder.Property(e => e.PostId)
                .HasColumnType("int");

            builder.Property(e => e.Status)
                .HasColumnType("bit");

            builder.Property(e => e.UpdateAt)
                .HasColumnType("datetime2");

            builder.Property(e => e.UpdatedBy)
                .HasColumnType("int");

            builder.Property(e => e.UserId)
                .HasColumnType("int");

            builder.Property(e => e.comment)
                .HasColumnType("nvarchar(max)");

            builder.Property(e => e.timestamp)
                .HasColumnType("datetime2");

            builder.HasKey("Id");

            builder.HasIndex("PostId");

            builder.HasIndex("UserId");

            builder.ToTable("Comment");

            builder.HasOne(e => e.Post)
                       .WithMany(e => e.Comment)
                       .HasForeignKey(e => e.PostId)
                       .OnDelete(DeleteBehavior.Cascade)
                       .IsRequired();

            builder.HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

          
        }
    }
   
}
