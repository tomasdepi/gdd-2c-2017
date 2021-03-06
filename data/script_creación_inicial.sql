
USE [GD2C2017]

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--ELIMINACIÓN DE TABLAS

--ELIMINACIÓN TABLA CLIENTE
IF OBJECT_ID('[pizza].[Cliente]' , 'U') IS NOT NULL
DROP table [pizza].[Cliente];

--ELIMINACIÓN TABLA EMPRESA
IF OBJECT_ID('[pizza].[Empresa]', 'U') IS NOT NULL
DROP table  [pizza].[Empresa];

--ELIMINACIÓN TABLA DEVOLUCIÓN
IF OBJECT_ID('[pizza].[Devolucion]', 'U') IS NOT NULL
DROP table [pizza].[Devolucion];

--ELIMINACIÓN TABLA RENDICIÓN
IF OBJECT_ID('[pizza].[Rendicion]', 'U') IS NOT NULL
DROP table [pizza].[Rendicion];

--ELIMINACIÓN TABLA FACTURA_POR_RENDICION
IF OBJECT_ID('[pizza].[Factura_por_rendicion]', 'U') IS NOT NULL
DROP table [pizza].[Factura_por_rendicion];

--ELIMINACIÓN TABLA FACTURA
IF OBJECT_ID('[pizza].[Factura]', 'U') IS NOT NULL
DROP table [pizza].[Factura];

--ELIMINACIÓN TABLA ITEM_FACTURA
IF OBJECT_ID('[pizza].[Item_factura]', 'U') IS NOT NULL
DROP table [pizza].[Item_factura];

--ELIMINACIÓN TABLA FACTURA_POR_PAGO
IF OBJECT_ID('[pizza].[Factura_por_pago]', 'U') IS NOT NULL
DROP table [pizza].[Factura_por_pago];

--ELIMINACIÓN TABLA PAGO
IF OBJECT_ID('[pizza].[Pago]', 'U') IS NOT NULL
DROP table [pizza].[Pago];

--ELIMINACIÓN TABLA SUCURSAL
IF OBJECT_ID('[pizza].[Sucursal]', 'U') IS NOT NULL
DROP table [pizza].[Sucursal];

--ELIMINACIÓN TABLA USER_POR_SUCURSAL
IF OBJECT_ID('[pizza].[User_por_sucursal]', 'U') IS NOT NULL
DROP table [pizza].[User_por_sucursal];

--ELIMINACIÓN TABLA USUARIO
IF OBJECT_ID('[pizza].[Usuario]', 'U') IS NOT NULL
DROP table [pizza].[Usuario]

--ELIMINACIÓN TABLA ROL_POR_USUARIO
IF OBJECT_ID('[pizza].[Rol_por_usuario]', 'U') IS NOT NULL
DROP table [pizza].[Rol_por_usuario];

--ELIMINACIÓN TABLA ROL
IF OBJECT_ID('[pizza].[Rol]', 'U') IS NOT NULL
DROP table [pizza].[Rol];

--ELIMINACIÓN TABLA ROL_POR_FUNCIONALIDAD
IF OBJECT_ID('[pizza].[Rol_por_funcionalidad]', 'U') IS NOT NULL
DROP table [pizza].[Rol_por_funcionalidad];

--ELIMINACIÓN TABLA FUNCIONALIDAD
IF OBJECT_ID('[pizza].[Funcionalidad]', 'U') IS NOT NULL
DROP table [pizza].[Funcionalidad];

--ELIMINACIÓN DE PROCEDURES

--ELIMINACIÓN PROCEDURE MIGRACION CLIENTE
IF OBJECT_ID('[pizza].[Migracion_cliente]') IS NOT NULL
BEGIN
	DROP PROCEDURE [pizza].[Migracion_cliente]
END
GO

--ELIMINACIÓN PROCEDURE MIGRACION EMPRESA
IF OBJECT_ID('[pizza].[Migracion_empresa]') IS NOT NULL
BEGIN
	DROP PROCEDURE [pizza].[Migracion_empresa]
END
GO

--ELIMINACIÓN PROCEDURE MIGRACION SUCURSAL
IF OBJECT_ID('[pizza].[Migracion_sucursal]') IS NOT NULL
BEGIN
	DROP PROCEDURE [pizza].[Migracion_sucursal]
