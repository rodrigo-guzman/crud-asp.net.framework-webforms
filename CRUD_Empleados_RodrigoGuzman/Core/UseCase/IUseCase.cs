using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUD_Empleados_RodrigoGuzman.Core.UseCase
{
    public interface IUseCase<TInput, TOutput>
    {
        Task<TOutput> GetEmpleado(TInput input);
        Task<List<TOutput>> GetEmpleados(TInput input);
    }
}
