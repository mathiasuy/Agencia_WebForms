
use master;
 
go
 
if exists (select * from SysDataBases where Name = 'Periodico')
begin
    drop database Periodico;
end
 
go
 
create database Periodico
 
go
 
use Periodico;
 
go
 create Table Edicion(
    NumeroEdicion int primary key,
    FechaPublicacion date NOT NULL
    );
go
    
create table Fuentes( 
    IdF int primary key,
    nombre varchar(20)NOT NULL
    );  
    
go

create table Articulos(
    IdArticulo int primary key IDENTITY,
    Seccion varchar(20) NOT NULL,
    Imagen bit,
    Costo money NOT NULL,
    Contenido varchar(MAX)NOT NULL,
    IdF int,     
    foreign key (IdF) references Fuentes(IdF));
 
go

create table Agencias(
    PaisOrigen varchar(20)NOT NULL,
    IdF int primary key,
    foreign key (IdF) references Fuentes(IdF));
 
go
    
create table Periodistas(
    DocumentoIdentidad VARCHAR(30) Unique,
    Direccion varchar(100) NOT NULL,
    Telefono VARCHAR (20) NOT NULL,
    IdF int primary key,
    foreign key (IdF) references Fuentes (IdF));
   
go    

create table Tiene (
	NumeroEdicion int,
	IdArticulo int,
	foreign key (NumeroEdicion) references Edicion(NumeroEdicion),
	foreign key (IdArticulo) references Articulos(IdArticulo)
	);


-------------------------------------------------------------------------------------
                                     --EDICION--
-------------------------------------------------------------------------------------

INSERT INTO Edicion
VALUES (10,'12/10/1998');

INSERT INTO Edicion
VALUES (20,'10/10/2000');

INSERT INTO Edicion
VALUES (30,'02/05/2005');

INSERT INTO Edicion
VALUES (40,'06/06/2012');

INSERT INTO Edicion
VALUES (50,'11/01/2013');

INSERT INTO Edicion
VALUES (1,'14/02/2013');

INSERT INTO Edicion
VALUES (2,'22/09/2011');

-------------------------------------------------------------------------------------
                                     --FUENTES--
-------------------------------------------------------------------------------------

INSERT INTO Fuentes
values (1,'La Rep�blica')

INSERT INTO Fuentes
values (2,'180.com.uy')

INSERT INTO Fuentes
values (3,'Periodista Juan')

INSERT INTO Fuentes
values (4, 'Brecha')

INSERT INTO Fuentes
values (5,'Clarin')

INSERT INTO Fuentes
VALUES (8,'El Pais')

INSERT INTO Fuentes
VALUES (7,'Rodrigo Arocena')

INSERT INTO Fuentes
VALUES (9,'Observador')


INSERT INTO Fuentes
VALUES (55,'LA INFORMATIVA')

INSERT INTO Fuentes
VALUES (56,'AGENCIA NOTICIAS')


INSERT INTO Fuentes
VALUES (14,'Martin Cardozo')


INSERT INTO Fuentes
VALUES (13,'Pedro Picapiedra')


INSERT INTO Fuentes
VALUES (17,'Diego Armando')


INSERT INTO Fuentes
VALUES (11,'Roberto Moar')


INSERT INTO Fuentes
VALUES (12,'Jose Gervasio')



-------------------------------------------------------------------------------------
                                     --ARTICULOS--
-------------------------------------------------------------------------------------


INSERT INTO Articulos
VALUES ('DEPORTES',0,45,'URUGUAY CAMPEON DEL MUNDO EN BRASIL',8)

INSERT INTO Articulos
VALUES ('Nuevo',0,450,'URUGUAY',8)

INSERT INTO Articulos
VALUES ('MODA',1,20,'DOLCE & GABBANA EN URUGUAY',9)

INSERT INTO Articulos
VALUES ('BELLEZA',1,100,'TENER UN CUERPO 10',9)

INSERT INTO Articulos
VALUES ('ESPECTACULOS',1,60,'JORGE RIAL DE VACACIONES EN ATLANTIDA',14)

INSERT INTO Articulos
VALUES ('DEPORTES',1,12,'MESSI LLEGO A 100 GOLES EN UNA TEMPORADA',13)

INSERT INTO Articulos
VALUES ('DEPORTES',1,55,'CRISTIANO RONALDO ES UNA BARBIE',8)

INSERT INTO Articulos
VALUES ('DEPORTES',1,55,'CRISTIANO RONALDO ES UNA BARBIE',9)