END
GO

--ELIMINACIÓN PROCEDURE MIGRACION FACTURA
IF OBJECT_ID('[pizza].[Migracion_factura]') IS NOT NULL
BEGIN
	DROP PROCEDURE [pizza].[Migracion_factura]
END
GO

--ELIMINACIÓN PROCEDURE MIGRACION PAGO
IF OBJECT_ID('[pizza].[Migracion_pago]') IS NOT NULL
BEGIN
	DROP PROCEDURE [pizza].[Migracion_pago]
END
GO

--ELIMINACIÓN PROCEDURE MIGRACION RENDICION
IF OBJECT_ID('[pizza].[Migracion_rendicion]') IS NOT NULL
BEGIN
	DROP PROCEDURE [pizza].[Migracion_rendicion]
END
GO

--ELIMINACIÓN PROCEDURE MIGRACION ROL
IF OBJECT_ID('[pizza].[Migracion_rol]') IS NOT NULL
BEGIN
	DROP PROCEDURE [pizza].[Migracion_rol]
END
GO

--ELIMINACIÓN PROCEDURE MIGRACION USUARIO
IF OBJECT_ID('[pizza].[Migracion_Usuario]') IS NOT NULL
BEGIN
	DROP PROCEDURE [pizza].[Migracion_Usuario]
END
GO

--ELIMINACIÓN DEL SCHEMA

IF EXISTS (SELECT * FROM sys.schemas WHERE sys.schemas.name = 'pizza')
	DROP SCHEMA pizza
GO

--CREACIÓN DEL SCHEMA

CREATE SCHEMA [pizza] AUTHORIZATION [gd]
GO

--CREACIÓN DE TABLAS

