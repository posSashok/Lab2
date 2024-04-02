// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Proekt.Models;

public partial class CinemaContext : DbContext
{
    public CinemaContext()
    {
    }

    public CinemaContext(DbContextOptions<CinemaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Film> Films { get; set; }

    public virtual DbSet<Kinozal> Kinozals { get; set; }

    public virtual DbSet<Klient> Klients { get; set; }

    public virtual DbSet<Personal> Personals { get; set; }

    public virtual DbSet<Salecard> Salecards { get; set; }

    public virtual DbSet<Seanse> Seanses { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Cinema;Username=postgres;Password=1303");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Film>(entity =>
        {
            entity.HasKey(e => e.FilmId).HasName("films_pkey");

            entity.ToTable("films");

            entity.Property(e => e.FilmId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("film_id");
            entity.Property(e => e.Country)
                .HasMaxLength(30)
                .HasColumnName("country");
            entity.Property(e => e.FilmName)
                .HasMaxLength(30)
                .HasColumnName("film_name");
            entity.Property(e => e.Janr)
                .HasMaxLength(30)
                .HasColumnName("janr");
            entity.Property(e => e.Long)
                .HasMaxLength(30)
                .HasColumnName("long");
            entity.Property(e => e.Old)
                .HasMaxLength(255)
                .HasColumnName("old");
            entity.Property(e => e.Rating)
                .HasMaxLength(30)
                .HasColumnName("rating");
        });

        modelBuilder.Entity<Kinozal>(entity =>
        {
            entity.HasKey(e => e.ZalId).HasName("kinozals_pkey");

            entity.ToTable("kinozals");

            entity.Property(e => e.ZalId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("zal_id");
            entity.Property(e => e.KolvoMpk).HasColumnName("kolvo_mpk");
            entity.Property(e => e.Vmestimost).HasColumnName("vmestimost");
        });

        modelBuilder.Entity<Klient>(entity =>
        {
            entity.HasKey(e => e.KlientId).HasName("klients_pkey");

            entity.ToTable("klients");

            entity.Property(e => e.KlientId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("klient_id");
            entity.Property(e => e.Bday).HasColumnName("bday");
            entity.Property(e => e.Familia)
                .HasMaxLength(30)
                .HasColumnName("familia");
            entity.Property(e => e.Kontact)
                .HasMaxLength(11)
                .IsFixedLength()
                .HasColumnName("kontact");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
            entity.Property(e => e.Otchestvo)
                .HasMaxLength(30)
                .HasColumnName("otchestvo");
        });

        modelBuilder.Entity<Personal>(entity =>
        {
            entity.HasKey(e => e.NomPers).HasName("personal_pkey");

            entity.ToTable("personal");

            entity.Property(e => e.NomPers)
                .UseIdentityAlwaysColumn()
                .HasColumnName("nom_pers");
            entity.Property(e => e.Doljnost)
                .HasMaxLength(50)
                .HasColumnName("doljnost");
            entity.Property(e => e.Familia)
                .HasMaxLength(30)
                .HasColumnName("familia");
            entity.Property(e => e.KontNom)
                .HasMaxLength(11)
                .IsFixedLength()
                .HasColumnName("kont_nom");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
            entity.Property(e => e.Otchestvo)
                .HasMaxLength(30)
                .HasColumnName("otchestvo");
        });

        modelBuilder.Entity<Salecard>(entity =>
        {
            entity.HasKey(e => e.KlientId).HasName("salecards_pkey");

            entity.ToTable("salecards");

            entity.Property(e => e.KlientId)
                .ValueGeneratedOnAdd()
                .UseIdentityAlwaysColumn()
                .HasColumnName("klient_id");
            entity.Property(e => e.Bonus).HasColumnName("bonus");

            entity.HasOne(d => d.Klient).WithOne(p => p.Salecard)
                .HasForeignKey<Salecard>(d => d.KlientId)
                .HasConstraintName("salecards_klient_id_fkey");
        });

        modelBuilder.Entity<Seanse>(entity =>
        {
            entity.HasKey(e => e.SeansId).HasName("seanses_pkey");

            entity.ToTable("seanses");

            entity.Property(e => e.SeansId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("seans_id");
            entity.Property(e => e.FilmId).HasColumnName("film_id");
            entity.Property(e => e.Nachalo)
                .HasColumnType("timestamp(4) without time zone")
                .HasColumnName("nachalo");
            entity.Property(e => e.OstMest).HasColumnName("ost_mest");
            entity.Property(e => e.Ps)
                .HasMaxLength(10)
                .HasColumnName("ps");

            entity.HasOne(d => d.Film).WithMany(p => p.Seanses)
                .HasForeignKey(d => d.FilmId)
                .HasConstraintName("seanses_film_id_fkey");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.TicketId).HasName("tickets_pkey");

            entity.ToTable("tickets");

            entity.Property(e => e.TicketId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ticket_id");
            entity.Property(e => e.Cost)
                .HasPrecision(10, 2)
                .HasColumnName("cost");
            entity.Property(e => e.Finaly)
                .HasPrecision(10, 2)
                .HasColumnName("finaly");
            entity.Property(e => e.KlientId).HasColumnName("klient_id");
            entity.Property(e => e.Sale)
                .HasPrecision(10, 2)
                .HasColumnName("sale");
            entity.Property(e => e.SeansId).HasColumnName("seans_id");
            entity.Property(e => e.ZalId).HasColumnName("zal_id");

            entity.HasOne(d => d.Klient).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.KlientId)
                .HasConstraintName("tickets_klient_id_fkey");

            entity.HasOne(d => d.Seans).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.SeansId)
                .HasConstraintName("tickets_seans_id_fkey");

            entity.HasOne(d => d.Zal).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.ZalId)
                .HasConstraintName("tickets_zal_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
