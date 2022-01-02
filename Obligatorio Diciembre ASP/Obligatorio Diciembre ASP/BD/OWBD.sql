use master 
go
if exists(select*from sysdatabases where name = 'OWBD')
begin
drop database OWBD
end
go
create database OWBD
go	
use OWBD

-- Creacion de Tablas

create table TPeriodista
(
	CodigoPeriodista int not null primary key,
	Nombre varchar (20) not null,
	Apellido varchar (20) not null,
	Mail varchar (40) not null
)
go

create table TNoticias
(
	CodigoNoticias int identity (1,1) primary key,
	Titulo varchar (30) not null,
	Resumen varchar (100) null,
	Contenido varchar (300) not null,
	Fecha Datetime not null,
	CodigoPeriodista int not null foreign key references TPeriodista(CodigoPeriodista)
	
)
go

Create table TSecciones
(
	CodigoSecciones varchar (3) primary key,
	NombreSeccion varchar (30) not null,
	
)
go

Create table TNacionales 
(
	CodigoNoticia int not null foreign key references TNoticias (CodigoNoticias),
	CodigoSecciones varchar (3) not null foreign key references TSecciones (CodigoSecciones)
	primary key (CodigoNoticia)
)
go

Create table TInternacionales 
(
	CodigoNoticia int not null foreign key references TNoticias (CodigoNoticias),
	Pais varchar (20) not null,
	primary key (CodigoNoticia)
)
go

-- DATOS DE PRUEBA

insert into TPeriodista (CodigoPeriodista,Nombre,Apellido,Mail)

values	        (1111, 'Juan',    'Lopez',	   'JuanLopez@gmail.com'),
				(2222, 'Rodrigo', 'Costa',     'RodrigoCosta@gmail.com'),
				(3333, 'Agustina','Pintos',    'AgustinaPintos@gmail.com'),
				(4444, 'Jazmin',  'Fleitas',   'JazminFleitas@gmail.com'),
				(5555, 'Enrique', 'Lopez',     'EnriqueLopez@gmail.com'),
				(6666, 'Claudia', 'Chaves',    'ClaudiaChaves@gmail.com'),
				(7777, 'Agustina','Merli',     'AgustinaMerli@gmail.com'),
				(8888, 'Federico','Diaz',      'FedericoDiaz@gmail.com'),
				(9999, 'Lautaro', 'Costa',     'LautaCosta@gmail.com'),
				(1001, 'Hector',  'Holdaway',  'HectorHoldaway@gmail.com')
go

