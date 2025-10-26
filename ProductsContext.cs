﻿using Microsoft.EntityFrameworkCore;

namespace PointOfSale.EntityFramework;

public class ProductsContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite($"Data Source=products.db");
}