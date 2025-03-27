using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Test2PEPRN222.Models;

public partial class LibraryManagementContext : DbContext
{
    public LibraryManagementContext()
    {
    }

    public LibraryManagementContext(DbContextOptions<LibraryManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<BookCopy> BookCopies { get; set; }

    public virtual DbSet<BorrowHistory> BorrowHistories { get; set; }

    public virtual DbSet<Borrower> Borrowers { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:MyStockDB");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.AuthorId).HasName("PK__Authors__70DAFC34A3E76EDD");

            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.BookId).HasName("PK__Books__3DE0C207228EC30C");

            entity.Property(e => e.Title).HasMaxLength(255);

            entity.HasOne(d => d.Genre).WithMany(p => p.Books)
                .HasForeignKey(d => d.GenreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Books__GenreId__398D8EEE");

            entity.HasMany(d => d.Authors).WithMany(p => p.Books)
                .UsingEntity<Dictionary<string, object>>(
                    "BookAuthor",
                    r => r.HasOne<Author>().WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__BookAutho__Autho__3F466844"),
                    l => l.HasOne<Book>().WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__BookAutho__BookI__3E52440B"),
                    j =>
                    {
                        j.HasKey("BookId", "AuthorId").HasName("PK__BookAuth__6AED6DC43C29E09F");
                        j.ToTable("BookAuthors");
                    });
        });

        modelBuilder.Entity<BookCopy>(entity =>
        {
            entity.HasKey(e => e.CopyId).HasName("PK__BookCopi__C26CCCC5548AD13F");

            entity.Property(e => e.Status).HasMaxLength(20);

            entity.HasOne(d => d.Book).WithMany(p => p.BookCopies)
                .HasForeignKey(d => d.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BookCopie__BookI__4222D4EF");
        });

        modelBuilder.Entity<BorrowHistory>(entity =>
        {
            entity.HasKey(e => e.BorrowId).HasName("PK__BorrowHi__4295F83FA85BF0CB");

            entity.ToTable("BorrowHistory");

            entity.HasOne(d => d.Borrower).WithMany(p => p.BorrowHistories)
                .HasForeignKey(d => d.BorrowerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BorrowHis__Borro__47DBAE45");

            entity.HasOne(d => d.Copy).WithMany(p => p.BorrowHistories)
                .HasForeignKey(d => d.CopyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BorrowHis__CopyI__46E78A0C");
        });

        modelBuilder.Entity<Borrower>(entity =>
        {
            entity.HasKey(e => e.BorrowerId).HasName("PK__Borrower__568EDB576D6DA704");

            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.GenreId).HasName("PK__Genres__0385057E68B1D9B8");

            entity.Property(e => e.GenreName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
