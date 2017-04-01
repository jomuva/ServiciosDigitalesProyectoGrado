-- Creacion de Base de Datos

USE MASTER;
GO
DROP DATABASE bdServiciosDigitalesProy;
GO

Create Database bdServiciosDigitalesProy;
Go
use bdServiciosDigitalesProy;
Go

-- Creacion de tablas

-- TABLA  TIPO DE ELEMENTO, LOS TIPOS DE elementos QUE SE TIENEN

create table TIPO_ELEMENTO(
id_tipo_elemento int  not null IDENTITY,
descripcion_elemento varchar(50) not null,
primary key (id_tipo_elemento)
);
INSERT INTO [dbo].[TIPO_ELEMENTO]
           ([descripcion_elemento])
     VALUES
            ('Portátil'),
		    ('Desktop'),
		    ('Tablet'),
			('Impresora'),
			('VHS'),
			('Video 8'),
			('Mini Dv'),
		    ('Monitor')
	GO


-- TABLA  CATEGORIA ELEMENTO, PARA CATEGORIZAR LOS ELEMENTOS EXISTENTES Y PODER AGRUPAR LOS SERVICIOS SEGUN SU CATEGORIA

create table CATEGORIA_ELEMENTO(
id_categoria_elemento int  not null IDENTITY,
descripcion_categoria_elemento varchar(50) not null,
primary key (id_categoria_elemento)
);
INSERT INTO [dbo].[CATEGORIA_ELEMENTO]
           ([descripcion_categoria_elemento])
     VALUES
            ('SoportePC'),
		    ('Impresion'),
		    ('Edicion Video'),
			('Trabajos'),
			('Reparacion Periféricos'),
			('Quemado'),
			('Diseño'),
			('Transfer')
			
	GO
	
-- TABLA  TIPO DE IDENTIFICACION DEL USUARIO, LOS TIPOS DE DOCUMENTO DE IDENTIDAD QUE EXISTEN

create table TIPO_IDENTIFICACION_USUARIO(
id_tipo_identificacion int  not null IDENTITY,
descripcion_tipo_identificacion varchar(50) not null,
primary key (id_tipo_identificacion)
);
INSERT INTO [dbo].[TIPO_IDENTIFICACION_USUARIO]
           ([descripcion_tipo_identificacion])
     VALUES
            ('Cédula'),
		    ('Cédula Extranjería'),
		    ('Tarjeta de Identidad'),
			('Pasaporte')	
	GO
	
-- TABLA  ROL, EL TIPO DE ROL DE LA TABLA USUARIO	
create table ROL(
id_rol int not null IDENTITY,
descripcion varchar(50) not null,
primary key (id_Rol)
);
INSERT INTO [dbo].[ROL]
           ([descripcion])
     VALUES
            ('Cliente'),
		    ('Administrador'),
		    ('Tecnico'),
			('Auxiliar')	
	GO

-- TABLA  ESTADO USUARIO, EL ESTADO EN EL QUE SE ENCUENTRA UN USUARIO (ELIMINADO, ACTIVO, INACTIVO, BLOQUEADO)	
create table ESTADO_USUARIO(
id_estado int  not null IDENTITY,
descripcion varchar(20) not null,
primary key (id_estado)
);
INSERT INTO [dbo].[ESTADO_USUARIO]
           ([descripcion])
     VALUES
            ('Activo'),
		    ('Bloqueado'),
		    ('Eliminado'),
			('Inactivo')	
	GO	
	

