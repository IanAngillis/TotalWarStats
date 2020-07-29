﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TotalWarStats.Data.Context;

namespace TotalWarStats.Data.Migrations
{
    [DbContext(typeof(TotalWarStatsContext))]
    partial class TotalWarStatsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6");

            modelBuilder.Entity("TotalWarStats.Model.Entities.Match", b =>
                {
                    b.Property<string>("MatchId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<bool>("HasWon")
                        .HasColumnType("INTEGER");

                    b.Property<string>("OpponentFaction")
                        .HasColumnType("TEXT");

                    b.Property<string>("PlayerFaction")
                        .HasColumnType("TEXT");

                    b.HasKey("MatchId");

                    b.ToTable("Matches");
                });
#pragma warning restore 612, 618
        }
    }
}
