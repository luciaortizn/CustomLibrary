

using Newtonsoft.Json;
using Proyecto2Trimestre_Lucía_Ortiz.Modelo;
using Proyecto2Trimestre_Lucía_Ortiz.Repositorio;
using Proyecto2Trimestre_Lucía_Ortiz.Vista;
using Proyecto2Trimestre_Lucía_Ortiz.VistaModelo;
using static System.Net.WebRequestMethods;

namespace Proyecto2Trimestre_Lucía_Ortiz
{
    public partial class App : Application
    {
        
       
        public static UserRepositorio userRepositorio { get; set; }
        

       
        public static string TxtBuscador_app { get; set; }
        

        public static string Username { get; set; }

        public static object Sender_ { get; set; }  
        public static EventArgs Event_ {get; set;}

        public App(UserRepositorio _userRepositorio)
        {
            
            userRepositorio = _userRepositorio;

            InitializeComponent();
            MainPage = new AppShell();

        }

        public void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        {
            if (sender is Image image)
            {
                String url = "";

                string imgSource_substring = image.Source.ToString().Length > 6 ? image.Source.ToString().Substring(6) : string.Empty;
                System.Diagnostics.Debug.WriteLine(imgSource_substring);

                switch (imgSource_substring)
                {
                    case "linkedin_icon.png":
                        url = "https://www.linkedin.com/in/luc%C3%ADa-ortiz-n%C3%BA%C3%B1ez-multiplataforma-java/";

                        break;

                    case "github_icon.png":
                        url = "https://github.com/luciaortizn";
                        break;
                }

               
                Launcher.OpenAsync(new Uri(url));
            }

        }

    }
}