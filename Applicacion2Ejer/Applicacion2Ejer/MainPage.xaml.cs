using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
//using Xamarin.Plugin.FilePicker;

namespace Applicacion2Ejer
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        //public event EventHandler Pressed;//Al presionar
        Rutina rutina;
        ControlAudio audio;
        NumerosEjer excer;
        public MainPage()
        {
            audio = new ControlAudio();
            rutina = new Rutina();
            BindingContext = rutina;
            BindingContext = audio;
            InitializeComponent();

        }
        void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            string oldText = e.OldTextValue;
            string newText = e.NewTextValue;
        }

        void OnEntryCompleted(object sender, EventArgs e)
        {
            string text = ((Entry)sender).Text;
        }
        void OnButtonClicked(object sender, EventArgs e)
        {
            (sender as Button).Text = "";
        }
        void OnButtonPressed_Mas(object sender, EventArgs args)
        {
            try
            {
                rutina.AumentarTiempo(10);
                lblTiempo.Text = ($"{rutina.Tiempo}");

            } catch (Exception e)
            {
                throw new Exception(e.Message);//error en la referencia de la instancia
            }
        }
        void OnButtonPressed_Menos(object sender, EventArgs args)
        {
            rutina.AumentarTiempo(10);
            lblTiempo.Text = ($"{rutina.Tiempo}");
        }
        void OnButtonClicked_Mas(object sender, EventArgs e)
        {
            rutina.AumentarTiempo(1);
            lblTiempo.Text = ($"{rutina.Tiempo}");
        }
        void OnButtonClicked_Menos(object sender, EventArgs e)
        {
            rutina.DisminuirTiempo(1);
            lblTiempo.Text = ($"{rutina.Tiempo}");

        }
        void OnButtonClicked_MasD(object sender, EventArgs e)
        {
            rutina.AumentarDescanso(1);
            lblDescanso.Text = ($"{rutina.Descanso}");
        }
        void OnButtonClicked_MenosD(object sender, EventArgs e)
        {
            rutina.DisminuirDescanso(1);
            lblDescanso.Text = ($"{rutina.Descanso}");
        }
        void OnButtonPressed_MasD(object sender, EventArgs e)
        {
            rutina.AumentarDescanso(2);
            lblDescanso.Text = ($"{rutina.Descanso}");
        }
        void OnButtonPressed_MenosD(object sender, EventArgs e)
        {
            rutina.DisminuirDescanso(2);
            lblDescanso.Text = ($"{rutina.Descanso}");
        }
        void OnButtonClicked_MasS(object sender, EventArgs e)
        {
            rutina.CambiarFasesMM();
            lblFases.Text = $"{rutina.Fases}";
        }
        void OnButtonClicked_MenosS(object sender, EventArgs e)
        {
            rutina.CambiarFasesM();
            lblFases.Text = $"{rutina.Fases}";
        }
        void OnButtonReleased(object sender, EventArgs args)
        {

        }
        void OnButtonClicked_Mute(object sender, EventArgs args)
        {
            audio.Opcion();
            BotonVolumen.Text = audio.NombreButtom;
        }

        void OnButtonClicked_Inicio(object sender, EventArgs args)
        {
            Page1 form = new Page1(rutina);
            audio = new ControlAudio();
            this.Navigation.PushModalAsync(new Page1(rutina));
            //await Navigation.PushAsync(new Page1()); // aun no
            //MainPage = new NavigationPage(new Page1()); //no se pudo
        }
        void OnButtonClicked_Personalizar(object sender, EventArgs args)
        {
            Page2 form = new Page2(rutina);
            audio = new ControlAudio();
            this.Navigation.PushModalAsync(new Page2(rutina));
            //await Navigation.PushAsync(new Page1()); // aun no
            //MainPage = new NavigationPage(new Page1()); //no se pudo
        }
        void CrearGrupo()
        {
            for (int i = 0; i < excer.NEjercicio; i++)
            {
                Title = "Vertical StackLayout demo";
                Content = new StackLayout
                {
                    Margin = new Thickness(20),
                    Children =
                    {
                        /*new Label { Text = "Primary colors" },
                        new BoxView { Color = Color.Red },
                        new BoxView { Color = Color.Yellow },
                        new BoxView { Color = Color.Blue },
                        new Label { Text = "Secondary colors" },
                        new BoxView { Color = Color.Green },
                        new BoxView { Color = Color.Orange },
                        new BoxView { Color = Color.Purple }*/
                    }
                };
            }
            
        }
        void GuardarNumero()
        {
            excer = new NumerosEjer();
            excer.NEjercicio++;
        }
        void OnButtonClicked_GuardadoEjer(object sender, EventArgs args)
        {
            GuardarNumero();
        }
    }
}
