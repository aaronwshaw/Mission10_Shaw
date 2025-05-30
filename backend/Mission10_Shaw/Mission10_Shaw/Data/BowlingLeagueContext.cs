﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Mission10_Shaw.Data;

public partial class BowlingLeagueContext : DbContext
{
    public BowlingLeagueContext()
    {
    }

    public BowlingLeagueContext(DbContextOptions<BowlingLeagueContext> options)
        : base(options)
    {
    }

    //public virtual DbSet<Bowler> Bowlers { get; set; }

    //public virtual DbSet<Team> Teams { get; set; }

    //All the recommendation table stuff
    public DbSet<SharedArticle> SharedArticles { get; set; }
    public DbSet<ContentRecommendation> ContentRecommendations { get; set; }
    public DbSet<CollaborativeRecommendation> CollaborativeRecommendations { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=./RecommendationDB.sqlite");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Bowler>(entity =>
        //{
        //    entity.HasIndex(e => e.BowlerLastName, "BowlerLastName");

        //    entity.HasIndex(e => e.TeamId, "BowlersTeamID");

        //    entity.Property(e => e.BowlerId)
        //        .HasColumnType("INT")
        //        .HasColumnName("BowlerID");
        //    entity.Property(e => e.BowlerAddress).HasColumnType("nvarchar (50)");
        //    entity.Property(e => e.BowlerCity).HasColumnType("nvarchar (50)");
        //    entity.Property(e => e.BowlerFirstName).HasColumnType("nvarchar (50)");
        //    entity.Property(e => e.BowlerLastName).HasColumnType("nvarchar (50)");
        //    entity.Property(e => e.BowlerMiddleInit).HasColumnType("nvarchar (1)");
        //    entity.Property(e => e.BowlerPhoneNumber).HasColumnType("nvarchar (14)");
        //    entity.Property(e => e.BowlerState).HasColumnType("nvarchar (2)");
        //    entity.Property(e => e.BowlerZip).HasColumnType("nvarchar (10)");
        //    entity.Property(e => e.TeamId)
        //        .HasColumnType("INT")
        //        .HasColumnName("TeamID");

        //    entity.HasOne(d => d.Team).WithMany(p => p.Bowlers).HasForeignKey(d => d.TeamId);
        //});

        //modelBuilder.Entity<Team>(entity =>
        //{
        //    entity.HasIndex(e => e.TeamId, "TeamID").IsUnique();

        //    entity.Property(e => e.TeamId)
        //        .HasColumnType("INT")
        //        .HasColumnName("TeamID");
        //    entity.Property(e => e.CaptainId)
        //        .HasColumnType("INT")
        //        .HasColumnName("CaptainID");
        //    entity.Property(e => e.TeamName).HasColumnType("nvarchar (50)");
        //});

        modelBuilder.Entity<SharedArticle>(entity =>
        {
            entity.HasKey(e => e.ContentId);
            entity.Property(e => e.Title).HasColumnType("nvarchar (255)");
        });

        modelBuilder.Entity<ContentRecommendation>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        modelBuilder.Entity<CollaborativeRecommendation>(entity =>
        {
            entity.HasKey(e => e.Id);
        });


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
