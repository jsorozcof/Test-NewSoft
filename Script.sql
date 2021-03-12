

USE master
CREATE DATABASE ConfeccionesCondor

USE ConfeccionesCondor

CREATE TABLE Empleado
(
  EmpleadoId INT PRIMARY KEY IDENTITY(1,1),
  TipoDocumentoId INT,
  NumeroDocumento NVARCHAR(50),
  Nombres NVARCHAR(100) NOT NULL,
  Apellidos NVARCHAR(100) NOT NULL,
  FechaNacimiento DATETIME NOT NULL,
  AreaId INT NOT NULL,
  FechaCreacion DATETIME

  FOREIGN KEY(AreaId) REFERENCES Area(AreaId)
)

CREATE TABLE Area
(
  AreaId INT PRIMARY KEY IDENTITY(1,1),
  Nombre NVARCHAR(100) NOT NULL,
)

SELECT * FROM Area

INSERT INTO Area (Nombre) VALUES ('Ventas')
INSERT INTO Area (Nombre) VALUES ('Costura')
INSERT INTO Area (Nombre) VALUES ('Contabilidad')
INSERT INTO Area (Nombre) VALUES ('Servicio Alcliente')
INSERT INTO Area (Nombre) VALUES ('TI')