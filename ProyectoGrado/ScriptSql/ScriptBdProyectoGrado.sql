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
	
-- TABLA  PERMISO, INDICA EL MODULO AL QUE SE LE DA PERMISO Y UNA DESCRIPCION DEL PERMISO	
create table PERMISO(
permisoID int not null IDENTITY,
modulo varchar(20),
descripcion varchar(100),
primary key (permisoID)
);
INSERT INTO [dbo].[PERMISO]
           ([modulo]
		   ,[descripcion])
     VALUES
            ('cliente','Puede_crear_nuevo_cliente'),
		    ('cliente','Puede_modificar_cliente'),
		    ('cliente','Puede_consultar_cliente'),
			('cliente','Puede_cambiar_estado_cliente'),
			('empleado','Puede_crear_nuevo_empleado'),
		    ('empleado','Puede_modificar_empleado'),
		    ('empleado','Puede_consultar_empleado'),
			('empleado','Puede_cambiar_estado_empleado'),
			('producto','Puede_crear_nuevo_producto'),
		    ('producto','Puede_modificar_producto'),
		    ('producto','Puede_consultar_producto'),
			('producto','Puede_cambiar_estado_producto'),
			('servicio','Puede_crear_nuevo_servicio'),
		    ('servicio','Puede_modificar_servicio'),
		    ('servicio','Puede_consultar_servicio'),
			('solicitud','Puede_crear_nuevo_elemento'),
		    ('solicitud','Puede_consultar_solicitud'),
			('solicitud','Puede_cambiar_estado_solicitud'),
			('solicitud','Puede_escalar_solicitud'),
			('solicitud','Puede_consultar_historico_solicitud'),
			('solicitud','Puede_agregar_anotacion_historico'),
			('solicitud','Puede_crear_solicitud'),
			('inventario','Puede_agregar_inventario'),
			('inventario','Puede_consultar_inventario'),
			('inventario','Puede_modificar_inventario'),
			('inventario','Puede_asignar_inventario_sucursal'),
			('ventas','Puede_agregar_factura'),
			('ventas','Puede_agregar_detalle_factura'),
			('ventas','Puede_consultar_factura'),
			('solicitud','Puede_Ver_Columna_Empleado_Asignado')
	
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

	
-- TABLA  PERMISO_DENEGADO_POR_ROL, SE ENCUENTRA LA LISTA DE LOS PERMISOS DENEGADOS A UN ROL EN ESPECIFICO	
create table PERMISO_DENEGADO_POR_ROL(
id_rol int not null,
permiso_id int not null,
primary key (id_rol,permiso_id),
	CONSTRAINT  fk_id_rol_permiso_denegado
    	FOREIGN KEY ( id_rol  )
    	REFERENCES   ROL ( id_rol  ),
	CONSTRAINT  fk_permiso_id
    	FOREIGN KEY ( permiso_id  )
    	REFERENCES   PERMISO ( permisoID  )
);
INSERT INTO [dbo].[PERMISO_DENEGADO_POR_ROL]
           ([id_rol]
		   ,[permiso_id])
     VALUES
			(3,30),
			(4,30),
            (3,5),
		    (3,6),
			(3,7),
			(3,8),
			(3,10),
			(3,14),
			(3,25)
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
password nvarchar (50) not null
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
GO
-- TABLA  ESCALADO, A QUE USUARIO SE LE ESCALA LA SOLICITUD
create table ESCALADO(
id_escalado int not null IDENTITY,
id_usuario_escalado int,
primary key (id_escalado),
	CONSTRAINT  fk_usuario_escalado
			FOREIGN KEY ( id_usuario_escalado  )
			REFERENCES   USUARIO ( id_usuario  )			
);
GO
	
-- PROCEDIMIENTO ALMACENADO PARA AGREGAR USUARIO	
CREATE PROCEDURE AgregarUsuario
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
@Passwd nVARCHAR(50)
as
BEGIN 
DECLARE @idusu int;
INSERT INTO USUARIO(id_tipo_Identificacion_usuario,id_estado_usuario,id_rol_usuario,identificacion,apellidos,nombres,direccion,correo,sexo,usuario_login,password)
VALUES (@tipoIdent,@estado,@rol,@identif,@apellidos,@nombres,@direccion,@correo,@sexo,@username,ENCRYPTBYPASSPHRASE('C0ntr4s3n4', @Passwd));

SET @idusu = @@IDENTITY;
IF(@rol<>1)
	BEGIN
		INSERT INTO ESCALADO (id_usuario_escalado) VALUES (@idusu);
	END
END
GO

exec AgregarUsuario 1,2,2,'1111111111','Servicios Digitales','System','No Address','system@gmail.com','M','system','systemServiciosDigitales'
go
exec AgregarUsuario 1,1,2,'1020727312','Munoz Vargas','Jonathan','Calle 123 No 34 - 34','jomuva@gmail.com','M','jomuva','jomuva'
go
exec AgregarUsuario 1,1,3,'1094572195','Ortiz Ortiz','Carlos Daniel','Calle 45 No 56 - 56','carlos5ort@hotmail.com','M','cortiz','cortiz'
go
exec AgregarUsuario 1,1,4,'79145807','Russo Rodriguez','Oswaldo','Calle 138 NO 57b-01','visionspd@gmail.com','M','oswaldorusso','oswaldorusso'
go
exec AgregarUsuario 1,1,1,'54151221','perez ortiz','andres','Calle 112 No 23 - 56','aperez@hotmail.com','M','aperez','aperez'
go
exec AgregarUsuario 1,1,1,'1532156513','guevara parra','lorena','Calle 432 No 23 - 56','lorena@hotmail.com','F','lguevara','lguevara'
go
exec AgregarUsuario 1,1,1,'51332514','Parra Mican','Daniela','Calle 165 No 23 - 56','dparra@hotmail.com','F','dparra','dparra'
go
exec AgregarUsuario 1,1,1,'79515121','mendez mendez','felipe','Calle 54 No 23 - 56','fmendez@hotmail.com','M','fmendez','fmendez'
go
exec AgregarUsuario 1,1,1,'52152251','lopez garzon','camila','Calle 34 No 23 - 56','cgarzon@hotmail.com','F','cgarzon','cgarzon'
go
exec AgregarUsuario 1,1,1,'64555212','gonzalez perez','juan','Calle 23 No 23 - 56','jgonzalez@hotmail.com','M','jgonzalez','jgonzalez'
go
exec AgregarUsuario 1,1,1,'1016251441','rodriguez ortiz','manuel','Calle 112 No 23 - 56','mrodriguez@hotmail.com','M','mrodriguez','mrodriguez'
go

