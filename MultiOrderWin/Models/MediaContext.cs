using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MultiOrderWin.Models
{
    public class MediaContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrdersEquipment> OrdersEquipments { get; set; }

        public MediaContext()
            : base("MultiOrderConnectionString")
        {
            
        }

        public ObjectContext ObjectContext()
        {
            return (this as IObjectContextAdapter).ObjectContext;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrdersEquipment>()
                .HasKey(cp => new { cp.OrderId, cp.EquipmentId });

            modelBuilder.Entity<Order>()
                        .HasMany(c => c.OrdersEquipment)
                        .WithRequired()
                        .HasForeignKey(cp => cp.OrderId);

            modelBuilder.Entity<Equipment>()
                        .HasMany(p => p.OrdersEquipment)
                        .WithRequired()
                        .HasForeignKey(cp => cp.EquipmentId);
        }
    }
}
