﻿using BlogApplication2.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogApplication2.Data
{
    public class BlogRecordsContext : DbContext
    {
        public BlogRecordsContext(DbContextOptions<BlogRecordsContext> options) : base(options)
        {
            
        }

        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogPost>().ToTable("BlogPost");
        }
    }
}