insert into TNoticias (Titulo,Resumen,Contenido,Fecha,CodigoPeriodista)
values           ('titulo1','resumen1','contenido1sdfdsfsdfsdklfjsdfjksdfjkjsdfjkdsfjksdfkjsdfhsdkfjsdhfkjsdfhsdkjfhsdkjfsdkfjhsdkfjsdkfjsdhfkjsdhfksdjfhsdfjksdhfsdkjfhsd','2014/07/23', 1111),
				 ('titulo2','resumen2','contenido2sdfdsfsdfsdklfjsdfjksdfjkjsdfjkdsfjksdfkjsdfhsdkfjsdhfkjsdfhsdkjfhsdkjfsdkfjhsdkfjsdkfjsdhfkjsdhfksdjfhsdfjksdhfsdkjfhsd','2020/10/10', 2222),
				 ('titulo3','resumen3','contenido4sdfdsfsdfsdklfjsdfjksdfjkjsdfjkdsfjksdfkjsdfhsdkfjsdhfkjsdfhsdkjfhsdkjfsdkfjhsdkfjsdkfjsdhfkjsdhfksdjfhsdfjksdhfsdkjfhsd','2005/03/10',1111),
				 ('titulo4','resumen1','contenido1sdfdsfsdfsdklfjsdfjksdfjkjsdfjkdsfjksdfkjsdfhsdkfjsdhfkjsdfhsdkjfhsdkjfsdkfjhsdkfjsdkfjsdhfkjsdhfksdjfhsdfjksdhfsdkjfhsd','2010/01/22', 4444),
				 ('titulo5','resumen1','contenido1sdfdsfsdfsdklfjsdfjksdfjkjsdfjkdsfjksdfkjsdfhsdkfjsdhfkjsdfhsdkjfhsdkjfsdkfjhsdkfjsdkfjsdhfkjsdhfksdjfhsdfjksdhfsdkjfhsd','2019/09/13', 5555),
				 ('titulo6','resumen1','contenido1sdfdsfsdfsdklfjsdfjksdfjkjsdfjkdsfjksdfkjsdfhsdkfjsdhfkjsdfhsdkjfhsdkjfsdkfjhsdkfjsdkfjsdhfkjsdhfksdjfhsdfjksdhfsdkjfhsd','2018/06/11', 6666),
				 ('titulo7','resumen1','contenido1sdfdsfsdfsdklfjsdfjksdfjkjsdfjkdsfjksdfkjsdfhsdkfjsdhfkjsdfhsdkjfhsdkjfsdkfjhsdkfjsdkfjsdhfkjsdhfksdjfhsdfjksdhfsdkjfhsd','2006/01/19', 7777),
				 ('titulo8','resumen1','contenido1sdfdsfsdfsdklfjsdfjksdfjkjsdfjkdsfjksdfkjsdfhsdkfjsdhfkjsdfhsdkjfhsdkjfsdkfjhsdkfjsdkfjsdhfkjsdhfksdjfhsdfjksdhfsdkjfhsd','2011/11/12', 8888),
				 ('titulo9','resumen1','contenido1sdfdsfsdfsdklfjsdfjksdfjkjsdfjkdsfjksdfkjsdfhsdkfjsdhfkjsdfhsdkjfhsdkjfsdkfjhsdkfjsdkfjsdhfkjsdhfksdjfhsdfjksdhfsdkjfhsd','2019/05/10', 9999),
				 ('titulo10','resumen1','contenido1sdfdsfsdfsdklfjsdfjksdfjkjsdfjkdsfjksdfkjsdfhsdkfjsdhfkjsdfhsdkjfhsdkjfsdkfjhsdkfjsdkfjsdhfkjsdhfksdjfhsdfjksdhfsdkjfhsd','2021/01/15', 1001) ,
				 ('titulo11','resumen3','contenido3sdfdsfsdfsdklfjsdfjksdfjkjsdfjkdsfjksdfkjsdfhsdkfjsdhfkjsdfhsdkjfhsdkjfsdkfjhsdkfjsdkfjsdhfkjsdhfksdjfhsdfjksdhfsdkjfhsd','2021/01/15', 8888) ,
				 ('titulo12','resumen1','contenido1sdfdsfsdfsdklfjsdfjksdfjkjsdfjkdsfjksdfkjsdfhsdkfjsdhfkjsdfhsdkjfhsdkjfsdkfjhsdkfjsdkfjsdhfkjsdhfksdjfhsdfjksdhfsdkjfhsd','2019/05/10', 9999)  
go
insert into TSecciones (CodigoSecciones,NombreSeccion)

values          ('PLC','Policiales'),
				('POL','Politicas'),
				('ECO','Economicas'),
				('SOC','Sociales'),
				('CIE','Cientificas'),
				('DEP','Deportivas'),
				('CUL','Culturales'),
				('ETN','Entretenimiento')
	
	go		

insert into TNacionales (CodigoNoticia,CodigoSecciones)
values               (1,'POL'),
					 (3,'ECO'),
					 (5,'ETN'),
					 (7,'DEP'),
					 (9,'POL') ,  
					 (11,'POL'),
					 (12,'POL') 
	
go

insert into TInternacionales (CodigoNoticia,Pais)
values          (2,'Uruguay'),
				(4,'Estados Unidos'),
				(6,'Nueva Zelanda'),
				(8,'Australia'),
				(10,'Inglaterra')

go

--Creado de noticias
create proc CrearInter
@codigop int,
@fechac datetime,
@titulo varchar(30),
@resumen varchar(100),
@contenido varchar(3000),
@pais varchar (20)
as
begin
declare @uid int,@b int
if not  exists (select*from TPeriodista where CodigoPeriodista=@codigop)
return-1
begin tran
insert into TNoticias(CodigoPeriodista,Fecha,Titulo,Resumen,Contenido)
values(@codigop,@fechac,@titulo,@resumen,@contenido)
if @@ERROR <>0
begin
rollback tran
return -2
end
set @uid=IDENT_Current('TNoticias')
insert into TInternacionales(CodigoNoticia,Pais)
values(@uid,@pais)
if @@ERROR<>0
begin
rollback tran
return-3
end
commit tran
return @uid
end
go
-- -- -- -- 

