using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Models
{
    public class Horario
    {
        private static List<string> horarios;

        /// <summary>
        /// Constructor de la clase Horario, donde tiene una lista de horarios desde las 00:00 hasta las 23:59 inclusive. En intervalos de 30minutos.
        /// </summary>
        public Horario()
        {
            horarios = new List<string>()
            {
                "00:00", "00:30", "01:00", "01:30", "02:00", "02:30", "03:00", "03:30", "04:00", "04:30", "05:00", "05:30", "06:00", "06:30",
                "07:00", "07:30", "08:00", "08:30", "09:00", "09:30", "10:00", "10:30", "11:00", "11:30", "12:00", "12:30", "13:00", "13:30",
                "14:00", "14:30", "15:00", "15:30", "16:00", "16:30", "17:00", "17:30", "18:00", "18:30", "19:00", "19:30", "20:00", "20:30",
                "21:00", "21:30", "22:00", "22:30", "23:00", "23:30", "23:59"
            };
        }

        /// <summary>
        /// Constructor de clase Horario, donde tiene una lista de horarios desde las 00:00 hasta las 23:59 inclusive. En intervalos de 30minutos.
        /// </summary>
        static Horario()
        {
            ListaHorarios = new List<string>()
            {
                "00:00", "00:30", "01:00", "01:30", "02:00", "02:30", "03:00", "03:30", "04:00", "04:30", "05:00", "05:30", "06:00", "06:30",
                "07:00", "07:30", "08:00", "08:30", "09:00", "09:30", "10:00", "10:30", "11:00", "11:30", "12:00", "12:30", "13:00", "13:30",
                "14:00", "14:30", "15:00", "15:30", "16:00", "16:30", "17:00", "17:30", "18:00", "18:30", "19:00", "19:30", "20:00", "20:30",
                "21:00", "21:30", "22:00", "22:30", "23:00", "23:30", "23:59"
            };
        }

        /// <summary>
        /// Propiedad que devuelve la lista de horarios.
        /// </summary>
        public static List<string> ListaHorarios
        {
            get
            {
                return Horario.horarios;
            }
            set
            {
                Horario.horarios = value;
            }
        }

        /// <summary>
        /// Propiedad que devuelve la lista de horarios
        /// </summary>
        public List<string> Horarios { get => horarios; set => horarios = value; }
    }
}
