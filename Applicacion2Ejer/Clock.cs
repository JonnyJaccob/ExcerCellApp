using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Plugin.LocalNotifications;
using Xamarin.Forms;

namespace Applicacion2Ejer
{
    //AÑADIMOS INOTIFYPROPERTYCHANGED PARA SABER CUANDO VA CAMBIANDO EL RELOJ
    public class Clock : INotifyPropertyChanged
    {
        public bool Comprobar = false;
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisedPropertyChanged(String propiedad)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propiedad));
            }
        }
        
        private int _Hora;
        public Clock(int hora)
        {
            this.Hora = hora;
            //INICIAMOS EL TIMER, FUNCIONANDO CADA SEGUNDO
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                this.Hora--;
                //EN EL MOMENTO QUE LLEGUE A CERO LO PARAMOS
                if (Hora == 0)
                {
                    //GENERAMOS LA NOTIFICACION                        
                    //CrossLocalNotifications.Current.Show("Notificaciones", "El lapso de tiempo finalizo finalizado. Tiempo transcurrido: " + hora);
                    Comprobar = true;
                    return false;
                }
                else
                    Comprobar = false;
                    return true;
            });
        }
        public int Hora
        {
            get { return this._Hora; }
            set { this._Hora = value; RaisedPropertyChanged("Hora"); }
        }
    }
}
