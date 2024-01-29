using SQLite;
using System.ComponentModel.DataAnnotations;

namespace Proyecto2Trimestre_Lucía_Ortiz.Modelo
{


    [Table("Usuario")]
    public partial class Usuario
    {
        [Key, AutoIncrement, PrimaryKey]
        public int Id_User { get; set; }

        public string Username { get; set; }

        public string Nombre { get; set; }

        public string Contrasena { get; set; }

        public int Edad { get; set; }

    }

    [Table("UsuarioLibroFavorito")]
    public partial class UsuarioLibroFavorito
    {
        [Key, AutoIncrement, PrimaryKey]
        public int Id { get; set; }

        [Indexed]
        public int Id_User { get; set; }

        [Indexed]
        public string Url { get; set; }
    }


}