--TABLA CLIENTE
CREATE TABLE [pizza].[Cliente](
	[clie_dni] [int] NOT NULL,
	[clie_nombre] [varchar](150) NOT NULL,
	[clie_apellido] [varchar](150) NOT NULL,
	[clie_telefono] [varchar](40) NOT NULL,
	[clie_mail] [varchar](150) NOT NULL,
	[clie_direccion] [varchar](150) NOT NULL,
	[clie_codPostal] [int] NOT NULL,
	[clie_fechaNac] [datetime] NOT NULL,
	[clie_habilitado] [tinyint] NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[clie_dni] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


--TABLA EMPRESA
GO
CREATE TABLE [pizza].[Empresa](
	[emp_id] [int] NOT NULL IDENTITY(1,1),
	[emp_cuit] [varchar](50) NOT NULL UNIQUE,
	[emp_nombre] [varchar](150) NOT NULL,
	[emp_direccion] [varchar](150) NULL,
	[emp_rubro] [varchar](100) NOT NULL,
	[emp_fechaRendicion] [datetime] NULL,
	[emp_habilitado] [tinyint] NOT NULL
 CONSTRAINT [PK_Empresa] PRIMARY KEY CLUSTERED 
(
	[emp_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


--TABLA DEVOLUCIÓN
GO
CREATE TABLE [pizza].[Devolucion](
	[dev_id] [int] NOT NULL IDENTITY(1,1),
	[dev_tipoEntidad] [varchar](40) NOT NULL,
	[dev_fecha] [datetime] NULL,
	[dev_motivo] [varchar](150) NOT NULL,
	[dev_entidad] [int] NOT NULL
 CONSTRAINT [PK_Devolucion] PRIMARY KEY CLUSTERED 
(
	[dev_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


--TABLA RENDICIÓN
GO
CREATE TABLE [pizza].[Rendicion](
	[rend_id] [int] NOT NULL IDENTITY(1,1),
	[rend_fecha] [datetime] NOT NULL,
	[rend_cantFacturas] [int] NULL,
	[rend_importeComision] [int] NOT NULL,
	[rend_empresa] [varchar](50) NOT NULL,
	[rend_porcentComision] [int] NOT NULL,
	[rend_totalRendicion] [int] NULL,
	[rend_devuelta] [tinyint] NOT NULL
 CONSTRAINT [PK_Rendicion] PRIMARY KEY CLUSTERED 
(
	[rend_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


--TABLA FACTURA_POR_RENDICION
GO
CREATE TABLE [pizza].[Factura_por_rendicion](
	[factRend_id] [int] NOT NULL IDENTITY(1,1),
	[factRend_factura] [int] NOT NULL,
	[factRend_rendicion] [int] NOT NULL
 CONSTRAINT [PK_Factura_por_rendicion] PRIMARY KEY CLUSTERED 
(
	[factRend_id]  ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


--TABLA FACTURA
GO
CREATE TABLE [pizza].[Factura](
	[fact_numero] [int] NOT NULL,
	[fact_cliente] [int] NOT NULL,
	[fact_alta] [datetime] NULL,
	[fact_vencimiento] [datetime] NOT NULL,
	[fact_pagada] [tinyint] NOT NULL,
	[fact_empresa] [varchar](50) NOT NULL
 CONSTRAINT [PK_Factura] PRIMARY KEY CLUSTERED 
(
	[fact_numero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


--TABLA ITEM_FACTURA
GO
CREATE TABLE [pizza].[Item_factura](
	[item_id] [int] NOT NULL IDENTITY(1,1),
	[item_numFacutura] [int] NOT NULL,
	[item_cantidad] [int] NULL,
	[item_monto] [int] NOT NULL
 CONSTRAINT [PK_ItemFactura] PRIMARY KEY CLUSTERED 
(
	[item_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


--TABLA FACTURA_POR_PAGO
GO
CREATE TABLE [pizza].[Factura_por_pago](
	[factPago_id] [int] NOT NULL IDENTITY(1,1),
	[factPago_pago] [varchar](50) NOT NULL,
	[factPago_factura] [int] NOT NULL
 CONSTRAINT [PK_Factura_por_pago] PRIMARY KEY CLUSTERED 
(
	[factPago_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


--TABLA PAGO
GO
CREATE TABLE [pizza].[Pago](
	[pago_id] [int] NOT NULL IDENTITY(1,1),
	[pago_clie] [int] NOT NULL,
	[pago_importeTotal] [int] NOT NULL,
	[pago_anulado] [tinyint] NULL,
	[pago_sucursal] [int] NOT NULL,
	[pago_fecha] [datetime] NOT NULL,
	[pago_formaPago] [varchar](100) NOT NULL
 CONSTRAINT [PK_Pago] PRIMARY KEY CLUSTERED 
(
	[pago_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


--TABLA SUCURSAL
GO
CREATE TABLE [pizza].[Sucursal](
	[suc_codPostal] [int] NOT NULL,
	[suc_nombre] [varchar](150) NOT NULL,
	[suc_direccion] [varchar](150) NULL,
	[suc_habilitado] [tinyint] NOT NULL
 CONSTRAINT [PK_Sucursal] PRIMARY KEY CLUSTERED 
(
	[suc_codPostal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


--TABLA USER_POR_SUCURSAL
GO
CREATE TABLE [pizza].[User_por_sucursal](
	[usrSuc_id] [int] NOT NULL IDENTITY(1,1),
	[usrSuc_usuario] [varchar](50) NOT NULL,
	[usrSuc_sucursal] [int] NOT NULL
 CONSTRAINT [PK_User_por_sucursal] PRIMARY KEY CLUSTERED 
(
	[usrSuc_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


--TABLA USUARIO
GO
CREATE TABLE [pizza].[Usuario](
	[usr_usuario] [varchar](50) NOT NULL,
	[usr_password] [varchar](100) NOT NULL,
	[usr_intentosLogin] [int] NULL
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[usr_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


--TABLA ROL_POR_USUARIO
GO
CREATE TABLE [pizza].[Rol_por_usuario](
	[rolUsr_id] [int] NOT NULL IDENTITY(1,1),
	[rolUsr_rol] [int] NOT NULL,
	[rolUsr_usuario] [varchar](150) NOT NULL,
 CONSTRAINT [PK_Rol_por_usuario] PRIMARY KEY CLUSTERED 
(
	[rolUsr_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


--TABLA ROL
GO
CREATE TABLE [pizza].[Rol](
	[rol_id] [int] NOT NULL IDENTITY(1,1),
	[rol_nombre] [varchar](100) NOT NULL,
	[rol_habilitado] [tinyint] NULL
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[rol_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


--TABLA ROL_POR_FUNCIONALIDAD
GO
CREATE TABLE [pizza].[Rol_por_funcionalidad](
	[rolFunc_id] [int] NOT NULL IDENTITY(1,1),
	[rolFunc_rol] [int] NOT NULL,
	[rolFunc_func] [int] NOT NULL
 CONSTRAINT [PK_Rol_por_Funcionalidad] PRIMARY KEY CLUSTERED 
(
	[rolFunc_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


--TABLA FUNCIONALIDAD
GO
CREATE TABLE [pizza].[Funcionalidad](
	[func_id] [int] NOT NULL,
	[func_nombre] [varchar](150) NOT NULL
 CONSTRAINT [PK_Funcionalidad] PRIMARY KEY CLUSTERED 
(
	[func_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


--CREACIÓN DE STORED PROCEDURES PARA LA MIGRACIÓN

--MIGRACIÓN DE CLIENTE
GO
CREATE PROCEDURE [pizza].[Migracion_cliente]
AS
BEGIN
	INSERT INTO PIZZA.Cliente(clie_dni, clie_nombre, clie_apellido,clie_mail, clie_direccion, clie_codPostal, clie_telefono, clie_fechaNac, clie_habilitado)
	SELECT DISTINCT [Cliente-Dni],[Cliente-Nombre],[Cliente-Apellido],Cliente_Mail,Cliente_Direccion,Cliente_Codigo_Postal,0,[Cliente-Fecha_Nac], 1 from gd_esquema.Maestra

END

--MIGRACIÓN DE EMPRESA
GO
CREATE PROCEDURE [pizza].[Migracion_empresa]
AS
BEGIN
	INSERT INTO PIZZA.Empresa(emp_cuit, emp_nombre, emp_direccion, emp_rubro, emp_fechaRendicion, emp_habilitado)
	SELECT DISTINCT Empresa_Cuit, Empresa_Nombre, Empresa_Direccion, Rubro_Descripcion, null, 1 from gd_esquema.Maestra
END

--MIGRACIÓN DE SUCURSAL
GO
CREATE PROCEDURE [pizza].[Migracion_sucursal]
AS
BEGIN
	INSERT INTO PIZZA.Sucursal(suc_codPostal, suc_nombre, suc_direccion, suc_habilitado)
	SELECT DISTINCT Sucursal_Codigo_Postal, Sucursal_Nombre, Sucursal_Dirección, 1 FROM gd_esquema.Maestra where Sucursal_Codigo_Postal is not null
END


--MIGRACIÓN DE FACTURA
GO
CREATE PROCEDURE [pizza].[Migracion_factura]
AS
BEGIN
	INSERT INTO PIZZA.Factura(fact_numero,fact_cliente, fact_alta, fact_vencimiento, fact_empresa, fact_pagada)	
	SELECT Nro_Factura, [Cliente-Dni], Factura_Fecha, Factura_Fecha_Vencimiento, Empresa_Cuit, (case when max(Pago_nro) is null then 0 else 1 end) FROM gd_esquema.Maestra
	group by Nro_Factura, [Cliente-Dni], Factura_Fecha, Factura_Fecha_Vencimiento, Empresa_Cuit

	INSERT INTO PIZZA.Item_factura(item_numFacutura, item_monto, item_cantidad)
	SELECT DISTINCT Nro_Factura, ItemFactura_Monto, ItemFactura_Cantidad FROM gd_esquema.Maestra
END


--MIGRACIÓN DE PAGO
GO
CREATE PROCEDURE [pizza].[Migracion_pago]
AS
BEGIN
	SET IDENTITY_INSERT [pizza].[Pago] ON
	INSERT INTO PIZZA.Pago(pago_id, pago_fecha, pago_sucursal, pago_importeTotal, pago_anulado, pago_formaPago, pago_clie)
	SELECT DISTINCT Pago_nro, Pago_fecha, Sucursal_codigo_postal, Total, 0, FormaPagoDescripcion, [Cliente-Dni] from gd_esquema.Maestra where Pago_nro is not null
	SET IDENTITY_INSERT [pizza].[Pago] OFF

	INSERT INTO PIZZA.Factura_por_pago (factPago_pago, factPago_factura)
	SELECT DISTINCT Pago_nro, Nro_Factura from gd_esquema.Maestra where Pago_nro is not null and Nro_Factura is not null

END


--MIGRACIÓN DE RENDICIÓN
GO
CREATE PROCEDURE [pizza].[Migracion_rendicion]
AS
BEGIN
	
	SET IDENTITY_INSERT PIZZA.Rendicion ON
	
	INSERT INTO Rendicion(rend_id, rend_fecha, rend_cantFacturas, rend_importeComision, rend_empresa, rend_porcentComision, rend_totalRendicion, rend_devuelta)
	SELECT DISTINCT Rendicion_Nro, Rendicion_Fecha, 1, ItemRendicion_Importe , Empresa_Cuit, ROUND((ItemRendicion_Importe/Factura_Total*100), 2), Factura_Total, 0
		FROM GD2C2017.gd_esquema.Maestra
		WHERE Rendicion_Nro IS NOT NULL

	SET IDENTITY_INSERT PIZZA.Rendicion OFF
	

	INSERT INTO Factura_por_rendicion(factRend_rendicion, factRend_factura)
	SELECT Rendicion_Nro, Nro_Factura FROM GD2C2017.gd_esquema.Maestra
	where Rendicion_Nro is not null

END
GO


--MIGRACIÓN DE ROL
GO
CREATE PROCEDURE [pizza].[Migracion_rol]
AS
BEGIN
	INSERT INTO PIZZA.Funcionalidad(func_id, func_nombre) VALUES
	(1, 'ABM Rol'),
	(2, 'Registro Usuarios'),
	(3, 'ABM Cliente'),
	(4, 'ABM Empresa'),
	(5, 'ABM Sucursal'),
	(6, 'ABM Factura'),
	(7, 'Registro de Pago de Facturas'),
	(8, 'Rendicion de Facturas Cobradas'),
	(9, 'Listado Estadistico'),
	(10, 'Devoluciones')

	SET IDENTITY_INSERT PIZZA.Rol ON
	INSERT INTO PIZZA.Rol(rol_id, rol_nombre, rol_habilitado) VALUES
	(1,'Administrador', 1), (2,'Cobrador', 1)
	SET IDENTITY_INSERT PIZZA.Rol OFF

	INSERT INTO PIZZA.Rol_por_funcionalidad(rolFunc_rol, rolFunc_func) VALUES
	(1,1),(1,2),(1,3),(1,4),(1,5),(1,6),(1,7),(1,8),(1,9),(1,10),(2,7),(2,8)

END


--MIGRACIÓN DE USUARIO
GO
CREATE PROCEDURE [PIZZA].[Migracion_Usuario]
AS
BEGIN
	INSERT INTO Usuario(usr_usuario, usr_password, usr_intentosLogin) VALUES
	('admin', CONVERT(NVARCHAR(32), HASHBYTES('SHA2_256', 'w23e'),2), 0)

	INSERT INTO User_por_sucursal (usrSuc_sucursal, usrSuc_usuario)
	VALUES (7210, 'admin')

	INSERT INTO Rol_por_usuario(rolUsr_rol, rolUsr_usuario) VALUES (1, 'admin')

	INSERT INTO Usuario(usr_usuario, usr_password, usr_intentosLogin) VALUES
	('cobrador', CONVERT(NVARCHAR(32), HASHBYTES('SHA2_256', 'cobrador'),2), 0)

	INSERT INTO User_por_sucursal (usrSuc_sucursal, usrSuc_usuario)
	VALUES (7210, 'cobrador')

	INSERT INTO Rol_por_usuario(rolUsr_rol, rolUsr_usuario) VALUES (2, 'cobrador')

END

GO
exec PIZZA.Migracion_cliente;
exec PIZZA.Migracion_empresa;
exec PIZZA.Migracion_factura;
exec PIZZA.Migracion_pago;
exec PIZZA.Migracion_rendicion;
exec PIZZA.Migracion_sucursal;
exec PIZZA.Migracion_rol;
exec PIZZA.Migracion_Usuario;

