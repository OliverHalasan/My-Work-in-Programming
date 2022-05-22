﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using GroceryList.Entities;

namespace GroceryList.DAL
{
    internal partial class GrocerylistContext : DbContext
    {
        public GrocerylistContext()
        {
        }

        public GrocerylistContext(DbContextOptions<GrocerylistContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Delivery> Deliveries { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderList> OrderLists { get; set; }
        public virtual DbSet<Picker> Pickers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Store> Stores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Description).IsFixedLength();
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Phone).IsFixedLength();

                entity.Property(e => e.Province).IsFixedLength();
            });

            modelBuilder.Entity<Delivery>(entity =>
            {
                entity.Property(e => e.Province).IsFixedLength();
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.LastStatusUpdate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Status)
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength()
                    .HasComment("**N**ew Order Placed, **A**ssigned to Picker, **R**ready (Picked), **O**ut on Delivery, **D**elivered, **P**icked up by Customer");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrdersCustomers_CustomerID");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StoreID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrdersStores_StoreID");
            });

            modelBuilder.Entity<OrderList>(entity =>
            {
                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderLists)
                    .HasForeignKey(d => d.OrderID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderListOrders_OrderID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderLists)
                    .HasForeignKey(d => d.ProductID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderListProducts_ProductID");
            });

            modelBuilder.Entity<Picker>(entity =>
            {
                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Pickers)
                    .HasForeignKey(d => d.StoreID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PickersStores_StoreID");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductsCategories_CategoryID");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.Property(e => e.Phone).IsFixedLength();

                entity.Property(e => e.Province).IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}