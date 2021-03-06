USE [ConfeccionesCondor]
GO
/****** Object:  Table [dbo].[Area]    Script Date: 12/03/2021 12:47:58 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Area](
	[AreaId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AreaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleado]    Script Date: 12/03/2021 12:47:58 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleado](
	[EmpleadoId] [int] IDENTITY(1,1) NOT NULL,
	[TipoDocumentoId] [int] NULL,
	[NumeroDocumento] [nvarchar](50) NULL,
	[Nombres] [nvarchar](100) NOT NULL,
	[Apellidos] [nvarchar](100) NOT NULL,
	[FechaNacimiento] [date] NOT NULL,
	[AreaId] [int] NOT NULL,
	[FechaCreacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[EmpleadoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Area] ON 

INSERT [dbo].[Area] ([AreaId], [Nombre]) VALUES (1, N'Ventas')
INSERT [dbo].[Area] ([AreaId], [Nombre]) VALUES (2, N'Costura')
INSERT [dbo].[Area] ([AreaId], [Nombre]) VALUES (3, N'Contabilidad')
INSERT [dbo].[Area] ([AreaId], [Nombre]) VALUES (4, N'Servicio Alcliente')
INSERT [dbo].[Area] ([AreaId], [Nombre]) VALUES (5, N'TI')
SET IDENTITY_INSERT [dbo].[Area] OFF
SET IDENTITY_INSERT [dbo].[Empleado] ON 

INSERT [dbo].[Empleado] ([EmpleadoId], [TipoDocumentoId], [NumeroDocumento], [Nombres], [Apellidos], [FechaNacimiento], [AreaId], [FechaCreacion]) VALUES (1, 1, N'1065613726', N'Faber Jose', N'Orozco Simanca', CAST(N'1989-09-22' AS Date), 5, CAST(N'2021-03-12T12:38:54.103' AS DateTime))
SET IDENTITY_INSERT [dbo].[Empleado] OFF
ALTER TABLE [dbo].[Empleado]  WITH CHECK ADD FOREIGN KEY([AreaId])
REFERENCES [dbo].[Area] ([AreaId])
GO
/****** Object:  StoredProcedure [dbo].[ObtenerEmpleados]    Script Date: 12/03/2021 12:47:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Faber Orozco>
-- Create date: <11-03-2021>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ObtenerEmpleados]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT em.EmpleadoId, em.TipoDocumentoId, em.NumeroDocumento, 
	CASE
		WHEN em.TipoDocumentoId = 1 THEN 'CEDULA DE CUIDADANIA'
		WHEN em.TipoDocumentoId = 2 THEN 'CCEDULA DE EXTRANJERIAA'
		WHEN em.TipoDocumentoId = 3 THEN 'NUMERO DE IDENTIFICACION PERSONAL'
		ELSE 'NUMERO DE IDENTIFICACION TRIBUTARIA'
	END AS TipoDocumento,
	convert(varchar, em.FechaNacimiento, 23) as FechaNacimiento , CONCAT(em.Nombres, ' ', em.Apellidos) AS NombreCompleto, ar.Nombre AS NombreArea, ar.AreaId
	FROM dbo.Empleado em
	JOIN Area ar on ar.AreaId = em.AreaId
	ORDER BY em.FechaCreacion ASC

END
GO
