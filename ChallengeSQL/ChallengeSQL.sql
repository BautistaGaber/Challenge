select * from Encuestas;


INSERT INTO Encuestas(NumeroUsuario, FechaNacimiento, Sexo, Periodo, CantidadPeliculas)
VALUES (1, '2001-11-09', 'M', 022023, 5);

INSERT INTO Encuestas(NumeroUsuario, FechaNacimiento, Sexo, Periodo, CantidadPeliculas)
VALUES (2, '2003-10-12', 'F', 012023, 7); 

INSERT INTO Encuestas(NumeroUsuario, FechaNacimiento, Sexo, Periodo, CantidadPeliculas)
VALUES (3, '2005-07-02', 'M', 032022, 3);

INSERT INTO Encuestas(NumeroUsuario, FechaNacimiento, Sexo, Periodo, CantidadPeliculas)
VALUES (4, '2001-11-17', 'M', 032021, 8); 

INSERT INTO Encuestas(NumeroUsuario, FechaNacimiento, Sexo, Periodo, CantidadPeliculas)
VALUES (5, '2004-04-05', 'F', 112022, 9);

INSERT INTO Encuestas(NumeroUsuario, FechaNacimiento, Sexo, Periodo, CantidadPeliculas)
VALUES (6, '2000-05-15', 'M', 112022, 12);


--Query para calcular promedio de peliculas vistas, utilizamos AVG para calcular el promedio--

select AVG(CantidadPeliculas) as promedio from Encuestas;

--Query para calcular promedio de peliculas vistas por periodo--

select periodo, AVG(CantidadPeliculas) as promedio from Encuestas group by Periodo;

--Query para calcular promedio de peliculas vistas por edad--

select	DATEDIFF(YEAR, FechaNacimiento, GETDATE()) as edad, 
		AVG (CantidadPeliculas) as promedio
from Encuestas 
group by DATEDIFF(YEAR, FechaNacimiento, GETDATE());

--Query para calcular promedio de peliculas vistas por sexo--

select Sexo, AVG(CantidadPeliculas) as promedio from Encuestas group by sexo;

--Query para calcular promedio de peliculas vistas por periodo y por sexo--

select periodo, sexo, AVG(CantidadPeliculas) as promedio from Encuestas group by Periodo, Sexo
order by periodo;
