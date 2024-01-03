using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using myMoviez.Models;

namespace myMoviez.Data
{
    public partial class MyMoviezDBContext : DbContext
    {
        public MyMoviezDBContext()
        {
        }

        public MyMoviezDBContext(DbContextOptions<MyMoviezDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actor> Actors { get; set; } = null!;
        public virtual DbSet<Director> Directors { get; set; } = null!;
        public virtual DbSet<Distributor> Distributors { get; set; } = null!;
        public virtual DbSet<Genre> Genres { get; set; } = null!;
        public virtual DbSet<Movie> Movies { get; set; } = null!;
        public virtual DbSet<Producer> Producers { get; set; } = null!;
        public virtual DbSet<RatingAndReview> RatingAndReviews { get; set; } = null!;
        public object Genre { get; internal set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=MOMORE-SPACE\\SQLEXPRESS;Database=MyMoviezDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>(entity =>
            {
                entity.HasKey(e => e.ActorId)
                    .IsClustered(false);

                entity.ToTable("Actor");

                entity.Property(e => e.ActorName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Director>(entity =>
            {
                entity.HasKey(e => e.DirectorId)
                    .IsClustered(false);

                entity.ToTable("Director");

                entity.Property(e => e.DirectorName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Distributor>(entity =>
            {
                entity.HasKey(e => e.DistributorId)
                    .IsClustered(false);

                entity.ToTable("Distributor");

                entity.Property(e => e.DistributerName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.HasKey(e => e.GenreId)
                    .IsClustered(false);

                entity.ToTable("Genre");

                entity.Property(e => e.GenreName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasKey(e => e.MovieId)
                    .IsClustered(false);

                entity.ToTable("Movie");

                entity.Property(e => e.Duration)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MovieName)
                    .HasMaxLength(400)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Plot)
                    .HasMaxLength(1500)
                    .IsUnicode(false);

                entity.Property(e => e.ReleaseDate)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RnRid).HasColumnName("RnRId");

                entity.HasOne(d => d.Actor)
                    .WithMany(p => p.Movies)
                    .HasForeignKey(d => d.ActorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Actor_Movie");

                entity.HasOne(d => d.Director)
                    .WithMany(p => p.Movies)
                    .HasForeignKey(d => d.DirectorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Director_Movie");

                entity.HasOne(d => d.Distributor)
                    .WithMany(p => p.Movies)
                    .HasForeignKey(d => d.DistributorId)
                    .HasConstraintName("FK_Distributor_Movie");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.Movies)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Genre_Movie");

                entity.HasOne(d => d.Producer)
                    .WithMany(p => p.Movies)
                    .HasForeignKey(d => d.ProducerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Producer_Movie");

                entity.HasOne(d => d.RnR)
                    .WithMany(p => p.Movies)
                    .HasForeignKey(d => d.RnRid)
                    .HasConstraintName("FK_RatingAndReview_Movie");
            });

            modelBuilder.Entity<Producer>(entity =>
            {
                entity.HasKey(e => e.ProducerId)
                    .IsClustered(false);

                entity.ToTable("Producer");

                entity.Property(e => e.ProducerName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RatingAndReview>(entity =>
            {
                entity.HasKey(e => e.RnRid)
                    .IsClustered(false);

                entity.ToTable("RatingAndReview");

                entity.Property(e => e.RnRid).HasColumnName("RnRId");

                entity.Property(e => e.Review)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
