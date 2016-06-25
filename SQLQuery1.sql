if exists (select * from sys.tables where name='Genero')
BEGIN
DROP TABLE Genero
END
create table genero( 
Idgenero  int not null IDENTITY(1,1) constraint pk_usuario primary key,
detalle char(1))

if exists (select * from sys.tables where name='Niño')
BEGIN
DROP TABLE Niño
END
create table Niño( 
Idniño  char(4) not null constraint Pk_Niño primary key,
Nombres varchar(255) not null,
Idhogar int not null,
Genero int not null,
DNI char(8) not null,
fechanacimiento date not null,
nivel int not null,
direccion varchar(255) not null,
Grupo_clase int not null)




if exists (select * from sys.tables where name='Nivel')
BEGIN
DROP TABLE Nivel
END
create table Nivel(
Idnivel int not null IDENTITY(1,1) constraint Pk_nivel primary key,
nombre varchar(255) not null,
descripcion varchar(100) not null
)

if exists (select * from sys.tables where name='Hogar')
BEGIN
DROP TABLE Hogar
END
create table Hogar(
Idhogar int IDENTITY(1,1) constraint Pk_hogar primary key,
nombre varchar(255) not null)


if exists (select * from sys.tables where name='miembros_hogar')
BEGIN
DROP TABLE miembros_hogar
END
create table miembros_hogar(
Idmiembro int IDENTITY(1,1) constraint Pk_miembro primary key,
idhogar int not null,
nombres varchar(255) not null,
idrol int not null,
cuidador Bit )

if exists (select * from sys.tables where name='Rol')
BEGIN
DROP TABLE Rol
END
create table Rol(
Idrol int IDENTITY(1,1) constraint Pk_rol primary key,
nombre varchar(255) )

/*VALIDACION DE LLAVES FORANEAS*/
IF NOT EXISTS ( select * from sys.key_constraints where name='FK_NIÑO_NIVEL')
begin
ALTER TABLE Niño ADD CONSTRAINT FK_NIÑO_NIVEL FOREIGN KEY (nivel) references Nivel(Idnivel)
end

IF NOT EXISTS ( select * from sys.key_constraints where name='FK_NIÑO_HOGAR')
begin
ALTER TABLE Niño ADD CONSTRAINT FK_NIÑO_HOGAR FOREIGN KEY (Idhogar) references Hogar(Idhogar)
end

IF NOT EXISTS ( select * from sys.key_constraints where name='FK_NIÑO_HOGAR')
begin
ALTER TABLE Niño ADD CONSTRAINT FK_NIÑO_GENERO FOREIGN KEY (Genero) references Genero(Idgenero)
end

IF NOT EXISTS ( select * from sys.key_constraints where name='FK_HOGAR_MIEMBROS_HOGAR')
begin
ALTER TABLE miembros_hogar ADD CONSTRAINT FK_HOGAR_MIEMBROS_HOGAR FOREIGN KEY (idhogar) references Hogar(Idhogar)
end

IF NOT EXISTS ( select * from sys.key_constraints where name='FK_MIEMBROS_HOGAR_ROL')
begin
ALTER TABLE miembros_hogar ADD CONSTRAINT FK_MIEMBROS_HOGAR_ROL FOREIGN KEY (idrol) references Rol(Idrol)
end


/*incidentes medicos*/
if exists (select * from sys.tables where name='INCIDENTE_MEDICO')
BEGIN
DROP TABLE INCIDENTE_MEDICO
END
CREATE TABLE INCIDENTE_MEDICO(
IDincidente int IDENTITY(1,1) constraint Pk_incidente primary key,
idniño char(4) not null,
fecha date not null,
tipo int not null,
monto_desembolsado float not null)


if exists (select * from sys.tables where name='Tipo')
BEGIN
DROP TABLE Tipo
END

CREATE TABLE Tipo(
IDtipo int IDENTITY(1,1) constraint Pk_tipo primary key,
nombre varchar(100) NOT NULL ,
descripcion varchar(100) NOT NULL)

