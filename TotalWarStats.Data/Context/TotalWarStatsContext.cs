using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using TotalWarStats.Model.Entities;

namespace TotalWarStats.Data.Context
{
    public class TotalWarStatsContext : DbContext
    {
        public DbSet<Model.Entities.Match> Matches { get; set; }

        public TotalWarStatsContext(DbContextOptions<TotalWarStatsContext> options) : base(options)
        {
        }

        public TotalWarStatsContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=totalwarstats.db");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