-- TABLA  USUARIO, LOS USUARIOS TANTO EMPLEADOS COMO CLIENTES
create table USUARIO (
id_usuario int  not null IDENTITY,
id_tipo_Identificacion_usuario int  not null,
id_estado_usuario int  not null,
id_rol_usuario int not null,
identificacion varchar(15) not null,
apellidos varchar(30) not null,
nombres varchar (30) not null,
direccion varchar (50),
correo varchar (50) not null,
sexo char (1) not null,
usuario_login varchar(15) not null,
password nvarchar (30) not null
primary key (id_usuario)
	CONSTRAINT  fk_tipo_Identificacion_usuario
    	FOREIGN KEY ( id_tipo_Identificacion_usuario  )
    	REFERENCES   TIPO_IDENTIFICACION_USUARIO ( id_tipo_identificacion  ),
	CONSTRAINT  fk_estado_usuario
    	FOREIGN KEY ( id_estado_usuario  )
    	REFERENCES   ESTADO_USUARIO ( id_estado  ),
	CONSTRAINT  fk_rol_usuario
    	FOREIGN KEY ( id_rol_usuario  )
    	REFERENCES   ROL ( id_rol  ),	
);
INSERT INTO [dbo].[USUARIO]
           ([id_tipo_Identificacion_usuario]
		   ,[id_estado_usuario]
		   ,[id_rol_usuario]
		   ,[identificacion]
		   ,[apellidos]
		   ,[nombres]
		   ,[direccion]
		   ,[correo]
		   ,[sexo]
		   ,[usuario_login]
		   ,[password])
     VALUES
            (1,1,2,'1020727312','Munoz Vargas','Jonathan','Calle 123 No 34 - 34','jomuva@gmail.com','M','jomuva','jomuva'),
			(1,1,3,'1094572195','Ortiz Ortiz','Carlos Daniel','Calle 45 No 56 - 56','carlos5ort@hotmail.com','M','cortiz','cortiz'),
		  	(1,1,1,'54151221','perez ortiz','andres','Calle 112 No 23 - 56','aperez@hotmail.com','M','aperez','aperez'),
			(1,1,1,'1532156513','guevara parra','lorena','Calle 432 No 23 - 56','lorena@hotmail.com','F','lguevara','lguevara'),
			(1,1,1,'51332514','Parra Mican','Daniela','Calle 165 No 23 - 56','dparra@hotmail.com','F','dparra','dparra'),
			(1,1,1,'79515121','mendez mendez','felipe','Calle 54 No 23 - 56','fmendez@hotmail.com','M','fmendez','fmendez'),
			(1,1,1,'52152251','lopez garzon','camila','Calle 34 No 23 - 56','cgarzon@hotmail.com','F','cgarzon','cgarzon'),
			(1,1,1,'64555212','gonzalez perez','juan','Calle 23 No 23 - 56','jgonzalez@hotmail.com','M','jgonzalez','jgonzalez'),
			(1,1,1,'1016251441','rodriguez ortiz','manuel','Calle 112 No 23 - 56','mrodriguez@hotmail.com','M','mrodriguez','mrodriguez')
	GO

-- TABLA  TELEFONO USUARIO, LOS POSIBLES TELEFONOS DE LOS USUARIOS	
create table TELEFONO_USUARIO(
id_telefono int  not null IDENTITY,
id_usuario_telefono int not null,
numero_telefono varchar(15)
primary key (id_telefono)
	CONSTRAINT  fk_usuario_telefono
			FOREIGN KEY ( id_usuario_telefono  )
			REFERENCES   USUARIO ( id_usuario  ),
);
INSERT INTO [dbo].[TELEFONO_USUARIO]
           ([id_usuario_telefono]
		   ,[numero_telefono])
     VALUES
            (1,'3202637423'),
		    (2,'3118406383'),
		    (1,'6317901'),
			(3,'3202151445'),	
			(4,'3102511455'),
		    (4,'3251225'),
		    (5,'3162515512')
	GO

	
