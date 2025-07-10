create proc spinsertar_categoria
@idcategoria int output,
@nombre varchar(50),
@descripcion varchar(256)
as
insert into Categoria values(@nombre,@descripcion)

create proc speditar_categoria
@idcategoria int,
@nombre varchar(50),
@descripcion varchar(256)
as
update Categoria set nombre=@nombre,descripcion=@descripcion
where Idcategoria=@idcategoria

create proc speliminar_categoria
@idcategoria int
as
delete from Categoria
where idcategoria=@idcategoria

create proc spmostrar_categoria
as
select * from Categoria
order by idcategoria desc

create proc spbuscar_categoria
@textobuscar varchar (50)
as
select * from Categoria
where nombre  like '%' + @textobuscar + '%'