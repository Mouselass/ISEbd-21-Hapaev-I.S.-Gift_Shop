using System;
using System.Collections.Generic;
using System.Text;
using GiftShopDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace GiftShopDatabaseImplement
{
    public class GiftShopDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=WIN-7QPLO386PS9;Initial Catalog=GiftShopDatabaseComplicated;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Component> Components { set; get; }
        public virtual DbSet<Gift> Gifts { set; get; }
        public virtual DbSet<GiftComponent> GiftComponents { set; get; }
        public virtual DbSet<Order> Orders { set; get; }
        public virtual DbSet<Warehouse> Warehouses { set; get; }
        public virtual DbSet<WarehouseComponent> WarehouseComponents { set; get; }
        public virtual DbSet<Client> Clients { set; get; }
        public virtual DbSet<Implementer> Implementers { set; get; }
    }
}
