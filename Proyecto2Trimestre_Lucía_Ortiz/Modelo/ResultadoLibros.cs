using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2Trimestre_Lucía_Ortiz.Modelo
{
    [Table("Libro")]
    public class ResultadoLibros
    {
        
        public string Isbn { get; set; }


        [PrimaryKey]
        public string Url { get; set; }

        public string Publication_dt { get; set; }

        public string Byline { get; set; }

        public string Book_Title { get; set; }

        public string Book_Author { get; set; }
        public string Summary { get; set; }

       
        public string Uuid { get; set; }

        public string Uri { get; set; }

        [Ignore]
        public List<string> Isbn13 { get; set; }
        
    }
}