if exists (select * from sys.tables where name='DETALLE_ENFERMEDAD')
BEGIN
DROP TABLE DETALLE_ENFERMEDAD
END
CREATE TABLE DETALLE_ENFERMEDAD(
IDdetalleEnf int IDENTITY(1,1) constraint Pk_detalleEnf primary key,
idincidente int not null,
categoria int not null,
subcategoria int not null,
descripcion varchar(250) null)

if exists (select * from sys.tables where name='CATEGORIA_ENFERMEDAD')
BEGIN
DROP TABLE CATEGORIA_ENFERMEDAD
END

CREATE TABLE CATEGORIA_ENFERMEDAD(
IDCategEnf int IDENTITY(1,1) constraint Pk_CatEnfermedad primary key,
nombre varchar(100))

if exists (select * from sys.tables where name='SUBCATEGORIA_ENFERMEDAD')
BEGIN
DROP TABLE SUBCATEGORIA_ENFERMEDAD
END

CREATE TABLE SUBCATEGORIA_ENFERMEDAD(
IDSubEnf int IDENTITY(1,1) constraint Pk_SubEnfermedad primary key,
nombre varchar(100) not null,
categoria int )

if exists (select * from sys.tables where name='DETALLE_LESION')
BEGIN
DROP TABLE DETALLE_LESION
END

CREATE TABLE DETALLE_LESION(
IDdetalleLes int IDENTITY(1,1) constraint Pk_detalleLes primary key,
IDincidente int not null,
tipo_lesion int not null,
cometario varchar(250))

if exists (select * from sys.tables where name='LESION')
BEGIN
DROP TABLE LESION
END

CREATE TABLE LESION(
IDLesion int IDENTITY(1,1) constraint Pk_Lesion primary key,
nombre varchar(100) NOT NULL)

/*VALIDACION DE LLAVES FORANEAS*/
IF NOT EXISTS ( select * from sys.key_constraints where name='FK_INCIDENTE_MEDICO_NIÑO')
begin
ALTER TABLE INCIDENTE_MEDICO ADD CONSTRAINT FK_INCIDENTE_MEDICO_NIÑO FOREIGN KEY (idniño) references Niño(Idniño)
end
IF NOT EXISTS ( select * from sys.key_constraints where name='FK_INCIDENTE_MEDICO_TIPO')
begin
ALTER TABLE INCIDENTE_MEDICO ADD CONSTRAINT FK_INCIDENTE_MEDICO_TIPO FOREIGN KEY (tipo) references Tipo(IDtipo)
end
IF NOT EXISTS ( select * from sys.key_constraints where name='FK_DETALLE_ENFERMEDAD_INCIDENTE')
begin
ALTER TABLE DETALLE_ENFERMEDAD ADD CONSTRAINT FK_DETALLE_ENFERMEDAD_INCIDENTE FOREIGN KEY (idincidente) references INCIDENTE_MEDICO(IDincidente)
end

IF NOT EXISTS ( select * from sys.key_constraints where name='FK_DETALLE_ENFERMEDAD_CATEGORIA')
begin
ALTER TABLE DETALLE_ENFERMEDAD ADD CONSTRAINT FK_DETALLE_ENFERMEDAD_CATEGORIA FOREIGN KEY (categoria) references CATEGORIA_ENFERMEDAD(IDCategEnf)
end

IF NOT EXISTS ( select * from sys.key_constraints where name='FK_DETALLE_ENFERMEDAD_SUBCATEGORIA')
begin
ALTER TABLE DETALLE_ENFERMEDAD ADD CONSTRAINT FK_DETALLE_ENFERMEDAD_SUBCATEGORIA FOREIGN KEY (subcategoria) references SUBCATEGORIA_ENFERMEDAD(IDSubEnf)
end

IF NOT EXISTS ( select * from sys.key_constraints where name='FK_DETALLE_LESION_INCIDENTE')
begin
ALTER TABLE DETALLE_LESION ADD CONSTRAINT FK_DETALLE_LESION_INCIDENTE FOREIGN KEY (IDincidente) references INCIDENTE_MEDICO(IDincidente)
end


