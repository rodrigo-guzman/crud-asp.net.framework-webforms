using CRUD_Empleados_RodrigoGuzman.Core.UseCase;
using CRUD_Empleados_RodrigoGuzman.Features.Empeados.InputOutput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Empleados_RodrigoGuzman.Features.Empeados.Interactor
{
    interface IEmpleadosUseCase : IUseCase<GetEmpleadoInput, GetEmpleadoOutput>
    {
    }
}
