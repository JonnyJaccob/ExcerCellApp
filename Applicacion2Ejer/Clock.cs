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
        //public int Cuentan=0;
        public int Cuentame=0;
        string Solo;
        public void RaisedPropertyChanged(String propiedad)
        {
            if (PropertyChanged != null)
            {
                
                PropertyChanged(this, new PropertyChangedEventArgs(propiedad));
                PropertyChanged(this, new PropertyChangedEventArgs(Solo));
                Cuentame++;
            }
        }
        
        public int _Hora;
        public Clock(int hora)
        {   
            
            this.Hora = hora;
            //INICIAMOS EL TIMER, FUNCIONANDO CADA SEGUNDO
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                this.Hora--;
                Cuentan = _Hora;
                Cuentame++;
                Solo = $"{Cuentame}";
                Aumentar();
                //EN EL MOMENTO QUE LLEGUE A CERO LO PARAMOS
                if (Hora == 0)
                {
                    //GENERAMOS LA NOTIFICACION                        
                    CrossLocalNotifications.Current.Show("Ejercicio Terminado!!!!", "BUEN TRABAJO!!!. Tiempo transcurrido: " + hora);
                    Comprobar = true;
                    return false;
                }
                else
                    Comprobar = false;
                    return true;
            });
            
        }
        void Aumentar()
        {
            Cuentame++;
        }
        public int Hora
        {
            get { return this._Hora; }
            set { this._Hora = value; RaisedPropertyChanged("Hora"); }
        }
        private int _Cuentan = 0;
        public int Cuentan
        {
            get { return this._Cuentan; }
            set { this._Cuentan = value; RaisedPropertyChanged("Cuentan"); }
        }
    
    }
}