create proc CrearNac
@codigop int,
@fechac datetime,
@titulo varchar(30),
@resumen varchar(100),
@contenido varchar(3000),
@codesec varchar (3)
as
begin
declare @uid int
if not exists (select*from TSecciones where CodigoSecciones=@codesec)
return -1
if not  exists (select*from TPeriodista where @codigop=@codigop)
return-2
begin tran
insert into TNoticias(CodigoPeriodista,fecha,titulo,Resumen,Contenido)
values(@codigop,@fechac,@titulo,@resumen,@contenido)
if @@ERROR <>0
begin
rollback tran
return -4
end
set @uid=IDENT_Current('TNoticias')
insert into TNacionales(CodigoNoticia,CodigoSecciones)
values( @uid,@codesec)
if @@ERROR<>0
begin
rollback tran
return-5
end
commit tran
return @uid
end
go

----------------------------------------------------
--Inicio mantenimiento periodista 

create proc buscarPeriodista
@codigoP int
as
begin
select * from TPeriodista where CodigoPeriodista=@codigoP
end
go

-- -- -- -- 

create proc altaPeriodista
@codigop int,
@nombre varchar(20),
@Apellido varchar(20),
@Mail varchar(40)
as 
begin
if (exists(select * from TPeriodista where CodigoPeriodista=@codigop))
return -1
else
insert into TPeriodista(CodigoPeriodista,Nombre,Apellido,Mail)
values(@codigop,@nombre,@Apellido,@Mail)
if @@ERROR <>0
return -2
else
return 1
end
go
-- -- -- -- 
create proc editarPeri
@codigoP int,
@nombre varchar(20),
@apellido varchar(20),
@mail   varchar (40)
as 
begin
if (not exists (select* from TPeriodista where CodigoPeriodista = @codigoP))
return -1
else
begin
update TPeriodista set Nombre=@nombre ,Apellido=@apellido,Mail= @mail where CodigoPeriodista = @codigoP
if @@ERROR <>0
return -2
return 1
end
end 
go


-- -- -- -- 

create proc EliminarPeri
@codigoP int 
as
begin
if  not exists (select * from TPeriodista where CodigoPeriodista=@codigoP)
return -1
if exists (select * from TNoticias where CodigoPeriodista=@codigoP)
return-2
delete from TPeriodista where CodigoPeriodista=@codigoP
if @@ERROR <>0 
return -3
else
return 1
end
go
-----------
create proc ListarPeri
as
begin

select * from  TPeriodista
end
go

-- Noticias
create proc ListarNoticias
as
begin
select * from TNoticias
end
go
-- -- -- -- 

create proc listarNacionales
as
begin
select * from TNoticias inner join TNacionales on TNoticias.CodigoNoticias=TNacionales.CodigoNoticia
end
go
-- -- -- --

create proc ListarInter
as
begin
select * from TNoticias a  inner join TInternacionales b on a.CodigoNoticias=b.CodigoNoticia
end
go
------------------


create proc BuscarSec
@codesec varchar(3)
as
begin
select * from TSecciones where CodigoSecciones=@codesec
end
go
-- -- -- -- 
create proc altaSeccion 
@codigosec varchar(3),
@nombresec  varchar(30)
as
begin
if (exists(select * from TSecciones where CodigoSecciones=@codigosec))
return -1
else
insert into TSecciones (CodigoSecciones,NombreSeccion)
values (@codigosec,@nombresec)
if @@ERROR <>0
return  -2
else
return 1
end
go
-- -- -- -- 
create proc EliminarSec
@codigoSec varchar(3)
as
begin
if not exists(select * from TSecciones where CodigoSecciones = @codigosec)
return-1
else
begin tran 
delete from TNacionales where CodigoSecciones=@codigoSec
if @@ERROR <>0 
begin
rollback tran 
return -2
end
delete  from TSecciones where CodigoSecciones = @codigoSec
if @@ERROR<>0
begin
rollback tran
return -2
end
commit tran
return 1
end 
go 
-- -- -- --

create proc ModificarSec
@codesec varchar (3),
@nombre varchar (30)
as
begin
if not exists(select* from TSecciones where CodigoSecciones=@codesec)
return -1
update TSecciones set NombreSeccion= @nombre
where CodigoSecciones=@codesec
if @@ERROR <>0
return -2
else
return 1
end
go

-- -- -- -- 
create proc Listarsec
as
begin
select * from TSecciones
end 
go



