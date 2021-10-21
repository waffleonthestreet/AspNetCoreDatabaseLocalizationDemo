using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using AspNetCoreDatabaseLocalizationDemo.Models;

#nullable disable

namespace AspNetCoreDatabaseLocalizationDemo.Data
{
    public partial class MyAppDbContext : DbContext
    {
        public MyAppDbContext()
        {
        }

        public MyAppDbContext(DbContextOptions<MyAppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Lang> Langs { get; set; }
        public virtual DbSet<StringResource> StringResources { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Korean_Wansung_CI_AS");

            modelBuilder.Entity<Lang>(entity =>
            {
                entity.HasKey(e => e.LanguageId)
                    .HasName("PK__LANG__2E35DD9D1FAB3C6E");

                entity.ToTable("LANG");

                entity.Property(e => e.LanguageId)
                    .ValueGeneratedNever()
                    .HasColumnName("LANGUAGE_ID");

                entity.Property(e => e.Culture)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("CULTURE");

                entity.Property(e => e.LanguageName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("LANGUAGE_NAME");
            });

            modelBuilder.Entity<StringResource>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.LanguageId });

                entity.ToTable("STRING_RESOURCES");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.LanguageId).HasColumnName("LANGUAGE_ID");

                entity.Property(e => e.ResourceName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("RESOURCE_NAME");

                entity.Property(e => e.ResourceValue)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("RESOURCE_VALUE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
