using System;
using System.Collections.Generic;
using System.IO;
using kino.Models;
using Microsoft.EntityFrameworkCore;

namespace kino;

public partial class KinoDbContext : DbContext
{
    public KinoDbContext()
    {
    }

    public KinoDbContext(DbContextOptions<KinoDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Archiv> Archivs { get; set; }

    public virtual DbSet<Bilet> Bilets { get; set; }

    public virtual DbSet<Film> Films { get; set; }

    public virtual DbSet<Mestum> Mesta { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite(PacHt());

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Archiv>(entity =>
        {
            entity.ToTable("Archiv");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FkFilm).HasColumnName("fkFilm");
            entity.Property(e => e.KolBilet).HasColumnName("kolBilet");
            entity.Property(e => e.Summ).HasColumnName("summ");

            entity.HasOne(d => d.FkFilmNavigation).WithMany(p => p.Archivs).HasForeignKey(d => d.FkFilm);
        });

        modelBuilder.Entity<Bilet>(entity =>
        {
            entity.ToTable("Bilet");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Data).HasColumnName("data");
            entity.Property(e => e.FkFilm).HasColumnName("fkFilm");
            entity.Property(e => e.FkUser).HasColumnName("fkUser");
            entity.Property(e => e.NumM).HasColumnName("numM");
            entity.Property(e => e.SumB).HasColumnName("sumB");

            entity.HasOne(d => d.FkFilmNavigation).WithMany(p => p.Bilets).HasForeignKey(d => d.FkFilm);

            entity.HasOne(d => d.FkUserNavigation).WithMany(p => p.Bilets).HasForeignKey(d => d.FkUser);
        });

        modelBuilder.Entity<Film>(entity =>
        {
            entity.ToTable("Film");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ColMest)
                .HasDefaultValueSql("20")
                .HasColumnName("colMest");
            entity.Property(e => e.Data).HasColumnName("data");
            entity.Property(e => e.NameFilm).HasColumnName("nameFilm");
            entity.Property(e => e.Photo).HasColumnName("photo");
            entity.Property(e => e.Sale).HasColumnName("sale");
            entity.Property(e => e.Zhanr).HasColumnName("zhanr");
        });

        modelBuilder.Entity<Mestum>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Data).HasColumnName("data");
            entity.Property(e => e.FkFilm).HasColumnName("fkFilm");
            entity.Property(e => e.M1)
                .HasDefaultValueSql("0")
                .HasColumnName("m1");
            entity.Property(e => e.M10)
                .HasDefaultValueSql("0")
                .HasColumnName("m10");
            entity.Property(e => e.M11)
                .HasDefaultValueSql("0")
                .HasColumnName("m11");
            entity.Property(e => e.M12)
                .HasDefaultValueSql("0")
                .HasColumnName("m12");
            entity.Property(e => e.M13)
                .HasDefaultValueSql("0")
                .HasColumnName("m13");
            entity.Property(e => e.M14)
                .HasDefaultValueSql("0")
                .HasColumnName("m14");
            entity.Property(e => e.M15)
                .HasDefaultValueSql("0")
                .HasColumnName("m15");
            entity.Property(e => e.M16)
                .HasDefaultValueSql("0")
                .HasColumnName("m16");
            entity.Property(e => e.M17)
                .HasDefaultValueSql("0")
                .HasColumnName("m17");
            entity.Property(e => e.M18)
                .HasDefaultValueSql("0")
                .HasColumnName("m18");
            entity.Property(e => e.M19)
                .HasDefaultValueSql("0")
                .HasColumnName("m19");
            entity.Property(e => e.M2)
                .HasDefaultValueSql("0")
                .HasColumnName("m2");
            entity.Property(e => e.M20)
                .HasDefaultValueSql("0")
                .HasColumnName("m20");
            entity.Property(e => e.M3)
                .HasDefaultValueSql("0")
                .HasColumnName("m3");
            entity.Property(e => e.M4)
                .HasDefaultValueSql("0")
                .HasColumnName("m4");
            entity.Property(e => e.M5)
                .HasDefaultValueSql("0")
                .HasColumnName("m5");
            entity.Property(e => e.M6)
                .HasDefaultValueSql("0")
                .HasColumnName("m6");
            entity.Property(e => e.M7)
                .HasDefaultValueSql("0")
                .HasColumnName("m7");
            entity.Property(e => e.M8)
                .HasDefaultValueSql("0")
                .HasColumnName("m8");
            entity.Property(e => e.M9)
                .HasDefaultValueSql("0")
                .HasColumnName("m9");

            entity.HasOne(d => d.FkFilmNavigation).WithMany(p => p.Mesta).HasForeignKey(d => d.FkFilm);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NameRole).HasColumnName("nameRole");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Fio).HasColumnName("fio");
            entity.Property(e => e.FkRole).HasColumnName("fkRole");
            entity.Property(e => e.Login).HasColumnName("login");
            entity.Property(e => e.Pass).HasColumnName("pass");

            entity.HasOne(d => d.FkRoleNavigation).WithMany(p => p.Users).HasForeignKey(d => d.FkRole);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    //Относительный путь
    static private string PacHt()
    {
        var x = Directory.GetCurrentDirectory();
        var y = Directory.GetParent(x).FullName;
        var c = Directory.GetParent(y).FullName;
        var r = "Data Source=" + Directory.GetParent(c).FullName + @"\DA\kinoDB.db";
        return r;
    }


    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