DELETE ESCALADO WHERE id_usuario_escalado = 1
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
			(1,'6317901'),
		    (2,'3118406383'),
			(2,'5154811'),
			(3,'3202151445'),
			(3,'3118406383'),
			(4,'3102511455'),
		    (4,'3251225'),
		    (5,'3162515512'),
			(5,'6317323'),
			(6,'3215154848'),
			(6,'4625148'),
			(7,'3165518596'),
			(7,'6458413'),
			(8,'3005146655'),
			(8,'7451232'),
			(9,'3515121320'),
			(9,'2515446'),
			(10,'3515121320'),
			(10,'2515446'),
			(11,'3515121320'),
			(11,'2515446')
	GO

	
-- TABLA  SERVICIOS, LOS SERVICIOS DISPONIBLES A OFRECER
create table SERVICIO(
id_servicio int  not null IDENTITY,
descripcion_servicio varchar(50) not null,
precio decimal(20,4),
primary key (id_servicio)
);
INSERT INTO [dbo].[SERVICIO]
           ([descripcion_servicio]
           ,[precio])
     VALUES
            ('Mantenimiento Correctivo Pc',70000),
		    ('Mantenimiento Preventivo Pc',30000),
		    ('Instalación de Programas',25000),
			('Edición de Videos',35000),
			('Diseño Gráfico',30000),
			('Impresión B&N',300),
			('Impresión Color',500),
			('Transfer de Videos',15000),
			('Trabajo en Computador',40000),
			('Mantenimiento Correctivo Impresora',50000),
			('Mantenimiento Preventivo Impresora',25000)
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
			(NULL,NULL,'No tiene elemento asignado',NULL,NULL,NULL,NULL,NULL,1,1),
            ('4ASD','QWERQRQRQWERWE','SJH2323','SONY','2GB','1TB','T45R','WINDOWS 10',1,1),
		    ('4EGD','UYTRYTJRGHJ23453','PAVILION 3433','HP','8GB','1TB','WERT','WINDOWS 10',1,1),
			('RET4','WERTWFGW54','TX150','EPSON',NULL,NULL,NULL,NULL,4,5),
			('4323',NULL,NULL,'Imation',NULL,NULL,NULL,NULL,6,7),
			('FSD5','SDFHJ568653H','W1907','HP',NULL,NULL,NULL,NULL,8,5),
			('RWE3','UYTRYTJRGHJ23453','X541U','ASUS','8GB','1TB',NULL,'WINDOWS 10',1,1)
			
	GO

	
-- TABLA  PRIORIDAD, INDICA LA PRIORIDAD DE LA SOLICITUD DEL CLIENTE
create table PRIORIDAD(
id_prioridad int not null IDENTITY,
descripcion_prioridad varchar(50),
tiempo_solucion int,
primary key (id_prioridad) 	
);
INSERT INTO [dbo].[PRIORIDAD]
           ([descripcion_prioridad]
		   ,[tiempo_solucion])
     VALUES
            ('Alta',2),
			('Media',10),
			('Baja',30)
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
			('Por Aprobar'),
			('Anulada'),
			('Vencida')
	GO		


-- TABLA  ESTADO_FACTURA, TABLA QUE CONTIENE LOS ESTADOS POSIBLES QUE LA FACTURA PUEDA TENER A NIVEL FINANCIERO
create table ESTADO_FACTURA(
id_estado_factura int not null IDENTITY,
descripcion_estado_factura varchar(20) not null,
primary key (id_estado_factura),	
);
INSERT INTO [dbo].[ESTADO_FACTURA]
           ([descripcion_estado_factura])
     VALUES
            ('Cancelado'),
			('Anulado'),
			('Abonado'),
			('Pendiente Por Pago'),
			('Sin Registros')
	GO		
	

	-- TABLA  FACTURA, TABLA QUE CONTIENE LOS REGISTROS DE LA FACTURA DE VENTA GENERADA
create table FACTURA(
id_factura int not null IDENTITY,
fecha DATETIME not null,
id_cliente_factura int,
id_empleado_factura int,
id_estado_factura int not null,
saldo decimal(30,4),
valor_total decimal(30,4),
primary key (id_factura),
	CONSTRAINT  fk_usuario_factura
			FOREIGN KEY ( id_cliente_factura  )
			REFERENCES   USUARIO ( id_usuario  ),
	CONSTRAINT  fk_empleado_factura
			FOREIGN KEY ( id_empleado_factura  )
			REFERENCES   ESCALADO ( id_escalado  ),		
	CONSTRAINT  fk_estado_factura
			FOREIGN KEY ( id_estado_factura  )
			REFERENCES   ESTADO_FACTURA ( id_estado_factura  )		
);
INSERT INTO [dbo].[FACTURA]
           ([fecha]
		   ,[id_cliente_factura]
		   ,[id_empleado_factura]
		   ,[id_estado_factura]
		   ,[saldo]
		   ,[valor_total])
     VALUES
            ('2016-11-29 02:57:24.480',8,2,3,20000,95000),
			('2016-12-13 02:57:24.480',4,3,1,0,60000),
			('2017-02-10 02:57:24.480',5,2,1,0,70000),
			('2017-02-25 02:57:24.480',6,3,4,0,55000),
			('2017-03-03 02:57:24.480',7,3,4,10000,40000)
		
	GO	
	
