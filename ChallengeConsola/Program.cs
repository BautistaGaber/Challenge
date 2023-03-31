using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeSGB1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pathEncuesta = ConfigurationManager.AppSettings["pathEncuesta"];
            Dictionary<int, Encuesta> encuesta = new Dictionary<int, Encuesta>();
            Dictionary<DateTime, int> periodos = new Dictionary<DateTime, int>();
            Dictionary<int, int> edades = new Dictionary<int, int>();
            Dictionary<string, int> sexo = new Dictionary<string, int>();
            Dictionary<(string, DateTime), int> periodoSexo = new Dictionary<(string, DateTime), int>();

            int cantPersonas = 0;
            int cantPeliculas = 0;


            CargarEncuesta(pathEncuesta, encuesta);

            foreach (KeyValuePair<int, Encuesta> e in encuesta)
            {
                int edad = e.Value.Edad();
                cantPersonas++;
                cantPeliculas += e.Value.CantidadPeliculas;

                if (!periodos.ContainsKey(e.Value.Periodo))
                {
                    periodos.Add(e.Value.Periodo, e.Value.CantidadPeliculas);
                }
                else
                {
                    periodos[e.Value.Periodo] += e.Value.CantidadPeliculas;
                }
                if (!edades.ContainsKey(edad))
                {
                    edades.Add(edad, e.Value.CantidadPeliculas);
                }
                else
                {
                    edades[edad] += e.Value.CantidadPeliculas;
                }
                if (!sexo.ContainsKey(e.Value.Sexo))
                {
                    sexo.Add(e.Value.Sexo, e.Value.CantidadPeliculas);
                }
                if (!periodoSexo.ContainsKey((e.Value.Sexo, e.Value.Periodo)))
                {
                    periodoSexo.Add((e.Value.Sexo, e.Value.Periodo), e.Value.CantidadPeliculas);
                }
            }

            Console.WriteLine($"El Promedio de cantidad de películas vistas es : {CalcularPromediodePeliculas(cantPersonas, cantPeliculas)}");
            Console.WriteLine("-------------------------------------------------------------------------------");
            foreach (KeyValuePair<DateTime, int> p in periodos)
            {
                Console.WriteLine($"El Promedio de películas vistas en el periodo {p.Key.ToShortDateString()} es de: {p.Value}");
            }
            Console.WriteLine("-------------------------------------------------------------------------------");

            foreach (KeyValuePair<int, int> e in edades)
            {
                Console.WriteLine($"El Promedio de películas vistas en edad {e.Key} es de: {e.Value}");
            }
            Console.WriteLine("-------------------------------------------------------------------------------");

            foreach (KeyValuePair<string, int> s in sexo)
            {
                Console.WriteLine($"El Promedio de películas vistas para el sexo {s.Key} es de: {s.Value}");
            }
            Console.WriteLine("-------------------------------------------------------------------------------");
            foreach (KeyValuePair<(string, DateTime), int> ps in periodoSexo)
            {
                Console.WriteLine($"El Promedio de películas vistas para el sexo {ps.Key.Item1} y el periodo {ps.Key.Item2.ToShortDateString()} es de: {ps.Value}");
            }
            Console.WriteLine("-------------------------------------------------------------------------------");

            Console.ReadKey();

        }
        public static void CargarEncuesta(string path, Dictionary<int, Encuesta> encuesta)
        {
            using (StreamReader streamReader = new StreamReader(path))
            {
                while (!streamReader.EndOfStream) //Mientras no sea el fin del archivo, seguir iterando y pasando las lineas
                {
                    string linea = streamReader.ReadLine();
                    int contadorLinea = 0;
                    if (linea != null)
                    {
                        try
                        {
                            string[] campos = linea.Split(';');
                            contadorLinea++;
                            Encuesta unaEncuesta = new Encuesta();

                            unaEncuesta.NumeroUsuario = int.Parse(campos[0]);
                            unaEncuesta.FechaNacimiento = DateTime.Parse(campos[1]);
                            unaEncuesta.Sexo = campos[2];
                            unaEncuesta.Periodo = DateTime.Parse(campos[3]);
                            unaEncuesta.CantidadPeliculas = int.Parse(campos[4]);

                            if (!encuesta.ContainsKey(unaEncuesta.NumeroUsuario))
                                encuesta.Add(unaEncuesta.NumeroUsuario, unaEncuesta);
                            else
                                throw new Exception($"Esta Numero de Usuario ya existe {unaEncuesta.NumeroUsuario}");

                        }
                        catch (Exception)
                        {
                            Console.WriteLine($"Problemas en la linea nro: {contadorLinea}");
                        }
                    }
                }
            }
        }
        public static float CalcularPromediodePeliculas(int cantPersonas, int cantPeliculas)
        {
            return cantPeliculas / cantPersonas;
        }
    }
}


