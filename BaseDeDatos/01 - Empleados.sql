CREATE DATABASE Evolits
GO

USE [Evolits]
GO

/****** Object:  Table [dbo].[Empleados]    Script Date: 17/9/2023 15:23:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Empleados](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[CorreoElectronico] [varchar](100) NOT NULL,
	[Salario] [money] NOT NULL,
 CONSTRAINT [PK_Empleados] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

Insert into empleados values('Juan', 'Perez', 'juanperez@gmail.com', 100000)
Insert into empleados values('Pedro', 'Gomez', 'pedrogomez@gmail.com', 150000)
Insert into empleados values('Luis', 'Gonzalez', 'luisgonzalez@gmail.com', 200000)