-- TABLA HISTORICO FACTURA, CONTIENE LOS MOVIMIENTOS DE LAS FACTURAS 
create table HISTORICO_FACTURA(
id_historico int not null IDENTITY,
id_empleado_historico int not null,
id_factura_historico int,
descripcion_historico varchar(500) not null,
fecha_historico DATETIME,
primary key (id_historico),
	CONSTRAINT  fk_factura_historico
			FOREIGN KEY ( id_factura_historico  )
			REFERENCES   FACTURA ( id_factura  ),			
);
INSERT INTO [dbo].[HISTORICO_FACTURA]
           ([id_empleado_historico]
		   ,[id_factura_historico]
		   ,[descripcion_historico]
		   ,[fecha_historico])
     VALUES
            (2,1,'Se agrega factura y se asigna al cliente correctamente','2017-04-08 02:57:24.480'),
			(3,2,'Se agrega factura y se asigna al cliente correctamente','2017-04-07 02:57:24.480'),
			(3,3,'Se agrega factura y se asigna al cliente correctamente','2017-03-06 02:57:24.480'),
			(2,5,'Se agrega factura con estado Sin registros','2017-04-08 02:57:24.480'),
			(2,5,'Se agrega factura con estado Sin registros','2017-04-06 02:57:24.480')
	GO

-- TABLA  SOLICITUD, TIENE LA INFORMACION DE LA SOLICITUD DEL CLIENTE Y SU SERVICIO ASOCIADO
create table SOLICITUD(
id_solicitud int not null IDENTITY,
id_prioridad_solicitud int not null,
id_estado_solicitud int not null,
id_usuario_solicitud int not null,
id_servicio_solicitud int not null,
id_elemento_solicitud int,
id_escalado_solicitud int,
fecha_solicitud  DATETIME,
descripcion VARCHAR(300),
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
	CONSTRAINT  fk_servicio_solicitud
			FOREIGN KEY ( id_servicio_solicitud  )
			REFERENCES   SERVICIO ( id_servicio  ),	
	CONSTRAINT  fk_elemento_solicitud
			FOREIGN KEY ( id_elemento_solicitud  )
			REFERENCES   ELEMENTO ( id_elemento  ),
	CONSTRAINT  fk_escalado_solicitud
			FOREIGN KEY ( id_escalado_solicitud  )
			REFERENCES   ESCALADO ( id_escalado  )			
);
INSERT INTO [dbo].[SOLICITUD]
           ([id_prioridad_solicitud]
		   ,[id_estado_solicitud]
		   ,[id_usuario_solicitud]
		   ,[id_servicio_solicitud]
		   ,[id_elemento_solicitud]
		   ,[id_escalado_solicitud]
		   ,[fecha_solicitud]
		   ,descripcion)
     VALUES
            (1,2,6,1,5,2,'2017-04-08 02:57:24.480','Por favor Instalar autocad'),
			(2,5,7,2,2,3,'2017-04-08 02:57:24.480','Por favor limpiar pantalla'),
			(3,3,8,11,3,2,'2017-02-10 02:57:24.480','Sin novedad'),
			(2,4,4,8,4,2,'2017-02-25 02:57:24.480','Conseguir cable'),
			(1,1,5,1,6,3,'2017-03-03 02:57:24.480','Sin novedad'),
			(2,5,8,10,1,2,'2017-04-08 02:57:24.480','Por favor realizar label con título de la universidad')
	GO
	


	
	-- TABLA  HISTORICO, TABLA QUE CONTIENE EL HISTORICO DE LOS SERVICIOS Y TIENE ASOCIADAS LAS TABLAS DE USUARIO Y SOLICIUD
create table HISTORICO_SOLICITUD(
id_historico int not null IDENTITY,
id_usuario_historico int not null,
id_solicitud_historico int not null,
descripcion_historico varchar(500) not null,
fecha_historico DATETIME,
primary key (id_historico),
	CONSTRAINT  fk_usuario_historico
			FOREIGN KEY ( id_usuario_historico  )
			REFERENCES   USUARIO ( id_usuario  ),
	CONSTRAINT  fk_solicitud_historico
			FOREIGN KEY ( id_solicitud_historico  )
			REFERENCES   SOLICITUD ( id_solicitud  ),			
);
INSERT INTO [dbo].[HISTORICO_SOLICITUD]
           ([id_usuario_historico]
		   ,[id_solicitud_historico]
		   ,[descripcion_historico]
		   ,[fecha_historico])
     VALUES
            (2,1,'Se realiza mantenimiento a satisfaccion del cliente','2017-04-08 02:57:24.480'),
			(3,2, 'El cliente realiza mantenimiento','2017-04-07 02:57:24.480'),
			(3,3,'Se repara el teclado y el mouse del cliente','2017-03-06 02:57:24.480'),
			(2,4,'se hace pruebas en el servicio contratado','2017-04-08 02:57:24.480'),
			(2,5,'se realizan pruebas de calidad en el servicio solicitado por el cliente','2017-04-06 02:57:24.480'),
			(3,6,'se hace pruebas en el servicio contratado','2017-04-08 02:57:24.480')
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

-- TABLA CATEGORIA DE PRODUCTO, CONTIENE LAS CATEGORIAS A LAS QUE SE PUEDE CLASIFICAR LOS PRODUCTOS
CREATE TABLE CATEGORIA_PRODUCTO(
id_categoria int not null IDENTITY,
descripcion varchar(50) not null,
primary key (id_categoria),	
);
INSERT INTO [dbo].[CATEGORIA_PRODUCTO]
           (descripcion)
     VALUES
            ('Discos Duros'),
			('Fuentes de Poder ATX'),
			('Accesorios Pc'),
			('Memorias Flash'),
			('Memorias RAM'),
			('Redes'),
			('Tarjeta Video'),
			('Papelería')
			
GO	


	-- TABLA  PRODUCTO, TABLA QUE CONTIENE LOS ATRIBUTOS DE UN PRODUCTO
