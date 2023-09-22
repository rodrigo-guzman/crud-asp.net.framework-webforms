
namespace CRUD_Empleados_RodrigoGuzman.Features.Empeados.DTOs
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;

    [Table("Empleados")]
    public class Empleado
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string CorreoElectronico { get; set; }
        public decimal Salario { get; set; }

        public static void ConfigureMapping(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empleado>().ToTable("Empleados");
        }
    }

}