-- TABLA  SERVICIOS, LOS SERVICIOS DISPONIBLES A OFRECER
create table SERVICIO(
id_servicio int  not null IDENTITY,
descripcion_servicio varchar(50) not null,
primary key (id_servicio)
);
INSERT INTO [dbo].[SERVICIO]
           ([descripcion_servicio])
     VALUES
            ('Mantenimiento Correctivo Pc'),
		    ('Mantenimiento Preventivo Pc'),
		    ('Instalación de Programas'),
			('Edición de Videos'),
			('Diseño Gráfico'),
			('Impresión B&N'),
			('Impresión Color'),
		    ('Reparación de Periféricos'),
		    ('Mantenimiento de Impresoras'),
			('Transfer de Videos'),
			('Quemado de CD'),
			('Quemado de DVD'),
			('Trabajo en Computador')
	GO
	

-- TABLA  SERVICIOS, LOS SERVICIOS DISPONIBLES A OFRECER
create table ELEMENTO(
id_elemento int  not null IDENTITY,
serial varchar(4),
placa  varchar(30),
modelo  varchar(30),
marca  varchar(15),
ram varchar(10),
rom varchar(15),
serial_bateria varchar(4),
sistema_operativo  varchar(20),
id_tipo_elemento int  not null,
id_categoria_elemento int  not null,
primary key (id_elemento), 
	CONSTRAINT  fk_tipo_elemento
			FOREIGN KEY ( id_tipo_elemento  )
			REFERENCES   TIPO_ELEMENTO ( id_tipo_elemento  ),
	CONSTRAINT  fk_categoria_elemento
			FOREIGN KEY ( id_categoria_elemento  )
			REFERENCES   CATEGORIA_ELEMENTO ( id_categoria_elemento  ),		
);
INSERT INTO [dbo].[ELEMENTO]
           ([serial]
		   ,[placa]
		   ,[modelo]
		   ,[marca]
		   ,[ram]
		   ,[rom]
		   ,[serial_bateria]
		   ,[sistema_operativo]
		   ,[id_tipo_elemento]
		   ,[id_categoria_elemento])
     VALUES
            ('4ASD','QWERQRQRQWERWE','SJH2323','SONY','2GB','1TB','T45R','WINDOWS 10',1,1),
		    ('4EGD','UYTRYTJRGHJ23453','PAVILION 3433','HP','8GB','1TB','WERT','WINDOWS 10',1,1),
			('RET4','WERTWFGW54','TX150','EPSON',NULL,NULL,NULL,NULL,4,5),
			('4323',NULL,NULL,'Imation',NULL,NULL,NULL,NULL,6,7),
			('FSD5','SDFHJ568653H','W1907','HP',NULL,NULL,NULL,NULL,8,5),
			('RWE3','UYTRYTJRGHJ23453','X541U','ASUS','8GB','1TB',NULL,'WINDOWS 10',1,1)
			
	GO


-- TABLA  SERVICIOS_ELEMENTO, ASOCIA EL ELEMENTO CON LOS SERVICIOS   Y LE DA UN PRECIO
create table SERVICIO_ELEMENTO(
id_servicio_elemento int not null IDENTITY,
id_servicio int not null,
id_elemento int,
precio  decimal(20,3),
primary key (id_servicio_elemento), 
	CONSTRAINT  fk_servicio
			FOREIGN KEY ( id_servicio  )
			REFERENCES   SERVICIO ( id_servicio  ),
	CONSTRAINT  fk_elemento
			FOREIGN KEY ( id_elemento  )
			REFERENCES   ELEMENTO ( id_elemento  ),		
);
INSERT INTO [dbo].[SERVICIO_ELEMENTO]
           ([id_servicio]
		   ,[id_elemento]
		   ,[precio])
     VALUES
            (1,1,70000),
			(2,2,25000),
			(9,3,30000),
			(11,NULL,6000),
			(10,4,15000)
	GO

	
-- TABLA  PRIORIDAD, INDICA LA PRIORIDAD DE LA SOLICITUD DEL CLIENTE
create table PRIORIDAD(
id_prioridad int not null IDENTITY,
descripcion_prioridad varchar(50),
primary key (id_prioridad) 	
);
INSERT INTO [dbo].[PRIORIDAD]
           ([descripcion_prioridad])
     VALUES
            ('Alta'),
			('Media'),
			('Baja')
	GO


