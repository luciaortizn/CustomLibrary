
using Microsoft.Maui.Controls;
using Newtonsoft.Json;
using Proyecto2Trimestre_Lucía_Ortiz.Modelo;
using Proyecto2Trimestre_Lucía_Ortiz.Plantillas;
using System.Collections.ObjectModel;

namespace Proyecto2Trimestre_Lucía_Ortiz.Vista;

public partial class WelcomePage : Plantillas.Plantilla1
{

    public static List<Modelo.ResultadoLibros> filteredBooks { get; set; }
    public static List<Modelo.ResultadoLibros> Books;

    public static string OpcionPicker_app { get; set; }
    public static string TxtBuscador_app { get; set; }

    public WelcomePage()
    {
        InitializeComponent();

        peticionBestseller();
        peticionReseñas();


    }
    public async void peticionReseñas()
    {

        String host = "https://api.nytimes.com/svc/books/v3/reviews.json?author=Stephen+King&api-key=XWnCQhS0DpNvoOC8wQonKuW8YIaD72AK";
        HttpClient result = new HttpClient();

        String cadena = await result.GetStringAsync(host);


        ApiResponse apiRecsResponse = JsonConvert.DeserializeObject<ApiResponse>(cadena);

        List<ResultadoLibros> bookResults = apiRecsResponse.Results;

        listaVista.ItemsSource = bookResults;

        foreach (var bookResult in bookResults)
        {
            new Modelo.ResultadoLibros
            {
                Url = bookResult.Url,
                Publication_dt = bookResult.Publication_dt,
                Byline = bookResult.Byline,
                Book_Title = bookResult.Book_Title,
                Book_Author = bookResult.Book_Author,
                Summary = bookResult.Summary,
                Uuid = bookResult.Uuid,
                Uri = bookResult.Uri,
                Isbn13 = bookResult.Isbn13
            };
        }
        listaVista.ItemsSource = bookResults;

    }
  
    public async void peticionBestseller()
    {

        String host = "https://api.nytimes.com/svc/books/v3/lists/current/hardcover-fiction.json?api-key=XWnCQhS0DpNvoOC8wQonKuW8YIaD72AK";
        HttpClient result = new HttpClient();

        String cadena = await result.GetStringAsync(host);


        ApiResponseBestellers apiResponseBestSeller = JsonConvert.DeserializeObject<ApiResponseBestellers>(cadena);


        ResultData resultData = apiResponseBestSeller.Results;

        // Obtener la lista de libros directamente de resultData
        List<Book> bookList1 = resultData.Books;

        List<String> isbnsList = new List<string>();
        //cambiar precio por isbn
        foreach (var book in bookList1)
        {
            foreach (var isbns in book.Isbns)
            {
                isbnsList.Add(isbns.Isbn13.ToString());
            }
            //System.Diagnostics.Debug.WriteLine($"Title: {book.Title}, Author: {book.Author}");
        }
        listaVista1.ItemsSource = bookList1;
    }

    public static void Picker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        if (OpcionPicker_app == null)
        {
            OpcionPicker_app = "nula";
        }
        else
        {
            string selectedOption = (string)picker.SelectedItem;
            OpcionPicker_app = selectedOption;
            System.Diagnostics.Debug.WriteLine("Opcion picker nueva: " + OpcionPicker_app);
        }
    }

    private async void Buscador_SearchButtonPressed(object sender, EventArgs e)
    {
        if (sender is SearchBar searchBar)
        {

            if (TxtBuscador_app == null)
            {
                TxtBuscador_app = "nulo";

            }
            else
            {
                TxtBuscador_app = searchBar.Text;
                System.Diagnostics.Debug.WriteLine("Texto buscador" + TxtBuscador_app);

                String peticionNueva = "";
                //poner si texto buscador es vacío
                switch (OpcionPicker_app)
                {
                    case "Título":

                        peticionNueva = $"https://api.nytimes.com/svc/books/v3/reviews.json?title={TxtBuscador_app}&api-key=XWnCQhS0DpNvoOC8wQonKuW8YIaD72AK";
                        break;
                    case "Autor":
                        peticionNueva = $"https://api.nytimes.com/svc/books/v3/reviews.json?author={TxtBuscador_app.ToLower()}&api-key=XWnCQhS0DpNvoOC8wQonKuW8YIaD72AK";
                        break;
                    case "ISBN":
                        //9780307476463

                        peticionNueva = $"https://api.nytimes.com/svc/books/v3/reviews.json?isbn={TxtBuscador_app.ToString()}&api-key=XWnCQhS0DpNvoOC8wQonKuW8YIaD72AK";
                        break;
                    default:
                        peticionNueva = "https://api.nytimes.com/svc/books/v3/reviews.json?author=Stephen+King&api-key=XWnCQhS0DpNvoOC8wQonKuW8YIaD72AK";
                        break;
                }

                HttpClient result = new HttpClient();
                String cadena = await result.GetStringAsync(peticionNueva);

                ApiResponse apiRecsResponse = JsonConvert.DeserializeObject<ApiResponse>(cadena);

                List<ResultadoLibros> bookResults = apiRecsResponse.Results;

                
                foreach (var bookResult in bookResults)
                {
                    new Modelo.ResultadoLibros
                    {
                        Url = bookResult.Url,
                        Publication_dt = bookResult.Publication_dt,
                        Byline = bookResult.Byline,
                        Book_Title = bookResult.Book_Title,
                        Book_Author = bookResult.Book_Author,
                        Summary = bookResult.Summary,
                        Uuid = bookResult.Uuid,
                        Uri = bookResult.Uri,
                        Isbn13 = bookResult.Isbn13
                    };
                }
                
                listaVista.ItemsSource = bookResults;

            }
        }
    }

    private  async void MenuFlyoutItem_Clicked(object sender, EventArgs e)
    {
        var menuItem = sender as MenuFlyoutItem; 
        

        if (menuItem != null )
        {
            string textoMenu = menuItem.Text.ToLower();
            if (textoMenu.Equals("favoritos"))
            {
                await Navigation.PushAsync(new Favoritos());
              

            }
            else 
            {
                //cerrar 
                await Navigation.PushAsync(new Vista.Login());
                Preferences.Remove("id");
                Template.DataTemplate._listaFavoritos.Clear();
            }
        }
    }
}




