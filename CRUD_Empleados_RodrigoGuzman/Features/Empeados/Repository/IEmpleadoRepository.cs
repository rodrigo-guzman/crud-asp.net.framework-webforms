
namespace CRUD_Empleados_RodrigoGuzman.Features.Empeados.Repository
{
    using CRUD_Empleados_RodrigoGuzman.Features.Empeados.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    interface IEmpleadoRepository
    {
        Task<EmpleadoEntity> GetEmpleadoAsync(int id);
        Task<List<EmpleadoEntity>> GetEmpleadosAsync(string search);
    }
}
