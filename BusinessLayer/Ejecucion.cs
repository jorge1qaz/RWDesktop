using System;
using System.Windows.Forms;

namespace BusinessLayer
{
    public class Ejecucion
    {
        //Jorge Luis|02/11/2017|RW-19
        /*Método para ejecutar en bucle un método en base a un determinado tiempo en segundos, emplea dos parámetros*/
        public void EventTimer(int tiempoSegundos, EventHandler evento)
        {
            Timer aTimer = new Timer();
            aTimer.Interval = tiempoSegundos * 1000;
            aTimer.Tick += new EventHandler(evento);
            aTimer.Start();
        }
    }
}
