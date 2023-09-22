using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CRUD_Empleados_RodrigoGuzman.Features.Empeados.DTOs
{
    public class SQLServerDBContext : DbContext
    {
        public SQLServerDBContext() : base("conexion")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<SQLServerDBContext>(null);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Empleado> Empleados { get; set; }
    }
}