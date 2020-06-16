using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Runtime;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
//using System.Security.Cryptography.X509Certificates;

namespace Applicacion2Ejer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    
    public partial class Page1 : ContentPage
    {
        int min;
        int seg;
        int Etapa; 
        System.Timers.Timer timer1 = new System.Timers.Timer();
        string Subtitulo = "Ejercicio Rapido";
        Rutina rutina;
        Timer segundero = new Timer(1000);
        //Ejercicio rapido
        public Page1(Rutina rutinas)
        {
            rutina = rutinas;
            InitializeComponent();
            EjecutarEjer();
        }
        private void iniciar(int M,int S,string Sub)
        {
            /*double Tiempox = (M * 6000) * (S * 1000);
            timer1.Interval =  Tiempox;
            timer1.Start();
            min = M;
            seg = S;
            var TextColor = Color.Blue;
            Subtitulo = Sub;
            lblSubtitulo.Text = Subtitulo;
            FondoRapido.BackgroundColor= TextColor;*/

        }
        void Pausa()
        {
            timer1.Stop();
            var TextColor = Color.Cyan;
            Subtitulo = "Pausado";
            lblSubtitulo.Text = Subtitulo;
            FondoRapido.BackgroundColor = TextColor;
        }
        public void CuentaRegresiva(int a)
        {
            if (a == 1)
            {
                iniciar(rutina.minutosT, rutina.segundosT, "Trabajando");
            }else
            {
                iniciar(rutina.minutosD, rutina.segundosD, "Descanso");
            }
            // Hook up the Elapsed event for the timer. 
            timer1.Elapsed += OnTimedEvent;

            // Have the timer fire repeated events (true is the default)
            timer1.AutoReset = true;

            // Start the timer
            timer1.Enabled = true;
            seg -= 1;
            string minutos = $"{min}";
            string sec= $"{seg}";
            //string Etapa;
            if (min < 10) { minutos = "0" + min.ToString(); }
            if (seg < 10) { sec = "0" + seg.ToString(); }
            if(seg==0 && min >0)
            {
                min -= 1;
                seg = 60;
            }
            if(min==0 && seg==0)
            {
                timer1.Stop();
            }
            lblCuenta.Text = $"{minutos}:{sec}";
            timer1.Enabled = false;
        }
        private static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            //Console.WriteLine(e.SignalTime);
        }
        public void EjecutarEjer()
        {
            var TextColor=Color.White;
            
            for ( int i = rutina.Fases; i == 0; i--)
            {
                TextColor = Color.Gray;
                lblSubtitulo.Text = "Preparate...";
                FondoRapido.BackgroundColor = TextColor;
                Temporizador(0, 5);//Temporizador inicio

                TextColor = Color.Blue;
                lblSubtitulo.Text ="Ha ejercitarse";
                FondoRapido.BackgroundColor = TextColor;
                Temporizador(rutina.minutosT, rutina.segundosT);//Temporizador Work

                TextColor = Color.Yellow;
                lblSubtitulo.Text = "Puedes Descansar";
                FondoRapido.BackgroundColor = TextColor;
                Temporizador(rutina.minutosD, rutina.segundosD);//Temporizador Rest

            }
            
            
            /*Etapa = rutina.Fases;
            int Intervalo = 0;
            if(Intervalo ==0)
            {
                System.Timers.Timer timer2 = new System.Timers.Timer();
                timer2.Interval = 3000;
                for (int i = Etapa; i > 0; --i)
                {
                    if (Intervalo == 0)
                    {
                        timer2.Start();
                        timer2.Enabled = true;
                        var TextColor = Color.AliceBlue;
                        FondoRapido.BackgroundColor = TextColor;
                        Intervalo++;
                        timer2.Enabled = false;
                    }
                    if (timer1.Enabled)
                    {
                        CuentaRegresiva(1);
                        
                    }
                    if (timer1.Enabled && Etapa != 0)
                    {
                        CuentaRegresiva(0);
                    }*/
            //}
            //}
        }
        int x, y;
        void Temporizador(int min, int seg)
        {
            /*int segT = rutina.segundosT;
            int minT = rutina.minutosT;
            int Etapa = rutina.Fases;
            int segD = rutina.segundosD;
            int minD = rutina.minutosT;*/
            x = seg;y = min;
                do
                {
                    do
                    {
                        segundero.AutoReset = true;

                        segundero.Elapsed += new System.Timers.ElapsedEventHandler(timer_elapsed);

                        segundero.Start();
                        x -= 1;
                        
                    } while (x>0);
                    y -= 1;
                    
                } while (y>0);
        }
        private void timer_elapsed(object sender, System.Timers.ElapsedEventArgs e)

        {
            lblCuenta.Text = $"{y}:{x}";
        }
        void OnButtonClicked_Iniciar(object sender, EventArgs args)
        {
            CuentaRegresiva(1);
        }
        void OnButtonClicked_Pausar(object sender, EventArgs args)
        {
            Pausa();
        }

        void Regresar()
        {
            this.Navigation.PopAsync();
        }
        void Version()
        {
        }
    }
}