INSERT INTO Articulos
values ('Tambi�n interesa',1,13564,'
Correa, un soldado integrante de la Fuerza A�rea Uruguaya (FAU), es uno de los 12 socorristas que forman la �Secci�n de operaciones y entrenamiento de rescate�, perteneciente al Escuadr�n A�reo N� 5 (Helic�pteros), creado en 2000.

�Pero la recompensa est� cuando salv�s a una persona y sent�s ese orgullo adentro tuyo y luego volv�s a tu casa con tu familia. No necesito nada m�s a cambio, ni ese �Gracias, me sacaste��, asegura durante el simulacro realizado en aguas del R�o de la Plata.

Pese a la limitada infraestructura de la FAU, una docena de rescatistas apasionados por su profesi�n lucha a diario para mejorar su desempe�o y celebra una invitaci�n para participar en ejercicios de entrenamiento en Estados Unidos.

�No somos guapos lo que pasa es que nos gusta mucho lo que hacemos�, dice el cabo de segunda Richard V�zquez, integrante del equipo de rescatistas desde hace cinco a�os, mientras maneja una peque�a embarcaci�n.

Seis de sus integrantes son especialistas en �PARASAR�, la utilizaci�n de paraca�das en rescates. Dos integrantes del equipo integran actualmente el contingente uruguayo en la Misi�n de las Naciones Unidas para la Estabilizaci�n de la Rep�blica Democr�tica del Congo (MONUSCO).

La participaci�n en misiones de paz y el nivel demostrado por el grupo de rescatistas -en entrenamientos de b�squeda y rescate junto a la Fuerza A�rea estadounidense- llev� a que fueran invitados el pr�ximo abril al ejercicio de entrenamiento �Angel Thunder� en Estados Unidos, donde trabajar�n con fuerzas de Canad�, Colombia, Chile, Brasil, entre otros pa�ses.

�Hemos entrenado en forma conjunta con estadounidenses y m�s all� de que ellos tienen mejores helic�pteros y mejores equipos, las capacidades que tenemos son similares y la t�cnica tambi�n. Cuando vienen se van sorprendidos porque no imaginaban en Uruguay la existencia de un equipo como el nuestro�, comenta el teniente Fabricio Ruiz, segundo en el escalaf�n de mandos del grupo.

La brecha en equipamiento qued� reflejada en uno de los rescates m�s recordados por Ruiz, cuando a�os atr�s socorri� a un beb� de seis meses -aislado por una inundaci�n junto a sus padres en una vivienda del sureste del pa�s- y fue necesario modificar en el momento un arn�s para sacar al ni�o, ante la falta de uno espec�fico para una persona tan peque�a.

Se�al del trabajo artesanal al que en ocasiones apelan los rescatistas es la antigua m�quina de coser siempre presente en la �oficina� del grupo, en la que muchos de ellos demuestran sus aptitudes para la costura cuando alg�n objeto de trabajo debe ser modificado o arreglado.

Correa hace su tarea �sin analizar demasiado�.

�Ante una emergencia uno va y hace lo que tiene que hacer, en ese momento no pens�s en el peligro que corr�s. Si hay alguna carencia t�cnica se disimula con el compa�erismo entre nosotros, con apoyarnos siempre�, asegura. �Igual creo que para los tipos de rescates que tenemos en Uruguay tenemos lo necesario, estamos bien�.

Lejos de los grandes titulares, estos profesionales -que el a�o pasado realizaron unos 15 rescates, sin contar b�squedas y colaboraciones con otras fuerzas- hacen malabares para cumplir los entrenamientos diarios y estar a la orden ante emergencias, mientras realizan otro tipo de tareas para mejorar sus ingresos.

Hacer arreglos de electricidad o vender en puestos de feria son algunas de las actividades que estos socorristas emprenden cuando la emergencia pasa y las necesidades monetarias son las protagonistas.
',1);

INSERT INTO Articulos
values ('Medios',1,13564,'
TV: canales de Montevideo concentran 95,5% del mercado

Los propietarios de los tres canales privados de Montevideo controlan el 95,5% del mercado de la televisi�n abierta nacional y en 2010 facturaron 82,5 millones de d�lares. Si se suma el cable, recibieron 170 de los 276 millones de d�lares del mercado total de la televisi�n. Los datos surgen del estudio �La televisi�n privada comercial en Uruguay�, de Edison Lanza y Gustavo Buquet.

El informe se�ala que los canales privados de Montevideo concentran el 88,1% del mercado de la televisi�n abierta nacional. Sin embargo, �a trav�s de la Red Uruguaya de Televisi�n S. A. (RUTSA) y de otros canales del interior de su propiedad� las familias propietarias del 4, el 10 y el 12 �controlan el restante 7,4% de la audiencia y la facturaci�n�.

Esas tres empresas �concentran el 61% de la facturaci�n total de las m�s de 100 empresas de televisi�n del Uruguay�, agrega el estudio.

La televisi�n es el medio masivo por excelencia ya que pr�cticamente el 100% de los uruguayos la consume televisi�n habitualmente. Mientras, el 95% consume radio, el 61% internet y el 37% lee publicaciones peri�dicas. Los uruguayos, en promedio, destinan poco menos de dos horas por d�a a ver televisi�n.

En ese marco, �los tres grandes grupos empresariales de la televisi�n privada comercial nacional (conocidos por sus se�ales abiertas: 4, 10 y 12) han logrado conformar una red nacional de emisoras de televisi�n abierta y por cable que controlan en forma directa o indirecta, ya sea mediante la titularidad de las frecuencias u otras modalidades contractuales. Esto les ha permitido reproducir los contenidos que producen o adquieren centralmente en Montevideo en todo el territorio nacional y consecuentemente acaparar las audiencias en todos los formatos y en todas las zonas geogr�ficas�.

Esos grupos son Romay (Canal 4), De Feo-Fontaina (Canal 10) y Cardoso-Scheck (Canal 12). En este �ltimo caso, �la familia Scheck �que originalmente era la titular de la frecuencia� hoy es una accionista minoritaria sin poder alguno de decisi�n�.

A partir de la titularidad en las se�ales de aire en Montevideo, el informe describe c�mo se han ido expandiendo los grupos empresariales. Primero sumaron se�ales de la televisi�n abierta del interior (especialmente en los mercados m�s interesantes: Colonia, Maldonado y Rocha). Luego, en los a�os 90, obtuvieron las licencias de tv cable en la capital: Montecable, TCC y Nuevo Siglo, adem�s de Multise�al que emite en UHF.

En cambio sostienen que �la propiedad cruzada de medios audiovisuales con medios escritos se ha reducido en la �ltima d�cada. La antigua concertaci�n empresarial entre Canal 12 y El Pa�s se escindi� luego de que el grupo Cardoso-Pombo (accionistas de Disco-G�ant y Devoto) adquiriera la mayor�a accionaria de Teledoce a la familia Scheck. Los Cardoso-Pombo no tienen participaci�n en El Pa�s, aunque son los propietarios del semanario B�squeda (Editorial Agora S. A.), cuya propiedad ten�an antes de asumir el control de ese medio televisivo�.

�Para completar este cuadro, al menos dos de los grupos (Romay-Salvo y De Feo-Fontaina) tambi�n son titulares de varias frecuencias de radio, tanto en AM como en FM, con un importante alcance en buena parte del territorio nacional�, agregan los autores.

Los autores se�alan que desde la popularizaci�n de la televisi�n en la d�cada de los 50, estos tres grupos han construido un oligopolio, incluso asoci�ndose en empresas para comercializar determinados productos. Sin embargo, esa convivencia muestra se�ales de ruptura con la llegada de la televisi�n digital.

�Canal 10 est� construyendo una alianza con Antel, la empresa p�blica de telecomunicaciones, para la prestaci�n de servicios de datos, telefon�a y televisi�n, al tiempo que intenta convertirse en un productor de contenidos de escala regional. Mientras, los otros dos grandes solicitaron a la Unidad Reguladora de

Servicios de Comunicaci�n (Ursec) prestar el servicio de datos a trav�s de sus redes de cable y profundizan la alianza con productores de contenidos del exterior�, afirman.

As�, se teji� una red de medios de comunicaci�n controlados por estas familias en todo el pa�s, �con la consiguiente dificultad para acceder al mercado para cualquier iniciativa al margen de ellos�, afirman.

Respecto a la distribuci�n de la facturaci�n por publicidad en la televisi�n abierta, por un total de 82,5 millones de d�lares, el estudio asigna a grupo Cardoso � Pombo el 36%, al grupo Fontaina � De Feo el 26% y al grupo Romay � Salvo otro 26%. La Red Uruguaya de Televisi�n �de propiedad compartida entre los tres- tiene un 7% y Televisi�n Nacional junto a otros medios del interior reciben el 5% restante.

El informe se�ala como �nica amenaza a esta concentraci�n de medios en Uruguay la llegada del Grupo Clar�n, a trav�s de Cablevisi�n. Esta empresa, con una estrategia agresiva, ha captado m�s de 100.000 abonados. �Es el �nico grupo de medios que, hasta la fecha, amenaza la hegemon�a comunicacional de los canales privados nacionales�, dicen.

Para los autores del trabajo la realidad descripta deber�a llevar a cambios en la legislaci�n nacional de modo de promover la competencia y la diversidad en los servicios de comunicaci�n. Lanza y Buquet reclaman �un nuevo marco de competencia en los sectores de servicios de comunicaci�n audiovisual utilizando la inmejorable situaci�n que generan la tecnolog�a de televisi�n digital terrestre y la inversi�n que Antel ha desarrollado en fibra �ptica�.

En definitiva, afirman, �el advenimiento de la televisi�n digital se presenta como una gran oportunidad para mejorar los est�ndares de diversidad, pluralidad y competencia en el mercado televisivo uruguayo. Para ello, en el mercado de la televisi�n abierta se deber�a estimular el ingreso de nuevos operadores comerciales, fortalecer el sector p�blico de televisi�n y apoyar el ingreso de operadores sin fines de lucro como podr�a ser la Universidad de la Rep�blica�.'
,2)

INSERT INTO Articulos
values ('Politica',1,12345,'
Mujica enviar� una carta a los miembros del Mercosur para un �sinceramiento� y definir el �rumbo�

El presidente Jos� Mujica prepara una carta, en la cual solicita un �sinceramiento� de los pa�ses miembros y definir el �rumbo� del bloque, ya que, seg�n el mandatario, �en estas condiciones es inviable.� La misiva ser� enviada en estos d�as tanto a Brasil, como Argentina y Venezuela.
Enviar
Imprimir
A favoritos
Seg�n publica el semanario B�squeda, la propuesta del mandatario busca una instancia �para tomar decisiones�, principalmente con respecto al futuro del Mercosur.


UNoticias
',3)

INSERT INTO Articulos
values ('Economia',1,12345,'
Diario Clarin

Las Bolsas europeas abrieron en alza

Las principales Bolsas de Europa abrieron en alza, en anticipo de la cumbre europea y la publicaci�n de nuevas estad�sticas norteamericanas.

En Londres, el �ndice FTSE-100 de los valores principales gan� 0,05% mientras que en Paris el el CAC 40 gan� 0,44%. En Fr�ncfort, el DAX subi� 0,53% y en Madrid, el Ibex 0.80%.

AFP

El Pa�s Digital
',5)

INSERT INTO Articulos
values ('Educaci�n',0,19345,'
Doble jornada en el Parlamento por el Congreso Nacional de Educaci�n

Escribe el rector Dr. Rodrigo Arocena. 

Este mi�rcoles 13, en la ma�ana con la Comisi�n de Educaci�n y Cultura de la C�mara de Representantes y en la tarde con la correspondiente Comisi�n del Senado, una delegaci�n conjunta del MEC, la ANEP y la UDELAR estuvo impulsando la realizaci�n del Congreso Nacional de Educaci�n.

Desde hace largo tiempo, la UDELAR viene adoptando decisiones y promoviendo acciones para que el Congreso se concrete y sea valioso para la educaci�n nacional. Al respecto, el Consejo Directivo Central de la UDELAR adopt� el 19 de febrero una resoluci�n que incluye entre otros los siguientes puntos: 

1. El Congreso debiera ser un lugar de encuentro y de intercambio de ideas entre todos los actores que de una manera u otra tienen que poder opinar sobre la educaci�n, incluyendo a varios que no han sido tenidos en cuenta en la definici�n reciente de marcos legales. 

2. El Congreso debiera ser un �mbito donde se preste atenci�n prioritaria a los problemas mayores de la educaci�n nacional. 

3. El Congreso debiera orientar su trabajo de modo de poder plasmarlo en propuestas relativas a los problemas mencionados. 

Debemos incorporar a todos los actores mencionados en el numeral 1 a un intercambio de ideas sereno y fecundo, basado en hechos objetivables y orientado a formular propuestas viables. Ello es fundamental para llegar a construir una pol�tica de naci�n para la educaci�n, s�lida, de largo plazo y con amplio respaldo. Este fue uno de los planteos fundamentales que hicimos en las Comisiones de Educaci�n y Cultura de ambas C�maras, apuntando a que los sectores pol�ticos participen en las labores preparatorias del Congreso y en su realizaci�n, junto a representantes de las instituciones educativas (p�blicas y privadas), sindicatos de la ense�anza, gremios estudiantiles, asambleas t�cnico-docentes, central obrera, sectores productivos y del congreso de intendentes. Buscando esa amplia participaci�n, de acuerdo a instrucciones expl�citas del Consejo Directivo Central de la UDELAR, ha venido desempe��ndose el muy activo Grupo de Trabajo para el Congreso de nuestra instituci�n. En ambas Comisiones del Parlamento encontramos receptividad para el planteo de que el sector pol�tico se incorpore efectivamente al trabajo enmarcado en el Congreso. 

En las dos reuniones mencionadas se habl� del temario del Congreso, apuntando a que, como lo pide el numeral 2 de la resoluci�n de la UDELAR, �se preste atenci�n prioritaria a los problemas mayores de la educaci�n nacional�. Se destac� que la formulaci�n definitiva de la agenda debe ser definida por una Comisi�n Organizadora que incluya representantes de todos los sectores antes mencionados. La UDELAR ha venido contribuyendo, en el trabajo con ANEP y MEC, a una propuesta primaria conjunta que incluye los siguientes temas: 

1. Universalizaci�n de la Educaci�n Media; 

2. Generalizaci�n de la Educaci�n Terciaria y Universitaria; 

3. Educaci�n y Territorio; 

4. Cultura, Educaci�n T�cnica y Tecnol�gica. 

Adem�s, la UDELAR ha sugerido agregar otros dos temas: 

5. Desafiliaci�n temprana, Rezago, Titulaci�n; 

6. Formaci�n de docentes en todo el pa�s. 

Para que el Congreso pueda plasmar su labor en propuestas afinadas y viables, como lo plantea el numeral 3 de la resoluci�n de la UDELAR, todos los involucrados deben tener en cuenta los hechos de la educaci�n y contribuir a difundirlos de manera precisa. Con ese prop�sito, la delegaci�n de la UDELAR entreg� a las Comisiones de Educaci�n y Cultura de ambas C�maras un informe sint�tico general sobre lo realizado en 2012 y una puesta al d�a espec�fica sobre el cumplimiento del Plan de Obras a Mediano y Largo Plazo. 

Se trabaja para que 2013 sea un a�o fecundo para la educaci�n nacional. Ojal� incluya la creaci�n del Instituto Universitario de Educaci�n as� como la m�s estrecha colaboraci�n entre viejas y nuevas instituciones p�blicas de ense�anza terciaria y universitaria. 

Blog �Hacia la Reforma Universitaria�
Publicado el jueves 14 de marzo de 2013
',7)



-------------------------------------------------------------------------------------
                                     --AGENCIAS--
-------------------------------------------------------------------------------------

INSERT INTO Agencias
values ('Uruguay',1)

INSERT INTO Agencias
values ('Uruguay',2)

INSERT INTO Agencias
values ('Uruguay',4)

INSERT INTO Agencias
values ('Argentina',5)

INSERT INTO Agencias
VALUES ('URUGUAY',8)

INSERT INTO Agencias
VALUES ('ARGENTINA',9)

INSERT INTO Agencias
VALUES ('PANAMA',55)

INSERT INTO Agencias
VALUES ('CHILE',56)

-------------------------------------------------------------------------------------
                                     --PERIODISTAS--
-------------------------------------------------------------------------------------

INSERT INTO Periodistas
VALUES ('12345678','RIO NEGRO 1233','095888455',14)

INSERT INTO Periodistas
VALUES ('23456789','YAGUARON 1414','23445698',11)

INSERT INTO Periodistas
VALUES ('478119684','AV. ITALIA 1214','26485678',3)

INSERT INTO Periodistas
VALUES ('498199694','AV. BRasil 1124','29489698',7)

INSERT INTO Periodistas
VALUES ('34567891','SORIANO 2122','23556987',13)

INSERT INTO Periodistas
VALUES ('34567832','RIO BRANCO 2214','78996566',12)

INSERT INTO Periodistas
VALUES ('34578956','LA PAZ 1023','23478998',17)

-------------------------------------------------------------------------------------
                                     --TIENE--
-------------------------------------------------------------------------------------

INSERT INTO Tiene
VALUES (10,1);

INSERT INTO Tiene
VALUES (20,2);

INSERT INTO Tiene
VALUES (40,3);

INSERT INTO Tiene
VALUES (40,3);

INSERT INTO Tiene
VALUES (50,4);
 
INSERT INTO Tiene
values (50,9)
 
INSERT INTO Tiene
values(1,9)

INSERT INTO Tiene
values(1,13)


INSERT INTO Tiene
values(1,8)


INSERT INTO Tiene
values(1,12)


INSERT INTO Tiene
values(1,11)

INSERT INTO Tiene
values(1,10)

/**/
INSERT INTO Tiene
values(2,1)

INSERT INTO Tiene
values(2,2)


INSERT INTO Tiene
values(2,3)


INSERT INTO Tiene
values(2,4)

INSERT INTO Tiene
values(2,5)

INSERT INTO Tiene
values(2,6)

INSERT INTO Tiene
values(2,7)

INSERT INTO Tiene
values(2,8)

INSERT INTO Tiene
values(2,9)

INSERT INTO Tiene
values(2,10)

INSERT INTO Tiene
values(2,11)

INSERT INTO Tiene
values(2,12)

INSERT INTO Tiene
values(2,13)

go

/********************************************************************************************************/
/********************************************************************************************************/
/*************************  *  *  *  *  PROCEDIMIENTOS PARA AGENICAS  *  *  *  *************************/
/********************************************************************************************************/
/********************************************************************************************************/

-----------------------------------------------------
-----------------BuscarAgencia------------------------
-----------------------------------------------------
CREATE PROCEDURE BuscarAgencia
@id INT
AS
BEGIN
	SELECT *
	FROM Fuentes inner join Agencias 
	on Fuentes.IdF=Agencias.IdF
	where Agencias.IdF=@id;
END

GO    


-----------------------------------------------------
-----------------ModificarAgencia----------------
-----------------------------------------------------

CREATE PROCEDURE ModificarAgencia
@id INT,
@nombre VARCHAR(30),
@paisOrigen VARCHAR(20)

AS
BEGIN

		IF NOT EXISTS (SELECT * FROM Agencias WHERE IdF =@id  )
			RETURN -1;
	BEGIN TRANSACTION		
		UPDATE Fuentes
		SET Nombre = @nombre
		WHERE IdF = @id;
		
		UPDATE Agencias
		SET PaisOrigen=@paisOrigen
		WHERE IdF = @id;
		
		IF @@ERROR <> 0
		BEGIN
			ROLLBACK
			RETURN -2;
		END
	COMMIT TRANSACTION
END
GO

-----------------------------------------------------
-----------------AltaAgencia-----------------
-----------------------------------------------------
CREATE PROCEDURE AltaAgencia
@id INT,
@nombre VARCHAR(30),
@paisOrigen VARCHAR(20)

AS
BEGIN
		IF  EXISTS (SELECT * FROM Fuentes WHERE Fuentes.IdF = @id)
			RETURN -1;

	BEGIN TRANSACTION
	
		INSERT INTO Fuentes values(@id,@nombre);
		
		INSERT INTO Agencias
		VALUES (@paisOrigen,@id);
		
		IF @@ERROR <> 0
		BEGIN
			ROLLBACK TRANSACTION;
			RETURN -2;
		END;
	COMMIT TRANSACTION;
END

go


-----------------------------------------------------
-----------------BajaAgencia-------------------------
-----------------------------------------------------
CREATE PROCEDURE BajaAgencia
@id INT
AS
BEGIN
		IF NOT EXISTS (SELECT * FROM Agencias inner join Fuentes on Agencias.IdF = Fuentes.IdF WHERE Agencias.IdF = @id)
			RETURN -1;

		IF EXISTS (SELECT * FROM Agencias inner join Articulos
		on Agencias.IdF = Articulos.IdF
		WHERE Articulos.IdF = @id)
		RETURN -3;

	BEGIN TRANSACTION			
		
		DELETE Agencias
		WHERE IdF = @id;
		
		DELETE Fuentes
		WHERE IdF = @id;
		
		IF @@ERROR <> 0
		BEGIN
			ROLLBACK  TRANSACTION
			RETURN -2;
		END;
	COMMIT TRANSACTION;
END

GO

-----------------------------------------------------
-----------------ListarAgencias------------------------
-----------------------------------------------------
CREATE PROCEDURE ListarAgencias
AS
BEGIN
	SELECT *
	FROM Fuentes inner join Agencias 
	on Fuentes.IdF=Agencias.IdF
END

GO    

/********************************************************************************************************/
/********************************************************************************************************/
/***********************  *  *  *  *  PROCEDIMIENTOS PARA PERIODISTAS  *  *  *  *************************/
/********************************************************************************************************/
/********************************************************************************************************/

-----------------------------------------------------
-----------------BuscarPeriodista------------------------
-----------------------------------------------------
CREATE PROCEDURE BuscarPeriodista
@id INT
AS
BEGIN
	SELECT *
	FROM Fuentes inner join Periodistas 
	on Fuentes.IdF=Periodistas.IdF
	where Periodistas.IdF=@id;
	
	
END

GO    

-----------------------------------------------------
-----------------AltaPeriodista----------------------
-----------------------------------------------------

CREATE PROCEDURE AltaPeriodista
@documentoIdentidad VARCHAR (30),
@direccion VARCHAR(100),
@telefono VARCHAR (20),
@id INT,
@nombre VARCHAR(30)
AS

BEGIN
		IF  EXISTS (SELECT * FROM Fuentes WHERE Fuentes.IdF = @id)
			RETURN -1;

		IF EXISTS (SELECT * FROM Periodistas WHERE DocumentoIdentidad = @documentoIdentidad)
			RETURN -3;
			
	BEGIN TRANSACTION
				
		INSERT INTO Fuentes
		VALUES (@id,@nombre);	
		
		INSERT INTO Periodistas
		VALUES (@documentoIdentidad,@direccion,@telefono,@id);
		
		IF @@ERROR <> 0
		BEGIN
			ROLLBACK TRANSACTION
			RETURN -2;
		END
	COMMIT TRANSACTION
END

GO
--exec AltaPeriodista '34578956','LA PAZ 1023','23478998',17,'Diego Armando'
-----------------------------------------------------
-----------------BajaPeriodista----------------------
-----------------------------------------------------
CREATE PROCEDURE BajaPeriodista
@id INT
AS
BEGIN

	IF NOT EXISTS (SELECT * FROM Periodistas inner join Fuentes on PEriodistas.IdF = Fuentes.Idf)
		RETURN -1;
	
	IF EXISTS (SELECT * FROM Fuentes inner join Articulos on Fuentes.IdF = Articulos.Idf WHERE Articulos.IdF = @id)
		RETURN -3;
			
	BEGIN TRANSACTION
	
		DELETE Periodistas
		WHERE IdF = @id;	

		DELETE Fuentes
		WHERE IdF = @id;

		IF @@ERROR <> 0
		BEGIN 
			ROLLBACK TRANSACTION
			RETURN -2;
		END;
	COMMIT TRANSACTION
END
--exec BajaPeriodista 14
GO

-----------------------------------------------------
-----------------ModificarPeriodista-----------------
-----------------------------------------------------

CREATE PROCEDURE ModificarPeriodista
@documentoIdentidad VARCHAR (30),
@direccion VARCHAR(100),
@telefono VARCHAR (20),
@id INT,
@nombre VARCHAR(30)
AS
BEGIN

	IF NOT EXISTS (SELECT * FROM Periodistas WHERE IdF =@id  )
			RETURN -1;
		
	BEGIN TRANSACTION
	
		UPDATE Fuentes
		SET Nombre = @nombre
		WHERE IdF = @id;	
		
		UPDATE Periodistas
		SET DocumentoIdentidad=@documentoIdentidad,Direccion=@direccion,Telefono=@telefono
		WHERE IdF = @id;
		
		IF @@ERROR <> 0
		BEGIN
			ROLLBACK TRANSACTION
			RETURN -2;
		END;
	COMMIT TRANSACTION
END
GO


-----------------------------------------------------
-----------------ListarPeriodistas----------------------
-----------------------------------------------------
CREATE PROCEDURE ListarPeriodistas
AS
BEGIN 
	SELECT *
	FROM Periodistas inner join Fuentes
	on Fuentes.IdF = Periodistas.IdF;
END

GO 


/********************************************************************************************************/
/********************************************************************************************************/
/*************************  *  *  *  *  PROCEDIMIENTOS PARA EDICIONES  *  *  *  *************************/
/********************************************************************************************************/
/********************************************************************************************************/


-----------------------------------------------------
-------------------CrearEdicion----------------------
-----------------------------------------------------
CREATE PROCEDURE AltaEdicion
@numero int,
@FechaPublicacion DateTime
AS
BEGIN
	IF EXISTS (SELECT * FROM Edicion WHERE NumeroEdicion = @numero)
		RETURN -1;
			
	BEGIN TRANSACTION
		INSERT INTO Edicion values (@numero, @FechaPublicacion);
		
		IF @@ERROR <> 0
		BEGIN
			ROLLBACK
			RETURN -2;
		END
	COMMIT TRANSACTION
END
GO

--exec CrearEdicion 1, '11/11/2011'



-----------------------------------------------------
-----------------BuscarEdicion----------------------
-----------------------------------------------------
CREATE PROCEDURE BuscarEdicion
@numero int
AS
BEGIN 
	SELECT *
	FROM Edicion where Edicion.NumeroEdicion = @numero;
END

GO 



--SELECT * FROM Edicion

-----------------------------------------------------
-----------------AgregarAEdicion----------------
-----------------------------------------------------

CREATE PROCEDURE AgregarAEdicion
@numero int,
@id int
AS
BEGIN
	BEGIN TRANSACTION
	
		INSERT INTO Tiene values (@numero, @id);
		
		IF @@ERROR <> 0
		BEGIN
			ROLLBACK
			RETURN -2;
		END
	COMMIT TRANSACTION
END
GO


-----------------------------------------------------
------------------BajaEdicion--------------------
-----------------------------------------------------
CREATE PROCEDURE BajaEdicion
@numero int
AS
BEGIN

	IF NOT EXISTS (SELECT * FROM Edicion WHERE NumeroEdicion = @numero)
		RETURN -1;
		
	BEGIN TRANSACTION		
		DELETE Tiene WHERE Tiene.NumeroEdicion = @numero;
		DELETE Edicion WHERE NumeroEdicion = @numero;
		
		IF @@ERROR <> 0
		BEGIN
			ROLLBACK
			RETURN -2;
		END
	COMMIT TRANSACTION
END
GO


-----------------------------------------------------
-----------------ListarEdiciones----------------------
-----------------------------------------------------
CREATE PROCEDURE ListarEdiciones
AS
BEGIN 
	SELECT *
	FROM Edicion;
END

GO 


-----------------------------------------------------
-----------------ListarArticulosXEdicion-------------
-----------------------------------------------------



CREATE PROCEDURE ListarArticulosXEdicion
@numero int
AS
BEGIN
	SELECT Articulos.*
	FROM Articulos INNER JOIN Tiene
		ON Articulos.IdArticulo = Tiene.IdArticulo
	WHERE Tiene.NumeroEdicion = @numero;
END

GO
--exec ListarArticulosXEdicion 20

-----------------------------------------------------
-----------------ListarPeriodistasXEdicion-------------
-----------------------------------------------------



CREATE PROCEDURE ListarPeriodistasXEdicion
@numero int
AS
BEGIN
	SELECT * 
	FROM Fuentes INNER JOIN Periodistas
		on Periodistas.IdF = Fuentes.IdF
		INNER JOIN  Articulos
		ON Articulos.IdF = Periodistas.IdF
		INNER JOIN Tiene
		ON Tiene.IdArticulo = Articulos.IdArticulo
		WHERE Tiene.NumeroEdicion = @numero;
END

GO

-----------------------------------------------------
-----------------ListarAgenciasXEdicion-------------
-----------------------------------------------------



CREATE PROCEDURE ListarAgenciasXEdicion
@numero int
AS
BEGIN
	SELECT * 
	FROM Fuentes INNER JOIN Agencias
		on Agencias.IdF = Fuentes.IdF
		INNER JOIN  Articulos
		ON Articulos.IdF = Agencias.IdF
		INNER JOIN Tiene
		ON Tiene.IdArticulo = Articulos.IdArticulo
		WHERE Tiene.NumeroEdicion = @numero;
END

GO
/********************************************************************************************************/
/********************************************************************************************************/
/*************************  *  *  *  *  PROCEDIMIENTOS PARA ARTICULOS  *  *  *  *************************/
/********************************************************************************************************/
/********************************************************************************************************/

-----------------------------------------------------
-----------------BuscarArticulo----------------------
-----------------------------------------------------
CREATE PROCEDURE BuscarArticulo
@id INT
AS
BEGIN 
     SELECT *
     FROM Articulos
     WHERE IdArticulo=@id;
END

GO 

-----------------------------------------------------
-----------------AltaArticulo----------------
-----------------------------------------------------
CREATE PROCEDURE AltaArticulo
@Id int OUTPUT,
@Seccion varchar(20),
@Imagen bit,
@Costo money,
@Contenido varchar(MAX),
@Fuente int
AS
BEGIN
	IF EXISTS (SELECT * FROM Articulos WHERE IdArticulo =@id  )
		RETURN -1;
	
	
	BEGIN TRANSACTION	
		INSERT INTO Articulos values (@Seccion,@Imagen,@Costo,@Contenido ,@Fuente);
		set @Id = @@IDENTITY
		IF @@ERROR <> 0
		BEGIN
			RETURN -2;
			ROLLBACK TRANSACTION;
		END
	COMMIT TRANSACTION
END

go

-----------------------------------------------------
-----------------ModificarArticulo----------------
-----------------------------------------------------
CREATE PROCEDURE ModificarArticulo
@Id int,
@Seccion varchar(20),
@Imagen bit,
@Costo money,
@Contenido varchar(MAX),
@Fuente int
AS
BEGIN
	IF NOT EXISTS (SELECT * FROM Articulos WHERE IdArticulo =@id  )
		RETURN -1;
		
	BEGIN TRANSACTION	
		UPDATE Articulos
		SET 
		Seccion = @Seccion,
		Imagen =@Imagen,Costo = @Costo,
		Contenido = @Contenido ,IdF = @Fuente
		WHERE IdArticulo = @id;
		
		IF @@ERROR <> 0
		BEGIN
			RETURN -2;
			ROLLBACK TRANSACTION;
		END
	COMMIT TRANSACTION
END

go

-----------------------------------------------------
-----------------BajaArticulo----------------
-----------------------------------------------------
CREATE PROCEDURE BajaArticulo
@Id int
AS
BEGIN
	IF NOT EXISTS (SELECT * FROM Articulos WHERE IdArticulo =@id  )
		RETURN -1;
	IF EXISTS (SELECT * FROM Articulos inner join Tiene
	on Articulos.IdArticulo = Tiene.IdArticulo WHERE Articulos.IdArticulo = @Id)
		RETURN -3
	BEGIN TRANSACTION	
		DELETE Articulos WHERE IdArticulo = @Id;
		IF @@ERROR <> 0
		BEGIN
			RETURN -2;
			ROLLBACK TRANSACTION;
		END
	COMMIT TRANSACTION
END

go

-----------------------------------------------------
-----------------ListarArticulos----------------------
-----------------------------------------------------
CREATE PROCEDURE ListarArticulos
AS
BEGIN 
	SELECT *
	FROM Articulos
END

GO 


-----------------------------------------------------
-----------------ListarArticulosXFuente--------------
-----------------------------------------------------
CREATE PROCEDURE ListarArticulosXFuente
@IdF int
AS
BEGIN 
	SELECT *
	FROM Articulos inner join Fuentes
	on Articulos.IdF = Fuentes.IdF
	WHERE Articulos.IdF = @IdF
END

GO 

