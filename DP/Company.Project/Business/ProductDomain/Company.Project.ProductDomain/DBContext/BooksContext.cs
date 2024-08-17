using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Company.Project.ProductDomain.DBContext
{
    public partial class BooksContext : DbContext
    {
        public BooksContext()
        {
        }

        public BooksContext(DbContextOptions<BooksContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<Events> Events { get; set; }
        public virtual DbSet<InviteUser> InviteUser { get; set; }
        public virtual DbSet<LookUp> LookUp { get; set; }
        public virtual DbSet<LookUpCategoryId> LookUpCategoryId { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
///#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=IN-89W0BK3;database=Books;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comments>(entity =>
            {
                entity.HasKey(e => e.CommentNo);

                entity.Property(e => e.CommentNo).ValueGeneratedNever();

                entity.Property(e => e.Comment)
                    .HasMaxLength(40)
                    .IsFixedLength();

                entity.Property(e => e.CommentDateTime).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Events>(entity =>
            {
                entity.HasKey(e => e.Eventid);

                entity.Property(e => e.Eventid).ValueGeneratedNever();

                entity.Property(e => e.Creator)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.DateOfEvent)
                .HasColumnName("DateOfEvent");

                entity.Property(e => e.EventDescription)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.EventLocation)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.InviteUsers)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.OtherDetails)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Title)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<InviteUser>(entity =>
            {
                entity.HasKey(e => e.InviteId);

                entity.Property(e => e.InviteId).ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .HasMaxLength(40)
                    .IsFixedLength();
            });

            modelBuilder.Entity<LookUp>(entity =>
            {
                entity.Property(e => e.LookUpId).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<LookUpCategoryId>(entity =>
            {
                entity.HasKey(e => e.LookUpCategoryId1);

                entity.Property(e => e.LookUpCategoryId1)
                    .HasColumnName("LookUpCategoryId")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.Email);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.UserName)
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.UserPassword)
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.UserType)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
