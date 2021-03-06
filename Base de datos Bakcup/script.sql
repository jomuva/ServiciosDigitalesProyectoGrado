USE [master]
GO
/****** Object:  Database [bdServiciosDigitalesProy]    Script Date: 23/08/2017 5:34:58 p.m. ******/
CREATE DATABASE [bdServiciosDigitalesProy]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'bdServiciosDigitalesProy', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\bdServiciosDigitalesProy.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'bdServiciosDigitalesProy_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\bdServiciosDigitalesProy_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [bdServiciosDigitalesProy] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [bdServiciosDigitalesProy].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [bdServiciosDigitalesProy] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [bdServiciosDigitalesProy] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [bdServiciosDigitalesProy] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [bdServiciosDigitalesProy] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [bdServiciosDigitalesProy] SET ARITHABORT OFF 
GO
ALTER DATABASE [bdServiciosDigitalesProy] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [bdServiciosDigitalesProy] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [bdServiciosDigitalesProy] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [bdServiciosDigitalesProy] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [bdServiciosDigitalesProy] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [bdServiciosDigitalesProy] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [bdServiciosDigitalesProy] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [bdServiciosDigitalesProy] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [bdServiciosDigitalesProy] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [bdServiciosDigitalesProy] SET  ENABLE_BROKER 
GO
ALTER DATABASE [bdServiciosDigitalesProy] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [bdServiciosDigitalesProy] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [bdServiciosDigitalesProy] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [bdServiciosDigitalesProy] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [bdServiciosDigitalesProy] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [bdServiciosDigitalesProy] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [bdServiciosDigitalesProy] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [bdServiciosDigitalesProy] SET RECOVERY FULL 
GO
ALTER DATABASE [bdServiciosDigitalesProy] SET  MULTI_USER 
GO
ALTER DATABASE [bdServiciosDigitalesProy] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [bdServiciosDigitalesProy] SET DB_CHAINING OFF 
GO
ALTER DATABASE [bdServiciosDigitalesProy] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [bdServiciosDigitalesProy] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [bdServiciosDigitalesProy] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'bdServiciosDigitalesProy', N'ON'
GO
ALTER DATABASE [bdServiciosDigitalesProy] SET QUERY_STORE = OFF
GO
USE [bdServiciosDigitalesProy]
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [bdServiciosDigitalesProy]
GO
/****** Object:  Table [dbo].[CATEGORIA_ELEMENTO]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CATEGORIA_ELEMENTO](
	[id_categoria_elemento] [int] IDENTITY(1,1) NOT NULL,
	[descripcion_categoria_elemento] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_categoria_elemento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CATEGORIA_PRODUCTO]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CATEGORIA_PRODUCTO](
	[id_categoria] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_categoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DETALLE_FACTURA_PRODUCTO]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DETALLE_FACTURA_PRODUCTO](
	[id_detalle_factura] [int] IDENTITY(1,1) NOT NULL,
	[id_producto_detalle_factura] [int] NULL,
	[id_factura_detalle_factura] [int] NOT NULL,
	[cantidad_venta] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_detalle_factura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DETALLE_FACTURA_SOLICITUD]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DETALLE_FACTURA_SOLICITUD](
	[id_detalle_factura_solicitud] [int] IDENTITY(1,1) NOT NULL,
	[id_solicitud_detalle_factura] [int] NULL,
	[id_factura_detalle_factura] [int] NOT NULL,
	[cantidad_venta] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_detalle_factura_solicitud] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ELEMENTO]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ELEMENTO](
	[id_elemento] [int] IDENTITY(1,1) NOT NULL,
	[serial] [varchar](4) NULL,
	[placa] [varchar](30) NULL,
	[modelo] [varchar](30) NULL,
	[marca] [varchar](15) NULL,
	[ram] [varchar](10) NULL,
	[rom] [varchar](15) NULL,
	[serial_bateria] [varchar](4) NULL,
	[sistema_operativo] [varchar](20) NULL,
	[id_tipo_elemento] [int] NOT NULL,
	[id_categoria_elemento] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_elemento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ESCALADO]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ESCALADO](
	[id_escalado] [int] NOT NULL,
	[id_usuario_escalado] [int] NULL,
	[id_sucursal_escalado] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_escalado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ESTADO_FACTURA]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ESTADO_FACTURA](
	[id_estado_factura] [int] IDENTITY(1,1) NOT NULL,
	[descripcion_estado_factura] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_estado_factura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ESTADO_PRODUCTO]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ESTADO_PRODUCTO](
	[id_estado_producto] [int] IDENTITY(1,1) NOT NULL,
	[descripcion_estado_producto] [varchar](15) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_estado_producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ESTADO_SOLICITUD]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ESTADO_SOLICITUD](
	[id_estado_solicitud] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_estado_solicitud] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ESTADO_USUARIO]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ESTADO_USUARIO](
	[id_estado] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_estado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FACTURA]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FACTURA](
	[id_factura] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [datetime] NOT NULL,
	[id_cliente_factura] [int] NULL,
	[id_empleado_factura] [int] NULL,
	[id_estado_factura] [int] NOT NULL,
	[saldo] [decimal](30, 4) NULL,
	[valor_total] [decimal](30, 4) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_factura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HISTORICO_FACTURA]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HISTORICO_FACTURA](
	[id_historico] [int] IDENTITY(1,1) NOT NULL,
	[id_empleado_historico] [int] NOT NULL,
	[id_factura_historico] [int] NULL,
	[descripcion_historico] [varchar](500) NOT NULL,
	[fecha_historico] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_historico] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HISTORICO_INVENTARIO]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HISTORICO_INVENTARIO](
	[id_historico] [int] IDENTITY(1,1) NOT NULL,
	[id_empleado] [int] NOT NULL,
	[id_inventario_historico] [int] NOT NULL,
	[fecha] [datetime] NOT NULL,
	[descripcion] [varchar](500) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_historico] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HISTORICO_INVENTARIO_BAJAS]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HISTORICO_INVENTARIO_BAJAS](
	[id_historico] [int] IDENTITY(1,1) NOT NULL,
	[id_empleado] [int] NOT NULL,
	[id_inventario_historico] [int] NOT NULL,
	[fecha] [datetime] NOT NULL,
	[descripcion] [varchar](500) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_historico] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HISTORICO_SOLICITUD]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HISTORICO_SOLICITUD](
	[id_historico] [int] IDENTITY(1,1) NOT NULL,
	[id_usuario_historico] [int] NOT NULL,
	[id_solicitud_historico] [int] NOT NULL,
	[descripcion_historico] [varchar](500) NOT NULL,
	[fecha_historico] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_historico] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[INVENTARIO]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[INVENTARIO](
	[id_inventario] [int] IDENTITY(1,1) NOT NULL,
	[id_producto_inventario] [int] NOT NULL,
	[id_sucursal_inventario] [int] NULL,
	[cantidad_existencias] [int] NOT NULL,
	[fecha_actualizacion_inventario] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_inventario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[INVENTARIO_BAJAS]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[INVENTARIO_BAJAS](
	[id_inventario_bajas] [int] IDENTITY(1,1) NOT NULL,
	[id_producto_inventario] [int] NOT NULL,
	[id_sucursal_inventario] [int] NULL,
	[cantidad_existencias] [int] NOT NULL,
	[fecha_actualizacion_inventario] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_inventario_bajas] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PERMISO]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PERMISO](
	[permisoID] [int] IDENTITY(1,1) NOT NULL,
	[modulo] [varchar](20) NULL,
	[descripcion] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[permisoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PERMISO_DENEGADO_POR_ROL]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PERMISO_DENEGADO_POR_ROL](
	[id_rol] [int] NOT NULL,
	[permiso_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_rol] ASC,
	[permiso_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PRIORIDAD]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PRIORIDAD](
	[id_prioridad] [int] IDENTITY(1,1) NOT NULL,
	[descripcion_prioridad] [varchar](50) NULL,
	[tiempo_solucion] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_prioridad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PRODUCTO]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PRODUCTO](
	[id_producto] [int] IDENTITY(1,1) NOT NULL,
	[id_estado_producto] [int] NOT NULL,
	[id_categoria_producto] [int] NOT NULL,
	[nombre_producto] [varchar](100) NOT NULL,
	[precio_costo] [decimal](20, 4) NULL,
	[precio_venta] [decimal](20, 4) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ROL]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ROL](
	[id_rol] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_rol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SERVICIO]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SERVICIO](
	[id_servicio] [int] IDENTITY(1,1) NOT NULL,
	[descripcion_servicio] [varchar](50) NOT NULL,
	[precio] [decimal](20, 4) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_servicio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SOLICITUD]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SOLICITUD](
	[id_solicitud] [int] IDENTITY(1,1) NOT NULL,
	[id_prioridad_solicitud] [int] NOT NULL,
	[id_estado_solicitud] [int] NOT NULL,
	[id_usuario_solicitud] [int] NOT NULL,
	[id_servicio_solicitud] [int] NOT NULL,
	[id_elemento_solicitud] [int] NULL,
	[id_escalado_solicitud] [int] NULL,
	[fecha_solicitud] [datetime] NULL,
	[descripcion] [varchar](300) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_solicitud] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SUCURSAL]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SUCURSAL](
	[id_sucursal] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](20) NOT NULL,
	[direccion] [varchar](50) NULL,
	[ciudad] [varchar](50) NULL,
	[telefonoFijo] [varchar](10) NULL,
	[telefonoCelular] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_sucursal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TELEFONO_USUARIO]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TELEFONO_USUARIO](
	[id_telefono] [int] IDENTITY(1,1) NOT NULL,
	[id_usuario_telefono] [int] NOT NULL,
	[numero_telefono] [varchar](15) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_telefono] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TIPO_ELEMENTO]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TIPO_ELEMENTO](
	[id_tipo_elemento] [int] IDENTITY(1,1) NOT NULL,
	[descripcion_elemento] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_tipo_elemento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TIPO_IDENTIFICACION_USUARIO]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TIPO_IDENTIFICACION_USUARIO](
	[id_tipo_identificacion] [int] IDENTITY(1,1) NOT NULL,
	[descripcion_tipo_identificacion] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_tipo_identificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[USUARIO]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USUARIO](
	[id_usuario] [int] IDENTITY(1,1) NOT NULL,
	[id_tipo_Identificacion_usuario] [int] NOT NULL,
	[id_estado_usuario] [int] NOT NULL,
	[id_rol_usuario] [int] NOT NULL,
	[identificacion] [varchar](15) NOT NULL,
	[apellidos] [varchar](30) NOT NULL,
	[nombres] [varchar](30) NOT NULL,
	[direccion] [varchar](50) NULL,
	[correo] [varchar](50) NOT NULL,
	[sexo] [char](1) NOT NULL,
	[usuario_login] [varchar](15) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[VALIDAR_USUARIO_LOGUEADO]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VALIDAR_USUARIO_LOGUEADO](
	[id_validar] [int] IDENTITY(1,1) NOT NULL,
	[idEmpleado] [int] NULL,
	[estado] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_validar] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[DETALLE_FACTURA_PRODUCTO]  WITH CHECK ADD  CONSTRAINT [fk_factura_detalle_factura_producto] FOREIGN KEY([id_factura_detalle_factura])
REFERENCES [dbo].[FACTURA] ([id_factura])
GO
ALTER TABLE [dbo].[DETALLE_FACTURA_PRODUCTO] CHECK CONSTRAINT [fk_factura_detalle_factura_producto]
GO
ALTER TABLE [dbo].[DETALLE_FACTURA_PRODUCTO]  WITH CHECK ADD  CONSTRAINT [fk_producto_detalle_factura] FOREIGN KEY([id_producto_detalle_factura])
REFERENCES [dbo].[PRODUCTO] ([id_producto])
GO
ALTER TABLE [dbo].[DETALLE_FACTURA_PRODUCTO] CHECK CONSTRAINT [fk_producto_detalle_factura]
GO
ALTER TABLE [dbo].[DETALLE_FACTURA_SOLICITUD]  WITH CHECK ADD  CONSTRAINT [fk_factura_detalle_factura_solicitud] FOREIGN KEY([id_factura_detalle_factura])
REFERENCES [dbo].[FACTURA] ([id_factura])
GO
ALTER TABLE [dbo].[DETALLE_FACTURA_SOLICITUD] CHECK CONSTRAINT [fk_factura_detalle_factura_solicitud]
GO
ALTER TABLE [dbo].[DETALLE_FACTURA_SOLICITUD]  WITH CHECK ADD  CONSTRAINT [fk_solicitud_detalle_factura] FOREIGN KEY([id_solicitud_detalle_factura])
REFERENCES [dbo].[SOLICITUD] ([id_solicitud])
GO
ALTER TABLE [dbo].[DETALLE_FACTURA_SOLICITUD] CHECK CONSTRAINT [fk_solicitud_detalle_factura]
GO
ALTER TABLE [dbo].[ELEMENTO]  WITH CHECK ADD  CONSTRAINT [fk_categoria_elemento] FOREIGN KEY([id_categoria_elemento])
REFERENCES [dbo].[CATEGORIA_ELEMENTO] ([id_categoria_elemento])
GO
ALTER TABLE [dbo].[ELEMENTO] CHECK CONSTRAINT [fk_categoria_elemento]
GO
ALTER TABLE [dbo].[ELEMENTO]  WITH CHECK ADD  CONSTRAINT [fk_tipo_elemento] FOREIGN KEY([id_tipo_elemento])
REFERENCES [dbo].[TIPO_ELEMENTO] ([id_tipo_elemento])
GO
ALTER TABLE [dbo].[ELEMENTO] CHECK CONSTRAINT [fk_tipo_elemento]
GO
ALTER TABLE [dbo].[ESCALADO]  WITH CHECK ADD  CONSTRAINT [fk_sucursal_escalado] FOREIGN KEY([id_sucursal_escalado])
REFERENCES [dbo].[SUCURSAL] ([id_sucursal])
GO
ALTER TABLE [dbo].[ESCALADO] CHECK CONSTRAINT [fk_sucursal_escalado]
GO
ALTER TABLE [dbo].[ESCALADO]  WITH CHECK ADD  CONSTRAINT [fk_usuario_escalado] FOREIGN KEY([id_usuario_escalado])
REFERENCES [dbo].[USUARIO] ([id_usuario])
GO
ALTER TABLE [dbo].[ESCALADO] CHECK CONSTRAINT [fk_usuario_escalado]
GO
ALTER TABLE [dbo].[FACTURA]  WITH CHECK ADD  CONSTRAINT [fk_empleado_factura] FOREIGN KEY([id_empleado_factura])
REFERENCES [dbo].[ESCALADO] ([id_escalado])
GO
ALTER TABLE [dbo].[FACTURA] CHECK CONSTRAINT [fk_empleado_factura]
GO
ALTER TABLE [dbo].[FACTURA]  WITH CHECK ADD  CONSTRAINT [fk_estado_factura] FOREIGN KEY([id_estado_factura])
REFERENCES [dbo].[ESTADO_FACTURA] ([id_estado_factura])
GO
ALTER TABLE [dbo].[FACTURA] CHECK CONSTRAINT [fk_estado_factura]
GO
ALTER TABLE [dbo].[FACTURA]  WITH CHECK ADD  CONSTRAINT [fk_usuario_factura] FOREIGN KEY([id_cliente_factura])
REFERENCES [dbo].[USUARIO] ([id_usuario])
GO
ALTER TABLE [dbo].[FACTURA] CHECK CONSTRAINT [fk_usuario_factura]
GO
ALTER TABLE [dbo].[HISTORICO_FACTURA]  WITH CHECK ADD  CONSTRAINT [fk_factura_historico] FOREIGN KEY([id_factura_historico])
REFERENCES [dbo].[FACTURA] ([id_factura])
GO
ALTER TABLE [dbo].[HISTORICO_FACTURA] CHECK CONSTRAINT [fk_factura_historico]
GO
ALTER TABLE [dbo].[HISTORICO_INVENTARIO]  WITH CHECK ADD  CONSTRAINT [fk_empleado_historico_inventario] FOREIGN KEY([id_empleado])
REFERENCES [dbo].[USUARIO] ([id_usuario])
GO
ALTER TABLE [dbo].[HISTORICO_INVENTARIO] CHECK CONSTRAINT [fk_empleado_historico_inventario]
GO
ALTER TABLE [dbo].[HISTORICO_INVENTARIO]  WITH CHECK ADD  CONSTRAINT [fk_inventario_historico_inventario] FOREIGN KEY([id_inventario_historico])
REFERENCES [dbo].[INVENTARIO] ([id_inventario])
GO
ALTER TABLE [dbo].[HISTORICO_INVENTARIO] CHECK CONSTRAINT [fk_inventario_historico_inventario]
GO
ALTER TABLE [dbo].[HISTORICO_INVENTARIO_BAJAS]  WITH CHECK ADD  CONSTRAINT [fk_empleado_historico_inventario_bajas] FOREIGN KEY([id_empleado])
REFERENCES [dbo].[USUARIO] ([id_usuario])
GO
ALTER TABLE [dbo].[HISTORICO_INVENTARIO_BAJAS] CHECK CONSTRAINT [fk_empleado_historico_inventario_bajas]
GO
ALTER TABLE [dbo].[HISTORICO_INVENTARIO_BAJAS]  WITH CHECK ADD  CONSTRAINT [fk_inventario_historico_inventario_bajas] FOREIGN KEY([id_inventario_historico])
REFERENCES [dbo].[INVENTARIO_BAJAS] ([id_inventario_bajas])
GO
ALTER TABLE [dbo].[HISTORICO_INVENTARIO_BAJAS] CHECK CONSTRAINT [fk_inventario_historico_inventario_bajas]
GO
ALTER TABLE [dbo].[HISTORICO_SOLICITUD]  WITH CHECK ADD  CONSTRAINT [fk_solicitud_historico] FOREIGN KEY([id_solicitud_historico])
REFERENCES [dbo].[SOLICITUD] ([id_solicitud])
GO
ALTER TABLE [dbo].[HISTORICO_SOLICITUD] CHECK CONSTRAINT [fk_solicitud_historico]
GO
ALTER TABLE [dbo].[HISTORICO_SOLICITUD]  WITH CHECK ADD  CONSTRAINT [fk_usuario_historico] FOREIGN KEY([id_usuario_historico])
REFERENCES [dbo].[USUARIO] ([id_usuario])
GO
ALTER TABLE [dbo].[HISTORICO_SOLICITUD] CHECK CONSTRAINT [fk_usuario_historico]
GO
ALTER TABLE [dbo].[INVENTARIO]  WITH CHECK ADD  CONSTRAINT [fk_producto_inventario] FOREIGN KEY([id_producto_inventario])
REFERENCES [dbo].[PRODUCTO] ([id_producto])
GO
ALTER TABLE [dbo].[INVENTARIO] CHECK CONSTRAINT [fk_producto_inventario]
GO
ALTER TABLE [dbo].[INVENTARIO]  WITH CHECK ADD  CONSTRAINT [fk_sucursal_inventario] FOREIGN KEY([id_sucursal_inventario])
REFERENCES [dbo].[SUCURSAL] ([id_sucursal])
GO
ALTER TABLE [dbo].[INVENTARIO] CHECK CONSTRAINT [fk_sucursal_inventario]
GO
ALTER TABLE [dbo].[INVENTARIO_BAJAS]  WITH CHECK ADD  CONSTRAINT [fk_producto_inventario_bajas] FOREIGN KEY([id_producto_inventario])
REFERENCES [dbo].[PRODUCTO] ([id_producto])
GO
ALTER TABLE [dbo].[INVENTARIO_BAJAS] CHECK CONSTRAINT [fk_producto_inventario_bajas]
GO
ALTER TABLE [dbo].[INVENTARIO_BAJAS]  WITH CHECK ADD  CONSTRAINT [fk_sucursal_inventario_bajas] FOREIGN KEY([id_sucursal_inventario])
REFERENCES [dbo].[SUCURSAL] ([id_sucursal])
GO
ALTER TABLE [dbo].[INVENTARIO_BAJAS] CHECK CONSTRAINT [fk_sucursal_inventario_bajas]
GO
ALTER TABLE [dbo].[PERMISO_DENEGADO_POR_ROL]  WITH CHECK ADD  CONSTRAINT [fk_id_rol_permiso_denegado] FOREIGN KEY([id_rol])
REFERENCES [dbo].[ROL] ([id_rol])
GO
ALTER TABLE [dbo].[PERMISO_DENEGADO_POR_ROL] CHECK CONSTRAINT [fk_id_rol_permiso_denegado]
GO
ALTER TABLE [dbo].[PERMISO_DENEGADO_POR_ROL]  WITH CHECK ADD  CONSTRAINT [fk_permiso_id] FOREIGN KEY([permiso_id])
REFERENCES [dbo].[PERMISO] ([permisoID])
GO
ALTER TABLE [dbo].[PERMISO_DENEGADO_POR_ROL] CHECK CONSTRAINT [fk_permiso_id]
GO
ALTER TABLE [dbo].[PRODUCTO]  WITH CHECK ADD  CONSTRAINT [fk_categoria_producto] FOREIGN KEY([id_categoria_producto])
REFERENCES [dbo].[CATEGORIA_PRODUCTO] ([id_categoria])
GO
ALTER TABLE [dbo].[PRODUCTO] CHECK CONSTRAINT [fk_categoria_producto]
GO
ALTER TABLE [dbo].[PRODUCTO]  WITH CHECK ADD  CONSTRAINT [fk_estado_producto] FOREIGN KEY([id_estado_producto])
REFERENCES [dbo].[ESTADO_PRODUCTO] ([id_estado_producto])
GO
ALTER TABLE [dbo].[PRODUCTO] CHECK CONSTRAINT [fk_estado_producto]
GO
ALTER TABLE [dbo].[SOLICITUD]  WITH CHECK ADD  CONSTRAINT [fk_elemento_solicitud] FOREIGN KEY([id_elemento_solicitud])
REFERENCES [dbo].[ELEMENTO] ([id_elemento])
GO
ALTER TABLE [dbo].[SOLICITUD] CHECK CONSTRAINT [fk_elemento_solicitud]
GO
ALTER TABLE [dbo].[SOLICITUD]  WITH CHECK ADD  CONSTRAINT [fk_escalado_solicitud] FOREIGN KEY([id_escalado_solicitud])
REFERENCES [dbo].[ESCALADO] ([id_escalado])
GO
ALTER TABLE [dbo].[SOLICITUD] CHECK CONSTRAINT [fk_escalado_solicitud]
GO
ALTER TABLE [dbo].[SOLICITUD]  WITH CHECK ADD  CONSTRAINT [fk_estado_solicitud] FOREIGN KEY([id_estado_solicitud])
REFERENCES [dbo].[ESTADO_SOLICITUD] ([id_estado_solicitud])
GO
ALTER TABLE [dbo].[SOLICITUD] CHECK CONSTRAINT [fk_estado_solicitud]
GO
ALTER TABLE [dbo].[SOLICITUD]  WITH CHECK ADD  CONSTRAINT [fk_prioridad_solicitud] FOREIGN KEY([id_prioridad_solicitud])
REFERENCES [dbo].[PRIORIDAD] ([id_prioridad])
GO
ALTER TABLE [dbo].[SOLICITUD] CHECK CONSTRAINT [fk_prioridad_solicitud]
GO
ALTER TABLE [dbo].[SOLICITUD]  WITH CHECK ADD  CONSTRAINT [fk_servicio_solicitud] FOREIGN KEY([id_servicio_solicitud])
REFERENCES [dbo].[SERVICIO] ([id_servicio])
GO
ALTER TABLE [dbo].[SOLICITUD] CHECK CONSTRAINT [fk_servicio_solicitud]
GO
ALTER TABLE [dbo].[SOLICITUD]  WITH CHECK ADD  CONSTRAINT [fk_usuario_solicitud] FOREIGN KEY([id_usuario_solicitud])
REFERENCES [dbo].[USUARIO] ([id_usuario])
GO
ALTER TABLE [dbo].[SOLICITUD] CHECK CONSTRAINT [fk_usuario_solicitud]
GO
ALTER TABLE [dbo].[TELEFONO_USUARIO]  WITH CHECK ADD  CONSTRAINT [fk_usuario_telefono] FOREIGN KEY([id_usuario_telefono])
REFERENCES [dbo].[USUARIO] ([id_usuario])
GO
ALTER TABLE [dbo].[TELEFONO_USUARIO] CHECK CONSTRAINT [fk_usuario_telefono]
GO
ALTER TABLE [dbo].[USUARIO]  WITH CHECK ADD  CONSTRAINT [fk_estado_usuario] FOREIGN KEY([id_estado_usuario])
REFERENCES [dbo].[ESTADO_USUARIO] ([id_estado])
GO
ALTER TABLE [dbo].[USUARIO] CHECK CONSTRAINT [fk_estado_usuario]
GO
ALTER TABLE [dbo].[USUARIO]  WITH CHECK ADD  CONSTRAINT [fk_rol_usuario] FOREIGN KEY([id_rol_usuario])
REFERENCES [dbo].[ROL] ([id_rol])
GO
ALTER TABLE [dbo].[USUARIO] CHECK CONSTRAINT [fk_rol_usuario]
GO
ALTER TABLE [dbo].[USUARIO]  WITH CHECK ADD  CONSTRAINT [fk_tipo_Identificacion_usuario] FOREIGN KEY([id_tipo_Identificacion_usuario])
REFERENCES [dbo].[TIPO_IDENTIFICACION_USUARIO] ([id_tipo_identificacion])
GO
ALTER TABLE [dbo].[USUARIO] CHECK CONSTRAINT [fk_tipo_Identificacion_usuario]
GO
/****** Object:  StoredProcedure [dbo].[ActualizarEstadoFactura]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--  ACTUALIZA EL ESTADO DE LA FACTURA Y SE ACTUALIZA EL NUEVO PAGO REALIZADO
CREATE PROCEDURE [dbo].[ActualizarEstadoFactura]
@idFactura int,
@idEstado int,
@pago decimal(30,4),
@identifEmpleado VARCHAR(15)
AS
DECLARE @fecha DATETIME, @idEmpleado int, @saldoActual Decimal(30,4),@saldoNuevo decimal(30,4)
SET @fecha = (SELECT CURRENT_TIMESTAMP);
SET @idEmpleado = (SELECT id_usuario FROM USUARIO WHERE identificacion = @identifEmpleado);
SET @saldoActual = (SELECT saldo FROM FACTURA WHERE id_factura = @idFactura);

BEGIN
	UPDATE FACTURA SET id_estado_factura = @idEstado, saldo = saldo - @pago
	WHERE id_factura =  @idFactura;
	SET @saldoNuevo =(SELECT saldo FROM FACTURA WHERE id_factura = @idFactura);

	INSERT INTO HISTORICO_FACTURA (id_empleado_historico,id_factura_historico,descripcion_historico,fecha_historico)
	VALUES (@idEmpleado,@idFactura,'Se actualiza el estado de la factura.  Saldo anterior: '+cast(@saldoActual as varchar)+' - Nuevo Saldo: '+cast(@saldoNuevo as varchar),@fecha);
END

GO
/****** Object:  StoredProcedure [dbo].[ActualizarEstadoProducto_Automatico]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- PROCEDIMIENTO QUE ACTUALIZA EL ESTADO DE CADA PRODUCTO DEL INVENTARIO SEGUN CANTIDAD DE EXISTENCIAS DE MANERA AUTOMÁTICA
CREATE PROCEDURE [dbo].[ActualizarEstadoProducto_Automatico]
AS
DECLARE 
@fecha DATETIME,
@TotalRegistrosInventario int,
@CantidadExistencias int,
@idestadoActual int,
@idProducto int,
@idSucursal int,
@descripcion VARCHAR (500)
SET @TotalRegistrosInventario = (SELECT COUNT(*) FROM INVENTARIO);
SET @fecha = (SELECT CURRENT_TIMESTAMP);
BEGIN
	WHILE @TotalRegistrosInventario > 0
	BEGIN
		SET @CantidadExistencias = (SELECT cantidad_existencias FROM INVENTARIO WHERE id_inventario = @TotalRegistrosInventario);
		SET @idProducto = (SELECT id_producto_inventario FROM INVENTARIO WHERE id_inventario = @TotalRegistrosInventario);
		SET @idSucursal = (SELECT id_sucursal_inventario FROM INVENTARIO WHERE id_inventario = @TotalRegistrosInventario);
		SET @idestadoActual = (SELECT id_estado_producto FROM PRODUCTO WHERE id_producto = @idProducto AND (SELECT id_sucursal_inventario FROM INVENTARIO WHERE id_inventario = @TotalRegistrosInventario)=@idSucursal);
		IF(@CantidadExistencias =0 AND @idestadoActual=1)
		BEGIN
			UPDATE PRODUCTO SET id_estado_producto = 2 
			WHERE id_producto = @idProducto AND (SELECT id_sucursal_inventario FROM INVENTARIO WHERE id_inventario = @TotalRegistrosInventario)=@idSucursal

			UPDATE INVENTARIO SET fecha_actualizacion_inventario = @fecha
			WHERE id_producto_inventario =@idProducto AND (SELECT id_sucursal_inventario FROM INVENTARIO WHERE id_inventario = @TotalRegistrosInventario)=@idSucursal
			
			SET @descripcion = ('Se ha cambiado el estado del producto a no disponible por falta de existencias');
			INSERT INTO HISTORICO_INVENTARIO(id_empleado,id_inventario_historico,fecha,descripcion)
			VALUES (1,@TotalRegistrosInventario,@fecha,@descripcion);
		END
		ELSE IF(@CantidadExistencias <>0 AND @idestadoActual=2)
		BEGIN
			UPDATE PRODUCTO SET id_estado_producto = 1 
			WHERE id_producto = @idProducto AND (SELECT id_sucursal_inventario FROM INVENTARIO WHERE id_inventario = @TotalRegistrosInventario)=@idSucursal

			SET @descripcion = ('Se ha cambiado el estado del producto a Disponible por detección de existencias en stock');
			INSERT INTO HISTORICO_INVENTARIO(id_empleado,id_inventario_historico,fecha,descripcion)
			VALUES (1,@TotalRegistrosInventario,@fecha,@descripcion);
		END
		SET @TotalRegistrosInventario = @TotalRegistrosInventario -1;
	END
END 


GO
/****** Object:  StoredProcedure [dbo].[ActualizarEstadoSolicitud_Automatico]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--PROCEDIMIENTO ALMACENADO PARA ACTUALIZAR ESTADO DE LA SOLICITUD DE MANERA AUTOMATICA SEGUN LA PRIORIDAD EL ESTADO Y EL TIEMPO DE SOLICITUD
CREATE PROCEDURE [dbo].[ActualizarEstadoSolicitud_Automatico]
AS
declare @Inicio DATETIME,
		@Fin DATETIME,
		@TotalRegistros int,
		@Resultado int,
		@tiempoSoluc int,
		@estadoSolic int,
		@Descrip_estado_anterior VARCHAR(50),
		@Descrip_historico VARCHAR(100);
SET @TotalRegistros =  (SELECT COUNT(*) FROM SOLICITUD);
BEGIN
WHILE @TotalRegistros > 0
	BEGIN
		SET @Inicio = (SELECT fecha_solicitud FROM SOLICITUD WHERE id_solicitud =  @TotalRegistros)
		SET @Fin = (SELECT CURRENT_TIMESTAMP)
		SET @estadoSolic = (SELECT id_estado_solicitud FROM SOLICITUD WHERE id_solicitud = @TotalRegistros)
		SET @tiempoSoluc = (SELECT PRIORIDAD.tiempo_solucion FROM PRIORIDAD INNER JOIN SOLICITUD ON PRIORIDAD.id_prioridad = SOLICITUD.id_prioridad_solicitud WHERE id_solicitud = @TotalRegistros)
		SET @Resultado =  (SELECT  DATEDIFF(minute, @Inicio, @Fin) as [MinutosTranscurridos] FROM SOLICITUD WHERE id_solicitud = @TotalRegistros)
		SET @Descrip_estado_anterior = (SELECT ESTADO_SOLICITUD.descripcion FROM ESTADO_SOLICITUD INNER JOIN SOLICITUD ON ESTADO_SOLICITUD.id_estado_solicitud = SOLICITUD.id_estado_solicitud WHERE id_solicitud =  @TotalRegistros)
		IF(@tiempoSoluc < @Resultado AND @estadoSolic <> 1 AND @estadoSolic <> 4 AND @estadoSolic <> 5)
			BEGIN
				UPDATE SOLICITUD SET id_estado_solicitud = 5 WHERE id_solicitud = @TotalRegistros
				SET @Descrip_historico = ('Se ha modificado el estado de la solicitud de '+@Descrip_estado_anterior+' a Vencido')
				
				INSERT INTO HISTORICO_SOLICITUD (id_usuario_historico,id_solicitud_historico,descripcion_historico,fecha_historico)
				VALUES (1,@TotalRegistros,@Descrip_historico,CURRENT_TIMESTAMP)
			END
		SET @TotalRegistros = @TotalRegistros -1
	END
END

GO
/****** Object:  StoredProcedure [dbo].[ActualizarFacturaVacia]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ACTUALIZA LA FACTURA VACIA CREADA PREVIAMENTE Y SE AGREGA EN HISTORICO
CREATE PROCEDURE [dbo].[ActualizarFacturaVacia]
@identifCliente VARCHAR(15),
@identifEmpleado VARCHAR(15),
@estado int,
@idFactura int,
@valorPagado decimal(30,4),
@total decimal(30,4),
@fecha DATETIME
AS
DECLARE @idEmpleado int, @idCliente int, @NombreEstado VARCHAR(20)
SET @NombreEstado = (SELECT descripcion_estado_factura FROM ESTADO_FACTURA WHERE id_estado_factura = @estado)
SET @idEmpleado = (SELECT id_usuario FROM USUARIO WHERE identificacion = @identifEmpleado);
SET @idCliente = (SELECT id_usuario FROM USUARIO WHERE identificacion = @identifCliente);
BEGIN
	UPDATE FACTURA SET id_cliente_factura = @idCliente, id_empleado_factura = @idEmpleado,
					   id_estado_factura = @estado, saldo = @total - @valorPagado,
					   valor_total = @total
	WHERE id_factura = @idFactura

	INSERT INTO HISTORICO_FACTURA (id_empleado_historico,id_factura_historico,descripcion_historico,fecha_historico)
	VALUES (@idEmpleado,@idFactura,'Se modifica la factura exitosamente con estado de Sin registros a '+@NombreEstado,@fecha)
END

GO
/****** Object:  StoredProcedure [dbo].[ActualizarInventarioProductos]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--PROCEDIMIENTO QUE ACTUALIZA LA CANTIDAD DE EXISTENCIAS DE UN PRODUCTO Y SE AGREGA AL HISTORICO
CREATE PROCEDURE [dbo].[ActualizarInventarioProductos]
@id_inventario int,
@id_producto int,
@cantidad int,
@identifEmpleado VARCHAR(15)
AS
DECLARE @fecha DATETIME, @idEmpleado int, @cantidadAnterior int, @suma int
BEGIN 
SET @fecha = (SELECT CURRENT_TIMESTAMP);
SET @idEmpleado = (SELECT id_usuario FROM USUARIO WHERE identificacion = @identifEmpleado);
SET @cantidadAnterior = (SELECT cantidad_existencias FROM INVENTARIO WHERE id_inventario =@id_inventario);
SET @suma = @cantidadAnterior +@cantidad;
UPDATE INVENTARIO SET id_producto_inventario = @id_producto, cantidad_existencias=@cantidad+@cantidadAnterior, fecha_actualizacion_inventario =@fecha
WHERE id_inventario = @id_inventario;

INSERT INTO HISTORICO_INVENTARIO (id_empleado,id_inventario_historico,fecha,descripcion)
VALUES (@idEmpleado,@id_inventario,@fecha,'Se actualiza la cantidad, de '+cast(@cantidadAnterior as varchar)+' unidades, a '+cast(@suma as varchar)+' unidades' );
END

GO
/****** Object:  StoredProcedure [dbo].[ActualizarInventarioXVenta]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ACTUALIZA EL INVENTARIO SEGUN LA VENTA REALIZADA Y SE ALMACENA EN HISTORICO
CREATE PROCEDURE [dbo].[ActualizarInventarioXVenta]
@idProducto int,
@cantidadVendida int,
@fecha DATETIME,
@identifEmpleado VARCHAR(15)
AS
DECLARE @cantidadActual int, @idEmpleado int, @nuevaCantidad int, @idSucursal int, @idInventario int
SET @idEmpleado = (SELECT id_usuario FROM USUARIO WHERE identificacion = @identifEmpleado);
SET @idSucursal = (SELECT id_sucursal_escalado FROM ESCALADO WHERE id_usuario_escalado = @idEmpleado);
SET @cantidadActual = (SELECT cantidad_existencias FROM INVENTARIO WHERE id_producto_inventario = @idProducto AND id_sucursal_inventario = @idSucursal);
BEGIN
	UPDATE INVENTARIO SET cantidad_existencias =  @cantidadActual - @cantidadVendida, fecha_actualizacion_inventario = @fecha 
	WHERE id_producto_inventario = @idProducto AND id_sucursal_inventario = @idSucursal
	SET @idInventario = (SELECT id_inventario FROM INVENTARIO WHERE id_producto_inventario = @idProducto AND id_sucursal_inventario = @idSucursal);

	SET @nuevaCantidad = (@cantidadActual-@cantidadVendida);
	INSERT INTO HISTORICO_INVENTARIO (id_empleado,id_inventario_historico,fecha,descripcion)
	VALUES (@idEmpleado,@idInventario,@fecha,'Se modifica la cantidad de unidades del producto de '+cast(@cantidadActual as varchar)+' a '+ cast(@nuevaCantidad as varchar)+' unidades' )
END

GO
/****** Object:  StoredProcedure [dbo].[ActualizarProducto]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--PROCEDIMIENTO ALMACENADO PARA ACTUALIZAR EL PRODUCTO SEGUN EL ID
CREATE PROC [dbo].[ActualizarProducto]
@idProd int,
@nombre_prod VARCHAR(100),
@precio_costo DECIMAL(20,4),
@precio_venta DECIMAL (20,4)
as
BEGIN 

UPDATE PRODUCTO SET nombre_producto=@nombre_prod, precio_costo=@precio_costo, precio_venta=@precio_venta WHERE id_producto = @idProd

END

GO
/****** Object:  StoredProcedure [dbo].[ActualizarServicio]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--PROCEDIMIENTO ALMACENADO PARA actualizar un servicio

CREATE PROCEDURE [dbo].[ActualizarServicio]
@idserv int,
@descripc VARCHAR(50),
@precio decimal(20,4)
as
BEGIN 

UPDATE SERVICIO SET descripcion_servicio=@descripc,precio=@precio WHERE id_servicio = @idserv

END

GO
/****** Object:  StoredProcedure [dbo].[AgregarAnotacionHistoricoInventario]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- PROCEDIMIENTO QUE AGREGA UNA ANOTACION ADICIONAL AL HISTORICO DEL INVENTARIO
CREATE PROCEDURE [dbo].[AgregarAnotacionHistoricoInventario]
@identifEmpleado VARCHAR(15),
@idInventario int,
@descripcion VARCHAR(500)
AS
DECLARE @fecha DATETIME,@idEmpleado int;
SET @fecha = (SELECT CURRENT_TIMESTAMP);
SET @idEmpleado = (SELECT id_usuario FROM USUARIO WHERE identificacion = @identifEmpleado);
BEGIN
	INSERT INTO HISTORICO_INVENTARIO(id_empleado,id_inventario_historico,fecha,descripcion)
	VALUES (@idEmpleado,@idInventario,@fecha,@descripcion);
END

GO
/****** Object:  StoredProcedure [dbo].[AgregarAnotacionHistoricoInventarioBajas]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- PROCEDIMIENTO QUE AGREGA UNA ANOTACION ADICIONAL AL HISTORICO DEL INVENTARIO DE BAJAS
CREATE PROCEDURE [dbo].[AgregarAnotacionHistoricoInventarioBajas]
@identifEmpleado VARCHAR(15),
@idInventario int,
@descripcion VARCHAR(500)
AS
DECLARE @fecha DATETIME,@idEmpleado int;
SET @fecha = (SELECT CURRENT_TIMESTAMP);
SET @idEmpleado = (SELECT id_usuario FROM USUARIO WHERE identificacion = @identifEmpleado);
BEGIN
	INSERT INTO HISTORICO_INVENTARIO_BAJAS(id_empleado,id_inventario_historico,fecha,descripcion)
	VALUES (@idEmpleado,@idInventario,@fecha,@descripcion);
END

GO
/****** Object:  StoredProcedure [dbo].[AgregarAnotacionHistoricoSolicitud]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--PROCEDIMIENTO QUE AGREGA UNA ANOTACION AL HISTORICO DE UNA SOLICITUD Y LA FIRMA QUIEN ESTÁ LOGUEADO
CREATE PROCEDURE [dbo].[AgregarAnotacionHistoricoSolicitud]
@identifEmpleado VARCHAR(15),
@idSolici int,
@descripcion VARCHAR(100)
AS
DECLARE @fecha DATETIME,@idEmpleado int;
SET @fecha = (SELECT CURRENT_TIMESTAMP);
SET @idEmpleado = (SELECT id_usuario FROM USUARIO WHERE identificacion = @identifEmpleado);
BEGIN
	INSERT INTO HISTORICO_SOLICITUD (id_usuario_historico,id_solicitud_historico,descripcion_historico,fecha_historico)
	VALUES (@idEmpleado,@idSolici,@descripcion,@fecha);
END

GO
/****** Object:  StoredProcedure [dbo].[AgregarBajaInventario]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--PROCEDIMIENTO QUE AGREGA UNA BAJA AL INVENTARIO DE BAJAS, LO DISMINUYE DEL INVENTARIO DE PRODUCTOS Y AGREGA AMBOS MOVIMIENTOS A SU
-- RESPECTIVO HISTORICO
CREATE PROCEDURE [dbo].[AgregarBajaInventario] 
  @idInventario int,
 @cantidadBajas int,
 @identifEmpleado VARCHAR(15),
 @descripcionBaja VARCHAR(500)
AS
DECLARE @fecha DATETIME,
@cantidadExistenciasInventario int,
@cantidadExistenciasInventarioBajasActual int,
@idEmpleado int

SET @fecha = (SELECT CURRENT_TIMESTAMP);
SET @idEmpleado = (SELECT id_usuario FROM USUARIO WHERE identificacion = @identifEmpleado);
SET @cantidadExistenciasInventario  = (SELECT cantidad_existencias FROM INVENTARIO WHERE id_inventario=@idInventario);
SET @cantidadExistenciasInventarioBajasActual = (SELECT cantidad_existencias FROM INVENTARIO_BAJAS WHERE id_inventario_bajas = @idInventario);
BEGIN
	UPDATE INVENTARIO_BAJAS SET cantidad_existencias=@cantidadExistenciasInventarioBajasActual+@cantidadBajas,
	fecha_actualizacion_inventario = @fecha WHERE (id_inventario_bajas = @idInventario);
	
	INSERT INTO HISTORICO_INVENTARIO_BAJAS (id_empleado,id_inventario_historico,fecha,descripcion)
	VALUES (@idEmpleado,@idInventario,@fecha,@descripcionBaja);

	UPDATE INVENTARIO SET cantidad_existencias = @cantidadExistenciasInventario - @cantidadBajas 
	WHERE INVENTARIO.id_inventario = @idInventario;
	
	INSERT INTO HISTORICO_INVENTARIO (id_empleado,id_inventario_historico,fecha,descripcion)
	VALUES (@idEmpleado,@idInventario,@fecha,'Se realiza disminución de inventario.  Motivo: '+@descripcionBaja); 
END

GO
/****** Object:  StoredProcedure [dbo].[AgregarDetalleFacturaProducto]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--CREA EL DETALLE DE FACTURA PRODUCTO
CREATE PROCEDURE [dbo].[AgregarDetalleFacturaProducto]
@idProducto int,
@cantidad int,
@idFactura int
AS
BEGIN
INSERT INTO DETALLE_FACTURA_PRODUCTO (id_producto_detalle_factura,id_factura_detalle_factura,cantidad_venta)
VALUES (@idProducto,@idFactura,@cantidad)
END

GO
/****** Object:  StoredProcedure [dbo].[AgregarDetalleFacturaSolicitud]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--CREA EL DETALLE DE FACTURA SOLICITUD
CREATE PROCEDURE [dbo].[AgregarDetalleFacturaSolicitud]
@idSolicitud int,
@cantidad int,
@idFactura int
AS
BEGIN
INSERT INTO DETALLE_FACTURA_SOLICITUD(id_solicitud_detalle_factura,id_factura_detalle_factura,cantidad_venta)
VALUES (@idSolicitud,@idFactura,@cantidad)
END

GO
/****** Object:  StoredProcedure [dbo].[AgregarElemento]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--PROCEDIMIENTO ALMACENADO PARA  agregar un elemento 

CREATE PROC [dbo].[AgregarElemento]
@id_categ int,
@id_tipo_elem int,
@serial VARCHAR(4),
@placa VARCHAR(30),
@modelo VARCHAR(30),
@marca VARCHAR(15),
@ram VARCHAR(10),
@rom VARCHAR(15),
@serial_bateria VARCHAR(4),
@SO VARCHAR(20)

as
BEGIN 
DECLARE @idElemento int
INSERT INTO ELEMENTO(serial,placa,modelo,marca,ram,rom,serial_bateria,sistema_operativo,id_tipo_elemento,id_categoria_elemento)
VALUES (@serial,@placa,@modelo,@marca,@ram,@rom,@serial_bateria,@SO,@id_tipo_elem,@id_categ);
SET @idElemento = @@IDENTITY

SELECT id_elemento FROM ELEMENTO WHERE id_elemento = @idElemento 

END

GO
/****** Object:  StoredProcedure [dbo].[AgregarServicio]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--PROCEDIMIENTO ALMACENADO PARA crear un servicio

CREATE PROCEDURE [dbo].[AgregarServicio]
@descripc VARCHAR(50),
@precio decimal(20,4)
as

BEGIN 
IF NOT EXISTS(SELECT descripcion_servicio FROM SERVICIO WHERE descripcion_servicio =@descripc)
	BEGIN
	INSERT INTO SERVICIO (descripcion_servicio,precio)
	VALUES (@descripc,@precio);
	END
	
SELECT @@ROWCOUNT;
END

GO
/****** Object:  StoredProcedure [dbo].[AgregarSucursal]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--PERMITE LA CREACION DE UNA NUEVA SUCURSAL
CREATE PROCEDURE [dbo].[AgregarSucursal]
@nombre VARCHAR(20),
@direccion VARCHAR(50),
@ciudad VARCHAR(50),
@telefonoFijo VARCHAR(10),
@telefonoCelular VARCHAR(10)
AS
BEGIN
	IF NOT EXISTS(SELECT nombre FROM SUCURSAL WHERE nombre =@nombre)
	BEGIN
		INSERT INTO SUCURSAL (nombre,direccion,ciudad,telefonoFijo,telefonoCelular)
		VALUES (@nombre,@direccion,@ciudad,@telefonoFijo,@telefonoCelular)
	END
SELECT @@ROWCOUNT;
END

GO
/****** Object:  StoredProcedure [dbo].[AgregarUsuario]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	
-- PROCEDIMIENTO ALMACENADO PARA AGREGAR USUARIO	
CREATE PROCEDURE [dbo].[AgregarUsuario]
@tipoIdent int,
@estado int,
@rol int,
@identif VARCHAR(15),
@apellidos VARCHAR(30),
@nombres VARCHAR(30),
@direccion VARCHAR(50),
@correo VARCHAR(50),
@sexo CHAR(1),
@username VARCHAR(15),
@Passwd nVARCHAR(50),
@idSucursal int
as
BEGIN 
DECLARE @idusu int;
INSERT INTO USUARIO(id_tipo_Identificacion_usuario,id_estado_usuario,id_rol_usuario,identificacion,apellidos,nombres,direccion,correo,sexo,usuario_login,password)
VALUES (@tipoIdent,@estado,@rol,@identif,@apellidos,@nombres,@direccion,@correo,@sexo,@username,ENCRYPTBYPASSPHRASE('C0ntr4s3n4', @Passwd));

SET @idusu = @@IDENTITY;
IF(@rol<>1)
	BEGIN
		INSERT INTO ESCALADO (id_escalado,id_usuario_escalado,id_sucursal_escalado) VALUES (@idusu,@idusu,@idSucursal);
		INSERT INTO VALIDAR_USUARIO_LOGUEADO (idEmpleado,estado) VALUES (@idusu,'NoActivo');
	END
END

GO
/****** Object:  StoredProcedure [dbo].[AnularFactura]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[AnularFactura]
@idFactura int,
@identifEmpleado VARCHAR(15),
@MotivoAnulacion VARCHAR(500)
AS
DECLARE @fecha DATETIME, @idEmpleado int
SET @fecha = (SELECT CURRENT_TIMESTAMP);
SET @idEmpleado = (SELECT id_usuario FROM USUARIO WHERE identificacion = @identifEmpleado);

BEGIN
	UPDATE FACTURA SET id_estado_factura = 2
	WHERE id_factura =  @idFactura;

	INSERT INTO HISTORICO_FACTURA (id_empleado_historico,id_factura_historico,descripcion_historico,fecha_historico)
	VALUES (@idEmpleado,@idFactura,'factura Anulada por el empleado con id: '+@identifEmpleado+', Motivo: '+@MotivoAnulacion,@fecha);
END

GO
/****** Object:  StoredProcedure [dbo].[CambiarEmpleado_de_Sucursal]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- CAMBIA DE SUCURSAL A UN EMPLEADO
CREATE PROCEDURE [dbo].[CambiarEmpleado_de_Sucursal]
@identifEmpleado VARCHAR(15),
@idSucursal int

AS
BEGIN
DECLARE @idEmpleado int
END
SET @idEmpleado = (SELECT id_usuario FROM USUARIO WHERE identificacion = @identifEmpleado);

UPDATE ESCALADO SET id_sucursal_escalado = @idSucursal WHERE id_usuario_escalado = @idEmpleado

GO
/****** Object:  StoredProcedure [dbo].[CambiarEstadoLogueoUser]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ACTUALIZA EL ESTADO DE LOGUEO DEL USUARIO
CREATE PROCEDURE [dbo].[CambiarEstadoLogueoUser]
@username VARCHAR(15)
AS
DECLARE @idEmpleado int, @estadoActual VARCHAR(15)
SET @idEmpleado = (SELECT id_usuario FROM USUARIO WHERE usuario_login = @username);
SET @estadoActual = (SELECT estado FROM VALIDAR_USUARIO_LOGUEADO WHERE idEmpleado = @idEmpleado);
BEGIN 
	IF (@estadoActual = 'NoActivo')
	BEGIN
		UPDATE VALIDAR_USUARIO_LOGUEADO SET estado = 'Activo' WHERE idEmpleado = @idEmpleado;
	END
	ELSE IF (@estadoActual = 'Activo')
		UPDATE VALIDAR_USUARIO_LOGUEADO SET estado = 'NoActivo' WHERE idEmpleado = @idEmpleado;
END

GO
/****** Object:  StoredProcedure [dbo].[CambiarEstadoProducto]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--PROCEDIMIENTO ALMACENADO PARA ACTUALIZAR EL ESTADO DEL PRODUCTO
CREATE PROC [dbo].[CambiarEstadoProducto]
@idProd int,
@idEstado int

as
BEGIN 

UPDATE PRODUCTO SET id_estado_producto=@idEstado WHERE id_producto = @idProd

END

GO
/****** Object:  StoredProcedure [dbo].[CambiarEstadoSolicitud]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--PROCEDIMIENTO ALMACENADO PARA CAMBIAR EL ESTADO DE LA SOLICITUD Y AGREGARLO EN HISTORICO 
CREATE PROC [dbo].[CambiarEstadoSolicitud]
@idSolicit int,
@idEstadoAnterior int,
@idEstadoNuevo int,
@identifEmpleado VARCHAR (15)
as
BEGIN 
	DECLARE @fecha DATETIME,
	@Descrip_estado_anterior VARCHAR(50),
	@Descrip_estado_nuevo VARCHAR(50),
	@idEmpleado int;
	SET @fecha = (SELECT CURRENT_TIMESTAMP);
	SET @Descrip_estado_anterior = (SELECT ESTADO_SOLICITUD.descripcion FROM ESTADO_SOLICITUD INNER JOIN SOLICITUD ON ESTADO_SOLICITUD.id_estado_solicitud = SOLICITUD.id_estado_solicitud WHERE id_solicitud =  @idSolicit);
	SET @idEmpleado = (SELECT id_usuario FROM USUARIO WHERE identificacion = @identifEmpleado);
	SET @Descrip_estado_nuevo = (SELECT descripcion FROM ESTADO_SOLICITUD WHERE id_estado_solicitud = @idEstadoNuevo);
	IF(@idEstadoAnterior = 5)
		BEGIN
			UPDATE SOLICITUD SET id_estado_solicitud = @idEstadoNuevo, fecha_solicitud = @fecha 
			WHERE id_solicitud = @idSolicit

			INSERT INTO HISTORICO_SOLICITUD (id_usuario_historico,id_solicitud_historico,descripcion_historico,fecha_historico)
			VALUES (@idEmpleado,@idSolicit,'Se ha modificado el estado de la solicitud de '+@Descrip_estado_anterior+' a '+ @Descrip_estado_nuevo,@fecha)
		END
	ELSE IF (@idEstadoAnterior <> 4 AND @idEstadoAnterior <> 1)
		BEGIN
			UPDATE SOLICITUD SET id_estado_solicitud = @idEstadoNuevo 
			WHERE id_solicitud = @idSolicit

			INSERT INTO HISTORICO_SOLICITUD (id_usuario_historico,id_solicitud_historico,descripcion_historico,fecha_historico)
			VALUES (@idEmpleado,@idSolicit,'Se ha modificado el estado de la solicitud de '+@Descrip_estado_anterior+' a '+ @Descrip_estado_nuevo,@fecha)
		END
	SELECT id_solicitud FROM SOLICITUD WHERE id_solicitud = @idSolicit AND id_estado_solicitud = @idEstadoNuevo
END	

GO
/****** Object:  StoredProcedure [dbo].[ConsultaNombresEmpleadosXSolicitud]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--PROCEDIMIENTO PARA Consulta Nombres Empleados X Solicitud
CREATE PROCEDURE [dbo].[ConsultaNombresEmpleadosXSolicitud]
AS
BEGIN
SELECT    USUARIO.nombres
FROM            ESCALADO INNER JOIN
                         SOLICITUD ON ESCALADO.id_escalado = SOLICITUD.id_escalado_solicitud INNER JOIN
                         USUARIO ON ESCALADO.id_usuario_escalado = USUARIO.id_usuario;
END

GO
/****** Object:  StoredProcedure [dbo].[Consultar_id_UsuarioXIdentificacion]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--PROCEDIMIENTO ALMACENADO PARA CONSULTAR el id de un usuario segun su numero de identificacion
CREATE PROCEDURE [dbo].[Consultar_id_UsuarioXIdentificacion]
@codigo int
AS
BEGIN
SELECT id_usuario FROM USUARIO WHERE identificacion = @codigo
END

GO
/****** Object:  StoredProcedure [dbo].[ConsultarCantidadDeProductos]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- TRAE LA CANTIDAD DE REGISTROS QUE HAY DE PRODUCTOS
CREATE PROCEDURE [dbo].[ConsultarCantidadDeProductos]
AS
BEGIN
SELECT count(*) FROM  PRODUCTO
END

GO
/****** Object:  StoredProcedure [dbo].[ConsultarCantidadProductoXid]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- PROCEDIMIENTO QUE TRAE LA CANTIDAD DE EXISTENCIAS DE UN PRODUCTO EN ESPECIAL
CREATE PROCEDURE [dbo].[ConsultarCantidadProductoXid]
@idProd int
AS
BEGIN
SELECT cantidad_existencias FROM INVENTARIO WHERE id_producto_inventario = @idProd
END

GO
/****** Object:  StoredProcedure [dbo].[ConsultarCantidadXProducto]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- PROCEDIMIENTO QUE TRAE LA CANTIDAD DE EXISTENCIAS POR PRODUCTO
CREATE PROCEDURE [dbo].[ConsultarCantidadXProducto]
@id_inventario int
AS
BEGIN 
SELECT  cantidad_existencias FROM INVENTARIO WHERE id_inventario =  @id_inventario
END

GO
/****** Object:  StoredProcedure [dbo].[ConsultarCategorias_Elemento]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--PROCEDIMIENTO ALMACENADO PARA CONSULTAR TODOS LOS CATEGORIAS DE ELEMENTO
CREATE PROCEDURE [dbo].[ConsultarCategorias_Elemento]
AS
BEGIN
SELECT id_categoria_elemento,descripcion_categoria_elemento FROM CATEGORIA_ELEMENTO
END

GO
/****** Object:  StoredProcedure [dbo].[ConsultarCategoriasProductos]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--PROCEDIMIENTO ALMACENADO PARA CONSULTAR LAS CATEGORIAS DE LOS PRODUCTOS
CREATE PROC [dbo].[ConsultarCategoriasProductos]
AS
BEGIN
SELECT id_categoria,descripcion FROM CATEGORIA_PRODUCTO
END

GO
/****** Object:  StoredProcedure [dbo].[ConsultarDetallesFacturaProducto]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--PROCEDIMIENTO QUE CONSULTA TODOS LOS DETALLES DE FACTURA EN BD
CREATE PROCEDURE [dbo].[ConsultarDetallesFacturaProducto]
AS
BEGIN
SELECT        PRODUCTO.nombre_producto, DETALLE_FACTURA_PRODUCTO.cantidad_venta, FACTURA.id_factura, PRODUCTO.precio_venta
FROM            DETALLE_FACTURA_PRODUCTO INNER JOIN
                         FACTURA ON DETALLE_FACTURA_PRODUCTO.id_factura_detalle_factura = FACTURA.id_factura INNER JOIN
                         PRODUCTO ON DETALLE_FACTURA_PRODUCTO.id_producto_detalle_factura = PRODUCTO.id_producto
END

GO
/****** Object:  StoredProcedure [dbo].[ConsultarDetallesFacturaProductoXid]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- PROCEDIMIENTO QUE CONSULTA LOS DETALLE DE FACTURA PRODUCTO SEGUN UN NUM DE FACTURA ESPECIFICO
CREATE PROCEDURE [dbo].[ConsultarDetallesFacturaProductoXid] 
@idFactura int
AS
BEGIN
SELECT        PRODUCTO.id_producto, PRODUCTO.nombre_producto, DETALLE_FACTURA_PRODUCTO.cantidad_venta, FACTURA.id_factura, PRODUCTO.precio_venta
FROM            DETALLE_FACTURA_PRODUCTO INNER JOIN
                         FACTURA ON DETALLE_FACTURA_PRODUCTO.id_factura_detalle_factura = FACTURA.id_factura INNER JOIN
                         PRODUCTO ON DETALLE_FACTURA_PRODUCTO.id_producto_detalle_factura = PRODUCTO.id_producto
	WHERE id_factura_detalle_factura = @idFactura
END

GO
/****** Object:  StoredProcedure [dbo].[ConsultarDetallesFacturaSolicitudXid]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- PROCEDIMIENTO QUE CONSULTA LOS DETALLES DE FACTURA DE LA SOLICITUD SEGUN NUMERO DE FACTURA ESPECIFICO
CREATE PROCEDURE [dbo].[ConsultarDetallesFacturaSolicitudXid] 
@idFactura int
AS
BEGIN
SELECT        SOLICITUD.id_solicitud, SERVICIO.descripcion_servicio, SERVICIO.precio, SOLICITUD.id_estado_solicitud
FROM            DETALLE_FACTURA_SOLICITUD INNER JOIN
                         FACTURA ON DETALLE_FACTURA_SOLICITUD.id_factura_detalle_factura = FACTURA.id_factura INNER JOIN
                         SOLICITUD ON DETALLE_FACTURA_SOLICITUD.id_solicitud_detalle_factura = SOLICITUD.id_solicitud INNER JOIN
                         SERVICIO ON SOLICITUD.id_servicio_solicitud = SERVICIO.id_servicio
WHERE FACTURA.id_factura =  @idFactura
END

GO
/****** Object:  StoredProcedure [dbo].[ConsultarElementos]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--PROCEDIMIENTO QUE CONSULTA TODOS LOS ELEMENTOS EN BD
CREATE PROCEDURE [dbo].[ConsultarElementos]
AS
BEGIN
	SELECT          ELEMENTO.id_elemento,ELEMENTO.id_tipo_elemento,TIPO_ELEMENTO.descripcion_elemento,ELEMENTO.id_categoria_elemento, CATEGORIA_ELEMENTO.descripcion_categoria_elemento, ELEMENTO.serial, ELEMENTO.placa, ELEMENTO.modelo, ELEMENTO.marca, 
                         ELEMENTO.ram, ELEMENTO.rom, ELEMENTO.serial_bateria, ELEMENTO.sistema_operativo
                         
FROM            CATEGORIA_ELEMENTO INNER JOIN
                         ELEMENTO ON CATEGORIA_ELEMENTO.id_categoria_elemento = ELEMENTO.id_categoria_elemento INNER JOIN
                         TIPO_ELEMENTO ON ELEMENTO.id_tipo_elemento = TIPO_ELEMENTO.id_tipo_elemento
END

GO
/****** Object:  StoredProcedure [dbo].[ConsultarEmpleados]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--CONSULTA LOS EMPLEADOS EN SU TOTALIDAD INCLUYENDO SU SUCURSAL
CREATE PROCEDURE [dbo].[ConsultarEmpleados]
AS
BEGIN
SELECT        USUARIO.id_usuario, USUARIO.nombres, USUARIO.apellidos, USUARIO.identificacion, USUARIO.direccion, USUARIO.correo, USUARIO.sexo, ESTADO_USUARIO.descripcion, ROL.descripcion AS Rol, 
                         SUCURSAL.nombre as sucursal, USUARIO.usuario_login as username
FROM            ESTADO_USUARIO INNER JOIN
                         USUARIO ON ESTADO_USUARIO.id_estado = USUARIO.id_estado_usuario INNER JOIN
                         ROL ON USUARIO.id_rol_usuario = ROL.id_rol INNER JOIN
                         ESCALADO ON USUARIO.id_usuario = ESCALADO.id_usuario_escalado INNER JOIN
                         SUCURSAL ON ESCALADO.id_sucursal_escalado = SUCURSAL.id_sucursal
END

GO
/****** Object:  StoredProcedure [dbo].[ConsultarEstado_Solicitud]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--PROCEDIMIENTO QUE CONSULTA EL ID Y DESCRIPCION  DEL ESTADO DE LA SOLICITUD DE UNA SOLICITUD SEGUN EL ID QUE SE ENVIA
CREATE PROCEDURE [dbo].[ConsultarEstado_Solicitud]
@idSolic int
AS
BEGIN

SELECT        SOLICITUD.id_estado_solicitud, ESTADO_SOLICITUD.descripcion
FROM            ESTADO_SOLICITUD INNER JOIN
                         SOLICITUD ON ESTADO_SOLICITUD.id_estado_solicitud = SOLICITUD.id_estado_solicitud
WHERE id_solicitud = @idSolic

END

GO
/****** Object:  StoredProcedure [dbo].[ConsultarEstadoEmpleadoX_Username]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--CONSULTA EL ESTADO DE UN EMPLEADO USANDO SU USERNAME
CREATE PROCEDURE [dbo].[ConsultarEstadoEmpleadoX_Username]
@username VARCHAR (15)
AS
BEGIN
SELECT        ESTADO_USUARIO.descripcion
FROM            ESTADO_USUARIO INNER JOIN
                         USUARIO ON ESTADO_USUARIO.id_estado = USUARIO.id_estado_usuario
WHERE USUARIO.usuario_login = @username
END

GO
/****** Object:  StoredProcedure [dbo].[ConsultarEstadoFactura]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--PROCEDIMIENTO QUE CONSULTA EL ESTADO DE UNA FACTURA SEGUN SU ID Y TRAE EL VALOR , EL SALDO Y EL ESTADO
CREATE PROCEDURE [dbo].[ConsultarEstadoFactura]
@idFactura int
AS
BEGIN
SELECT        FACTURA.id_factura, FACTURA.saldo, FACTURA.valor_total, ESTADO_FACTURA.descripcion_estado_factura
FROM            ESTADO_FACTURA INNER JOIN
                         FACTURA ON ESTADO_FACTURA.id_estado_factura = FACTURA.id_estado_factura
WHERE FACTURA.id_factura = @idFactura;
END

GO
/****** Object:  StoredProcedure [dbo].[ConsultarEstadoLogueoUser]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- CONSULTA EL ESTADO DE UN EMPLEADO PARA SABER SI ESTA LOGUEADO O NO
CREATE PROCEDURE [dbo].[ConsultarEstadoLogueoUser]
@username VARCHAR(15)
AS
DECLARE @idEmpleado int
SET @idEmpleado = (SELECT id_usuario FROM USUARIO WHERE usuario_login = @username);
BEGIN 
	SELECT estado FROM VALIDAR_USUARIO_LOGUEADO WHERE idEmpleado = @idEmpleado
END

GO
/****** Object:  StoredProcedure [dbo].[ConsultarEstadosSolicitud]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




--PROCEDIMIENTO ALMACENADO PARA CONSULTAR TODOS LOS ESTADOS DE SOLICITUD EXISTENTES EN BD
CREATE PROCEDURE [dbo].[ConsultarEstadosSolicitud]
AS
BEGIN
SELECT id_estado_solicitud,descripcion FROM ESTADO_SOLICITUD WHERE id_estado_solicitud <> 5
END

GO
/****** Object:  StoredProcedure [dbo].[ConsultarFacturas]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--CONSULTA TODAS LAS FACTURAS EXISTENTES
CREATE PROCEDURE [dbo].[ConsultarFacturas]
AS
BEGIN

SELECT        FACTURA.id_factura, FACTURA.fecha, USUARIO.identificacion, USUARIO.apellidos, USUARIO.nombres, ESTADO_FACTURA.descripcion_estado_factura, FACTURA.saldo, FACTURA.valor_total
FROM            FACTURA INNER JOIN
                         USUARIO ON FACTURA.id_cliente_factura = USUARIO.id_usuario INNER JOIN
                         ESTADO_FACTURA ON FACTURA.id_estado_factura = ESTADO_FACTURA.id_estado_factura

END

GO
/****** Object:  StoredProcedure [dbo].[ConsultarFacturaXid]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- CONSULTA LA FACTURA COMPLETA SEGUN SU ID PARA PRESENTARLA AL USUARIO
CREATE PROCEDURE [dbo].[ConsultarFacturaXid]
@idFactura int
AS
BEGIN

SELECT        FACTURA.id_factura, ESTADO_FACTURA.descripcion_estado_factura, FACTURA.fecha, FACTURA.saldo, FACTURA.valor_total, USUARIO.nombres, USUARIO.apellidos, USUARIO.identificacion, 
                         PRODUCTO.precio_venta, PRODUCTO.nombre_producto, DETALLE_FACTURA_PRODUCTO.cantidad_venta, SERVICIO.descripcion_servicio, SERVICIO.precio
FROM            ESTADO_FACTURA INNER JOIN
                         FACTURA ON ESTADO_FACTURA.id_estado_factura = FACTURA.id_estado_factura INNER JOIN
                         DETALLE_FACTURA_PRODUCTO ON FACTURA.id_factura = DETALLE_FACTURA_PRODUCTO.id_factura_detalle_factura INNER JOIN
                         DETALLE_FACTURA_SOLICITUD ON FACTURA.id_factura = DETALLE_FACTURA_SOLICITUD.id_factura_detalle_factura INNER JOIN
                         PRODUCTO ON DETALLE_FACTURA_PRODUCTO.id_producto_detalle_factura = PRODUCTO.id_producto INNER JOIN
                         SOLICITUD ON DETALLE_FACTURA_SOLICITUD.id_solicitud_detalle_factura = SOLICITUD.id_solicitud INNER JOIN
                         SERVICIO ON SOLICITUD.id_servicio_solicitud = SERVICIO.id_servicio INNER JOIN
                         USUARIO ON FACTURA.id_cliente_factura = USUARIO.id_usuario 
WHERE        FACTURA.id_factura =  @idFactura
END

GO
/****** Object:  StoredProcedure [dbo].[ConsultarHistoricoFacturaX_id]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- CONSULTA EL HISTORICO DE UNA FACTURA ESPECIFICA
CREATE PROCEDURE [dbo].[ConsultarHistoricoFacturaX_id]
@idFactura int
AS
BEGIN 
SELECT        HISTORICO_FACTURA.fecha_historico, HISTORICO_FACTURA.descripcion_historico, USUARIO.apellidos, USUARIO.nombres, FACTURA.id_factura
FROM            HISTORICO_FACTURA INNER JOIN
                         FACTURA ON HISTORICO_FACTURA.id_factura_historico = FACTURA.id_factura INNER JOIN
                         USUARIO ON HISTORICO_FACTURA.id_empleado_historico = USUARIO.id_usuario
WHERE FACTURA.id_factura = @idFactura
END

GO
/****** Object:  StoredProcedure [dbo].[ConsultarHistoricoInventarioBajasX_id]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--PROCEDIMIENTO CONSULTA EL HISTORICO DEL INVENTARIO DE BAJAS SEGUN SU ID
CREATE PROCEDURE [dbo].[ConsultarHistoricoInventarioBajasX_id]
@id_inventario int
AS
BEGIN 
SELECT        HISTORICO_INVENTARIO_BAJAS.fecha, USUARIO.nombres, USUARIO.apellidos, HISTORICO_INVENTARIO_BAJAS.descripcion
FROM            HISTORICO_INVENTARIO_BAJAS INNER JOIN
                         INVENTARIO_BAJAS ON HISTORICO_INVENTARIO_BAJAS.id_inventario_historico = INVENTARIO_BAJAS.id_inventario_bajas INNER JOIN
                         USUARIO ON HISTORICO_INVENTARIO_BAJAS.id_empleado = USUARIO.id_usuario INNER JOIN
                         PRODUCTO ON INVENTARIO_BAJAS.id_producto_inventario = PRODUCTO.id_producto
WHERE INVENTARIO_BAJAS.id_inventario_bajas = @id_inventario
END

GO
/****** Object:  StoredProcedure [dbo].[ConsultarHistoricoInventarioX_id]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--PROCEDIMIENTO CONSULTA EL HISTORICO DEL INVENTARIO SEGUN SU ID
CREATE PROCEDURE [dbo].[ConsultarHistoricoInventarioX_id]
@id_inventario int
AS
BEGIN 
SELECT        HISTORICO_INVENTARIO.fecha, USUARIO.nombres, USUARIO.apellidos, HISTORICO_INVENTARIO.descripcion
FROM            HISTORICO_INVENTARIO INNER JOIN
                         INVENTARIO ON HISTORICO_INVENTARIO.id_inventario_historico = INVENTARIO.id_inventario INNER JOIN
                         USUARIO ON HISTORICO_INVENTARIO.id_empleado = USUARIO.id_usuario INNER JOIN
                         PRODUCTO ON INVENTARIO.id_producto_inventario = PRODUCTO.id_producto
WHERE INVENTARIO.id_inventario = @id_inventario
END

GO
/****** Object:  StoredProcedure [dbo].[ConsultarHistoricoSolicitudX_id]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--PROCEDIMIENTO QUE CONSULTA EL HISTORICO DE UNA SOLICITUD SEGUN EL ID ENVIADO
CREATE PROCEDURE [dbo].[ConsultarHistoricoSolicitudX_id]
@id_solicitud int
AS
BEGIN 
SELECT        HISTORICO_SOLICITUD.fecha_historico, HISTORICO_SOLICITUD.descripcion_historico, USUARIO.apellidos, USUARIO.nombres, SOLICITUD.id_solicitud
FROM            HISTORICO_SOLICITUD INNER JOIN
                         SOLICITUD ON HISTORICO_SOLICITUD.id_solicitud_historico = SOLICITUD.id_solicitud INNER JOIN
                         USUARIO ON HISTORICO_SOLICITUD.id_usuario_historico = USUARIO.id_usuario
WHERE SOLICITUD.id_solicitud = @id_solicitud
END

GO
/****** Object:  StoredProcedure [dbo].[ConsultarIdProductos]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- CONSULTA LA LISTA DE IDs DE TODOS LOS PRODUCTOS
CREATE PROCEDURE [dbo].[ConsultarIdProductos]
AS
BEGIN
SELECT count(*) FROM  PRODUCTO
END

GO
/****** Object:  StoredProcedure [dbo].[ConsultarInventarioBajas]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--PROCEDIMIENTO CONSULTA EL TOTAL DE INVENTARIOS DE TODOS LOS PRODUCTOS
CREATE PROCEDURE [dbo].[ConsultarInventarioBajas]
AS
BEGIN
SELECT        INVENTARIO_BAJAS.id_inventario_bajas, PRODUCTO.nombre_producto, INVENTARIO_BAJAS.id_producto_inventario, INVENTARIO_BAJAS.cantidad_existencias, INVENTARIO_BAJAS.fecha_actualizacion_inventario, SUCURSAL.id_sucursal, SUCURSAL.nombre
FROM            INVENTARIO_BAJAS INNER JOIN
                         PRODUCTO ON INVENTARIO_BAJAS.id_producto_inventario = PRODUCTO.id_producto INNER JOIN
						  SUCURSAL ON INVENTARIO_BAJAS.id_sucursal_inventario = SUCURSAL.id_sucursal
END

GO
/****** Object:  StoredProcedure [dbo].[ConsultarInventarios]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--PROCEDIMIENTO CONSULTA EL TOTAL DE INVENTARIOS DE TODOS LOS PRODUCTOS
CREATE PROCEDURE [dbo].[ConsultarInventarios]
AS
BEGIN
SELECT        INVENTARIO.id_inventario, PRODUCTO.nombre_producto, INVENTARIO.id_producto_inventario, INVENTARIO.cantidad_existencias, INVENTARIO.fecha_actualizacion_inventario, 
                         ESTADO_PRODUCTO.descripcion_estado_producto, SUCURSAL.id_sucursal, SUCURSAL.nombre
FROM            INVENTARIO INNER JOIN
                         PRODUCTO ON INVENTARIO.id_producto_inventario = PRODUCTO.id_producto INNER JOIN
                         ESTADO_PRODUCTO ON PRODUCTO.id_estado_producto = ESTADO_PRODUCTO.id_estado_producto INNER JOIN
                         SUCURSAL ON INVENTARIO.id_sucursal_inventario = SUCURSAL.id_sucursal
END

GO
/****** Object:  StoredProcedure [dbo].[ConsultarInventarioXCodigoProducto]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--PROCEDIMIENTO CONSULTA EL INVENTARIO DE UN PRODUCTO SEGUN SU CODIGO
CREATE PROCEDURE [dbo].[ConsultarInventarioXCodigoProducto]
@codigo int
AS
BEGIN
SELECT        INVENTARIO.id_inventario, PRODUCTO.nombre_producto, INVENTARIO.id_producto_inventario, INVENTARIO.cantidad_existencias, INVENTARIO.fecha_actualizacion_inventario, 
                         ESTADO_PRODUCTO.descripcion_estado_producto
FROM            INVENTARIO INNER JOIN
                         PRODUCTO ON INVENTARIO.id_producto_inventario = PRODUCTO.id_producto INNER JOIN
                         ESTADO_PRODUCTO ON PRODUCTO.id_estado_producto = ESTADO_PRODUCTO.id_estado_producto
WHERE PRODUCTO.id_producto = @codigo
END

GO
/****** Object:  StoredProcedure [dbo].[ConsultarInventarioXNombreProducto]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--PROCEDIMIENTO CONSULTA EL INVENTARIO DE UN PRODUCTO SEGUN SU NOMBRE
CREATE PROCEDURE [dbo].[ConsultarInventarioXNombreProducto]
@nombr VARCHAR(100)
AS
BEGIN
SELECT        INVENTARIO.id_inventario, PRODUCTO.nombre_producto, INVENTARIO.id_producto_inventario, INVENTARIO.cantidad_existencias, INVENTARIO.fecha_actualizacion_inventario, 
                         ESTADO_PRODUCTO.descripcion_estado_producto
FROM            INVENTARIO INNER JOIN
                         PRODUCTO ON INVENTARIO.id_producto_inventario = PRODUCTO.id_producto INNER JOIN
                         ESTADO_PRODUCTO ON PRODUCTO.id_estado_producto = ESTADO_PRODUCTO.id_estado_producto
WHERE PRODUCTO.nombre_producto like  '%'+@nombr+'%'
END

GO
/****** Object:  StoredProcedure [dbo].[ConsultarNombreSucursalEmpleado]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- CONSULTA NOMBRE DE SUCURSAL DEL EMPLEADO LOGUEADO

CREATE PROCEDURE [dbo].[ConsultarNombreSucursalEmpleado]
@identifEmpleado VARCHAR (15)
AS
BEGIN
DECLARE @idEmpleado int
SET @idEmpleado = (SELECT id_usuario FROM USUARIO WHERE identificacion = @identifEmpleado);
SELECT        SUCURSAL.nombre
FROM            ESCALADO INNER JOIN
                         SUCURSAL ON ESCALADO.id_sucursal_escalado = SUCURSAL.id_sucursal
WHERE id_usuario_escalado = @idEmpleado

END 

GO
/****** Object:  StoredProcedure [dbo].[ConsultarPermisosXUsuario]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--PROCEDIMIENTO ALMACENADO PARA CONSULTAR PERMISOS POR ROL DE USUARIO RETORNANDO LOS PERMISOS Y EL ID A LOS QUE NO TIENE ACCESO
CREATE PROC [dbo].[ConsultarPermisosXUsuario]
@identif VARCHAR(15)
AS
BEGIN
SELECT        PERMISO.descripcion, PERMISO_DENEGADO_POR_ROL.permiso_id
FROM            PERMISO INNER JOIN
                         PERMISO_DENEGADO_POR_ROL ON PERMISO.permisoID = PERMISO_DENEGADO_POR_ROL.permiso_id INNER JOIN
                         ROL ON PERMISO_DENEGADO_POR_ROL.id_rol = ROL.id_rol INNER JOIN
                         USUARIO ON ROL.id_rol = USUARIO.id_rol_usuario
WHERE USUARIO.identificacion = @identif
END

GO
/****** Object:  StoredProcedure [dbo].[ConsultarProductoEnTodasLasSucursales]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--CONSULTA EL MISMO PRODUCTO EN TODAS LAS SUCURSALES Y TRAE LA LISTA DE LAS MISMAS PARA DESPUES SUMAR SUS CANTIDADES
CREATE PROCEDURE [dbo].[ConsultarProductoEnTodasLasSucursales]
@idProducto int
AS
BEGIN
SELECT        PRODUCTO.id_producto, PRODUCTO.nombre_producto, INVENTARIO.cantidad_existencias
FROM            INVENTARIO INNER JOIN
                         PRODUCTO ON INVENTARIO.id_producto_inventario = PRODUCTO.id_producto
WHERE PRODUCTO.id_producto = @idProducto
END

GO
/****** Object:  StoredProcedure [dbo].[ConsultarProductos]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--PROCEDIMIENTO ALMACENADO PARA CONSULTAR TODOS LOS PRODUCTOS
CREATE PROCEDURE [dbo].[ConsultarProductos]
AS
BEGIN
SELECT id_producto,id_estado_producto,nombre_producto,precio_costo,precio_venta FROM PRODUCTO
END

GO
/****** Object:  StoredProcedure [dbo].[ConsultarProductosXSucursal]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- CONSULTA LOS PRODUCTOS EXISTENTES EN UNA SUCURSAL Y SU CANTIDAD
CREATE PROCEDURE [dbo].[ConsultarProductosXSucursal]
@idSucursal int
AS
BEGIN

SELECT        PRODUCTO.id_producto, PRODUCTO.nombre_producto, INVENTARIO.cantidad_existencias, ESTADO_PRODUCTO.descripcion_estado_producto, INVENTARIO.fecha_actualizacion_inventario, 
                         SUCURSAL.id_sucursal, SUCURSAL.nombre, INVENTARIO.id_inventario
FROM            INVENTARIO INNER JOIN
                         PRODUCTO ON INVENTARIO.id_producto_inventario = PRODUCTO.id_producto INNER JOIN
                         SUCURSAL ON INVENTARIO.id_sucursal_inventario = SUCURSAL.id_sucursal INNER JOIN
                         ESTADO_PRODUCTO ON PRODUCTO.id_estado_producto = ESTADO_PRODUCTO.id_estado_producto
WHERE SUCURSAL.id_sucursal = @idSucursal
END

GO
/****** Object:  StoredProcedure [dbo].[ConsultarProductosXSucursalSegunEmpleado]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- CONSULTA LOS PRODUCTOS EXISTENTES EN UNA SUCURSAL Y SU CANTIDAD DEPENDIENDO EL EMPLEADO LOGUEADO
CREATE PROCEDURE [dbo].[ConsultarProductosXSucursalSegunEmpleado]
@identifEmpleado VARCHAR(15)
AS 
BEGIN
DECLARE @id_sucursalEmpleado int, @idEmpleado int
SET @idEmpleado = (SELECT id_usuario FROM USUARIO WHERE identificacion = @identifEmpleado);
SET @id_sucursalEmpleado = (SELECT id_sucursal_escalado FROM ESCALADO WHERE id_usuario_escalado = @idEmpleado);
SELECT        PRODUCTO.id_producto, PRODUCTO.nombre_producto, PRODUCTO.precio_costo, PRODUCTO.precio_venta, INVENTARIO.cantidad_existencias, SUCURSAL.id_sucursal, SUCURSAL.nombre
FROM            INVENTARIO INNER JOIN
                         PRODUCTO ON INVENTARIO.id_producto_inventario = PRODUCTO.id_producto INNER JOIN
                         SUCURSAL ON INVENTARIO.id_sucursal_inventario = SUCURSAL.id_sucursal
WHERE INVENTARIO.id_sucursal_inventario =  @id_sucursalEmpleado
END

GO
/****** Object:  StoredProcedure [dbo].[ConsultarProductoXCodigo]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--PROCEDIMIENTO ALMACENADO PARA CONSULTAR UN PRODUCTO POR CODIGO.  ADICIONAL A ELLO ACTUALIZA EL ESTADO DEL PRODUCTO EN CASO TAL QUE NO HAYAN UNIDADES EN INVENTARIO
CREATE PROCEDURE [dbo].[ConsultarProductoXCodigo]
@codigo int
AS
BEGIN

SELECT id_producto,id_estado_producto,nombre_producto,precio_costo,precio_venta FROM PRODUCTO
WHERE id_producto = @codigo

END

GO
/****** Object:  StoredProcedure [dbo].[ConsultarProductoXNombre]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--PROCEDIMIENTO ALMACENADO PARA CONSULTAR UN PRODUCTO POR NOMBRE.  ADICIONAL A ELLO ACTUALIZA EL ESTADO DEL PRODUCTO EN CASO TAL QUE NO HAYAN UNIDADES EN INVENTARIO
CREATE PROCEDURE [dbo].[ConsultarProductoXNombre] 
@nombr VARCHAR(100)
AS
BEGIN

DECLARE @cantidadProd int,
		@idProd int;

SET @idProd = (SELECT id_producto FROM PRODUCTO WHERE nombre_producto = @nombr);
SET	@cantidadProd = (SELECT cantidad_existencias FROM INVENTARIO WHERE id_producto_inventario = @idProd ); 

IF(@cantidadProd=0)
	BEGIN
		UPDATE PRODUCTO SET id_estado_producto = 2 WHERE id_producto = @idProd
	END
END

SELECT id_producto,id_estado_producto,nombre_producto,precio_costo,precio_venta FROM PRODUCTO
WHERE nombre_producto like '%'+@nombr+'%'


GO
/****** Object:  StoredProcedure [dbo].[ConsultarRolUsuario]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--PROCEDIMIENTO PARA CONSULTAR EL ROL DE UN USUARIO SEGUN SU DOCUMENTO
CREATE PROCEDURE [dbo].[ConsultarRolUsuario]
@identif VARCHAR (15)
AS
BEGIN
	SELECT id_rol_usuario FROM USUARIO WHERE identificacion = @identif
END

GO
/****** Object:  StoredProcedure [dbo].[ConsultarServicio]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--PROCEDIMIENTO ALMACENADO PARA consultar un unico servicio
CREATE PROCEDURE [dbo].[ConsultarServicio]
@codigo int
AS
BEGIN
SELECT id_servicio,descripcion_servicio,precio FROM SERVICIO
WHERE id_servicio = @codigo
END


GO
/****** Object:  StoredProcedure [dbo].[ConsultarServicios]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--PROCEDIMIENTO ALMACENADO PARA consultar los servicios
CREATE PROCEDURE [dbo].[ConsultarServicios]
AS
BEGIN
SELECT id_servicio,descripcion_servicio,precio FROM SERVICIO
END

GO
/****** Object:  StoredProcedure [dbo].[ConsultarSolicitudes]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--PROCEDIMIENTO ALMACENADO PARA CONSULTAR SOLICITUDES TOTALES
CREATE PROCEDURE [dbo].[ConsultarSolicitudes]
AS
BEGIN
SELECT        SOLICITUD.id_solicitud, SOLICITUD.descripcion, SOLICITUD.fecha_solicitud, SOLICITUD.id_escalado_solicitud, USUARIO.identificacion, USUARIO.apellidos, USUARIO.nombres, 
                         ESTADO_SOLICITUD.descripcion AS Expr1, PRIORIDAD.descripcion_prioridad, TIPO_ELEMENTO.descripcion_elemento, CATEGORIA_ELEMENTO.descripcion_categoria_elemento, ELEMENTO.sistema_operativo, 
                         ELEMENTO.marca, ELEMENTO.modelo, ELEMENTO.serial, ELEMENTO.serial_bateria, ELEMENTO.rom, ELEMENTO.ram, ELEMENTO.placa, SERVICIO.descripcion_servicio, SERVICIO.precio
FROM            SOLICITUD INNER JOIN
                         USUARIO ON SOLICITUD.id_usuario_solicitud = USUARIO.id_usuario INNER JOIN
                         PRIORIDAD ON SOLICITUD.id_prioridad_solicitud = PRIORIDAD.id_prioridad INNER JOIN
                         ESTADO_SOLICITUD ON SOLICITUD.id_estado_solicitud = ESTADO_SOLICITUD.id_estado_solicitud INNER JOIN
                         ESCALADO ON SOLICITUD.id_escalado_solicitud = ESCALADO.id_escalado INNER JOIN
                         ELEMENTO ON SOLICITUD.id_elemento_solicitud = ELEMENTO.id_elemento INNER JOIN
                         TIPO_ELEMENTO ON ELEMENTO.id_tipo_elemento = TIPO_ELEMENTO.id_tipo_elemento INNER JOIN
                         CATEGORIA_ELEMENTO ON ELEMENTO.id_categoria_elemento = CATEGORIA_ELEMENTO.id_categoria_elemento INNER JOIN
                         SERVICIO ON SOLICITUD.id_servicio_solicitud = SERVICIO.id_servicio
END

GO
/****** Object:  StoredProcedure [dbo].[ConsultarSolicitudesAPP]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ConsultarSolicitudesAPP]
AS
BEGIN

SELECT        SOLICITUD.id_solicitud, SOLICITUD.descripcion, SOLICITUD.fecha_solicitud, USUARIO.identificacion, USUARIO.apellidos, USUARIO.nombres, 
                         ESTADO_SOLICITUD.descripcion AS Estado, TIPO_ELEMENTO.descripcion_elemento,ELEMENTO.serial, SERVICIO.descripcion_servicio, SERVICIO.precio
FROM            SOLICITUD INNER JOIN
                         USUARIO ON SOLICITUD.id_usuario_solicitud = USUARIO.id_usuario INNER JOIN
                         PRIORIDAD ON SOLICITUD.id_prioridad_solicitud = PRIORIDAD.id_prioridad INNER JOIN
                         ESTADO_SOLICITUD ON SOLICITUD.id_estado_solicitud = ESTADO_SOLICITUD.id_estado_solicitud INNER JOIN
                         ESCALADO ON SOLICITUD.id_escalado_solicitud = ESCALADO.id_escalado INNER JOIN
                         ELEMENTO ON SOLICITUD.id_elemento_solicitud = ELEMENTO.id_elemento INNER JOIN
                         TIPO_ELEMENTO ON ELEMENTO.id_tipo_elemento = TIPO_ELEMENTO.id_tipo_elemento INNER JOIN
                         CATEGORIA_ELEMENTO ON ELEMENTO.id_categoria_elemento = CATEGORIA_ELEMENTO.id_categoria_elemento INNER JOIN
                         SERVICIO ON SOLICITUD.id_servicio_solicitud = SERVICIO.id_servicio

END

GO
/****** Object:  StoredProcedure [dbo].[ConsultarSolicitudesXClienteAPP]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ConsultarSolicitudesXClienteAPP]
@username VARCHAR(15)
AS
DECLARE @idCliente int;
SET @idCliente = (SELECT id_usuario FROM USUARIO WHERE usuario_login = @username);
BEGIN
SELECT        SOLICITUD.id_solicitud, SOLICITUD.descripcion, SOLICITUD.fecha_solicitud, USUARIO.identificacion, USUARIO.apellidos, USUARIO.nombres, 
                         ESTADO_SOLICITUD.descripcion AS Estado, TIPO_ELEMENTO.descripcion_elemento, SERVICIO.descripcion_servicio, SERVICIO.precio
FROM            SOLICITUD INNER JOIN
                         USUARIO ON SOLICITUD.id_usuario_solicitud = USUARIO.id_usuario INNER JOIN
                         PRIORIDAD ON SOLICITUD.id_prioridad_solicitud = PRIORIDAD.id_prioridad INNER JOIN
                         ESTADO_SOLICITUD ON SOLICITUD.id_estado_solicitud = ESTADO_SOLICITUD.id_estado_solicitud INNER JOIN
                         ESCALADO ON SOLICITUD.id_escalado_solicitud = ESCALADO.id_escalado INNER JOIN
                         ELEMENTO ON SOLICITUD.id_elemento_solicitud = ELEMENTO.id_elemento INNER JOIN
                         TIPO_ELEMENTO ON ELEMENTO.id_tipo_elemento = TIPO_ELEMENTO.id_tipo_elemento INNER JOIN
                         CATEGORIA_ELEMENTO ON ELEMENTO.id_categoria_elemento = CATEGORIA_ELEMENTO.id_categoria_elemento INNER JOIN
                         SERVICIO ON SOLICITUD.id_servicio_solicitud = SERVICIO.id_servicio
WHERE        USUARIO.id_usuario = @idCliente

END
GO
/****** Object:  StoredProcedure [dbo].[ConsultarSolicitudesXEmpleado]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--PROCEDIMIENTO ALMACENADO PARA CONSULTAR LAS SOLICITUDES DE UN EMPLEADO
CREATE PROCEDURE [dbo].[ConsultarSolicitudesXEmpleado]
@identif VARCHAR(15)
AS
DECLARE @idEmpleado int;
SET @idEmpleado = (SELECT id_usuario FROM USUARIO WHERE identificacion = @identif);
BEGIN
SELECT        SOLICITUD.id_solicitud, SOLICITUD.descripcion, SOLICITUD.fecha_solicitud, SOLICITUD.id_escalado_solicitud, USUARIO.identificacion, USUARIO.apellidos, USUARIO.nombres, 
                         ESTADO_SOLICITUD.descripcion AS Expr1, PRIORIDAD.descripcion_prioridad, TIPO_ELEMENTO.descripcion_elemento, CATEGORIA_ELEMENTO.descripcion_categoria_elemento, ELEMENTO.sistema_operativo, 
                         ELEMENTO.marca, ELEMENTO.modelo, ELEMENTO.serial, ELEMENTO.serial_bateria, ELEMENTO.rom, ELEMENTO.ram, ELEMENTO.placa, SERVICIO.descripcion_servicio, SERVICIO.precio
FROM            SOLICITUD INNER JOIN
                         USUARIO ON SOLICITUD.id_usuario_solicitud = USUARIO.id_usuario INNER JOIN
                         PRIORIDAD ON SOLICITUD.id_prioridad_solicitud = PRIORIDAD.id_prioridad INNER JOIN
                         ESTADO_SOLICITUD ON SOLICITUD.id_estado_solicitud = ESTADO_SOLICITUD.id_estado_solicitud INNER JOIN
                         ESCALADO ON SOLICITUD.id_escalado_solicitud = ESCALADO.id_escalado INNER JOIN
                         ELEMENTO ON SOLICITUD.id_elemento_solicitud = ELEMENTO.id_elemento INNER JOIN
                         TIPO_ELEMENTO ON ELEMENTO.id_tipo_elemento = TIPO_ELEMENTO.id_tipo_elemento INNER JOIN
                         CATEGORIA_ELEMENTO ON ELEMENTO.id_categoria_elemento = CATEGORIA_ELEMENTO.id_categoria_elemento INNER JOIN
                         SERVICIO ON SOLICITUD.id_servicio_solicitud = SERVICIO.id_servicio
WHERE        ESCALADO.id_escalado = @idEmpleado

END

GO
/****** Object:  StoredProcedure [dbo].[ConsultarSucursales]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--CONSULTAR SUCURSALES EXISTENTES

CREATE PROCEDURE [dbo].[ConsultarSucursales]
AS
BEGIN
SELECT id_sucursal,nombre FROM SUCURSAL
END

GO
/****** Object:  StoredProcedure [dbo].[ConsultarSucursalesCompleto]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[ConsultarSucursalesCompleto]
AS
BEGIN
SELECT id_sucursal,nombre,direccion,ciudad,telefonoFijo,telefonoCelular FROM SUCURSAL
END

GO
/****** Object:  StoredProcedure [dbo].[ConsultarTiposElemento]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--PROCEDIMIENTO ALMACENADO PARA CONSULTAR TODOS LOS TIPOS DE ELEMENTO
CREATE PROCEDURE [dbo].[ConsultarTiposElemento]
AS
BEGIN
SELECT id_tipo_elemento,descripcion_elemento FROM TIPO_ELEMENTO
END

GO
/****** Object:  StoredProcedure [dbo].[ConsultarTiposPrioridad]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--PROCEDIMIENTO ALMACENADO PARA CONSULTAR TODOS LOS TIPOS DE PRIORIDAD QUE HAY PARA LA SOLICITUD
CREATE PROCEDURE [dbo].[ConsultarTiposPrioridad]
AS
BEGIN
SELECT id_prioridad,descripcion_prioridad FROM PRIORIDAD
END

GO
/****** Object:  StoredProcedure [dbo].[CrearFacturaSinRegistros]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--PROCEDIMIENTO QUE CREA UNA FACTURA SIN REGISTROS PARA EL INICIO DE LA GENERACION DE UNA FACTURA FINAL
CREATE PROCEDURE [dbo].[CrearFacturaSinRegistros]
@identifEmpleado VARCHAR(15)
AS
DECLARE @idEmpleado int, @fecha DATETIME, @idFacturaNueva int
SET @fecha = (SELECT CURRENT_TIMESTAMP);
SET @idEmpleado = (SELECT id_usuario FROM USUARIO WHERE identificacion = @identifEmpleado);

BEGIN
	INSERT INTO FACTURA (fecha,id_empleado_factura,id_estado_factura) 
	VALUES (@fecha,@idEmpleado,5);
	SET @idFacturaNueva =(@@IDENTITY);
	 
	INSERT INTO HISTORICO_FACTURA (id_empleado_historico,id_factura_historico,descripcion_historico,fecha_historico)
	VALUES (@idEmpleado,@idFacturaNueva,'Se agrega Factura con estado Sin registros',@fecha);

	SELECT id_factura,fecha FROM FACTURA WHERE id_factura = @idFacturaNueva;
END

GO
/****** Object:  StoredProcedure [dbo].[CrearInventarioProductoVacioASucursal]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- CREA UN ESPACIO EN SUCURSAL ESPECIFICA PARA ASIGNARLE CANTIDADES A UN PRODUCTO EN ESPECIAL
CREATE PROCEDURE [dbo].[CrearInventarioProductoVacioASucursal]
@idProducto int,
@id_sucursal int,
@identifEmpleado VARCHAR(15)
AS
BEGIN
	IF NOT EXISTS(SELECT id_producto_inventario FROM INVENTARIO WHERE id_sucursal_inventario =@id_sucursal AND id_producto_inventario = @idProducto)
	BEGIN
		DECLARE @idInventario int, @fecha DATETIME, @idEmpleado int,@nombreProd VARCHAR(50),@nombreSucursal VARCHAR(20);
		SET @fecha =  (SELECT CURRENT_TIMESTAMP);		
		SET @idEmpleado = (SELECT id_usuario FROM USUARIO WHERE identificacion = @identifEmpleado);
		SET @nombreProd =(SELECT nombre_producto FROM PRODUCTO WHERE id_producto = @idProducto);
		SET @nombreSucursal = (SELECT nombre FROM SUCURSAL WHERE id_sucursal = @id_sucursal);

		INSERT INTO INVENTARIO (id_producto_inventario,id_sucursal_inventario,cantidad_existencias,fecha_actualizacion_inventario)
		VALUES (@idProducto,@id_sucursal,0,@fecha);
		SET @idInventario = @@IDENTITY;

		INSERT INTO INVENTARIO_BAJAS (id_producto_inventario,id_sucursal_inventario,cantidad_existencias,fecha_actualizacion_inventario)
		VALUES (@idProducto,@id_sucursal,0,@fecha);

		INSERT INTO HISTORICO_INVENTARIO (id_empleado,id_inventario_historico,fecha,descripcion)
		VALUES (@idEmpleado,@idInventario,@fecha,'se abre espacio de inventario del producto '+@nombreProd+' para la sucursal '+@nombreSucursal)
	END
SELECT @@ROWCOUNT;

END

GO
/****** Object:  StoredProcedure [dbo].[EscalarSolicitud]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--PROCEDIMIENTO PARA ESCALAR SOLICITUD Y GUARDAR HISTORICO
CREATE PROCEDURE [dbo].[EscalarSolicitud]
@id_solicitud int,
@identifEmpleado VARCHAR(15)
AS
BEGIN 
DECLARE @fecha DATETIME, @idEmpleado int,@idEmpleadoAnterior int, @nombreEmpleadoAnterior VARCHAR(30), @nombreEmpleadoNuevo VARCHAR(30);
SET @idEmpleadoAnterior = (SELECT id_escalado_solicitud FROM SOLICITUD WHERE id_solicitud = @id_solicitud);
SET @idEmpleado = (SELECT id_usuario FROM USUARIO WHERE identificacion = @identifEmpleado);
SET @nombreEmpleadoAnterior = (SELECT        USUARIO.nombres
								FROM         ESCALADO INNER JOIN
								SOLICITUD ON ESCALADO.id_escalado = SOLICITUD.id_escalado_solicitud INNER JOIN
								USUARIO ON ESCALADO.id_usuario_escalado = USUARIO.id_usuario
								WHERE SOLICITUD.id_solicitud = @id_solicitud );
SET @nombreEmpleadoNuevo = (SELECT nombres FROM USUARIO WHERE identificacion = @identifEmpleado);
SET @fecha = (SELECT CURRENT_TIMESTAMP);
	UPDATE SOLICITUD SET id_escalado_solicitud = @idEmpleado WHERE id_solicitud = @id_solicitud

INSERT INTO HISTORICO_SOLICITUD (id_usuario_historico,id_solicitud_historico,descripcion_historico,fecha_historico)
VALUES (@idEmpleadoAnterior,@id_solicitud,'Se ha cambiado el responsable de la solicitud, de  '+@nombreEmpleadoAnterior+' a '+@nombreEmpleadoNuevo,@fecha)
END

GO
/****** Object:  StoredProcedure [dbo].[GarbageCollector_FacturasSinRegistros_Automatico]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--PROCEDIMIENTO QUE ELIMINA FACTURAS SIN REGISTROS.   ESTE PROC SE EJECUTARÁ POR MEDIO DE UN JOB QUE HARÁ EL PROCESO CADA X PERIODO DE TIEMPO
CREATE PROCEDURE [dbo].[GarbageCollector_FacturasSinRegistros_Automatico]
AS
DECLARE @TotalRegistros int
BEGIN

SET @TotalRegistros =  (SELECT COUNT(*) FROM SOLICITUD);
DELETE FROM HISTORICO_FACTURA WHERE id_factura_historico IN (SELECT id_factura FROM FACTURA 
								WHERE id_estado_factura = 5)

DELETE FROM FACTURA WHERE id_estado_factura = 5

END

GO
/****** Object:  StoredProcedure [dbo].[GenerarSolicitud]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--PROCEDIMIENTO ALMACENADO PARA GENERAR UNA SOLICITUD DE SERVICIO 
CREATE PROC [dbo].[GenerarSolicitud]
@id_prioridad int,
@id_estado int,
@identifEmpleado VARCHAR(15),
@id_cliente int,
@id_servicio int, 
@id_elemento int,
@descripcion VARCHAR(300)
as
BEGIN 
declare @fecha DATETIME,
@idEmpleado int,
@nombreEmpleado VARCHAR(30),
@id_solicitudFinal int;
SET @fecha = (SELECT CURRENT_TIMESTAMP);
SET @idEmpleado = (SELECT id_usuario FROM USUARIO WHERE identificacion = @identifEmpleado);
SET @nombreEmpleado = (SELECT nombres FROM USUARIO WHERE identificacion = @identifEmpleado);
	INSERT INTO SOLICITUD (id_prioridad_solicitud,id_estado_solicitud,id_usuario_solicitud,id_servicio_solicitud,id_elemento_solicitud,id_escalado_solicitud,fecha_solicitud,descripcion)
	VALUES (@id_prioridad,@id_estado,@id_cliente,@id_servicio,@id_elemento,@idEmpleado, @fecha,@descripcion);
	SET @id_solicitudFinal = @@IDENTITY

	INSERT INTO HISTORICO_SOLICITUD (id_usuario_historico,id_solicitud_historico,descripcion_historico,fecha_historico)
	VALUES (@idEmpleado,@id_solicitudFinal,'Se crea la solicitud del cliente y se asigna a '+@nombreEmpleado,@fecha)
END		

GO
/****** Object:  StoredProcedure [dbo].[InsertarProducto]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--PROCEDIMIENTO ALMACENADO PARA INSERTAR PRODUCTO

CREATE PROCEDURE [dbo].[InsertarProducto]
@id_estado_prod int,
@id_categoria int,
@nombre_prod VARCHAR(50),
@precio_costo DECIMAL(20,4),
@precio_venta DECIMAL (20,4), 
@identifEmpleado VARCHAR (15),
@cantidad int,
@id_sucursal int
as
BEGIN 
	IF NOT EXISTS(SELECT nombre_producto FROM PRODUCTO WHERE nombre_producto =@nombre_prod)
	BEGIN
		INSERT INTO PRODUCTO (id_estado_producto,id_categoria_producto,nombre_producto,precio_costo,precio_venta)
		VALUES (@id_estado_prod,@id_categoria,@nombre_prod,@precio_costo,@precio_venta);

		declare  @id_prod int,
				 @idInventario int,
				 @idEmpleado int,
				 @nombreSucursal VARCHAR(20),
				 @fecha DATETIME;
		SET @fecha =  (SELECT CURRENT_TIMESTAMP);		 
		SET @id_prod = (SELECT id_producto FROM PRODUCTO WHERE nombre_producto = @nombre_prod);
		SET @idEmpleado = (SELECT id_usuario FROM USUARIO WHERE identificacion = @identifEmpleado);
		SET @nombreSucursal = (SELECT nombre FROM SUCURSAL WHERE id_sucursal = @id_sucursal);

		INSERT INTO INVENTARIO (id_producto_inventario,id_sucursal_inventario,cantidad_existencias,fecha_actualizacion_inventario)
		VALUES (@id_prod,@id_sucursal,@cantidad,@fecha);
		SET @idInventario = @@IDENTITY;

		INSERT INTO INVENTARIO_BAJAS (id_producto_inventario,id_sucursal_inventario,cantidad_existencias,fecha_actualizacion_inventario)
		VALUES (@id_prod,@id_sucursal,0,@fecha);

		INSERT INTO HISTORICO_INVENTARIO (id_empleado,id_inventario_historico,fecha,descripcion)
		VALUES (@idEmpleado,@idInventario,@fecha,'Se agrega el producto '+@nombre_prod+' y se crea su inventario con una cantidad inicial en stock de '+cast(@cantidad as varchar)+' para la sucursal '+@nombreSucursal)
	END
	
SELECT @@ROWCOUNT;

END

GO
/****** Object:  StoredProcedure [dbo].[ObtenerIdUltimaFacturaGenerada]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--PROCEDIMIENTO QUE TRAE EL ID DE LA ULTIMA FACTURA CREADA
CREATE PROCEDURE [dbo].[ObtenerIdUltimaFacturaGenerada]
AS
BEGIN
	SELECT COUNT(*) FROM factura
END

GO
/****** Object:  StoredProcedure [dbo].[ReintegrarProductoXAnulacionFactura]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ReintegrarProductoXAnulacionFactura]
@idFactura int,
@idProducto int,
@identifEmpleado VARCHAR(15)
AS
DECLARE @fecha DATETIME, @idEmpleado int,  @idInventario int,
		@cantidadVendida int, @idSucursal int, @existenciasActuales int
SET @fecha = (SELECT CURRENT_TIMESTAMP);
SET @idEmpleado = (SELECT id_usuario FROM USUARIO WHERE identificacion = @identifEmpleado);
SET @idSucursal = (SELECT id_sucursal_escalado FROM ESCALADO WHERE id_usuario_escalado = @idEmpleado);
SET @cantidadVendida = (SELECT cantidad_venta FROM DETALLE_FACTURA_PRODUCTO WHERE id_factura_detalle_factura =@idFactura AND id_producto_detalle_factura = @idProducto);
SET @existenciasActuales = (SELECT cantidad_existencias FROM INVENTARIO WHERE id_producto_inventario = @idProducto AND id_sucursal_inventario = @idSucursal);
SET @idInventario = (SELECT id_inventario FROM INVENTARIO WHERE id_producto_inventario = @idProducto AND id_sucursal_inventario = @idSucursal);

BEGIN

UPDATE INVENTARIO SET cantidad_existencias = @existenciasActuales + @cantidadVendida 
WHERE id_producto_inventario = @idProducto AND id_sucursal_inventario = @idSucursal;

INSERT INTO HISTORICO_INVENTARIO(id_empleado,id_inventario_historico,fecha,descripcion)
VALUES (@idEmpleado,@idInventario,@fecha,'Se vuelven a ingresar '+cast(@cantidadVendida as varchar)+' unidades
		por anulación de factura');	
END

GO
/****** Object:  StoredProcedure [dbo].[TrasladarProductoASucursal]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- PROCEDIMIENTO QUE TRASLADA UN PRODUCTO DE UNA SUCURSAL A OTRA 
CREATE PROCEDURE [dbo].[TrasladarProductoASucursal]
@idInventarioOrigen int,
@idProducto int,
@cantidadATrasladar int,
@idSucursalATrasladar int,
@idSucursalActual int,
@identifEmpleado VARCHAR(15)
AS
DECLARE @fecha DATETIME, @idEmpleado int, @cantidadAnteriorOrigen int, @resta int,@suma int, @idInventarioDestino int,
@cantidadAnteriorDestino int, @nombreSucursalATrasladar VARCHAR(20), @nombreSucursalActual VARCHAR(20)
BEGIN
SET @fecha = (SELECT CURRENT_TIMESTAMP);
SET @idEmpleado = (SELECT id_usuario FROM USUARIO WHERE identificacion = @identifEmpleado);
SET @nombreSucursalATrasladar = (SELECT nombre FROM SUCURSAL WHERE id_sucursal = @idSucursalATrasladar );
SET @nombreSucursalActual = (SELECT nombre FROM SUCURSAL WHERE id_sucursal = @idSucursalActual );
--Operaciones inventario origen
SET @cantidadAnteriorOrigen = (SELECT cantidad_existencias FROM INVENTARIO WHERE id_inventario =@idInventarioOrigen);
SET @resta = @cantidadAnteriorOrigen - @cantidadATrasladar;

--Operaciones inventario Destino
SET @idInventarioDestino = (SELECT id_inventario FROM INVENTARIO WHERE id_sucursal_inventario = @idSucursalATrasladar AND id_producto_inventario = @idProducto);
SET @cantidadAnteriorDestino = (SELECT cantidad_existencias FROM INVENTARIO WHERE id_inventario =@idInventarioDestino);
SET @suma = @cantidadAnteriorDestino + @cantidadATrasladar;

UPDATE INVENTARIO SET cantidad_existencias = @cantidadAnteriorOrigen - @cantidadATrasladar, fecha_actualizacion_inventario = @fecha
WHERE id_inventario = @idInventarioOrigen;

INSERT INTO HISTORICO_INVENTARIO (id_empleado,id_inventario_historico,fecha,descripcion)
VALUES (@idEmpleado,@idInventarioOrigen,@fecha,'Se actualiza la cantidad, de '+cast(@cantidadAnteriorOrigen as varchar)+' unidades, a '+cast(@resta as varchar)+' unidades por traslado
		a sucursal '+@nombreSucursalATrasladar );


UPDATE INVENTARIO SET cantidad_existencias = @cantidadAnteriorDestino + @cantidadATrasladar, fecha_actualizacion_inventario = @fecha
WHERE id_inventario = @idInventarioDestino;

INSERT INTO HISTORICO_INVENTARIO (id_empleado,id_inventario_historico,fecha,descripcion)
VALUES (@idEmpleado,@idInventarioDestino,@fecha,'Se actualiza la cantidad, de '+cast(@cantidadAnteriorDestino as varchar)+' unidades, a '+cast(@suma as varchar)+' unidades por envio
 de producto desde la sucursal '+@nombreSucursalActual );


END

GO
/****** Object:  StoredProcedure [dbo].[ValidarAutenticacionLogin]    Script Date: 23/08/2017 5:34:59 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- PROCEDIMIENTO ALMACENADO QUE VALIDA EL LOGIN DEL USUARIO QUE INTENTA INGRESAR AL SISTEMA Y SI ES EXITOSO RETORNA SU IDENTIFICACION
CREATE PROCEDURE [dbo].[ValidarAutenticacionLogin]
@username VARCHAR(15),
@passwd nVARCHAR(50)
AS
DECLARE @PassEncode As nvarchar(300)
DECLARE @PassDecode As nvarchar(50)

BEGIN
	SELECT @PassEncode = password From USUARIO WHERE usuario_login = @username
	SET @PassDecode = DECRYPTBYPASSPHRASE('C0ntr4s3n4', @PassEncode)
	SELECT identificacion FROM USUARIO WHERE (usuario_login =@username AND @PassDecode=@passwd)
END


GO
USE [master]
GO
ALTER DATABASE [bdServiciosDigitalesProy] SET  READ_WRITE 
GO
