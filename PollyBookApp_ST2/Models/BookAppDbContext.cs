﻿using Microsoft.EntityFrameworkCore;
using PollyBookApp_ST2.Models.ReadingItems;
using PollyBookApp_ST2.Models.Users;

namespace PollyBookApp_ST2.Models
{
    public class BookAppDbContext: DbContext
    {
        public DbSet<ReadingItem> ReadingItems { get; set; }
        public DbSet<User> Users { get; set; }


        public BookAppDbContext(DbContextOptions<BookAppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReadingItem>()
                .HasDiscriminator<string>("ItemType")
                .HasValue<Book>("Book")
                .HasValue<Magazine>("Magazine")
                .HasValue<Comics>("Comics");

            base.OnModelCreating(modelBuilder);
        }
    }
}
