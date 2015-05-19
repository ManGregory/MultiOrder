using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MultiOrderWin.Models
{
    class MediaContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<Order> Orders { get; set; }

        public MediaContext()
            : base("MultiOrderConnectionString")
        {
            
        }
    }
}
