using Newtonsoft.Json;
using Proyecto2Trimestre_Lucía_Ortiz.Modelo;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Proyecto2Trimestre_Lucía_Ortiz

{
    public partial class MainPage : Plantillas.Plantilla1
    {
       
        public MainPage()
        {
           peticionBestseller();
        }

        private async void peticionBestseller()
        {

            String host = "https://api.nytimes.com/svc/books/v3/lists/current/hardcover-fiction.json?api-key=XWnCQhS0DpNvoOC8wQonKuW8YIaD72AK";
            HttpClient result = new HttpClient();

            String cadena = await result.GetStringAsync(host);

            
            ApiResponseBestellers apiResponseBestSeller = JsonConvert.DeserializeObject<ApiResponseBestellers>(cadena);

          
            ResultData resultData = apiResponseBestSeller.Results;

            // Obtener la lista de libros directamente de resultData
            List<Book> bookList1 = resultData.Books;

            // Puedes iterar sobre la lista de libros
            foreach (var book in bookList1)
            {
                System.Diagnostics.Debug.WriteLine($"Title: {book.Title}, Author: {book.Author}");
            }
        }

        /*
         *  ObservableCollection<Modelo.Noticia> listaReducida = new ObservableCollection<Modelo.Noticia>(lista.Take(20).ToList());


        foreach (Modelo.Noticia pelicula in listaReducida)
        {
            Modelo.Noticia peliculaActual = new Modelo.Noticia
            {

                Name = pelicula.Name,
                Author = pelicula.Author,
                Title = pelicula.Title,
                Description = pelicula.Description,
                Url = pelicula.Url,
                UrlToImage = pelicula.UrlToImage,
                PublishedAt = pelicula.PublishedAt
            };
         * /

            /* public String Name;
    public String Author;
    public String Title;
    public String Description;
    public String Url;
    public String UrlToImage;
    public String PublishedAt;*/

        //System.Diagnostics.Debug.WriteLine($"Id:{pelicula.I} , Título:{pelicula.T}, Año:{pelicula.Y}, Trama:{pelicula.Plot}");

    }
}