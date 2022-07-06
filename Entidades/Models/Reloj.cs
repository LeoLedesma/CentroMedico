using System;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public delegate void NotificarHorarioHandler(Reloj sender);

    public class Reloj
    {   
        private DateTime tiempo;
        public event NotificarHorarioHandler OnNotificarCambio;

        public void Iniciar()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    DateTime now = DateTime.Now;
                    Thread.Sleep(100);

                    if (now.Second != this.tiempo.Second)
                    {
                        if (OnNotificarCambio is not null)
                            this.OnNotificarCambio.Invoke(this);
                    }
                    
                    tiempo = now;
                }
            });
        }

        public string ToString(bool fecha)
        {
            if (fecha)
                return $"{tiempo.ToString("d")}";
            else
                return $"{tiempo.ToString("T")}";            
        }

    }
}
