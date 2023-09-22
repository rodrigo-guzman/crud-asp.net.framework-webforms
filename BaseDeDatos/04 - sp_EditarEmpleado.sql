USE Evolits
GO

CREATE PROCEDURE sp_EditarEmpleado
@Id int,
@Nombre Varchar(50),
@Apellido Varchar(50),
@Email Varchar(100),
@Salario money
AS
BEGIN
	UPDATE Empleados SET Nombre= @Nombre, Apellido= @Apellido, CorreoElectronico= @Email, Salario = @Salario WHERE Id= @Id
END