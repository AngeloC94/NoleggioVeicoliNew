using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NoleggioVeicoliNew.domain;

public partial class NoleggioDbContext : DbContext
{
    public NoleggioDbContext()
    {
    }

    public NoleggioDbContext(DbContextOptions<NoleggioDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Auto> Autos { get; set; }

    public virtual DbSet<Clienti> Clientis { get; set; }

    public virtual DbSet<Furgoni> Furgonis { get; set; }

    public virtual DbSet<Moto> Motos { get; set; }

    public virtual DbSet<Noleggi> Noleggis { get; set; }

    public virtual DbSet<Syspatenti> Syspatentis { get; set; }

    public virtual DbSet<Veicoli> Veicolis { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(LocalDb)\\MSSQLLocalDB;Database=noleggio-v2;Trusted_Connection=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Veicoli>(entity =>
        {
            entity.ToTable("Veicoli");
            entity.UseTptMappingStrategy();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Modello).HasMaxLength(50);
            entity.Property(e => e.Targa)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<Auto>(entity =>
        {
            entity.ToTable("Auto");
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Furgoni>(entity =>
        {
            entity.ToTable("Furgoni");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Moto>(entity =>
        {
            entity.ToTable("Moto");

            entity.Property(e => e.Id).ValueGeneratedNever();

        });

        modelBuilder.Entity<Clienti>(entity =>
               {
                   entity.ToTable("Clienti");

                   entity.Property(e => e.Id).ValueGeneratedNever();
                   entity.Property(e => e.CodiceCliente).HasMaxLength(50);
                   entity.Property(e => e.Nome).HasMaxLength(50);

                   entity.HasOne(d => d.TipoPatenteNavigation).WithMany(p => p.Clientis)
                       .HasForeignKey(d => d.TipoPatente)
                       .OnDelete(DeleteBehavior.ClientSetNull)
                       .HasConstraintName("FK_Clienti_TipoPatente");
               });

        modelBuilder.Entity<Noleggi>(entity =>
        {
            entity.ToTable("Noleggi");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Noleggis)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK_Noleggi_Clienti");

            entity.HasOne(d => d.IdVeicoloNavigation).WithMany(p => p.Noleggis)
                .HasForeignKey(d => d.IdVeicolo)
                .HasConstraintName("FK_Noleggi_Veicoli");
        });

        modelBuilder.Entity<Syspatenti>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_TipoPatente");

            entity.ToTable("SYSPatenti");

            entity.Property(e => e.Tipo)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
