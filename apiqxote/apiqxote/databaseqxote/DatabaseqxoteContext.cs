using System;
using System.Collections.Generic;
using apiqxote.Models;
using Microsoft.EntityFrameworkCore;

namespace apiqxote.databaseqxote;

public partial class DatabaseqxoteContext : DbContext
{
    public DatabaseqxoteContext()
    {
    }

    public DatabaseqxoteContext(DbContextOptions<DatabaseqxoteContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Animal> Animals { get; set; }

    public virtual DbSet<BioConcentration> BioConcentrations { get; set; }

    public virtual DbSet<Plant> Plants { get; set; }

    public virtual DbSet<Tree> Trees { get; set; }

    public virtual DbSet<TreeName> TreeNames { get; set; }

    public virtual DbSet<Zone> Zones { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("Data Source=localhost;Database=databaseqxote;Uid=root;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Animal>(entity =>
        {
            entity.HasKey(e => e.AnimalId).HasName("PRIMARY");

            entity.ToTable("animal");

            entity.HasIndex(e => e.Zone, "fk_animal_zone1");

            entity.Property(e => e.AnimalId)
                .HasColumnType("int(11)")
                .HasColumnName("animal_id");
            entity.Property(e => e.Abudance)
                .HasMaxLength(45)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("abudance");
            entity.Property(e => e.CloudCover)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("cloud_cover");
            entity.Property(e => e.Coordinates)
                .HasMaxLength(90)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("coordinates");
            entity.Property(e => e.Coverboards)
                .HasMaxLength(45)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("coverboards");
            entity.Property(e => e.Date)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.EndTime)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("datetime")
                .HasColumnName("end_time");
            entity.Property(e => e.SpeciesName)
                .HasMaxLength(45)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("species_name");
            entity.Property(e => e.StartTime)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("datetime")
                .HasColumnName("start_time");
            entity.Property(e => e.Temperature)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("temperature");
            entity.Property(e => e.WindSpeed)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("wind_speed");
            entity.Property(e => e.Zone)
                .HasMaxLength(1)
                .HasColumnName("zone");

            entity.HasOne(d => d.ZoneNavigation).WithMany(p => p.Animals)
                .HasForeignKey(d => d.Zone)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_animal_zone1");
        });

        modelBuilder.Entity<BioConcentration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("bio_concentration");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Bcf)
                .HasPrecision(10)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("bcf");
            entity.Property(e => e.Cf)
                .HasPrecision(10)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("cf");
            entity.Property(e => e.Ctree)
                .HasPrecision(10)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("ctree");
            entity.Property(e => e.R)
                .HasPrecision(10)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("r");
            entity.Property(e => e.Species)
                .HasMaxLength(45)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("species");
        });

        modelBuilder.Entity<Plant>(entity =>
        {
            entity.HasKey(e => e.PlantId).HasName("PRIMARY");

            entity.ToTable("plant");

            entity.HasIndex(e => e.Zone, "fk_plant_zone1");

            entity.Property(e => e.PlantId)
                .HasColumnType("int(11)")
                .HasColumnName("plant_id");
            entity.Property(e => e.Coordinate)
                .HasMaxLength(90)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("coordinate");
            entity.Property(e => e.Cover)
                .HasMaxLength(45)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("cover");
            entity.Property(e => e.Date)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.Humidity)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("humidity");
            entity.Property(e => e.PlotNr)
                .HasMaxLength(4)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("plot_nr");
            entity.Property(e => e.Species)
                .HasMaxLength(45)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("species");
            entity.Property(e => e.Temperature)
                .HasMaxLength(45)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("temperature");
            entity.Property(e => e.Zone)
                .HasMaxLength(1)
                .HasColumnName("zone");

            entity.HasOne(d => d.ZoneNavigation).WithMany(p => p.Plants)
                .HasForeignKey(d => d.Zone)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_plant_zone1");
        });

        modelBuilder.Entity<Tree>(entity =>
        {
            entity.HasKey(e => new { e.TreeNr, e.Zone }).HasName("PRIMARY");

            entity.ToTable("tree");

            entity.HasIndex(e => e.BioConcentrationId, "fk_tree_bio_concentration1");

            entity.HasIndex(e => e.TreeName, "fk_tree_tree_name1");

            entity.HasIndex(e => e.Zone, "fk_tree_zone1");

            entity.Property(e => e.TreeNr)
                .ValueGeneratedOnAdd()
                .HasColumnType("int(11)")
                .HasColumnName("tree_nr");
            entity.Property(e => e.Zone)
                .HasMaxLength(1)
                .HasColumnName("zone");
            entity.Property(e => e.BioConcentrationId)
                .HasColumnType("int(11)")
                .HasColumnName("bio_concentration_id");
            entity.Property(e => e.Circumference)
                .HasPrecision(10)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("circumference");
            entity.Property(e => e.Coordinate)
                .HasMaxLength(90)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("coordinate");
            entity.Property(e => e.Height)
                .HasPrecision(10)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("height");
            entity.Property(e => e.TreeName)
                .HasMaxLength(45)
                .HasColumnName("tree_name");
            entity.Property(e => e.Volume)
                .HasPrecision(10)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("volume");

            entity.HasOne(d => d.BioConcentration).WithMany(p => p.Trees)
                .HasForeignKey(d => d.BioConcentrationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tree_bio_concentration1");

            entity.HasOne(d => d.TreeNameNavigation).WithMany(p => p.Trees)
                .HasForeignKey(d => d.TreeName)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tree_tree_name1");

            entity.HasOne(d => d.ZoneNavigation).WithMany(p => p.Trees)
                .HasForeignKey(d => d.Zone)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tree_zone1");
        });

        modelBuilder.Entity<TreeName>(entity =>
        {
            entity.HasKey(e => e.TreeName1).HasName("PRIMARY");

            entity.ToTable("tree_name");

            entity.Property(e => e.TreeName1)
                .HasMaxLength(45)
                .HasColumnName("tree_name");
            entity.Property(e => e.CoordinateCount)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("coordinate_count");
        });

        modelBuilder.Entity<Zone>(entity =>
        {
            entity.HasKey(e => e.Zone1).HasName("PRIMARY");

            entity.ToTable("zone");

            entity.Property(e => e.Zone1)
                .HasMaxLength(1)
                .HasColumnName("zone");
            entity.Property(e => e.Area)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("area");
            entity.Property(e => e.Classification)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("enum('homogenuis','no_homogenuis','transition')")
                .HasColumnName("classification");
            entity.Property(e => e.Plots)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("plots");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
