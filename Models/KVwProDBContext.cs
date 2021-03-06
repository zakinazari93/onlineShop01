// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace KVwWPF.Models
{
    public partial class KVwProDBContext : DbContext
    {
        public KVwProDBContext()
        {
        }

        public KVwProDBContext(DbContextOptions<KVwProDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Kategorie> Kategorie { get; set; }
        public virtual DbSet<Kunde> Kunde { get; set; }
        public virtual DbSet<Mitarbeiter> Mitarbeiter { get; set; }
        public virtual DbSet<ProdRechZuordnung> ProdRechZuordnung { get; set; }
        public virtual DbSet<Produkt> Produkt { get; set; }
        public virtual DbSet<Rechnung> Rechnung { get; set; }
        public virtual DbSet<Regal> Regal { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-U2358VG;Initial Catalog=KVwProDB;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Kategorie>(entity =>
            {
                entity.HasKey(e => e.KategoriePk);

                entity.Property(e => e.KategoriePk).HasColumnName("KategoriePK");

                entity.Property(e => e.KategorieName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Kunde>(entity =>
            {
                entity.HasKey(e => e.KundePk);

                entity.Property(e => e.KundePk).HasColumnName("KundePK");

                entity.Property(e => e.KundeAdresse)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.KundeEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("KundeEMail");

                entity.Property(e => e.KundeNachname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.KundeTelNr)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.KundeVorname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Passwort)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Mitarbeiter>(entity =>
            {
                entity.HasKey(e => e.MaPk);

                entity.Property(e => e.MaPk).HasColumnName("MaPK");

                entity.Property(e => e.MaNachname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MaPasswort)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MaVorname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProdRechZuordnung>(entity =>
            {
                entity.HasKey(e => new { e.ProdRechProduktFk, e.ProdRechRechnungFk });

                entity.Property(e => e.ProdRechProduktFk)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ProdRechProduktFK");

                entity.Property(e => e.ProdRechRechnungFk).HasColumnName("ProdRechRechnungFK");

                entity.HasOne(d => d.ProdRechProduktFkNavigation)
                    .WithMany(p => p.ProdRechZuordnung)
                    .HasForeignKey(d => d.ProdRechProduktFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProdRechZuordnung_Produkt");

                entity.HasOne(d => d.ProdRechRechnungFkNavigation)
                    .WithMany(p => p.ProdRechZuordnung)
                    .HasForeignKey(d => d.ProdRechRechnungFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProdRechZuordnung_Rechnung");
            });

            modelBuilder.Entity<Produkt>(entity =>
            {
                entity.HasKey(e => e.ProduktPk);

                entity.Property(e => e.ProduktPk).HasColumnName("ProduktPK");

                entity.Property(e => e.ProduktKategorieFk).HasColumnName("ProduktKategorieFK");

                entity.Property(e => e.ProduktName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProduktRegalFk).HasColumnName("ProduktRegalFK");

                entity.HasOne(d => d.ProduktKategorieFkNavigation)
                    .WithMany(p => p.Produkt)
                    .HasForeignKey(d => d.ProduktKategorieFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Produkt_Kategorie");

                entity.HasOne(d => d.ProduktRegalFkNavigation)
                    .WithMany(p => p.Produkt)
                    .HasForeignKey(d => d.ProduktRegalFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Produkt_Regal");
            });

            modelBuilder.Entity<Rechnung>(entity =>
            {
                entity.HasKey(e => e.RechnungPk);

                entity.Property(e => e.RechnungPk).HasColumnName("RechnungPK");

                entity.Property(e => e.RechDat).HasColumnType("date");

                entity.Property(e => e.RechKundeFk).HasColumnName("RechKundeFK");

                entity.HasOne(d => d.RechKundeFkNavigation)
                    .WithMany(p => p.Rechnung)
                    .HasForeignKey(d => d.RechKundeFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rechnung_Kunde");
            });

            modelBuilder.Entity<Regal>(entity =>
            {
                entity.HasKey(e => e.RegalPk);

                entity.Property(e => e.RegalPk).HasColumnName("RegalPK");

                entity.Property(e => e.RegalName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RegalOrt)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}