-- TABLA  ESTADO_SOLICITUD, ESTADO DE LA SOLICITUD EN LA QUE SE ENCUENTRA EL SERVICIO
create table ESTADO_SOLICITUD(
id_estado_solicitud int not null IDENTITY,
descripcion varchar(50),
primary key (id_estado_solicitud) 	
);
INSERT INTO [dbo].[ESTADO_SOLICITUD]
           ([descripcion])
     VALUES
            ('Terminado'),
			('En Progreso'),
			('En Espera'),
			('En Cola'),
			('Por Aprobar')
	GO		


-- TABLA  ESTADO_FACTURA, TABLA QUE CONTIENE LOS ESTADOS POSIBLES QUE LA FACTURA PUEDA TENER A NIVEL FINANCIERO
create table ESTADO_FACTURA(
id_estado_factura int not null IDENTITY,
descripcion_estado_factura varchar(15) not null,
primary key (id_estado_factura),	
);
INSERT INTO [dbo].[ESTADO_FACTURA]
           ([descripcion_estado_factura])
     VALUES
            ('Cancelado'),
			('Anulado'),
			('Abonado'),
			('Pendiente')
	GO		
	

	-- TABLA  FACTURA, TABLA QUE CONTIENE LOS REGISTROS DE LA FACTURA DE VENTA GENERADA
create table FACTURA(
id_factura int not null IDENTITY,
fecha date not null,
id_usuario_factura int not null,
id_estado_factura int not null,
abono decimal(30,4) not null,
guardar_total decimal(30,4) not null,
primary key (id_factura),
	CONSTRAINT  fk_usuario_factura
			FOREIGN KEY ( id_usuario_factura  )
			REFERENCES   USUARIO ( id_usuario  ),
	CONSTRAINT  fk_estado_factura
			FOREIGN KEY ( id_estado_factura  )
			REFERENCES   ESTADO_FACTURA ( id_estado_factura  ),		
);
INSERT INTO [dbo].[FACTURA]
           ([fecha]
		   ,[id_usuario_factura]
		   ,[id_estado_factura]
		   ,[abono]
		   ,[guardar_total])
     VALUES
            ('2016-11-29',3,3,20000,95000),
			('2016-12-13',4,1,0,60000),
			('2017-02-10',5,1,0,70000),
			('2017-02-25',6,4,0,55000),
			('2017-03-03',7,4,10000,40000)
		
	GO	

-- TABLA  SOLICITUD, TIENE LA INFORMACION DE LA SOLICITUD DEL CLIENTE Y SU SERVICIO ASOCIADO
create table SOLICITUD(
id_solicitud int not null IDENTITY,
id_prioridad_solicitud int not null,
id_estado_solicitud int not null,
id_usuario_solicitud int not null,
id_servicio_elemento_solicitud int not null,
id_factura int not null,
fecha_solicitud  date,
primary key (id_solicitud),
	CONSTRAINT  fk_prioridad_solicitud
			FOREIGN KEY ( id_prioridad_solicitud  )
			REFERENCES   PRIORIDAD ( id_prioridad  ),
	CONSTRAINT  fk_estado_solicitud
			FOREIGN KEY ( id_estado_solicitud  )
			REFERENCES   ESTADO_SOLICITUD ( id_estado_solicitud  ),
	CONSTRAINT  fk_usuario_solicitud
			FOREIGN KEY ( id_usuario_solicitud  )
			REFERENCES   USUARIO ( id_usuario  ),	
	CONSTRAINT  fk_servicio_elemento_solicitud
			FOREIGN KEY ( id_servicio_elemento_solicitud  )
			REFERENCES   SERVICIO_ELEMENTO ( id_servicio_elemento  ),	
	CONSTRAINT  fk_factura
			FOREIGN KEY ( id_factura  )
			REFERENCES   FACTURA ( id_factura  ),				
);
INSERT INTO [dbo].[SOLICITUD]
           ([id_prioridad_solicitud]
		   ,[id_estado_solicitud]
		   ,[id_usuario_solicitud]
		   ,[id_servicio_elemento_solicitud]
		   ,[id_factura]
		   ,[fecha_solicitud])
     VALUES
            (1,2,6,1,1,'2016-11-29'),
			(2,5,7,2,2,'2016-12-13'),
			(3,3,3,3,3,'2017-02-10'),
			(2,4,4,4,4,'2017-02-25'),
			(1,1,5,5,5,'2017-03-03')
	GO
	
