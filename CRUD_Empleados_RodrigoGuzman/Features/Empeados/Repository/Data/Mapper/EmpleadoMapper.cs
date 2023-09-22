using CRUD_Empleados_RodrigoGuzman.Features.Empeados.DTOs;
using CRUD_Empleados_RodrigoGuzman.Features.Empeados.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_Empleados_RodrigoGuzman.Features.Empeados.Repository.Data.Mapper
{
    public static class EmpleadoMapper
    {
        public static EmpleadoEntity ToEmpleadoEntity(this Empleado empleadoDTO)
        {
            if (empleadoDTO == null)
            {
                return null;
            }

            return new EmpleadoEntity
            {
                Id = empleadoDTO.Id,
                Nombre = empleadoDTO.Nombre,
                Apellido = empleadoDTO.Apellido,
                CorreoElectronico = empleadoDTO.CorreoElectronico,
                Salario = empleadoDTO.Salario
            };
        }
    }
}