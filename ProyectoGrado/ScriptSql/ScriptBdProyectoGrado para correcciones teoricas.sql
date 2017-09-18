-- Creacion de Base de Datos

USE MASTER;
GO
DROP DATABASE bdCopiaTeoricaServiciosDigitalesProy;
GO

Create Database bdCopiaTeoricaServiciosDigitalesProy;
Go
use bdCopiaTeoricaServiciosDigitalesProy;
Go

-- Creacion de tablas

-- TABLA  TIPO DE ELEMENTO, LOS TIPOS DE elementos QUE SE TIENEN

create table TIPO_ELEMENTO(
id_tipo_elemento int  not null IDENTITY,
descripcion_elemento varchar(50) not null,
primary key (id_tipo_elemento)
);


-- TABLA  CATEGORIA ELEMENTO, PARA CATEGORIZAR LOS ELEMENTOS EXISTENTES Y PODER AGRUPAR LOS SERVICIOS SEGUN SU CATEGORIA

create table CATEGORIA_ELEMENTO(
id_categoria_elemento int  not null IDENTITY,
descripcion_categoria_elemento varchar(50) not null,
primary key (id_categoria_elemento)
);

	
-- TABLA  TIPO DE IDENTIFICACION DEL USUARIO, LOS TIPOS DE DOCUMENTO DE IDENTIDAD QUE EXISTEN

create table TIPO_IDENTIFICACION_USUARIO(
id_tipo_identificacion int  not null IDENTITY,
descripcion_tipo_identificacion varchar(50) not null,
primary key (id_tipo_identificacion)
);

	
-- TABLA  PERMISO, INDICA EL MODULO AL QUE SE LE DA PERMISO Y UNA DESCRIPCION DEL PERMISO	
create table PERMISO(
permisoID int not null IDENTITY(1,1),
modulo varchar(20),
descripcion varchar(100),
primary key (permisoID)
);

	
-- TABLA  ROL, EL TIPO DE ROL DE LA TABLA USUARIO	
create table ROL(
id_rol int not null IDENTITY,
descripcion varchar(50) not null,
primary key (id_Rol)
);


	
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


-- TABLA SUCURSAL, CONTIENE LA INFORMACIÓN DE CADA SUCURSAL DISPONIBLE PARA EL SISTEMA
create table SUCURSAL(
id_sucursal int  not null IDENTITY(1,1),
nombre varchar(20) not null,
direccion varchar(50),
ciudad varchar(50),
telefonoFijo varchar(10),
telefonoCelular varchar(10),
primary key (id_sucursal)
);



-- TABLA  ESTADO USUARIO, EL ESTADO EN EL QUE SE ENCUENTRA UN USUARIO (ELIMINADO, ACTIVO, INACTIVO, BLOQUEADO)	
create table ESTADO_EMPLEADO(
id_estado int  not null IDENTITY,
descripcion varchar(20) not null,
primary key (id_estado)
);




-- TABLA  USUARIO, LOS USUARIOS TANTO EMPLEADOS COMO CLIENTES
create table EMPLEADO (
id_empleado int  not null IDENTITY(1,1),
id_tipo_Identificacion_empleado int  not null,
id_estado_empleado int  not null,
id_rol_usuario int not null,
identificacion varchar(15) not null,
apellidos varchar(30) not null,
nombres varchar (30) not null,
direccion varchar (50),
correo varchar (50) not null,
sexo char (1) not null,
usuario_login varchar(15) not null,
password nvarchar (50) not null
primary key (id_empleado)
	CONSTRAINT  fk_tipo_Identificacion_usuario
    	FOREIGN KEY ( id_tipo_Identificacion_empleado  )
    	REFERENCES   TIPO_IDENTIFICACION_USUARIO ( id_tipo_identificacion  ),
	CONSTRAINT  fk_estado_usuario
    	FOREIGN KEY ( id_estado_empleado  )
    	REFERENCES   ESTADO_EMPLEADO ( id_estado  ),
	CONSTRAINT  fk_rol_usuario
    	FOREIGN KEY ( id_rol_usuario  )
    	REFERENCES   ROL ( id_rol  ),	
);
GO

create table CLIENTE (
id_cliente int  not null IDENTITY(1,1),
id_tipo_Identificacion_cliente int  not null,
identificacion varchar(15) not null,
apellidos varchar(30) not null,
nombres varchar (30) not null,
direccion varchar (50),
correo varchar (50) not null,
sexo char (1) not null,
usuario_login varchar(15) not null,
password nvarchar (50) not null
primary key (id_cliente)
	CONSTRAINT  fk_tipo_Identificacion_cliente
    	FOREIGN KEY ( id_tipo_Identificacion_cliente  )
    	REFERENCES   TIPO_IDENTIFICACION_USUARIO ( id_tipo_identificacion  )
);
GO