-- TABLA  ESCALADO, A QUE USUARIO SE LE ESCALA LA SOLICITUD
create table ESCALADO(
id_escalado int not null IDENTITY,
id_solicitud_escalado int,
id_usuario_escalado int,
primary key (id_escalado),
	CONSTRAINT  fk_solicitud_escalado
			FOREIGN KEY ( id_solicitud_escalado  )
			REFERENCES   SOLICITUD ( id_solicitud  ),
	CONSTRAINT  fk_usuario_escalado
			FOREIGN KEY ( id_usuario_escalado  )
			REFERENCES   USUARIO ( id_usuario  ),			
);
INSERT INTO [dbo].[ESCALADO]
           ([id_solicitud_escalado]
		   ,[id_usuario_escalado])
     VALUES
            (1,1),
			(2,2),
			(3,3),
			(4,4),
			(5,5)
		
	GO

	
	-- TABLA  HISTORICO, TABLA QUE CONTIENE EL HISTORICO DE LOS SERVICIOS Y TIENE ASOCIADAS LAS TABLAS DE USUARIO Y SOLICIUD
create table HISTORICO(
id_historico int not null IDENTITY,
id_usuario_historico int not null,
id_solicitud_historico int not null,
descripcion_historico varchar(100) not null
primary key (id_historico)
	CONSTRAINT  fk_usuario_historico
			FOREIGN KEY ( id_usuario_historico  )
			REFERENCES   USUARIO ( id_usuario  ),
	CONSTRAINT  fk_solicitud_historico
			FOREIGN KEY ( id_solicitud_historico  )
			REFERENCES   SOLICITUD ( id_solicitud  ),			
);
INSERT INTO [dbo].[HISTORICO]
           ([id_usuario_historico]
		   ,[id_solicitud_historico]
		   ,[descripcion_historico])
     VALUES
            (1,1,'Se realiza mantenimiento a satisfaccion del cliente'),
			(2,2, 'El cliente realiza mantenimiento'),
			(1,3,'Se repara el teclado y el mouse del cliente'),
			(2,4,'se hace pruebas en el servicio contratado'),
			(2,5,'se realizan pruebas de calidad en el servicio solicitado por el cliente')
		
	GO


-- TABLA  ESTADO_PRODUCTO, TABLA QUE CONTIENE LOS ESTADOS QUE PUEDE TENER EL PRODUCTO
create table ESTADO_PRODUCTO(
id_estado_producto int not null IDENTITY,
descripcion_estado_producto varchar(15) not null,
primary key (id_estado_producto),	
);
INSERT INTO [dbo].[ESTADO_PRODUCTO]
           ([descripcion_estado_producto])
     VALUES
            ('Disponible'),
			('No Disponible')
	GO	

	-- TABLA  PRODUCTO, TABLA QUE CONTIENE LOS ATRIBUTOS DE UN PRODUCTO
