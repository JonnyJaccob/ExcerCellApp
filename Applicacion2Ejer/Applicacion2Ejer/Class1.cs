using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Xamarin.Forms;
using System.Threading;
using Plugin.FilePicker;

namespace Applicacion2Ejer
{
    public class Rutina : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        string nombre = string.Empty;
        public int minutosT = 0;
        public int segundosT = 10;
        public int minutosD = 0;
        public int segundosD = 10;
        DateTime tiempo = DateTime.Now;
        public Xamarin.Forms.ImageSource[] ArregloImagen = new Xamarin.Forms.ImageSource[2];
        
        public string Nombre
        {
            get => nombre;
            set { 
                if (nombre == value)
                return;
                nombre = value;
                onProperityChanged(nameof(Nombre));
                onProperityChanged(nameof(MostrarNombre));
                }
        }
        public string MostrarNombre => $"Ejercicio ingresado: {Nombre}";
        void onProperityChanged(string n)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(n));
        }
        private string _strTiempo;
        public string Tiempo
        {
            get => $"{this.minutosT}:{this.segundosT}";
            set
            {
                if (minutosT < 10 && segundosT >= 0)
                {
                    //nombre = value;
                    _strTiempo = $"{minutosT}:{segundosT}";
                    
                }
                else
                {
                    throw new Exception("Se sobre paso el limite de minutos o por debajo de los segundos");
                }
            }
        }
        

        public string MostrarDescanso => $"{minutosT}:{segundosT}";
        void onProperityChangedD(string n)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(n));
        }
        public void AumentarTiempo(int t)
        {
            segundosT += t;
            if(segundosT >=60)
            {
                minutosT += 1;
                segundosT = 0;
            }
        }
        public void DisminuirTiempo(int t)
        {
            segundosT -= t;
            if (segundosT <= 60)
            {
                minutosT -= 1;
                segundosT = 0;
            }
        }
        private string _strDescanso;
        public string Descanso
        {
            get => $"{this.minutosD}:{this.segundosD}";
            set
            {
                if (minutosD < 10 && segundosD >= 0)
                {
                    //nombre = value;
                    _strDescanso = $"{minutosD}:{segundosD}";
                }
                else
                {
                    throw new Exception("Se sobre paso el limite de minutos o por debajo de los segundos");
                }
            }
        }
        public string MostrarDescansoD => $"{minutosD}:{segundosD}";
        void onProperityChangedT(string n)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(n));
        }
        public void AumentarDescanso(int t)
        {
            segundosD += t;
            if(segundosD >=60)
            {
                minutosD += 1;
                segundosD = 0;
            }
        }
        public void DisminuirDescanso(int t)
        {
            segundosD -= t;
            if (segundosD <= 60)
            {
                minutosD -= 1;
                segundosD = 0;
            }
        }
        private int _intStep=1;

        public int Fases
        {
            get { return _intStep; }
            set {   if (Fases > 0 )
                    {
                    _intStep = value;
                        return;
                }
                else
                {
                    _intStep = 1;
                }
                }
        }
        public string MostrarFases => $"{Fases}";
        void onProperityChangedS(string n)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs($"{n}"));
        }
        public void CambiarFasesMM()
        {
            
            {
                Fases += 1;
            } 
        }
        public void CambiarFasesM()
        {
            //MENOS
            {
                Fases -= 1;
            }
            
        }
        public void CargarImagen(Xamarin.Forms.ImageSource x)
        {
            try
            {
                for (int i = 0; i < ArregloImagen.Length; i++)
                {
                    if (ArregloImagen[i] != null)
                    {
                        ArregloImagen[i] = x;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Ha sobrepasado el limite de imagenes \nError: "+ ex);
                throw;
            }
            
        }
        private int PosicionEnElArchivo;

        public int Posicion
        {
            get { return PosicionEnElArchivo; }
            set { PosicionEnElArchivo = value; }
        }

    }
}