IF NOT EXISTS ( select * from sys.key_constraints where name='FK_DETALLE_LESION_LESION')
begin
ALTER TABLE DETALLE_LESION ADD CONSTRAINT FK_DETALLE_LESION_LESION FOREIGN KEY (tipo_lesion) references LESION(IDLesion)
end

IF NOT EXISTS ( select * from sys.key_constraints where name='FK_SUBCATEGORIA_ENFERMEDAD')
begin
ALTER TABLE SUBCATEGORIA_ENFERMEDAD ADD CONSTRAINT FK_SUBCATEGORIA_ENFERMEDAD FOREIGN KEY (categoria) references CATEGORIA_ENFERMEDAD(IDCategEnf)
end

/*INMUNIZACIONES/VACUNAS*/

if exists (select * from sys.tables where name='DETALLE_INMUNIZACIONES')
BEGIN
DROP TABLE DETALLE_INMUNIZACIONES
END

CREATE TABLE DETALLE_INMUNIZACIONES(
IDInmunizacion int IDENTITY(1,1) constraint Pk_inmunizacion primary key,
idniño char(4) not null,
fecha date not null,
tipo_inmunizacion int not null,
dosis int not null,
estado varchar(100) null)

if exists (select * from sys.tables where name='TIPO_INMUNIZACION')
BEGIN
DROP TABLE TIPO_INMUNIZACION
END

CREATE TABLE TIPO_INMUNIZACION(
IDT_Inmunizacion int IDENTITY(1,1) constraint Pk_t_inmunizacion primary key,
nombre varchar(100) not null,
nro_dosis int not null,
periodo int not null)




if exists (select * from sys.tables where name='DOSIS')
BEGIN
DROP TABLE DOSIS
END

CREATE TABLE DOSIS(
IDDosis int IDENTITY(1,1) constraint Pk_dosis primary key,
nombre varchar(100) not null)



IF NOT EXISTS ( select * from sys.key_constraints where name='FK_TIPO_INMUNIZACION')
begin
ALTER TABLE DETALLE_INMUNIZACIONES ADD CONSTRAINT FK_TIPO_INMUNIZACION FOREIGN KEY (tipo_inmunizacion) references TIPO_INMUNIZACION(IDT_Inmunizacion)
end
IF NOT EXISTS ( select * from sys.key_constraints where name='FK_DOSIS_INMUNIZACIONES')
begin
ALTER TABLE DETALLE_INMUNIZACIONES ADD CONSTRAINT FK_DOSIS_INMUNIZACIONES FOREIGN KEY (dosis) references DOSIS(IDDosis)
end
IF NOT EXISTS ( select * from sys.key_constraints where name='FK_inmunizacion_niño')
begin
ALTER TABLE DETALLE_INMUNIZACIONES ADD CONSTRAINT FK_inmunizacion_niño FOREIGN KEY (idniño) references niño(IDniño)
end



/* REGISTRO DE ASISTENCIA*/


if exists (select * from sys.tables where name='TUTOR')
BEGIN
DROP TABLE TUTOR
END

CREATE TABLE TUTOR(
IDTutor int IDENTITY(1,1) constraint Pk_tutor primary key,
nombres varchar(100) not null,
apellidos varchar(100) not null,
telefono char(9) ,
grado_instruccion int not null,
fecha_inicio_voluntariado date not null,
estado int not null)


if exists (select * from sys.tables where name='ESTADO')
BEGIN
DROP TABLE ESTADO
END

CREATE TABLE ESTADO(
IDEstado int IDENTITY(1,1) constraint Pk_estado primary key,
detalle varchar(50))

if exists (select * from sys.tables where name='GRADO_INSTRUCCION')
BEGIN
DROP TABLE GRADO_INSTRUCCION
END

CREATE TABLE GRADO_INSTRUCCION(
IDgrado int IDENTITY(1,1) constraint Pk_grado_ins primary key,
nombres varchar(50))



