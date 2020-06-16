using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.FilePicker;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Applicacion2Ejer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : ContentPage
    {
        FileData fileData;
        Rutina rutina;
        public Page2(Rutina ruta)
        {
            rutina = ruta;
            InitializeComponent();
        }
        void OnButtonClicked_GuardarImagen(object sender, EventArgs args)
        {
            rutina.CargarImagen(FileImagePreview.Source);
        }
        async void OnButtonClicked_SubirImagenAsync(object sender, EventArgs args)
        {
            ImagenAsync();
            string[] fileTypes = null;

            if (Device.RuntimePlatform == Device.Android)
            {
                fileTypes = new string[] { "image/png", "image/jpeg", "image/gif" };
            }

            if (Device.RuntimePlatform == Device.iOS)
            {
                fileTypes = new string[] { "public.image" }; // same as iOS constant UTType.Image
            }

            if (Device.RuntimePlatform == Device.UWP)
            {
                fileTypes = new string[] { ".jpg", ".png" };
            }

            if (Device.RuntimePlatform == Device.WPF)
            {
                fileTypes = new string[] { "JPEG files (*.jpg)|*.jpg", "PNG files (*.png)|*.png", "Gif files ( *.gif)|*.gif" };
            }

            await PickAndShowFile(fileTypes);
        }
        private async Task PickAndShowFile(string[] fileTypes)
        {
            try
            {
                var pickedFile = await CrossFilePicker.Current.PickFile(fileTypes);

                if (pickedFile != null)
                {
                    //FileNameLabel.Text = pickedFile.FileName;
                    //FilePathLabel.Text = pickedFile.FilePath;

                    if (pickedFile.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase)
                        || pickedFile.FileName.EndsWith("png", StringComparison.OrdinalIgnoreCase))
                    {
                        FileImagePreview.Source = ImageSource.FromStream(() => pickedFile.GetStream());
                        //rutina.CargarImagen(FileImagePreview.Source);
                        FileImagePreview.IsVisible = true;
                    }
                    else
                    {
                        FileImagePreview.IsVisible = false;
                    }
                }
            }
            catch (Exception )
            {
                //FileNameLabel.Text = ex.ToString();
                //FilePathLabel.Text = string.Empty;
                FileImagePreview.IsVisible = false;
            }
        

        }
        private async void PickFile_Clicked(object sender, EventArgs args)//obtener ruta del archivo
        {
            await PickAndShowFile(null);
        }
        public async void ImagenAsync()
        {
            try
            {
                fileData = await CrossFilePicker.Current.PickFile();
                if (fileData == null)
                    return; // user canceled file picking

                string fileName = fileData.FileName;
                string contents = System.Text.Encoding.UTF8.GetString(fileData.DataArray);

                System.Console.WriteLine("File name chosen: " + fileName);
                System.Console.WriteLine("File data: " + contents);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception choosing file: " + ex.ToString());
            }
        }
        public async Task TiposFilesAsync()
        {
            string[] fileTypes = null;

            if (Device.RuntimePlatform == Device.Android)
            {
                fileTypes = new string[] { "image/png", "image/jpeg", "image/gif" };
            }

            if (Device.RuntimePlatform == Device.iOS)
            {
                fileTypes = new string[] { "public.image" }; // same as iOS constant UTType.Image
            }

            if (Device.RuntimePlatform == Device.UWP)
            {
                fileTypes = new string[] { ".jpg", ".png" };
            }

            if (Device.RuntimePlatform == Device.WPF)
            {
                fileTypes = new string[] { "JPEG files (*.jpg)|*.jpg", "PNG files (*.png)|*.png","Gif files ( *.gif)|*.gif" };
            }

            await PickAndShowFile(fileTypes);
        }
    }
}