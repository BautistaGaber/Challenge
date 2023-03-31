using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeSGB1
{
    public class Encuesta
    {
        public int NumeroUsuario { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Sexo { get; set; }
        public DateTime Periodo { get; set; }
        public int CantidadPeliculas { get; set; }
        public int Edad()
        {
            return DateTime.Now.Year - FechaNacimiento.Year;
        } 
    }
}
