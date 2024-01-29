using Proyecto2Trimestre_Lucía_Ortiz.Modelo;
using Proyecto2Trimestre_Lucía_Ortiz.Repositorio;
using Proyecto2Trimestre_Lucía_Ortiz.VistaModelo;
using System.Collections.ObjectModel;

namespace Proyecto2Trimestre_Lucía_Ortiz.Template;

public partial class DataTemplate : ContentView
{
    public static ObservableCollection<ResultadoLibros> _listaFavoritos = new ObservableCollection<ResultadoLibros>();
    public static int id_User = App.userRepositorio.getIdUser();
    public DataTemplate()
	{
		InitializeComponent();

    }

    public void setImage()
    {

        //no
        //metodo de obtener favoritos sin isbn
        string stringISBN = (BindingContext as Modelo.ResultadoLibros)?.Isbn13[0].ToString();
        int id_User = App.userRepositorio.getIdUser();
        if (!App.userRepositorio.VerificarSiExisteEnFavoritos(id_User, stringISBN))
        {
            likeImage.Source = "like_icon.png";
           

        }
        else
        {
            likeImage.Source = "like_icon_filled.png";
            
        }
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
                System.Diagnostics.Debug.WriteLine("");
                // Abre la URL en el navegador
                Launcher.OpenAsync(new Uri(url));
            }
           
        }
    }

   
    private void TapGestureRecognizer_Tapped_Like(object sender, TappedEventArgs e)
    {
        System.Diagnostics.Debug.WriteLine("comienza evento");
        var imagen = sender as Image;

        // Verificar la fuente actual y cambiarla
        if (imagen != null)
        {
            string stringISBN = (BindingContext as Modelo.ResultadoLibros)?.Isbn13[0].ToString();
            string stringUrl= (BindingContext as Modelo.ResultadoLibros)?.Url.ToString();
            
           

            //validacion si está en la relación pero no cuando haces tap


            if (imagen.Source.ToString().Contains("like_icon.png"))
            {
               
                imagen.Source = "like_icon_filled.png";
                
                System.Diagnostics.Debug.WriteLine(stringUrl+ " añadida");
                

                if (!App.userRepositorio.VerificarSiExisteEnFavoritos(id_User, stringUrl) )
                {
                    System.Diagnostics.Debug.WriteLine(App.userRepositorio.VerificarSiExisteEnFavoritos(id_User, stringUrl));


                    //1º encontrar todos los parámetros del libro, añadir el libro
                    var newLibro = new Modelo.ResultadoLibros

                    {
                        Isbn = stringISBN,
                        //la url es única
                        Url = (BindingContext as Modelo.ResultadoLibros)?.Url,
                        Byline = (BindingContext as Modelo.ResultadoLibros)?.Byline,
                        Book_Title = (BindingContext as Modelo.ResultadoLibros)?.Book_Title,
                        Book_Author = (BindingContext as Modelo.ResultadoLibros)?.Book_Author,
                        Summary = (BindingContext as Modelo.ResultadoLibros)?.Summary,
                        Publication_dt = (BindingContext as Modelo.ResultadoLibros)?.Publication_dt

                    };




                    //3º añade el libro
                    if (!App.userRepositorio.VerificarSiExisteLibro(stringISBN))
                    {
                        App.userRepositorio.addResultadoLibros(newLibro);
                    }
                    
                    

                    var newUserLibroFavorito = new Modelo.UsuarioLibroFavorito

                    {
                        Id_User = id_User,
                        Url = stringUrl,
                    };


                    App.userRepositorio.addUsuarioLibroFavorito(newUserLibroFavorito);
                    
                    System.Diagnostics.Debug.WriteLine("Relación: " + newUserLibroFavorito.Url + " " + newUserLibroFavorito.Id_User);
                    //libro en lista para otro template
                    _listaFavoritos.Add(newLibro);
                    System.Diagnostics.Debug.WriteLine("Hay en la lista: "+ _listaFavoritos.Count() + "Elementos");
                }
                

            }
            else if (imagen.Source.ToString().Contains("like_icon_filled.png"))
            { 
                imagen.Source = "like_icon.png";
                System.Diagnostics.Debug.WriteLine(stringUrl + " quitada");
                ResultadoLibros libroquitar = _listaFavoritos.FirstOrDefault(objeto => objeto.Url == stringUrl);

                App.userRepositorio.deleteUsuarioLibroFavorito(App.userRepositorio.getUsuarioLibroFavoritoByPK(stringUrl));

                Template.DataTemplate._listaFavoritos.Remove(libroquitar);
                //App.userRepositorio.deleteResultadoLibros(); de momento no elimino la relación

            }
        }

    }
}