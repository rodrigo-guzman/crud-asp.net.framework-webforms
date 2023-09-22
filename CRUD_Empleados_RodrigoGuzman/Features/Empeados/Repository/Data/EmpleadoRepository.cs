using CRUD_Empleados_RodrigoGuzman.Features.Empeados.DTOs;
using CRUD_Empleados_RodrigoGuzman.Features.Empeados.Entities;
using CRUD_Empleados_RodrigoGuzman.Features.Empeados.Repository.Data.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CRUD_Empleados_RodrigoGuzman.Features.Empeados.Repository.Data
{
    public class EmpleadoRepository : IEmpleadoRepository
    {
        SQLServerDBContext dbContext;
        public EmpleadoRepository(SQLServerDBContext context)
        {
            dbContext = context;
        }

        public Task<EmpleadoEntity> GetEmpleadoAsync(int id)
        {
            SQLServerDBContext dbContext = new SQLServerDBContext();
            var empleado = dbContext.Empleados
                .FirstOrDefault(e => e.Id == id);
            return Task.FromResult(empleado.ToEmpleadoEntity());
        }

        public Task<List<EmpleadoEntity>> GetEmpleadosAsync(string search)
        {
            List<EmpleadoEntity> ListaEmpleados = new List<EmpleadoEntity>();

            SQLServerDBContext dbContext = new SQLServerDBContext();
            var empleados = dbContext.Empleados
                .Where(e => e.Nombre.Contains(search) || e.Apellido.Contains(search))
                .OrderBy(e => e.Apellido).ThenBy(e => e.Nombre);

            foreach (var empleado in empleados)
            {
                ListaEmpleados.Add(empleado.ToEmpleadoEntity());
            }
            return Task.FromResult(ListaEmpleados);
        }
    }
}