USE Evolits
GO

CREATE PROCEDURE sp_EliminarEmpleado
@Id int
AS
BEGIN
	DELETE FROM Empleados WHERE Id= @Id
END