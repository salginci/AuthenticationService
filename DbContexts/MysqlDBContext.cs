﻿using System; 
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities;

namespace WebApi.DbContexts
{
    public class MyDBContext : DbContext
    {
        
        public DbSet<User> Users { get; set; }

        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Use Fluent API to configure  

            // Map entities to tables  
        
            modelBuilder.Entity<User>().ToTable("Users");

            // Configure Primary Keys  
          
            modelBuilder.Entity<User>().HasKey(u => u.Id).HasName("PK_Users");

            // Configure indexes  
   
            modelBuilder.Entity<User>().HasIndex(u => u.FirstName).HasDatabaseName("Idx_FirstName");
            modelBuilder.Entity<User>().HasIndex(u => u.LastName).HasDatabaseName("Idx_LastName");

           

            modelBuilder.Entity<User>().Property(u => u.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<User>().Property(u => u.FirstName).HasColumnType("nvarchar(50)").IsRequired();
            modelBuilder.Entity<User>().Property(u => u.LastName).HasColumnType("nvarchar(50)").IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Password).HasColumnType("nvarchar(50)").IsRequired();
            modelBuilder.Entity<User>().Property(u => u.CreationDateTime).HasColumnType("datetime").IsRequired();
            modelBuilder.Entity<User>().Property(u => u.LastUpdateDateTime).HasColumnType("datetime").IsRequired(false);

        }
    }
}

