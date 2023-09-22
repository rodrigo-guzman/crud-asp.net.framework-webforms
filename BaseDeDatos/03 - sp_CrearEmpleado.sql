USE Evolits
GO

CREATE PROCEDURE sp_CrearEmpleado
@Nombre Varchar(50),
@Apellido Varchar(50),
@Email Varchar(100),
@Salario money
AS
BEGIN
	INSERT INTO Empleados VALUES(@Nombre, @Apellido, @Email, @Salario)
END