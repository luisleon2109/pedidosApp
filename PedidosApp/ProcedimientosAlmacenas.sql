create table Articulo(
idarticulo int identity(1,1) not null primary key,
codigo varchar(50) not null,
nombre varchar(50) not null,
descripcion varchar(256) null,
imagen image null,
idcategoria int not null,
idpresentacion int not null
)
create table Categoria(
idcategoria int identity(1,1) not null primary key,
nombre varchar(50) not null,
descripcion varchar(256) null,

)



create table Proveedor(
idproveedor int identity(1,1) not null primary key,
razonsocial varchar(50) not null,
sectorcomercial varchar(50) not null,
tipodocumento varchar(50) not null,
nrodocumento int not null,
direccion varchar(256) not null,
email varchar(100) not null,
telefono int not null,
enlace varchar(100)
)
--Procedimiento Insertar Proveedor
create proc spinsertar_proveedor
@idproveedor int output,
@razonsocial varchar(50),
@sectorcomercial varchar(50),
@tipodocumento varchar(50),
@nrodocumento int,
@direccion varchar(256),
@email varchar(100),
@telefono int,
@enlace varchar(100)
as
insert into Proveedor values(@razonsocial,@sectorcomercial,@tipodocumento,@nrodocumento,@direccion,@email,@telefono,@enlace)
--Procedimiento Editar Proveedor
create proc speditar_proveedor
@idproveedor int,
@razonsocial varchar(50),
@sectorcomercial varchar(50),
@tipodocumento varchar(50),
@nrodocumento int,
@direccion varchar(256),
@email varchar(100),
@telefono int,
@enlace varchar(100)
as
update Proveedor set razonsocial=@razonsocial,sectorcomercial=@sectorcomercial,
tipodocumento=@tipodocumento,
nrodocumento=@nrodocumento,direccion=@direccion,email=@email,telefono=@telefono,enlace=@enlace
where idproveedor=@idproveedor
--Procedimiento Eliminar Proveedor
create proc speliminar_proveedor
@idproveedor int
as
delete from Proveedor
where idproveedor=@idproveedor

---Procedimiento Mostrar Proveedor
CREATE PROCEDURE spmostrar_proveedor
AS
BEGIN
    SELECT 
        p.idproveedor,
        p.razonsocial,
		p.sectorcomercial,
        p.tipodocumento,
        p.nrodocumento,
        p.direccion,
        p.email,
        p.telefono,
        p.enlace
    FROM 
        Proveedor p
    ORDER BY 
        p.idproveedor DESC;
		END;
--Procedimiento almacenado Buscar proveedor
create proc spbuscar_proveedor
@textobuscar varchar (50)
as
select * from Proveedor
where razonsocial  like '%' + @textobuscar + '%'



create table Presentacion (
idpresentacion int identity(1,1) not null primary key,
nombre varchar(50) not null,
descripcion varchar(256) null,
)

create table Detalle_ingreso(
iddetalle_ingreso int identity(1,1) not null primary key,
idingreso int not null,
idarticulo int not null,
precio_compra money not null,
precion_venta money not null,
stock_inicial int not null,
stock_actual int not null,
fecha_produccion date null,
fecha_vencimiento date null,
)

create table Ingreso(
idingreso int identity(1,1) not null primary key,
idtrabajador int not null,
idproveedor int not null,
fecha date not null,
tipo_comprobante varchar(20) not null,
serie varchar(20) not null,
iva decimal(4,2) not null,
estado varchar(20) not null,

)

create proc spinsertar_articulo
@idarticulo int output,
@codigo varchar(50),
@nombre varchar(50),
@descripcion varchar(256),
@imagen image,
@idcategoria int,
@idpresentacion int
as
insert into Articulo values(@codigo,@nombre,@descripcion,@imagen,@idcategoria,@idpresentacion)

---Procedimiento Editar Articulo
create proc speditar_articulo
@idarticulo int,
@codigo varchar(50),
@nombre varchar(50),
@descripcion varchar(256),
@imagen image,
@idcategoria int,
@idpresentacion int
as
update Articulo set codigo=@codigo,nombre=@nombre,descripcion=@descripcion,
imagen=@imagen,idcategoria=@idcategoria,idpresentacion=@idpresentacion
where idarticulo=@idarticulo


---Procedimiento Eliminar Articulo
create proc speliminar_articulo
@idarticulo int
as
delete from Articulo
where idarticulo=@idarticulo


---Procedimiento Mostrar Articulo
create proc spmostrar_articulo
as
select a.idarticulo,a.codigo,a.nombre,a.descripcion,a.imagen,a.idcategoria,
c.nombre as categoria,a.idpresentacion,p.nombre as presentacion
from Articulo a inner join Categoria c on a.idcategoria=c.idcategoria
inner join Presentacion p on a.idpresentacion = p.idpresentacion
order by a.idarticulo desc

---Procedimiento buscar articulo
create proc spbuscar_articulo_nombre
@textobuscar varchar(50)
as
select a.idarticulo,a.codigo,a.nombre,a.descripcion,a.imagen,a.idcategoria,
c.nombre as categoria,a.idpresentacion,p.nombre as presentacion
from Articulo a inner join Categoria c on a.idcategoria =c.idcategoria
inner join Presentacion p on a.idpresentacion = p.idpresentacion
where a.nombre like '%' + @textobuscar + '%'
order by a.idarticulo desc

---procedimiento stock articulos
create proc spstock_articulos 
as
select a.codigo, a.nombre, c.nombre as categoria,
SUM(di.stock_inicial) as Cantidad_ingreso,
SUM(di.stock_actual) as Cantidad_stock,
SUM((di.stock_inicial)-(di.stock_actual)) as Cantidad_venta
from Articulo a inner join Categoria c on a.idcategoria=c.idcategoria
inner join detalle_ingreso di on a.idarticulo = di.idarticulo
inner join ingreso i on di.idingreso = i.idingreso
where i.estado <> 'ANULADO'
group by a.codigo, a.nombre, c.nombre

create proc spinsertar_presentacion
@idpresentacion int output,
@nombre varchar(50),
@descripcion varchar(256)
as
insert into Presentacion values(@nombre,@descripcion)

create proc speditar_presentacion
@idpresentacion int,
@nombre varchar(50),
@descripcion varchar(256)
as
update Presentacion set nombre=@nombre,descripcion=@descripcion
where idpresentacion=@idpresentacion

create proc speliminar_presentacion
@idpresentacion int
as
delete from Presentacion
where idpresentacion=@idpresentacion

create proc spmostrar_presentacion
as
select * from Presentacion
order by idpresentacion desc

create proc spbuscar_presentacion_nombre
@textobuscar varchar (50)
as
select * from Presentacion
where nombre  like '%' + @textobuscar + '%'