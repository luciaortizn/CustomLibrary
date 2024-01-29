
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2Trimestre_Lucía_Ortiz.Modelo
{
    //para la petición de recomendación de libros
    public partial class ApiResponse
    {
        public string Status { get; set; }
        public string Copyright { get; set; }
        public int NumResults { get; set; }
        public List<ResultadoLibros> Results { get; set; }

    }










    //para la petición de bestsellers de la api
    public partial class ApiResponseBestellers {

        public string Status { get; set; }
        public string Copyright { get; set; }
        public int NumResults { get; set; }
        public DateTime LastModified { get; set; }
        public ResultData Results { get; set; }


    }
    public partial class ResultData
    {
        public string ListName { get; set; }
        public string ListNameEncoded { get; set; }
        public DateTime BestsellersDate { get; set; }
        public DateTime PublishedDate { get; set; }
        public string PublishedDateDescription { get; set; }
        public string NextPublishedDate { get; set; }
        public string PreviousPublishedDate { get; set; }
        public string DisplayName { get; set; }
        public int NormalListEndsAt { get; set; }
        public string Updated { get; set; }
        public List<Book> Books { get; set; }
    }
    public partial class Book
    {
        public int Rank { get; set; }
        public int Rank_last_week { get; set; }
        public int WeeksOnList { get; set; }
        public int Asterisk { get; set; }
        public int Dagger { get; set; }
        public string PrimaryIsbn10 { get; set; }
        public string PrimaryIsbn13 { get; set; }
        public string Publisher { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Book_Image { get; set; }
        public string Amazon_Product_Url { get; set; }
        public string AgeGroup { get; set; }
        public string BookReviewLink { get; set; }
        public string ArticleChapterLink { get; set; }
        public List<Isbn> Isbns { get; set; }
        public List<BuyLink> BuyLinks { get; set; }
        public string BookUri { get; set; }
    }
    public partial class Isbn
    {
        public string Isbn10 { get; set; }
        public string Isbn13 { get; set; }
    }

    public partial class BuyLink
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
