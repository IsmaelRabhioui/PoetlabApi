﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PoetlabApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoetlabApi.Data.Mappers
{
    public class PoemConfiguration : IEntityTypeConfiguration<Poem>
    {
        public void Configure(EntityTypeBuilder<Poem> builder)
        {
            builder.ToTable("Poem");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Title).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Author).IsRequired().HasMaxLength(50);
            builder.Property(p => p.PoemText).IsRequired();
            builder.Property(p => p.Themes).HasConversion(
                                                t => string.Join(',', t), 
                                                t => t.Split(',' , StringSplitOptions.RemoveEmptyEntries));
            builder.Property(p => p.DownVoters).HasConversion(
                                                t => string.Join(',', t),
                                                t => t.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList());
            builder.Property(p => p.UpVoters).HasConversion(
                                                t => string.Join(',', t),
                                                t => t.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList());
        }
    }
}