create table PRODUCTO(
id_producto int not null IDENTITY,
id_estado_producto int not null,
id_categoria_producto int not null,
nombre_producto varchar(100) not null,
precio_costo decimal(20,4),
precio_venta decimal (20,4),
primary key (id_producto),
	CONSTRAINT  fk_estado_producto
			FOREIGN KEY ( id_estado_producto  )
			REFERENCES   ESTADO_PRODUCTO ( id_estado_producto  ),		
	CONSTRAINT  fk_categoria_producto
			FOREIGN KEY ( id_categoria_producto  )
			REFERENCES   CATEGORIA_PRODUCTO ( id_categoria  ),				
);
INSERT INTO [dbo].[PRODUCTO]
           ([id_estado_producto]
		   ,[id_categoria_producto]
		   ,[nombre_producto]
		   ,[precio_costo]
		   ,[precio_venta])
     VALUES
            (1,4,'Memoria USB 16Gb',10000,25000),
			(1,3,'Mouse Bluetooth',15000,30000),
			(1,3,'Teclado USB',20000,40000),
			(1,2,'Fuente de Poder 350Watts',18000,38000),
			(1,1,'HDD solido 256Gb',150000,300000)
		
	GO	
	
	-- TABLA  INVENTARIO, TABLA QUE CONTIENE LOS INVENTARIOS DE LOS PRODUCTOS 
