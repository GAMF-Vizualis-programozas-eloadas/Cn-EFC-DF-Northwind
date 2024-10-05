﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using EF Core template.
// Code is generated on: 2021. 03. 21. 11:46:02
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace Northwind
{

    public partial class cnNorthwind : DbContext
    {

        public cnNorthwind() :
            base()
        {
            OnCreated();
        }

        public cnNorthwind(DbContextOptions<cnNorthwind> options) :
            base(options)
        {
            OnCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured ||
                (!optionsBuilder.Options.Extensions.OfType<RelationalOptionsExtension>().Any(ext => !string.IsNullOrEmpty(ext.ConnectionString) || ext.Connection != null) &&
                 !optionsBuilder.Options.Extensions.Any(ext => !(ext is RelationalOptionsExtension) && !(ext is CoreOptionsExtension))))
            {
                optionsBuilder.UseSqlServer(GetConnectionString("csNorthwind"));
            }
            CustomizeConfiguration(ref optionsBuilder);
            base.OnConfiguring(optionsBuilder);
        }

        private static string GetConnectionString(string connectionStringName)
        {
            var configurationBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: false);
            var configuration = configurationBuilder.Build();
            return configuration.GetConnectionString(connectionStringName);
        }

        partial void CustomizeConfiguration(ref DbContextOptionsBuilder optionsBuilder);

        public virtual DbSet<Category> Categories
        {
            get;
            set;
        }

        public virtual DbSet<Product> Products
        {
            get;
            set;
        }

        public virtual DbSet<Supplier> Suppliers
        {
            get;
            set;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            this.CategoryMapping(modelBuilder);
            this.CustomizeCategoryMapping(modelBuilder);

            this.ProductMapping(modelBuilder);
            this.CustomizeProductMapping(modelBuilder);

            this.SupplierMapping(modelBuilder);
            this.CustomizeSupplierMapping(modelBuilder);

            RelationshipsMapping(modelBuilder);
            CustomizeMapping(ref modelBuilder);
        }

        #region Category Mapping

        private void CategoryMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().ToTable(@"Categories", @"dbo");
            modelBuilder.Entity<Category>().Property(x => x.CategoryID).HasColumnName(@"CategoryID").HasColumnType(@"int").IsRequired().ValueGeneratedOnAdd().HasPrecision(10, 0);
            modelBuilder.Entity<Category>().Property(x => x.CategoryName).HasColumnName(@"CategoryName").HasColumnType(@"nvarchar(15)").IsRequired().ValueGeneratedNever().HasMaxLength(15);
            modelBuilder.Entity<Category>().Property(x => x.Description).HasColumnName(@"Description").HasColumnType(@"ntext").ValueGeneratedNever().HasMaxLength(1073741823);
            modelBuilder.Entity<Category>().Property(x => x.Picture).HasColumnName(@"Picture").HasColumnType(@"image").ValueGeneratedNever().HasMaxLength(2147483647);
            modelBuilder.Entity<Category>().HasKey(@"CategoryID");
        }

        partial void CustomizeCategoryMapping(ModelBuilder modelBuilder);

        #endregion

        #region Product Mapping

        private void ProductMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable(@"Products", @"dbo");
            modelBuilder.Entity<Product>().Property(x => x.ProductID).HasColumnName(@"ProductID").HasColumnType(@"int").IsRequired().ValueGeneratedOnAdd().HasPrecision(10, 0);
            modelBuilder.Entity<Product>().Property(x => x.ProductName).HasColumnName(@"ProductName").HasColumnType(@"nvarchar(40)").IsRequired().ValueGeneratedNever().HasMaxLength(40);
            modelBuilder.Entity<Product>().Property(x => x.SupplierID).HasColumnName(@"SupplierID").HasColumnType(@"int").ValueGeneratedNever().HasPrecision(10, 0);
            modelBuilder.Entity<Product>().Property(x => x.CategoryID).HasColumnName(@"CategoryID").HasColumnType(@"int").ValueGeneratedNever().HasPrecision(10, 0);
            modelBuilder.Entity<Product>().Property(x => x.QuantityPerUnit).HasColumnName(@"QuantityPerUnit").HasColumnType(@"nvarchar(20)").ValueGeneratedNever().HasMaxLength(20);
            modelBuilder.Entity<Product>().Property(x => x.UnitPrice).HasColumnName(@"UnitPrice").HasColumnType(@"money").ValueGeneratedNever().HasPrecision(19, 4).HasDefaultValueSql(@"0");
            modelBuilder.Entity<Product>().Property(x => x.UnitsInStock).HasColumnName(@"UnitsInStock").HasColumnType(@"smallint").ValueGeneratedNever().HasPrecision(5, 0).HasDefaultValueSql(@"0");
            modelBuilder.Entity<Product>().Property(x => x.UnitsOnOrder).HasColumnName(@"UnitsOnOrder").HasColumnType(@"smallint").ValueGeneratedNever().HasPrecision(5, 0).HasDefaultValueSql(@"0");
            modelBuilder.Entity<Product>().Property(x => x.ReorderLevel).HasColumnName(@"ReorderLevel").HasColumnType(@"smallint").ValueGeneratedNever().HasPrecision(5, 0).HasDefaultValueSql(@"0");
            modelBuilder.Entity<Product>().Property(x => x.Discontinued).HasColumnName(@"Discontinued").HasColumnType(@"bit").IsRequired().ValueGeneratedOnAdd().HasDefaultValueSql(@"0");
            modelBuilder.Entity<Product>().HasKey(@"ProductID");
        }

        partial void CustomizeProductMapping(ModelBuilder modelBuilder);

        #endregion

        #region Supplier Mapping

        private void SupplierMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Supplier>().ToTable(@"Suppliers", @"dbo");
            modelBuilder.Entity<Supplier>().Property(x => x.SupplierID).HasColumnName(@"SupplierID").HasColumnType(@"int").IsRequired().ValueGeneratedOnAdd().HasPrecision(10, 0);
            modelBuilder.Entity<Supplier>().Property(x => x.CompanyName).HasColumnName(@"CompanyName").HasColumnType(@"nvarchar(40)").IsRequired().ValueGeneratedNever().HasMaxLength(40);
            modelBuilder.Entity<Supplier>().Property(x => x.ContactName).HasColumnName(@"ContactName").HasColumnType(@"nvarchar(30)").ValueGeneratedNever().HasMaxLength(30);
            modelBuilder.Entity<Supplier>().Property(x => x.ContactTitle).HasColumnName(@"ContactTitle").HasColumnType(@"nvarchar(30)").ValueGeneratedNever().HasMaxLength(30);
            modelBuilder.Entity<Supplier>().Property(x => x.Address).HasColumnName(@"Address").HasColumnType(@"nvarchar(60)").ValueGeneratedNever().HasMaxLength(60);
            modelBuilder.Entity<Supplier>().Property(x => x.City).HasColumnName(@"City").HasColumnType(@"nvarchar(15)").ValueGeneratedNever().HasMaxLength(15);
            modelBuilder.Entity<Supplier>().Property(x => x.Region).HasColumnName(@"Region").HasColumnType(@"nvarchar(15)").ValueGeneratedNever().HasMaxLength(15);
            modelBuilder.Entity<Supplier>().Property(x => x.PostalCode).HasColumnName(@"PostalCode").HasColumnType(@"nvarchar(10)").ValueGeneratedNever().HasMaxLength(10);
            modelBuilder.Entity<Supplier>().Property(x => x.Country).HasColumnName(@"Country").HasColumnType(@"nvarchar(15)").ValueGeneratedNever().HasMaxLength(15);
            modelBuilder.Entity<Supplier>().Property(x => x.Phone).HasColumnName(@"Phone").HasColumnType(@"nvarchar(24)").ValueGeneratedNever().HasMaxLength(24);
            modelBuilder.Entity<Supplier>().Property(x => x.Fax).HasColumnName(@"Fax").HasColumnType(@"nvarchar(24)").ValueGeneratedNever().HasMaxLength(24);
            modelBuilder.Entity<Supplier>().Property(x => x.HomePage).HasColumnName(@"HomePage").HasColumnType(@"ntext").ValueGeneratedNever().HasMaxLength(1073741823);
            modelBuilder.Entity<Supplier>().HasKey(@"SupplierID");
        }

        partial void CustomizeSupplierMapping(ModelBuilder modelBuilder);

        #endregion

        private void RelationshipsMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasMany(x => x.Products).WithOne(op => op.Category).HasForeignKey(@"CategoryID").IsRequired(false);

            modelBuilder.Entity<Product>().HasOne(x => x.Category).WithMany(op => op.Products).HasForeignKey(@"CategoryID").IsRequired(false);
            modelBuilder.Entity<Product>().HasOne(x => x.Supplier).WithMany(op => op.Products).HasForeignKey(@"SupplierID").IsRequired(false);

            modelBuilder.Entity<Supplier>().HasMany(x => x.Products).WithOne(op => op.Supplier).HasForeignKey(@"SupplierID").IsRequired(false);
        }

        partial void CustomizeMapping(ref ModelBuilder modelBuilder);

        public bool HasChanges()
        {
            return ChangeTracker.Entries().Any(e => e.State == Microsoft.EntityFrameworkCore.EntityState.Added || e.State == Microsoft.EntityFrameworkCore.EntityState.Modified || e.State == Microsoft.EntityFrameworkCore.EntityState.Deleted);
        }

        partial void OnCreated();
    }
}