create table PRODUCTO(
id_producto int not null IDENTITY,
id_estado_producto int not null,
nombre_producto varchar(100) not null,
precio_costo decimal(20,4),
precio_venta decimal (20,4),
primary key (id_producto),
	CONSTRAINT  fk_estado_producto
			FOREIGN KEY ( id_estado_producto  )
			REFERENCES   ESTADO_PRODUCTO ( id_estado_producto  ),			
);
INSERT INTO [dbo].[PRODUCTO]
           ([id_estado_producto]
		   ,[nombre_producto]
		   ,[precio_costo]
		   ,[precio_venta])
     VALUES
            (1,'Memoria USB 16Gb',10000,25000),
			(1,'Mouse Bluetooth',15000,30000),
			(1,'Teclado USB',20000,40000),
			(1,'Fuente de Poder 350Watts',18000,38000),
			(1,'HDD solido 256Gb',150000,300000)
		
	GO	
	
	-- TABLA  INVENTARIO, TABLA QUE CONTIENE LOS INVENTARIOS DE LOS PRODUCTOS 
create table INVENTARIO(
id_inventario int not null IDENTITY,
id_producto_inventario int not null,
cantidad_existencias int not null,
fecha_actualizacion_inventario date not null,
primary key (id_inventario),
	CONSTRAINT  fk_producto_inventario
			FOREIGN KEY ( id_producto_inventario  )
			REFERENCES   PRODUCTO ( id_producto  ),			
);
INSERT INTO [dbo].[INVENTARIO]
           ([id_producto_inventario]
		   ,[cantidad_existencias]
		   ,[fecha_actualizacion_inventario])
     VALUES
            (1,25,'2017-01-01'),
			(2,15,'2017-01-01'),
			(3,20,'2017-01-01'),
			(4,18,'2017-01-01'),
			(5,6,'2017-01-01')
		
	GO	
	
	-- TABLA  DETALLE_FACTURA, TABLA QUE AGRUPA LA INFORMACION DE LA FACTURA CON EL PRODUCTO Y EL CLIENTE
create table DETALLE_FACTURA(
id_detalle_factura int not null IDENTITY,
id_producto_detalle_factura int,
id_vendedor_usuario int not null,
id_factura_detalle_factura int not null,
cantidad_venta int not null,
primary key (id_detalle_factura),
	CONSTRAINT  fk_producto_detalle_factura
			FOREIGN KEY ( id_producto_detalle_factura  )
			REFERENCES   PRODUCTO ( id_producto  ),	
	CONSTRAINT  fk_vendedor_usuario
			FOREIGN KEY ( id_vendedor_usuario  )
			REFERENCES   USUARIO ( id_usuario  ),	
	CONSTRAINT  fk_factura_detalle_factura
			FOREIGN KEY ( id_factura_detalle_factura  )
			REFERENCES   FACTURA ( id_factura  ),			
);
INSERT INTO [dbo].[DETALLE_FACTURA]
           ([id_producto_detalle_factura]
		   ,[id_vendedor_usuario]
		   ,[id_factura_detalle_factura]
		   ,[cantidad_venta])
     VALUES
            (1,1,1,1),
			(2,2,2,1),
			(1,2,3,1),
			(3,2,4,1),
			(1,2,5,1)
		
	GO	

--PROCEDIMIENTO ALMACENADO PARA INSERTAR PRODUCTO

	CREATE PROC InsertarProducto
@id_estado_prod int,
@nombre_prod VARCHAR(100),
@precio_costo DECIMAL(20,4),
@precio_venta DECIMAL (20,4), 
@cantidad int
as
BEGIN 

INSERT INTO PRODUCTO (id_estado_producto,nombre_producto,precio_costo,precio_venta)
VALUES (@id_estado_prod,@nombre_prod,@precio_costo,@precio_venta);

declare  @id_prod int,
         @fecha datetimeoffset = switchoffset (CONVERT(datetimeoffset, GETDATE()), '-05:00');
SET @id_prod = (SELECT id_producto FROM PRODUCTO WHERE nombre_producto = @nombre_prod);

INSERT INTO INVENTARIO (id_producto_inventario,cantidad_existencias,fecha_actualizacion_inventario)
VALUES (@id_prod,@cantidad,@fecha)

END
GO


	
	
	
	
	