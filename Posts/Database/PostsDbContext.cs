using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Posts.Database
{
    public partial class PostsDbContext : DbContext
    {
        public PostsDbContext()
        {
        }

        public PostsDbContext(DbContextOptions<PostsDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BlogPosts> BlogPosts { get; set; }
        public virtual DbSet<BlogPostsTags> BlogPostsTags { get; set; }
        public virtual DbSet<Tags> Tags { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=DESKTOP-0415RGN\\DJENANSQL;Database=Posts;Trusted_Connection=false;User=sa;Password=Globus315");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogPosts>(entity =>
            {
                entity.Property(e => e.Body).IsRequired();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Slug).IsRequired();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<BlogPostsTags>(entity =>
            {
                entity.HasOne(d => d.BlogPosts)
                    .WithMany(p => p.BlogPostsTags)
                    .HasForeignKey(d => d.BlogPostsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BlogPostsId");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.BlogPostsTags)
                    .HasForeignKey(d => d.TagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TagId");
            });

            modelBuilder.Entity<Tags>(entity =>
            {
                entity.Property(e => e.TagName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
