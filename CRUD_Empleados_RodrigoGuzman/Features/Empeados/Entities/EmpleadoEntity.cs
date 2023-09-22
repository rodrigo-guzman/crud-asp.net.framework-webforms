using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_Empleados_RodrigoGuzman.Features.Empeados.Entities
{
    public class EmpleadoEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string CorreoElectronico { get; set; }
        public decimal Salario { get; set; }
    }
}