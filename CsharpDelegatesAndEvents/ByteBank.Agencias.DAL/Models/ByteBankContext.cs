using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ByteBank.Agencias.DAL.Models
{
    public partial class ByteBankContext : DbContext
    {
        public ByteBankContext()
        {
        }

        public ByteBankContext(DbContextOptions<ByteBankContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Agencia> Agencias { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=ByteBank;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Agencia>(entity =>
            {
                entity.HasKey(e => e.Numero);

                entity.Property(e => e.Numero)
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.Descricao)
                    .HasMaxLength(256)
                    .IsFixedLength();

                entity.Property(e => e.Endereco)
                    .HasMaxLength(256)
                    .IsFixedLength();

                entity.Property(e => e.Nome)
                    .HasMaxLength(256)
                    .IsFixedLength();

                entity.Property(e => e.Telefone)
                    .HasMaxLength(16)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