create table INVENTARIO(
id_inventario int not null IDENTITY,
id_producto_inventario int not null,
cantidad_existencias int not null,
fecha_actualizacion_inventario DATETIME not null,
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
            (1,20,'2017-01-01 02:57:24.480'),
			(2,10,'2017-01-01 02:57:24.480'),
			(3,15,'2017-01-01 02:57:24.480'),
			(4,13,'2017-01-01 02:57:24.480'),
			(5,5,'2017-01-01 02:57:24.480')
		
	GO	
	

	-- TABLA  HISTORICO INVENTARIO, TABLA QUE CONTIENE EL HISTORICO DE MOVIMIENTOS DEL INVENTARIO
create table HISTORICO_INVENTARIO(
id_historico int not null IDENTITY,
id_empleado int not null,
id_inventario_historico int not null,
fecha DATETIME not null,
descripcion VARCHAR(500) not null,
primary key (id_historico),
	CONSTRAINT  fk_empleado_historico_inventario
			FOREIGN KEY ( id_empleado  )
			REFERENCES   USUARIO ( id_usuario  ),	
	CONSTRAINT  fk_inventario_historico_inventario
			FOREIGN KEY ( id_inventario_historico  )
			REFERENCES   INVENTARIO ( id_inventario  ),			
);
INSERT INTO [dbo].[HISTORICO_INVENTARIO]
           ([id_empleado]
		   ,[id_inventario_historico]
		   ,[fecha]
		   ,[descripcion])
     VALUES
            (2,1,'2017-01-01 02:57:24.480','Se agregan 25 memorias al stock'),
			(2,2,'2017-01-01 02:57:24.480','Se agregan 15 mouse al stock'),
			(2,3,'2017-01-01 02:57:24.480','Se agregan 20 teclados al stock'),
			(2,4,'2017-01-01 02:57:24.480','Se agregan 18 fuentes de poder al stock'),
			(2,5,'2017-01-01 02:57:24.480','Se agregan 6 HDD solidos al stock')
		
	GO


	-- TABLA  INVENTARIO, TABLA QUE CONTIENE LOS INVENTARIOS DE LOS PRODUCTOS 
create table INVENTARIO_BAJAS(
id_inventario_bajas int not null IDENTITY,
id_producto_inventario int not null,
cantidad_existencias int not null,
fecha_actualizacion_inventario DATETIME not null,
primary key (id_inventario_bajas),
	CONSTRAINT  fk_producto_inventario_bajas
			FOREIGN KEY ( id_producto_inventario  )
			REFERENCES   PRODUCTO ( id_producto  ),			
);
INSERT INTO [dbo].[INVENTARIO_BAJAS]
           ([id_producto_inventario]
		   ,[cantidad_existencias]
		   ,[fecha_actualizacion_inventario])
     VALUES
            (1,5,'2017-04-01 22:06:35.920'),
			(2,5,'2017-04-02 22:06:35.920'),
			(3,5,'2017-04-05 22:06:35.920'),
			(4,5,'2017-04-06 22:06:35.920'),
			(5,1,'2017-04-07 22:06:35.920')
		
	GO	
	

	-- TABLA  HISTORICO INVENTARIO, TABLA QUE CONTIENE EL HISTORICO DE MOVIMIENTOS DEL INVENTARIO
create table HISTORICO_INVENTARIO_BAJAS(
id_historico int not null IDENTITY,
id_empleado int not null,
id_inventario_historico int not null,
fecha DATETIME not null,
descripcion VARCHAR(500) not null,
primary key (id_historico),
	CONSTRAINT  fk_empleado_historico_inventario_bajas
			FOREIGN KEY ( id_empleado  )
			REFERENCES   USUARIO ( id_usuario  ),	
	CONSTRAINT  fk_inventario_historico_inventario_bajas
			FOREIGN KEY ( id_inventario_historico  )
			REFERENCES   INVENTARIO_BAJAS ( id_inventario_bajas  ),			
);
INSERT INTO [dbo].[HISTORICO_INVENTARIO_BAJAS]
           ([id_empleado]
		   ,[id_inventario_historico]
		   ,[fecha]
		   ,[descripcion])
     VALUES
            (2,1,'2017-04-01 22:06:35.920','Se agregan 5 memorias por daños de fabrica'),
			(2,2,'2017-04-02 22:06:35.920','Se agregan 5 mouse por daños de fabrica'),
			(2,3,'2017-04-05 22:06:35.920','Se agregan 5 teclados por daños de fabrica '),
			(2,4,'2017-04-06 22:06:35.920','Se agregan 5 fuentes de poder por daños de fabrica'),
			(2,5,'2017-04-07 22:06:35.920','Se agrega 1 HDD solido por daños de fabrica')
		
	GO
	
	-- TABLA  DETALLE_FACTURA, TABLA QUE AGRUPA LA INFORMACION DE LA FACTURA CON EL PRODUCTO Y EL CLIENTE
create table DETALLE_FACTURA_PRODUCTO(
id_detalle_factura int not null IDENTITY,
id_producto_detalle_factura int,
id_factura_detalle_factura int not null,
cantidad_venta int not null,
primary key (id_detalle_factura),
	CONSTRAINT  fk_producto_detalle_factura
			FOREIGN KEY ( id_producto_detalle_factura  )
			REFERENCES   PRODUCTO ( id_producto  ),	
	CONSTRAINT  fk_factura_detalle_factura_producto
			FOREIGN KEY ( id_factura_detalle_factura  )
			REFERENCES   FACTURA ( id_factura  ),			
);
INSERT INTO [dbo].[DETALLE_FACTURA_PRODUCTO]
           ([id_producto_detalle_factura]
		   ,[id_factura_detalle_factura]
		   ,[cantidad_venta])
     VALUES
            (1,1,1),
			(2,2,1),
			(1,3,3),
			(3,4,2),
			(1,5,1)
		
	GO	

	
	
	-- TABLA  DETALLE_FACTURA, TABLA QUE AGRUPA LA INFORMACION DE LA FACTURA CON  LA SOLICITUD Y EL CLIENTE
create table DETALLE_FACTURA_SOLICITUD(
id_detalle_factura_solicitud int not null IDENTITY,
id_solicitud_detalle_factura int,
id_factura_detalle_factura int not null,
cantidad_venta int not null,
primary key (id_detalle_factura_solicitud),
	CONSTRAINT  fk_solicitud_detalle_factura
			FOREIGN KEY ( id_solicitud_detalle_factura  )
			REFERENCES   SOLICITUD ( id_solicitud  ),	
	CONSTRAINT  fk_factura_detalle_factura_solicitud
			FOREIGN KEY ( id_factura_detalle_factura  )
			REFERENCES   FACTURA ( id_factura  ),			
);
INSERT INTO [dbo].[DETALLE_FACTURA_SOLICITUD]
           ([id_solicitud_detalle_factura]
		   ,[id_factura_detalle_factura]
		   ,[cantidad_venta])
     VALUES
            (1,1,1),
			(2,2,1),
			(3,3,1),
			(4,4,1),
			(5,5,1)
		
	GO
--PROCEDIMIENTO ALMACENADO PARA INSERTAR PRODUCTO

	CREATE PROC InsertarProducto
@id_estado_prod int,
@id_categoria int,
@nombre_prod VARCHAR(50),
@precio_costo DECIMAL(20,4),
@precio_venta DECIMAL (20,4), 
@identifEmpleado VARCHAR (15),
@cantidad int
as
BEGIN 

INSERT INTO PRODUCTO (id_estado_producto,id_categoria_producto,nombre_producto,precio_costo,precio_venta)
VALUES (@id_estado_prod,@id_categoria,@nombre_prod,@precio_costo,@precio_venta);

declare  @id_prod int,
		 @idInventario int,
		 @idEmpleado int,
         @fecha DATETIME;
SET @fecha =  (SELECT CURRENT_TIMESTAMP);		 
SET @id_prod = (SELECT id_producto FROM PRODUCTO WHERE nombre_producto = @nombre_prod);
SET @idEmpleado = (SELECT id_usuario FROM USUARIO WHERE identificacion = @identifEmpleado);

INSERT INTO INVENTARIO (id_producto_inventario,cantidad_existencias,fecha_actualizacion_inventario)
VALUES (@id_prod,@cantidad,@fecha);
SET @idInventario = @@IDENTITY;

INSERT INTO INVENTARIO_BAJAS (id_producto_inventario,cantidad_existencias,fecha_actualizacion_inventario)
VALUES (@id_prod,0,@fecha);

INSERT INTO HISTORICO_INVENTARIO (id_empleado,id_inventario_historico,fecha,descripcion)
VALUES (@idEmpleado,@idInventario,@fecha,'Se agrega el producto '+@nombre_prod+' y se crea su inventario con una cantidad inicial en stock de '+cast(@cantidad as varchar) )

END
GO


--PROCEDIMIENTO ALMACENADO PARA CONSULTAR UN PRODUCTO POR CODIGO.  ADICIONAL A ELLO ACTUALIZA EL ESTADO DEL PRODUCTO EN CASO TAL QUE NO HAYAN UNIDADES EN INVENTARIO
CREATE PROCEDURE ConsultarProductoXCodigo
@codigo int
AS
BEGIN

DECLARE @cantidadProd int,
		@idProd int;

SET @idProd = (SELECT id_producto FROM PRODUCTO WHERE id_producto = @codigo);
SET	@cantidadProd = (SELECT cantidad_existencias FROM INVENTARIO WHERE id_producto_inventario = @idProd ); 

IF(@cantidadProd=0)
	BEGIN
		UPDATE PRODUCTO SET id_estado_producto = 2 WHERE id_producto = @idProd
	END
END

SELECT id_producto,id_estado_producto,nombre_producto,precio_costo,precio_venta FROM PRODUCTO
WHERE id_producto = @codigo

GO


--PROCEDIMIENTO ALMACENADO PARA CONSULTAR UN PRODUCTO POR NOMBRE.  ADICIONAL A ELLO ACTUALIZA EL ESTADO DEL PRODUCTO EN CASO TAL QUE NO HAYAN UNIDADES EN INVENTARIO
CREATE PROCEDURE ConsultarProductoXNombre 
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
WHERE nombre_producto = @nombr

GO


--PROCEDIMIENTO ALMACENADO PARA CONSULTAR TODOS LOS PRODUCTOS
CREATE PROCEDURE ConsultarProductos
AS
BEGIN
SELECT id_producto,id_estado_producto,nombre_producto,precio_costo,precio_venta FROM PRODUCTO
END
GO
--PROCEDIMIENTO ALMACENADO PARA CONSULTAR LAS CATEGORIAS DE LOS PRODUCTOS
CREATE PROC ConsultarCategoriasProductos
AS
BEGIN
SELECT id_categoria,descripcion FROM CATEGORIA_PRODUCTO
END
GO

--PROCEDIMIENTO ALMACENADO PARA ACTUALIZAR EL PRODUCTO SEGUN EL ID
CREATE PROC ActualizarProducto
@idProd int,
@nombre_prod VARCHAR(100),
@precio_costo DECIMAL(20,4),
@precio_venta DECIMAL (20,4)
as
BEGIN 

UPDATE PRODUCTO SET nombre_producto=@nombre_prod, precio_costo=@precio_costo, precio_venta=@precio_venta WHERE id_producto = @idProd

END
GO

--PROCEDIMIENTO ALMACENADO PARA ACTUALIZAR EL ESTADO DEL PRODUCTO
CREATE PROC CambiarEstadoProducto
@idProd int,
@idEstado int

as
BEGIN 

UPDATE PRODUCTO SET id_estado_producto=@idEstado WHERE id_producto = @idProd

END
GO

--PROCEDIMIENTO ALMACENADO PARA crear un servicio

CREATE PROCEDURE AgregarServicio
@descripc VARCHAR(50),
@precio decimal(20,4)
as
BEGIN 

INSERT INTO SERVICIO (descripcion_servicio,precio)
VALUES (@descripc,@precio);

END
GO

--PROCEDIMIENTO ALMACENADO PARA consultar los servicios
CREATE PROCEDURE ConsultarServicios
AS
BEGIN
SELECT id_servicio,descripcion_servicio,precio FROM SERVICIO
END
GO

--PROCEDIMIENTO ALMACENADO PARA actualizar un servicio

CREATE PROCEDURE ActualizarServicio
@idserv int,
@descripc VARCHAR(50),
@precio decimal(20,4)
as
BEGIN 

UPDATE SERVICIO SET descripcion_servicio=@descripc,precio=@precio WHERE id_servicio = @idserv

END
GO

--PROCEDIMIENTO ALMACENADO PARA consultar un unico servicio
CREATE PROCEDURE ConsultarServicio
@codigo int
AS
BEGIN
SELECT id_servicio,descripcion_servicio,precio FROM SERVICIO
WHERE id_servicio = @codigo
END

GO

--PROCEDIMIENTO ALMACENADO PARA  agregar un elemento 

CREATE PROC AgregarElemento
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

--PROCEDIMIENTO ALMACENADO PARA GENERAR UNA SOLICITUD DE SERVICIO 
CREATE PROC GenerarSolicitud
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


--PROCEDIMIENTO ALMACENADO PARA CONSULTAR TODOS LOS TIPOS DE PRIORIDAD QUE HAY PARA LA SOLICITUD
CREATE PROCEDURE ConsultarTiposPrioridad
AS
BEGIN
SELECT id_prioridad,descripcion_prioridad FROM PRIORIDAD
END
GO

--PROCEDIMIENTO ALMACENADO PARA CONSULTAR TODOS LOS TIPOS DE ELEMENTO
CREATE PROCEDURE ConsultarTiposElemento
AS
BEGIN
SELECT id_tipo_elemento,descripcion_elemento FROM TIPO_ELEMENTO
END
GO

--PROCEDIMIENTO ALMACENADO PARA CONSULTAR TODOS LOS CATEGORIAS DE ELEMENTO
CREATE PROCEDURE ConsultarCategorias_Elemento
AS
BEGIN
SELECT id_categoria_elemento,descripcion_categoria_elemento FROM CATEGORIA_ELEMENTO
END
GO




--PROCEDIMIENTO ALMACENADO PARA CONSULTAR TODOS LOS ESTADOS DE SOLICITUD EXISTENTES EN BD
CREATE PROCEDURE ConsultarEstadosSolicitud
AS
BEGIN
SELECT id_estado_solicitud,descripcion FROM ESTADO_SOLICITUD WHERE id_estado_solicitud <> 5
END
GO

--PROCEDIMIENTO QUE CONSULTA EL ID Y DESCRIPCION  DEL ESTADO DE LA SOLICITUD DE UNA SOLICITUD SEGUN EL ID QUE SE ENVIA
CREATE PROCEDURE ConsultarEstado_Solicitud
@idSolic int
AS
BEGIN

SELECT        SOLICITUD.id_estado_solicitud, ESTADO_SOLICITUD.descripcion
FROM            ESTADO_SOLICITUD INNER JOIN
                         SOLICITUD ON ESTADO_SOLICITUD.id_estado_solicitud = SOLICITUD.id_estado_solicitud
WHERE id_solicitud = @idSolic

END
GO

--PROCEDIMIENTO ALMACENADO PARA CONSULTAR el id de un usuario segun su numero de identificacion
CREATE PROCEDURE Consultar_id_UsuarioXIdentificacion
@codigo int
AS
BEGIN
SELECT id_usuario FROM USUARIO WHERE identificacion = @codigo
END
GO

--PROCEDIMIENTO ALMACENADO PARA ACTUALIZAR ESTADO DE LA SOLICITUD DE MANERA AUTOMATICA SEGUN LA PRIORIDAD EL ESTADO Y EL TIEMPO DE SOLICITUD
CREATE PROCEDURE ActualizarEstadoSolicitud_Automatico
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




-- PROCEDIMIENTO ALMACENADO QUE VALIDA EL LOGIN DEL USUARIO QUE INTENTA INGRESAR AL SISTEMA Y SI ES EXITOSO RETORNA SU IDENTIFICACION
CREATE PROCEDURE ValidarAutenticacionLogin
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


--PROCEDIMIENTO ALMACENADO PARA CONSULTAR PERMISOS POR ROL DE USUARIO RETORNANDO LOS PERMISOS Y EL ID A LOS QUE NO TIENE ACCESO
CREATE PROC ConsultarPermisosXUsuario
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


--PROCEDIMIENTO ALMACENADO PARA CAMBIAR EL ESTADO DE LA SOLICITUD Y AGREGARLO EN HISTORICO 
CREATE PROC CambiarEstadoSolicitud
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

--PROCEDIMIENTO ALMACENADO PARA CONSULTAR LAS SOLICITUDES DE UN EMPLEADO
CREATE PROCEDURE ConsultarSolicitudesXEmpleado
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

--PROCEDIMIENTO ALMACENADO PARA CONSULTAR SOLICITUDES TOTALES
CREATE PROCEDURE ConsultarSolicitudes
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
--PROCEDIMIENTO PARA CONSULTAR EL ROL DE UN USUARIO SEGUN SU DOCUMENTO
CREATE PROCEDURE ConsultarRolUsuario
@identif VARCHAR (15)
AS
BEGIN
	SELECT id_rol_usuario FROM USUARIO WHERE identificacion = @identif
END
GO

--PROCEDIMIENTO PARA Consulta Nombres Empleados X Solicitud
CREATE PROCEDURE ConsultaNombresEmpleadosXSolicitud
AS
BEGIN
SELECT    USUARIO.nombres
FROM            ESCALADO INNER JOIN
                         SOLICITUD ON ESCALADO.id_escalado = SOLICITUD.id_escalado_solicitud INNER JOIN
                         USUARIO ON ESCALADO.id_usuario_escalado = USUARIO.id_usuario;
END
GO

--PROCEDIMIENTO PARA ESCALAR SOLICITUD Y GUARDAR HISTORICO
CREATE PROCEDURE EscalarSolicitud
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

--PROCEDIMIENTO QUE CONSULTA TODOS LOS ELEMENTOS EN BD
CREATE PROCEDURE ConsultarElementos
AS
BEGIN
	SELECT          ELEMENTO.id_elemento,ELEMENTO.id_tipo_elemento,TIPO_ELEMENTO.descripcion_elemento,ELEMENTO.id_categoria_elemento, CATEGORIA_ELEMENTO.descripcion_categoria_elemento, ELEMENTO.serial, ELEMENTO.placa, ELEMENTO.modelo, ELEMENTO.marca, 
                         ELEMENTO.ram, ELEMENTO.rom, ELEMENTO.serial_bateria, ELEMENTO.sistema_operativo
                         
FROM            CATEGORIA_ELEMENTO INNER JOIN
                         ELEMENTO ON CATEGORIA_ELEMENTO.id_categoria_elemento = ELEMENTO.id_categoria_elemento INNER JOIN
                         TIPO_ELEMENTO ON ELEMENTO.id_tipo_elemento = TIPO_ELEMENTO.id_tipo_elemento
END
GO

--PROCEDIMIENTO QUE CONSULTA EL HISTORICO DE UNA SOLICITUD SEGUN EL ID ENVIADO
CREATE PROCEDURE ConsultarHistoricoSolicitudX_id
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

--PROCEDIMIENTO QUE AGREGA UNA ANOTACION AL HISTORICO DE UNA SOLICITUD Y LA FIRMA QUIEN ESTÁ LOGUEADO
CREATE PROCEDURE AgregarAnotacionHistoricoSolicitud
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

--PROCEDIMIENTO CONSULTA EL TOTAL DE INVENTARIOS DE TODOS LOS PRODUCTOS
CREATE PROCEDURE ConsultarInventarios
AS
BEGIN
SELECT        INVENTARIO.id_inventario, PRODUCTO.nombre_producto, INVENTARIO.id_producto_inventario, INVENTARIO.cantidad_existencias, INVENTARIO.fecha_actualizacion_inventario, 
                         ESTADO_PRODUCTO.descripcion_estado_producto
FROM            INVENTARIO INNER JOIN
                         PRODUCTO ON INVENTARIO.id_producto_inventario = PRODUCTO.id_producto INNER JOIN
                         ESTADO_PRODUCTO ON PRODUCTO.id_estado_producto = ESTADO_PRODUCTO.id_estado_producto
END
GO

--PROCEDIMIENTO CONSULTA EL INVENTARIO DE UN PRODUCTO SEGUN SU NOMBRE
CREATE PROCEDURE ConsultarInventarioXNombreProducto
@nombr VARCHAR(100)
AS
BEGIN
SELECT        INVENTARIO.id_inventario, PRODUCTO.nombre_producto, INVENTARIO.id_producto_inventario, INVENTARIO.cantidad_existencias, INVENTARIO.fecha_actualizacion_inventario, 
                         ESTADO_PRODUCTO.descripcion_estado_producto
FROM            INVENTARIO INNER JOIN
                         PRODUCTO ON INVENTARIO.id_producto_inventario = PRODUCTO.id_producto INNER JOIN
                         ESTADO_PRODUCTO ON PRODUCTO.id_estado_producto = ESTADO_PRODUCTO.id_estado_producto
WHERE PRODUCTO.nombre_producto =  @nombr
END
GO

--PROCEDIMIENTO CONSULTA EL INVENTARIO DE UN PRODUCTO SEGUN SU CODIGO
CREATE PROCEDURE ConsultarInventarioXCodigoProducto
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
Go

--PROCEDIMIENTO CONSULTA EL HISTORICO DEL INVENTARIO SEGUN SU ID
CREATE PROCEDURE ConsultarHistoricoInventarioX_id
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


--PROCEDIMIENTO QUE ACTUALIZA LA CANTIDAD DE EXISTENCIAS DE UN PRODUCTO Y SE AGREGA AL HISTORICO
CREATE PROCEDURE ActualizarInventarioProductos
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


--PROCEDIMIENTO CONSULTA EL TOTAL DE INVENTARIOS DE TODOS LOS PRODUCTOS
CREATE PROCEDURE ConsultarInventarioBajas
AS
BEGIN
SELECT        INVENTARIO_BAJAS.id_inventario_bajas, PRODUCTO.nombre_producto, INVENTARIO_BAJAS.id_producto_inventario, INVENTARIO_BAJAS.cantidad_existencias, INVENTARIO_BAJAS.fecha_actualizacion_inventario
FROM            INVENTARIO_BAJAS INNER JOIN
                         PRODUCTO ON INVENTARIO_BAJAS.id_producto_inventario = PRODUCTO.id_producto
END
GO

--PROCEDIMIENTO CONSULTA EL HISTORICO DEL INVENTARIO DE BAJAS SEGUN SU ID
CREATE PROCEDURE ConsultarHistoricoInventarioBajasX_id
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

-- PROCEDIMIENTO QUE TRAE LA CANTIDAD DE EXISTENCIAS POR PRODUCTO
CREATE PROCEDURE ConsultarCantidadXProducto
@id_inventario int
AS
BEGIN 
SELECT  cantidad_existencias FROM INVENTARIO WHERE id_inventario =  @id_inventario
END
GO	

--PROCEDIMIENTO QUE AGREGA UNA BAJA AL INVENTARIO DE BAJAS, LO DISMINUYE DEL INVENTARIO DE PRODUCTOS Y AGREGA AMBOS MOVIMIENTOS A SU
-- RESPECTIVO HISTORICO
CREATE PROCEDURE AgregarBajaInventario 
 @id_producto int,
 @cantidadBajas int,
 @identifEmpleado VARCHAR(15),
 @descripcionBaja VARCHAR(500)
AS
DECLARE @fecha DATETIME,
@cantidadExistenciasInventario int,
@cantidadExistenciasInventarioBajasActual int,
@idEmpleado int,
@idInventario int

SET @fecha = (SELECT CURRENT_TIMESTAMP);
SET @idEmpleado = (SELECT id_usuario FROM USUARIO WHERE identificacion = @identifEmpleado);
SET @idInventario = (SELECT id_inventario FROM INVENTARIO WHERE id_producto_inventario = @id_producto);
SET @cantidadExistenciasInventario  = (SELECT cantidad_existencias FROM INVENTARIO WHERE id_producto_inventario=@id_producto);
SET @cantidadExistenciasInventarioBajasActual = (SELECT cantidad_existencias FROM INVENTARIO_BAJAS WHERE id_producto_inventario = @id_producto);
BEGIN
	UPDATE INVENTARIO_BAJAS SET id_producto_inventario =@id_producto ,cantidad_existencias=@cantidadExistenciasInventarioBajasActual+@cantidadBajas,
	fecha_actualizacion_inventario = @fecha WHERE (id_producto_inventario = @id_producto);
	
	INSERT INTO HISTORICO_INVENTARIO_BAJAS (id_empleado,id_inventario_historico,fecha,descripcion)
	VALUES (@idEmpleado,@idInventario,@fecha,@descripcionBaja);

	UPDATE INVENTARIO SET cantidad_existencias = @cantidadExistenciasInventario - @cantidadBajas 
	WHERE INVENTARIO.id_producto_inventario = @id_producto;
	
	INSERT INTO HISTORICO_INVENTARIO (id_empleado,id_inventario_historico,fecha,descripcion)
	VALUES (@idEmpleado,@idInventario,@fecha,'Se realiza disminución de inventario.  Motivo: '+@descripcionBaja); 
END

GO

-- PROCEDIMIENTO QUE AGREGA UNA ANOTACION ADICIONAL AL HISTORICO DEL INVENTARIO
CREATE PROCEDURE AgregarAnotacionHistoricoInventario
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

-- PROCEDIMIENTO QUE AGREGA UNA ANOTACION ADICIONAL AL HISTORICO DEL INVENTARIO DE BAJAS
CREATE PROCEDURE AgregarAnotacionHistoricoInventarioBajas
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

-- PROCEDIMIENTO QUE ACTUALIZA EL ESTADO DE CADA PRODUCTO DEL INVENTARIO SEGUN CANTIDAD DE EXISTENCIAS DE MANERA AUTOMÁTICA
CREATE PROCEDURE ActualizarEstadoProducto_Automatico
AS
DECLARE 
@fecha DATETIME,
@TotalRegistrosInventario int,
@CantidadExistencias int,
@idestadoActual int,
@descripcion VARCHAR (500)
SET @TotalRegistrosInventario = (SELECT COUNT(*) FROM INVENTARIO);
SET @fecha = (SELECT CURRENT_TIMESTAMP);
BEGIN
	WHILE @TotalRegistrosInventario > 0
	BEGIN
		SET @CantidadExistencias = (SELECT cantidad_existencias FROM INVENTARIO WHERE id_inventario = @TotalRegistrosInventario);
		SET @idestadoActual =  (SELECT id_estado_producto FROM PRODUCTO WHERE id_producto = @TotalRegistrosInventario);
		IF(@CantidadExistencias =0 AND @idestadoActual=1)
		BEGIN
			UPDATE PRODUCTO SET id_estado_producto = 2 
			WHERE id_producto = @TotalRegistrosInventario

			UPDATE INVENTARIO SET fecha_actualizacion_inventario = @fecha
			WHERE id_producto_inventario =@TotalRegistrosInventario
			
			SET @descripcion = ('Se ha cambiado el estado del producto a no disponible por falta de existencias');
			INSERT INTO HISTORICO_INVENTARIO(id_empleado,id_inventario_historico,fecha,descripcion)
			VALUES (1,@TotalRegistrosInventario,@fecha,@descripcion);
		END
		ELSE IF(@CantidadExistencias <>0 AND @idestadoActual=2)
		BEGIN
			UPDATE PRODUCTO SET id_estado_producto = 1 
			WHERE id_producto = @TotalRegistrosInventario

			SET @descripcion = ('Se ha cambiado el estado del producto a Disponible por detección de existencias en stock');
			INSERT INTO HISTORICO_INVENTARIO(id_empleado,id_inventario_historico,fecha,descripcion)
			VALUES (1,@TotalRegistrosInventario,@fecha,@descripcion);
		END
		SET @TotalRegistrosInventario = @TotalRegistrosInventario -1;
	END
END 
GO

--PROCEDIMIENTO QUE CREA UNA FACTURA SIN REGISTROS PARA EL INICIO DE LA GENERACION DE UNA FACTURA FINAL
CREATE PROCEDURE CrearFacturaSinRegistros
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

--PROCEDIMIENTO QUE ELIMINA FACTURAS SIN REGISTROS.   ESTE PROC SE EJECUTARÁ POR MEDIO DE UN JOB QUE HARÁ EL PROCESO CADA X PERIODO DE TIEMPO
CREATE PROCEDURE GarbageCollector_FacturasSinRegistros_Automatico
AS
DECLARE @TotalRegistros int
BEGIN

SET @TotalRegistros =  (SELECT COUNT(*) FROM SOLICITUD);
DELETE FROM HISTORICO_FACTURA WHERE id_factura_historico IN (SELECT id_factura FROM FACTURA 
								WHERE id_estado_factura = 5)

DELETE FROM FACTURA WHERE id_estado_factura = 5

END
GO

--PROCEDIMIENTO QUE TRAE EL ID DE LA ULTIMA FACTURA CREADA
CREATE PROCEDURE ObtenerIdUltimaFacturaGenerada
AS
BEGIN
	SELECT COUNT(*) FROM factura
END
GO