-- TABLA  ESCALADO, A QUE USUARIO SE LE ESCALA LA SOLICITUD
create table ESCALADO(
id_escalado int not null,
id_usuario_escalado int,
id_sucursal_escalado int,
primary key (id_escalado),
	CONSTRAINT  fk_usuario_escalado
			FOREIGN KEY ( id_usuario_escalado  )
			REFERENCES   EMPLEADO ( id_empleado  ),
	CONSTRAINT  fk_sucursal_escalado
			FOREIGN KEY ( id_sucursal_escalado  )
			REFERENCES   SUCURSAL ( id_sucursal  )			
);
GO

--TABLA QUE IMPIDE LOGUEAR UN USUARIO EN MAS DE UNA ESTACION
CREATE TABLE VALIDAR_USUARIO_LOGUEADO(
id_validar int not null IDENTITY,
idEmpleado int, 
estado VARCHAR(10),
primary key (id_validar),

);
GO
	

-- TABLA  TELEFONO USUARIO, LOS POSIBLES TELEFONOS DE LOS USUARIOS	
create table TELEFONO_USUARIO(
id_telefono int  not null IDENTITY,
id_usuario_telefono int not null,
numero_telefono varchar(15)
primary key (id_telefono)
	CONSTRAINT  fk_usuario_telefono
			FOREIGN KEY ( id_usuario_telefono  )
			REFERENCES   CLIENTE ( id_cliente  ),
);





	
-- TABLA  SERVICIOS, LOS SERVICIOS DISPONIBLES A OFRECER
create table SERVICIO(
id_servicio int  not null IDENTITY,
descripcion_servicio varchar(50) not null,
precio decimal(20,4),
primary key (id_servicio)
);


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


	
-- TABLA  PRIORIDAD, INDICA LA PRIORIDAD DE LA SOLICITUD DEL CLIENTE
create table PRIORIDAD(
id_prioridad int not null IDENTITY,
descripcion_prioridad varchar(50),
tiempo_solucion int,
primary key (id_prioridad) 	
);



-- TABLA  ESTADO_SOLICITUD, ESTADO DE LA SOLICITUD EN LA QUE SE ENCUENTRA EL SERVICIO
create table ESTADO_SOLICITUD(
id_estado_solicitud int not null IDENTITY,
descripcion varchar(50),
primary key (id_estado_solicitud) 	
);


-- TABLA  ESTADO_FACTURA, TABLA QUE CONTIENE LOS ESTADOS POSIBLES QUE LA FACTURA PUEDA TENER A NIVEL FINANCIERO
create table ESTADO_FACTURA(
id_estado_factura int not null IDENTITY,
descripcion_estado_factura varchar(20) not null,
primary key (id_estado_factura),	
);

	

	-- TABLA  FACTURA, TABLA QUE CONTIENE LOS REGISTROS DE LA FACTURA DE VENTA GENERADA
create table FACTURA_VENTA(
id_factura int not null IDENTITY (1,1),
fecha DATETIME not null,
id_cliente_factura int,
id_empleado_factura int,
id_estado_factura int not null,
saldo decimal(30,4),
valor_total decimal(30,4),
primary key (id_factura),
	CONSTRAINT  fk_usuario_factura
			FOREIGN KEY ( id_cliente_factura  )
			REFERENCES   CLIENTE ( id_cliente  ),
	CONSTRAINT  fk_empleado_factura
			FOREIGN KEY ( id_empleado_factura  )
			REFERENCES   ESCALADO ( id_escalado  ),		
	CONSTRAINT  fk_estado_factura
			FOREIGN KEY ( id_estado_factura  )
			REFERENCES   ESTADO_FACTURA ( id_estado_factura  )		
);
	
	
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
			REFERENCES   FACTURA_VENTA ( id_factura  ),			
);


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
			REFERENCES   CLIENTE ( id_cliente  ),	
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
			REFERENCES   CLIENTE ( id_cliente  ),
	CONSTRAINT  fk_solicitud_historico
			FOREIGN KEY ( id_solicitud_historico  )
			REFERENCES   SOLICITUD ( id_solicitud  ),			
);



-- TABLA  ESTADO_PRODUCTO, TABLA QUE CONTIENE LOS ESTADOS QUE PUEDE TENER EL PRODUCTO
create table ESTADO_PRODUCTO(
id_estado_producto int not null IDENTITY,
descripcion_estado_producto varchar(15) not null,
primary key (id_estado_producto),	
);


-- TABLA CATEGORIA DE PRODUCTO, CONTIENE LAS CATEGORIAS A LAS QUE SE PUEDE CLASIFICAR LOS PRODUCTOS
CREATE TABLE CATEGORIA_PRODUCTO(
id_categoria int not null IDENTITY,
descripcion varchar(50) not null,
primary key (id_categoria),	
);



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

	
	-- TABLA  INVENTARIO, TABLA QUE CONTIENE LOS INVENTARIOS DE LOS PRODUCTOS 