if exists (select * from sys.tables where name='GRUPO_CLASE')
BEGIN
DROP TABLE GRUPO_CLASE
END

CREATE TABLE GRUPO_CLASE(
IDgrupo int IDENTITY(1,1) constraint Pk_grupo primary key,
descripcion varchar(100) not null,
AÑO int not null,
PERIODO int not null,
TUTOR INT not null
)

if exists (select * from sys.tables where name='PERIODO')
BEGIN
DROP TABLE PERIODO
END

CREATE TABLE PERIODO(
IDPERIODO int IDENTITY(1,1) constraint Pk_periodo primary key,
NOMBRE VARCHAR(50))

if exists (select * from sys.tables where name='DIAS')
BEGIN
DROP TABLE DIAS
END

CREATE TABLE DIAS(
IDDIAS int IDENTITY(1,1) constraint Pk_dias primary key,
nombre VARCHAR(50))

if exists (select * from sys.tables where name='DETALLE_HORARIO')
BEGIN
DROP TABLE DETALLE_HORARIO
END

CREATE TABLE DETALLE_HORARIO(
IDDetHorario int IDENTITY(1,1) constraint Pk_det_horario primary key,
IDgrupo int not null,
dias int not null)

if exists (select * from sys.tables where name='ASISTENCIA')
BEGIN
DROP TABLE ASISTENCIA
END

CREATE TABLE ASISTENCIA(
IDasistencia int IDENTITY(1,1) constraint Pk_asistencia primary key,
idniño char(4) not null,
fecha date not null,
asistencia bit not null)

IF NOT EXISTS ( select * from sys.key_constraints where name='FK_TUTOR_ESTADO')
begin
ALTER TABLE TUTOR ADD CONSTRAINT FK_TUTOR_ESTADO FOREIGN KEY (estado) references estado(IDestado)
end
IF NOT EXISTS ( select * from sys.key_constraints where name='FK_TUTOR_grado')
begin
ALTER TABLE TUTOR ADD CONSTRAINT FK_TUTOR_grado FOREIGN KEY (grado_instruccion) references GRADO_INSTRUCCION(IDgrado)
end
IF NOT EXISTS ( select * from sys.key_constraints where name='FK_ASISTENCIA_NIÑO')
begin
ALTER TABLE ASISTENCIA ADD CONSTRAINT FK_ASISTENCIA_NIÑO FOREIGN KEY (idniño) references niño(IDniño)
end
IF NOT EXISTS ( select * from sys.key_constraints where name='FK_det_horario')
begin
ALTER TABLE DETALLE_HORARIO ADD CONSTRAINT FK_det_horario FOREIGN KEY (IDgrupo) references GRUPO_CLASE(IDgrupo)
end

IF NOT EXISTS ( select * from sys.key_constraints where name='FK_dGRUPO_CLASE_P')
begin
ALTER TABLE GRUPO_CLASE ADD CONSTRAINT FK_dGRUPO_CLASE_P FOREIGN KEY (PERIODO) references PERIODO(IDPERIODO)
end

IF NOT EXISTS ( select * from sys.key_constraints where name='FK_dGRUPO_CLASE_T')
begin
ALTER TABLE GRUPO_CLASE ADD CONSTRAINT FK_dGRUPO_CLASE_T FOREIGN KEY (TUTOR) references TUTOR(IDTUTOR)
end


IF NOT EXISTS ( select * from sys.key_constraints where name='FK_DET_HORARIO_D')
begin
ALTER TABLE DETALLE_HORARIO ADD CONSTRAINT FK_DET_HORARIO_D FOREIGN KEY (DIAS) references DIAS(IDDIAS)
end
IF NOT EXISTS ( select * from sys.key_constraints where name='FK_NIÑO_GRUPO')
begin
ALTER TABLE NIÑO ADD CONSTRAINT FK_NIÑO_GRUPO FOREIGN KEY (Grupo_clase) references GRUPO_CLASE(IDgrupo)
end



/* INSERTAR REGISTROS*/
select * from Rol

