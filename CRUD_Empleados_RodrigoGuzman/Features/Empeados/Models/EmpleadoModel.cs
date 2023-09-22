using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_Empleados_RodrigoGuzman.Features.Empeados.Models
{
    public class EmpleadoModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public decimal Salario { get; set; }
    }
}