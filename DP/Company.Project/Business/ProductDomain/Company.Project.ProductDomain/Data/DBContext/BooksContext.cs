using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Company.Project.ProductDomain.Data.DBContext
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
        public virtual DbSet<LookUpCategory> LookUpCategory { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=IN-DK3N2J3;database=Books;Trusted_connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comments>(entity =>
            {
                entity.HasKey(e => e.CommentNo)
                    .HasName("PK__Comments__C3B4E4796873BF48");

                entity.Property(e => e.Comment)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CommentDateTime).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Comments__EventI__4AB81AF0");
            });

            modelBuilder.Entity<Events>(entity =>
            {
                entity.HasKey(e => e.Eventid)
                    .HasName("PK__Events__7945F46883E497F4");

                entity.Property(e => e.Creator)
                    .HasColumnName("creator")
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.DateOfEvent)
                .HasColumnName("DateOfEvent");

                entity.Property(e => e.EventDescription)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.EventLocation)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.InviteUsers)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Otherdetails)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<InviteUser>(entity =>
            {
                entity.HasKey(e => e.InviteId)
                    .HasName("PK__InviteUs__AFACE86DAECEEEA6");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.InviteUser)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__InviteUse__Event__4D94879B");
            });

            modelBuilder.Entity<LookUp>(entity =>
            {
                entity.Property(e => e.LookupId).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.LookupCategory)
                    .WithMany(p => p.LookUp)
                    .HasForeignKey(d => d.LookupCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LookUp__LookupCa__44FF419A");
            });

            modelBuilder.Entity<LookUpCategory>(entity =>
            {
                entity.Property(e => e.LookupCategoryId).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.Email)
                    .HasName("PK__Users__A9D10535B1A2695A");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Usertype)
                    .IsRequired()
                    .HasColumnName("usertype")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
