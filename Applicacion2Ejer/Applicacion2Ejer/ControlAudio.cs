using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Applicacion2Ejer
{
    class ControlAudio: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        string nombre = "Mutear";
        int Cuento = 1;
        private string _strNombreBut;

        public string NombreButtom
        {
            get { return _strNombreBut; }
            set { _strNombreBut = value; }
        }

        public string NombreBoton
        {
            get => nombre;
            set
            {
                if (nombre == value)
                    return;
                nombre = value;
                onProperityChanged(nameof(NombreBoton));
                onProperityChanged(nameof(Opcion));
            }
        }
        //public string MostrarNombre => $"{Nombre}";
        void onProperityChanged(string n)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
        }
        public string MostarNombre() { return $"{NombreBoton}"; }

        public string Opcion()
        {
            if(Cuento==1)
            {
                NombreButtom = "Mutear";
                MostarNombre();
                Cuento = 2;
            }else
            {
                NombreButtom = "Encender";
                MostarNombre();
                Cuento = 1;
            }
            return nombre;
        }
       private void CambiarVolumen()
        {

        }
    }
}