create table INVENTARIO(
id_inventario int not null IDENTITY,
id_producto_inventario int not null,
id_sucursal_inventario int,
cantidad_existencias int not null,
fecha_actualizacion_inventario DATETIME not null,
primary key (id_inventario),
	CONSTRAINT  fk_producto_inventario
			FOREIGN KEY ( id_producto_inventario  )
			REFERENCES   PRODUCTO ( id_producto  ),	
	CONSTRAINT  fk_sucursal_inventario
			FOREIGN KEY ( id_sucursal_inventario  )
			REFERENCES   SUCURSAL ( id_sucursal  )		
);

	

	-- TABLA  HISTORICO INVENTARIO, TABLA QUE CONTIENE EL HISTORICO DE MOVIMIENTOS DEL INVENTARIO
create table HISTORICO_INVENTARIO(
id_historico int not null IDENTITY(1,1),
id_empleado int not null,
id_inventario_historico int not null,
fecha DATETIME not null,
descripcion VARCHAR(500) not null,
primary key (id_historico),
	CONSTRAINT  fk_empleado_historico_inventario
			FOREIGN KEY ( id_empleado  )
			REFERENCES   EMPLEADO ( id_empleado  ),	
	CONSTRAINT  fk_inventario_historico_inventario
			FOREIGN KEY ( id_inventario_historico  )
			REFERENCES   INVENTARIO ( id_inventario  ),			
);



	-- TABLA  INVENTARIO, TABLA QUE CONTIENE LOS INVENTARIOS DE LOS PRODUCTOS 
create table INVENTARIO_BAJAS(
id_inventario_bajas int not null IDENTITY(1,1),
id_producto_inventario int not null,
id_sucursal_inventario int,
cantidad_existencias int not null,
fecha_actualizacion_inventario DATETIME not null,
primary key (id_inventario_bajas),
	CONSTRAINT  fk_producto_inventario_bajas
			FOREIGN KEY ( id_producto_inventario  )
			REFERENCES   PRODUCTO ( id_producto  ),	
	CONSTRAINT  fk_sucursal_inventario_bajas
			FOREIGN KEY ( id_sucursal_inventario  )
			REFERENCES   SUCURSAL ( id_sucursal  )		
);

	

	-- TABLA  HISTORICO INVENTARIO, TABLA QUE CONTIENE EL HISTORICO DE MOVIMIENTOS DEL INVENTARIO
create table HISTORICO_INVENTARIO_BAJAS(
id_historico int not null IDENTITY(1,1),
id_empleado int not null,
id_inventario_historico int not null,
fecha DATETIME not null,
descripcion VARCHAR(500) not null,
primary key (id_historico),
	CONSTRAINT  fk_empleado_historico_inventario_bajas
			FOREIGN KEY ( id_empleado  )
			REFERENCES   EMPLEADO ( id_empleado  ),	
	CONSTRAINT  fk_inventario_historico_inventario_bajas
			FOREIGN KEY ( id_inventario_historico  )
			REFERENCES   INVENTARIO_BAJAS ( id_inventario_bajas  ),			
);

	-- TABLA  DETALLE_FACTURA, TABLA QUE AGRUPA LA INFORMACION DE LA FACTURA CON EL PRODUCTO Y EL CLIENTE
create table DETALLE_FACTURA_PRODUCTO(
id_detalle_factura int not null IDENTITY(1,1),
id_producto_detalle_factura int,
id_factura_detalle_factura int not null,
cantidad_venta int not null,
primary key (id_detalle_factura),
	CONSTRAINT  fk_producto_detalle_factura
			FOREIGN KEY ( id_producto_detalle_factura  )
			REFERENCES   PRODUCTO ( id_producto  ),	
	CONSTRAINT  fk_factura_detalle_factura_producto
			FOREIGN KEY ( id_factura_detalle_factura  )
			REFERENCES   FACTURA_VENTA ( id_factura  ),			
);


	
	
	-- TABLA  DETALLE_FACTURA, TABLA QUE AGRUPA LA INFORMACION DE LA FACTURA CON  LA SOLICITUD Y EL CLIENTE
create table DETALLE_FACTURA_SOLICITUD(
id_detalle_factura_solicitud int not null IDENTITY(1,1),
id_solicitud_detalle_factura int,
id_factura_detalle_factura int not null,
cantidad_venta int not null,
primary key (id_detalle_factura_solicitud),
	CONSTRAINT  fk_solicitud_detalle_factura
			FOREIGN KEY ( id_solicitud_detalle_factura  )
			REFERENCES   SOLICITUD ( id_solicitud  ),	
	CONSTRAINT  fk_factura_detalle_factura_solicitud
			FOREIGN KEY ( id_factura_detalle_factura  )
			REFERENCES   FACTURA_VENTA ( id_factura  ),			
);



