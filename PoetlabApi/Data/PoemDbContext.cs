using Microsoft.EntityFrameworkCore;
using PoetlabApi.Data.Mappers;
using PoetlabApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoetlabApi.Data
{
    public class PoemDbContext : DbContext
    {
        public DbSet<Poem> Poems { get; set; }

        public PoemDbContext(DbContextOptions<PoemDbContext> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new PoemConfiguration());
        }
    }
}