INSERT INTO ROL VALUES('MADRE')
INSERT INTO ROL VALUES('PADRE')
INSERT INTO ROL VALUES('HERMANA')
INSERT INTO ROL VALUES('HERMANO')
INSERT INTO ROL VALUES('TIO')
INSERT INTO ROL VALUES('TIA')
INSERT INTO NIVEL VALUES('JARDIN','3-5 AÑOS')
INSERT INTO NIVEL VALUES('NIVEL I','6-8 AÑOS')
INSERT INTO NIVEL VALUES('NIVEL II','9-11 AÑOS')
INSERT INTO NIVEL VALUES('NIVEL IIIA','12-14 AÑOS')
INSERT INTO NIVEL VALUES('NIVEL IIIB','15-17 AÑOS')
INSERT INTO NIVEL VALUES('NIVEL IV','18-21 AÑOS')
INSERT INTO Hogar VALUES('CALDERON PALOMINO')
INSERT INTO Hogar VALUES('JUAREZ ESPEJO')
INSERT INTO Hogar VALUES('HUAYANCA BERMUDEZ')
INSERT INTO Hogar VALUES('MANTARI LAURA')
INSERT INTO Hogar VALUES('CALCINA HUAYANCA')
INSERT INTO Hogar VALUES('SEVERINO MANRIQUE')
INSERT INTO Hogar VALUES('ANDIA VIZARRETA')
INSERT INTO Hogar VALUES('ALEJO LOPEZ')
INSERT INTO Hogar VALUES('QUINCHO EVANAN')
INSERT INTO Hogar VALUES('HUISA ATAUJE')
INSERT INTO Hogar VALUES('HUAPAYA ATAUJE')
INSERT INTO miembros_hogar VALUES(1,'MARIA',1,1)
INSERT INTO miembros_hogar VALUES(1,'JUAN',2,0)
INSERT INTO miembros_hogar VALUES(2,'CARMELA',1,1)
INSERT INTO miembros_hogar VALUES(2,'DANIEL',2,0)
INSERT INTO miembros_hogar VALUES(3,'FRANCISCA',1,1)
INSERT INTO miembros_hogar VALUES(3,'PEDRO',2,0)	
INSERT INTO miembros_hogar VALUES(11,'CARMEN',1,1)
INSERT INTO miembros_hogar VALUES(11,'JAVIER',2,0)



insert into DIAS values('lunes')
insert into DIAS values('Martes')
insert into DIAS values('Miercoles')
insert into DIAS values('Jueves')
insert into DIAS values('Viernes')
insert into DIAS values('Sabado')

INSERT INTO GRADO_INSTRUCCION VALUES('1ero. Secundaria')
INSERT INTO ESTADO VALUES('Activo')
INSERT INTO ESTADO VALUES('Pasivo')
INSERT INTO TUTOR VALUES('Nellie Catalina','Almora Castro','123456789',1,'2016-06-06',1)
INSERT INTO PERIODO VALUES('I')
INSERT INTO PERIODO VALUES('II')
INSERT INTO GRUPO_CLASE VALUES('NIÑOS TONTOS',2016,1,1)
select * from Genero 

insert into  DETALLE_HORARIO values(1,1)
insert into  DETALLE_HORARIO values(1,2) 

Insert into Genero values ('M')
Insert into Genero values ('F')

INSERT INTO Niño VALUES('0001','YERALDINE',1,2,'71534328','01-01-1997',3,'CARLOS RAMOS H-9',1)
INSERT INTO Niño VALUES('0002','CIELO',1,2,'71534328','02-01-1998',3,'CARLOS RAMOS H-9',1)
INSERT INTO Niño VALUES('0003','XIOMARA',1,2,'71534328','03-01-1998',3,'CARLOS RAMOS H-9',1)
INSERT INTO Niño VALUES('0004','JOSUE',1,1,'71534328','03-01-1998',3,'CARLOS RAMOS H-9',1)

insert into ASISTENCIA VALUES('0001','2016-06-06',1)

