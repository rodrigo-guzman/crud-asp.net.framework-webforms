using CRUD_Empleados_RodrigoGuzman.Features.Empeados.Entities;
using CRUD_Empleados_RodrigoGuzman.Features.Empeados.InputOutput;
using CRUD_Empleados_RodrigoGuzman.Features.Empeados.Interactor;
using CRUD_Empleados_RodrigoGuzman.Features.Empeados.Repository;
using CRUD_Empleados_RodrigoGuzman.Features.Empeados.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CRUD_Empleados_RodrigoGuzman.Features.Empeados
{
    public class EmpleadosUseCase : IEmpleadosUseCase
    {
        private readonly IEmpleadoRepository repository;

        public EmpleadosUseCase()
        {
            repository = new EmpleadoRepository(new DTOs.SQLServerDBContext());
        }

        public async Task<GetEmpleadoOutput> GetEmpleado(GetEmpleadoInput input)
        {
            try
            {
                EmpleadoEntity empleado = await GetEmpleadoById(input);

            return new GetEmpleadoOutput()
            {
                Id = empleado.Id,
                Nombre = empleado.Nombre,
                Apellido = empleado.Apellido,
                Email = empleado.CorreoElectronico,
                Salario = empleado.Salario
            };

            }
            catch (Exception e)
            {
                return new GetEmpleadoOutput()
                {
                    Id = 0
                };
            }
        }
        public async Task<List<GetEmpleadoOutput>> GetEmpleados(GetEmpleadoInput input)
        {
            try
            {
                List<EmpleadoEntity> empleados = await GetEmpleadosLista(input);
                List<GetEmpleadoOutput> empleadosOutputs = empleados
                .Select(e => new GetEmpleadoOutput
                {
                    Id = e.Id,
                    Nombre = e.Nombre,
                    Apellido = e.Apellido,
                    Email = e.CorreoElectronico,
                    Salario = e.Salario
                })
                .ToList();

                return empleadosOutputs;

            }
            catch (Exception e)
            {
                return new List<GetEmpleadoOutput>(){};
            }
        }
        private async Task<EmpleadoEntity> GetEmpleadoById(GetEmpleadoInput input)
        {
            var empleado = await this.repository.GetEmpleadoAsync(input.Id);
            return empleado;
        }
        private async Task<List<EmpleadoEntity>> GetEmpleadosLista(GetEmpleadoInput input)
        {
            var empleados = await this.repository.GetEmpleadosAsync(input.Search);
            return empleados;
        }
    }
}