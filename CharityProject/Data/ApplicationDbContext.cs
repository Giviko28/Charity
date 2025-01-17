﻿using CharityProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CharityProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Donation>()
        //        .Property(p => p.Created)
        //        .HasDefaultValueSql("getdate()");

        //}
    }
}
