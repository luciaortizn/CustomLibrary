using Proyecto2Trimestre_Lucía_Ortiz.VistaModelo;
using System.Diagnostics;

namespace Proyecto2Trimestre_Lucía_Ortiz.Template;

public partial class FavsTemplate : ContentView
{
	public FavsTemplate()
	{
		InitializeComponent();
	}

    public static void CambiarImagenEnFavoritos()
    {
        WelcomeViewModel welcomeViewModel = new WelcomeViewModel();

       
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        if (sender is Label label)
        {

            string url = (BindingContext as Modelo.ResultadoLibros)?.Url;

           
            if (!string.IsNullOrEmpty(url))
            {

                //string url_substring = url.Length > 4 ? url.Substring(4) : string.Empty;
                System.Diagnostics.Debug.WriteLine(url);
              
                Launcher.OpenAsync(new Uri(url));
            }

        }
    }



    private void TapGestureRecognizer_Tapped_Like(object sender, TappedEventArgs e)
    {
        System.Diagnostics.Debug.WriteLine("comienza evento");
        var imagen = sender as Image;

        // tiene que estar creado

       
        if (imagen != null && (BindingContext as Modelo.ResultadoLibros).Isbn.ToString() != null)
        {
            string stringUrl = (BindingContext as Modelo.ResultadoLibros).Url.ToString();
            string stringISBN = (BindingContext as Modelo.ResultadoLibros).Isbn.ToString();
            int id_User = App.userRepositorio.getIdUser();
            System.Diagnostics.Debug.WriteLine(id_User);

            if (imagen.Source.ToString().Contains("like_icon.png"))
            {
                 imagen.Source = "like_icon_filled.png";

                System.Diagnostics.Debug.WriteLine(stringUrl + " quitada");
                
            }
            else if (imagen.Source.ToString().Contains("like_icon_filled.png"))
            {
                imagen.Source = "like_icon.png";
                //solo quita relacion 
                //1º lo quito de bd
                App.userRepositorio.deleteUsuarioLibroFavorito(App.userRepositorio.getUsuarioLibroFavoritoByPK(stringUrl));
                //2º de fav
                Modelo.ResultadoLibros libroquitar = Template.DataTemplate._listaFavoritos.FirstOrDefault(objeto => objeto.Url == stringUrl);
                Template.DataTemplate._listaFavoritos.Remove(libroquitar);
                System.Diagnostics.Debug.WriteLine(libroquitar.Isbn.ToString());

                //mando mensaje
                CambiarImagenEnFavoritos();
               
            }
        }
        else {
                
        }

    }
}