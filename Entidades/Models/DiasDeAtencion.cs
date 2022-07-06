using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Models;

namespace Entidades.Models
{
    public class DiasDeAtencion
    {
        private HorarioDeAtencion lunes;
        private HorarioDeAtencion martes;
        private HorarioDeAtencion miercoles;
        private HorarioDeAtencion jueves;
        private HorarioDeAtencion viernes;
        private HorarioDeAtencion sabado;
        private HorarioDeAtencion domingo;

        public HorarioDeAtencion Lunes { get => lunes; set => lunes = value; }
        public HorarioDeAtencion Martes { get => martes; set => martes = value; }
        public HorarioDeAtencion Miercoles { get => miercoles; set => miercoles = value; }
        public HorarioDeAtencion Jueves { get => jueves; set => jueves = value; }
        public HorarioDeAtencion Viernes { get => viernes; set => viernes = value; }
        public HorarioDeAtencion Sabado { get => sabado; set => sabado = value; }
        public HorarioDeAtencion Domingo { get => domingo; set => domingo = value; }


        /// <summary>
        /// Indexador de dias de atencion, el indice va desde 1 a 7, correspondiente a los dias de la semana.
        /// </summary>
        /// <param name="index"></param>
        /// <returns>Retorna el dia de la semana en español</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public HorarioDeAtencion this[int index]
        {
            get
            {
                switch (index)
                {
                    case 1:
                        return Lunes;
                    case 2:
                        return Martes;
                    case 3:
                        return Miercoles;
                    case 4:
                        return Jueves;
                    case 5:
                        return Viernes;
                    case 6:
                        return Sabado;
                    case 7:
                        return Domingo;
                    default:
                        throw new ArgumentOutOfRangeException("El valor no es valido");
                }

            }

            set
            {
                switch (index)
                {
                    case 1:
                        Lunes = value;
                        break;
                    case 2:
                        Lunes = value;
                        break;
                    case 3:
                        Lunes = value;
                        break;
                    case 4:
                        Lunes = value;
                        break;
                    case 5:
                        Lunes = value;
                        break;
                    case 6:
                        Lunes = value;
                        break;
                    case 7:
                        Lunes = value;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("El indice no es valido.");
                }

            }
        }

        /// <summary>
        /// Dias de la semana en español. Los indices van de 0 a 7 inclusive, donde el 0 devuelve vacio.
        /// </summary>
        public string[] dias =
        {
            "",
            "Lunes",
            "Martes",
            "Miercoles",
            "Jueves",
            "Viernes",
            "Sabado",
            "Domingo"
        };

        /// <summary>
        /// Dias de la semana en ingles. Los indices van de 0 a 7 inclusive, donde el 0 devuelve vacio.
        /// </summary>
        public string[] days =
        {
            "",
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"
        };


        /// <summary>
        /// Crea una nueva instancia de la clase DiasDeAtencion, por defecto todos sus dias no atiende.
        /// </summary>
        public DiasDeAtencion()
        {
            Lunes = new HorarioDeAtencion(false);
            Martes = new HorarioDeAtencion(false);
            Miercoles = new HorarioDeAtencion(false);
            Jueves = new HorarioDeAtencion(false);
            Viernes = new HorarioDeAtencion(false);
            Sabado = new HorarioDeAtencion(false);
            Domingo = new HorarioDeAtencion(false);
        }

        /// <summary>
        /// Devuelve un string con los dias que atiende.
        /// </summary>
        /// <returns></returns>
        public List<string> diasQueAtiende()
        {
            List<string> diasQueAtiende = new List<string>();

            for (int i = 1; i <= 7; i++)
            {
                if (this[i].Atiende)
                    diasQueAtiende.Add(days[i]);

            }

            return diasQueAtiende;

        }

        /// <summary>
        /// Describe a todos los dias de atencion segun su condicion.
        /// </summary>
        /// <returns>Cada dia de la semana con su condicion por linea.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Lunes:       " + Lunes.ToString());
            sb.AppendLine("Martes:      " + Martes.ToString());
            sb.AppendLine("Miercoles:   " + Miercoles.ToString());
            sb.AppendLine("Jueves:      " + Jueves.ToString());
            sb.AppendLine("Viernes:     " + Viernes.ToString());
            sb.AppendLine("Sabado:      " + Sabado.ToString());
            sb.AppendLine("Domingo:     " + Domingo.ToString());
            return sb.ToString();

        }

    }

}

