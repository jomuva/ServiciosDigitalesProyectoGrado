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
			(1,1,2,'1020727312','Servicios Digitales','System','No Address','system@gmail.com','M','system','system'),
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
			(9,'2515446')
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
			('Transfer de Videos'),
			('Quemado de CD'),
			('Quemado de DVD'),
			('Trabajo en Computador'),
			('Mantenimiento Correctivo Impresora'),
			('Mantenimiento Preventivo Impresora')
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
			('En Espera'),
			('En Cola'),
			('Por Aprobar'),
			('Vencida')
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
fecha DATETIME not null,
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
            ('2016-11-29 02:57:24.480',3,3,20000,95000),
			('2016-12-13 02:57:24.480',4,1,0,60000),
			('2017-02-10 02:57:24.480',5,1,0,70000),
			('2017-02-25 02:57:24.480',6,4,0,55000),
			('2017-03-03 02:57:24.480',7,4,10000,40000)
		
	GO	

-- TABLA  SOLICITUD, TIENE LA INFORMACION DE LA SOLICITUD DEL CLIENTE Y SU SERVICIO ASOCIADO
create table SOLICITUD(
id_solicitud int not null IDENTITY,
id_prioridad_solicitud int not null,
id_estado_solicitud int not null,
id_usuario_solicitud int not null,
id_servicio_solicitud int not null,
id_elemento_solicitud int,
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
);
INSERT INTO [dbo].[SOLICITUD]
           ([id_prioridad_solicitud]
		   ,[id_estado_solicitud]
		   ,[id_usuario_solicitud]
		   ,[id_servicio_solicitud]
		   ,[id_elemento_solicitud]
		   ,[fecha_solicitud]
		   ,descripcion)
     VALUES
            (1,2,6,1,5,'2017-04-08 02:57:24.480','Por favor Instalar autocad'),
			(2,5,7,2,2,'2017-04-08 02:57:24.480','Por favor limpiar pantalla'),
			(3,3,8,12,3,'2017-02-10 02:57:24.480','Sin novedad'),
			(2,4,4,8,4,'2017-02-25 02:57:24.480','Conseguir cable'),
			(1,1,5,1,6,'2017-03-03 02:57:24.480','Sin novedad'),
			(2,5,8,10,1,'2017-04-08 02:57:24.480','Por favor realizar label con título de la universidad')
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
create table HISTORICO_SOLICITUD(
id_historico int not null IDENTITY,
id_usuario_historico int not null,
id_solicitud_historico int not null,
descripcion_historico varchar(100) not null,
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
            (1,1,'Se realiza mantenimiento a satisfaccion del cliente','2017-04-08 02:57:24.480'),
			(2,2, 'El cliente realiza mantenimiento','2017-04-07 02:57:24.480'),
			(1,3,'Se repara el teclado y el mouse del cliente','2017-03-06 02:57:24.480'),
			(2,4,'se hace pruebas en el servicio contratado','2017-04-08 02:57:24.480'),
			(2,5,'se realizan pruebas de calidad en el servicio solicitado por el cliente','2017-04-06 02:57:24.480')
		
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
            (1,25,'2017-01-01 02:57:24.480'),
			(2,15,'2017-01-01 02:57:24.480'),
			(3,20,'2017-01-01 02:57:24.480'),
			(4,18,'2017-01-01 02:57:24.480'),
			(5,6,'2017-01-01 02:57:24.480')
		
	GO	
	
	-- TABLA  DETALLE_FACTURA, TABLA QUE AGRUPA LA INFORMACION DE LA FACTURA CON EL PRODUCTO Y EL CLIENTE
create table DETALLE_FACTURA_PRODUCTO(
id_detalle_factura int not null IDENTITY,
id_producto_detalle_factura int,
id_vendedor_usuario int not null,
id_factura_detalle_factura int not null,
cantidad_venta int not null,
primary key (id_detalle_factura),
	CONSTRAINT  fk_producto_detalle_factura
			FOREIGN KEY ( id_producto_detalle_factura  )
			REFERENCES   PRODUCTO ( id_producto  ),	
	CONSTRAINT  fk_vendedor_usuario_detalle_producto
			FOREIGN KEY ( id_vendedor_usuario  )
			REFERENCES   USUARIO ( id_usuario  ),	
	CONSTRAINT  fk_factura_detalle_factura_producto
			FOREIGN KEY ( id_factura_detalle_factura  )
			REFERENCES   FACTURA ( id_factura  ),			
);
INSERT INTO [dbo].[DETALLE_FACTURA_PRODUCTO]
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

	
	
	-- TABLA  DETALLE_FACTURA, TABLA QUE AGRUPA LA INFORMACION DE LA FACTURA CON  LA SOLICITUD Y EL CLIENTE
create table DETALLE_FACTURA_SOLICITUD(
id_detalle_factura_solicitud int not null IDENTITY,
id_solicitud_detalle_factura int,
id_vendedor_usuario int not null,
id_factura_detalle_factura int not null,
cantidad_venta int not null,
primary key (id_detalle_factura_solicitud),
	CONSTRAINT  fk_solicitud_detalle_factura
			FOREIGN KEY ( id_solicitud_detalle_factura  )
			REFERENCES   SOLICITUD ( id_solicitud  ),	
	CONSTRAINT  fk_vendedor_usuario_detalle_solicitud
			FOREIGN KEY ( id_vendedor_usuario  )
			REFERENCES   USUARIO ( id_usuario  ),	
	CONSTRAINT  fk_factura_detalle_factura_solicitud
			FOREIGN KEY ( id_factura_detalle_factura  )
			REFERENCES   FACTURA ( id_factura  ),			
);
INSERT INTO [dbo].[DETALLE_FACTURA_SOLICITUD]
           ([id_solicitud_detalle_factura]
		   ,[id_vendedor_usuario]
		   ,[id_factura_detalle_factura]
		   ,[cantidad_venta])
     VALUES
            (1,1,1,1),
			(2,2,2,1),
			(3,2,3,1),
			(4,2,4,1),
			(5,2,5,1)
		
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
         @fecha DATETIME;
SET @fecha =  (SELECT CURRENT_TIMESTAMP);		 
SET @id_prod = (SELECT id_producto FROM PRODUCTO WHERE nombre_producto = @nombre_prod);

INSERT INTO INVENTARIO (id_producto_inventario,cantidad_existencias,fecha_actualizacion_inventario)
VALUES (@id_prod,@cantidad,@fecha)

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
CREATE PROC ConsultarProductoXNombre 
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
CREATE PROC ConsultarProductos
AS
BEGIN
SELECT id_producto,id_estado_producto,nombre_producto,precio_costo,precio_venta FROM PRODUCTO
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

CREATE PROC AgregarServicio
@descripc VARCHAR(50)
as
BEGIN 

INSERT INTO SERVICIO (descripcion_servicio)
VALUES (@descripc);

END
GO

--PROCEDIMIENTO ALMACENADO PARA consultar los servicios
CREATE PROC ConsultarServicios
AS
BEGIN
SELECT id_servicio,descripcion_servicio FROM SERVICIO
END
GO

--PROCEDIMIENTO ALMACENADO PARA actualizar un servicio

CREATE PROC ActualizarServicio
@idserv int,
@descripc VARCHAR(50)
as
BEGIN 

UPDATE SERVICIO SET descripcion_servicio=@descripc WHERE id_servicio = @idserv

END
GO

--PROCEDIMIENTO ALMACENADO PARA consultar un unico servicio
CREATE PROCEDURE ConsultarServicio
@codigo int
AS
BEGIN
SELECT id_servicio,descripcion_servicio FROM SERVICIO
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
@id_cliente int,
@id_servicio int, 
@id_elemento int,
@descripcion VARCHAR(300)
as
BEGIN 
declare @fecha DATETIME,
@id_solicitudFinal int;
SET @fecha = (SELECT CURRENT_TIMESTAMP);

IF(@id_elemento=0)
	BEGIN
		INSERT INTO SOLICITUD (id_prioridad_solicitud,id_estado_solicitud,id_usuario_solicitud,id_servicio_solicitud,fecha_solicitud,descripcion)
		VALUES (@id_prioridad,@id_estado,@id_cliente,@id_servicio,@fecha,@descripcion);
		SET @id_solicitudFinal = @@IDENTITY
	END
ELSE
	BEGIN
		INSERT INTO SOLICITUD (id_prioridad_solicitud,id_estado_solicitud,id_usuario_solicitud,id_servicio_solicitud,id_elemento_solicitud,fecha_solicitud,descripcion)
		VALUES (@id_prioridad,@id_estado,@id_cliente,@id_servicio,@id_elemento,@fecha,@descripcion);
		SET @id_solicitudFinal = @@IDENTITY
	END
END
	INSERT INTO HISTORICO_SOLICITUD (id_usuario_historico,id_solicitud_historico,descripcion_historico)
	VALUES (@id_cliente,@id_solicitudFinal,'Se crea la solicitud del cliente, pendiente por asignar técnico')
		
GO


--PROCEDIMIENTO ALMACENADO PARA CONSULTAR TODOS LOS TIPOS DE PRIORIDAD QUE HAY PARA LA SOLICITUD
CREATE PROCEDURE ConsultarTiposPrioridad
AS
BEGIN
SELECT id_prioridad,descripcion_prioridad FROM PRIORIDAD
END
GO

--PROCEDIMIENTO ALMACENADO PARA CONSULTAR TODOS LOS ESTADOS DE SOLICITUD EXISTENTES EN BD
CREATE PROCEDURE ConsultarEstadosSolicitud
AS
BEGIN
SELECT id_estado_solicitud,descripcion FROM ESTADO_SOLICITUD
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
		IF(@tiempoSoluc < @Resultado AND @estadoSolic <> 1 )
			BEGIN
				UPDATE SOLICITUD SET id_estado_solicitud = 6 WHERE id_solicitud = @TotalRegistros
				SET @Descrip_historico = ('Se ha modificado el estado de la solicitud de '+@Descrip_estado_anterior+' a Vencido')
				INSERT INTO HISTORICO_SOLICITUD (id_usuario_historico,id_solicitud_historico,descripcion_historico,fecha_historico)
				VALUES (1,@TotalRegistros,@Descrip_historico,CURRENT_TIMESTAMP)
			END
		SET @TotalRegistros = @TotalRegistros -1
	END
END
GO

--PROCEDIMIENTO ALMACENADO PARA CONSULTAR SOLICITUDES TOTALES
CREATE PROCEDURE ConsultarSolicitudes
AS
BEGIN
SELECT        USUARIO.identificacion, USUARIO.apellidos, USUARIO.nombres,SOLICITUD.id_solicitud, SOLICITUD.descripcion, SOLICITUD.fecha_solicitud, PRIORIDAD.descripcion_prioridad, ESTADO_SOLICITUD.descripcion AS Estado, 
                         TIPO_ELEMENTO.descripcion_elemento, SERVICIO.descripcion_servicio, ELEMENTO.serial, ELEMENTO.modelo, ELEMENTO.marca
FROM            SOLICITUD INNER JOIN
                         ELEMENTO ON ELEMENTO.id_elemento = SOLICITUD.id_elemento_solicitud INNER JOIN
                         ESTADO_SOLICITUD ON SOLICITUD.id_estado_solicitud = ESTADO_SOLICITUD.id_estado_solicitud INNER JOIN
                         PRIORIDAD ON SOLICITUD.id_prioridad_solicitud = PRIORIDAD.id_prioridad INNER JOIN
                         SERVICIO ON SOLICITUD.id_servicio_solicitud = SERVICIO.id_servicio INNER JOIN
                         TIPO_ELEMENTO ON ELEMENTO.id_tipo_elemento = TIPO_ELEMENTO.id_tipo_elemento INNER JOIN
                         USUARIO ON SOLICITUD.id_usuario_solicitud = USUARIO.id_usuario
END
GO

	


	
	
	