using SQLite;
using System.Collections.ObjectModel;
using Proyecto2Trimestre_Lucía_Ortiz;
using Proyecto2Trimestre_Lucía_Ortiz.Modelo;
using Proyecto2Trimestre_Lucía_Ortiz.VistaModelo;

namespace Proyecto2Trimestre_Lucía_Ortiz.Repositorio
{
    public partial class UserRepositorio
    {
        private String _ruta;

        private SQLiteConnection conexion;

        public UserRepositorio(String ruta)
        {
            _ruta = ruta;
            conexion = new SQLiteConnection(ruta);
            System.Diagnostics.Debug.WriteLine($"La ruta es {_ruta}");

            //user
            if (!conexion.TableMappings.Any(e => e.MappedType.Name == "Usuario"))
            {
                conexion.CreateTable<Usuario>();
            }
            //tabla unión 
            if (!conexion.TableMappings.Any(e => e.MappedType.Name == "UsuarioLibroFavorito"))
            {
                conexion.CreateTable<UsuarioLibroFavorito>();
            }
            //resultado libros
            if (!conexion.TableMappings.Any(e => e.MappedType.Name == "ResultadoLibros"))
            {
                conexion.CreateTable<ResultadoLibros>();
            }

        }
        public int getIdUser()
        {
            ObservableCollection<Usuario> usuarios = listarUsuarios();
            var current= usuarios.FirstOrDefault(u => u.Nombre == Preferences.Default.Get("id", "Hola"));
            return current.Id_User;
        }

        public ObservableCollection<UsuarioLibroFavorito> listarUsuarioLibroFavorito()
        {
            List<UsuarioLibroFavorito> lista = conexion.Table<UsuarioLibroFavorito>().ToList();
            ObservableCollection<UsuarioLibroFavorito> listaRelacion = new ObservableCollection<UsuarioLibroFavorito>(lista);
            return listaRelacion;
        }


        public ObservableCollection<ResultadoLibros> listarLibros()
        {
            List<ResultadoLibros> lista = conexion.Table<ResultadoLibros>().ToList();
            ObservableCollection<ResultadoLibros> listaLibros = new ObservableCollection<ResultadoLibros>(lista);
            return listaLibros;
        }

        public UsuarioLibroFavorito getUsuarioLibroFavoritoByPK(string url)
        {
            ObservableCollection<UsuarioLibroFavorito> listaRelacion = listarUsuarioLibroFavorito();
            UsuarioLibroFavorito userRelacion =  listaRelacion.FirstOrDefault(u => u.Url == url);
            return userRelacion;
        }
        public UsuarioLibroFavorito getUsuarioLibroFavoritoByUser(int id)
        {
            ObservableCollection<UsuarioLibroFavorito> listaRelacion = listarUsuarioLibroFavorito();
            UsuarioLibroFavorito userRelacion = listaRelacion.FirstOrDefault(u => u.Id_User == id);
            return userRelacion;
        }



        public void add(Usuario usuario)
        {
            conexion.Insert(usuario);
        }

        public void addUsuarioLibroFavorito(UsuarioLibroFavorito usuarioLibroFavorito) 
        {
            conexion.Insert(usuarioLibroFavorito);
        }

        public void deleteUsuarioLibroFavorito(UsuarioLibroFavorito usuarioLibroFavorito)
        {
            if (usuarioLibroFavorito!=null) { 
                conexion.Delete(usuarioLibroFavorito);
            }
           
        }

        public void addResultadoLibros(ResultadoLibros resultadolibros)
        {
            conexion.Insert(resultadolibros);
        }

        public void deleteResultadoLibros(ResultadoLibros resultadolibros)
        {
            conexion.Delete(resultadolibros);
        }


        public ObservableCollection<Usuario> listarUsuarios()
        {
            List<Usuario> lista = conexion.Table<Usuario>().ToList();
            ObservableCollection<Usuario> listaUsuarios = new ObservableCollection<Usuario>(lista);
            return listaUsuarios;
        }

        public bool VerificarSiExisteLibro(string _isbn)
        {
            var existe = conexion.Table<ResultadoLibros>().Any(x => x.Isbn == _isbn);
            return existe;
        }

        public bool VerificarSiExisteEnFavoritos(int idUsuario, string url)
        {

            var existe = conexion.Table<UsuarioLibroFavorito>().Any(x => x.Id_User == idUsuario && x.Url == url);
            return existe;
        }
        public ResultadoLibros getLibroByUrl(string url)
        {
            ObservableCollection<ResultadoLibros> listalibro= listarLibros();
            ResultadoLibros libro = listalibro.FirstOrDefault(u => u.Url == url);
            return libro;
        }
        public List<ResultadoLibros> obtenerLibrosPorRelacionYUser (int idUsuario)
        {
                var query = conexion.Table<UsuarioLibroFavorito>()
                    .Where(relacion => relacion.Id_User == idUsuario)
                    .Join(conexion.Table<ResultadoLibros>(),
                        relacion => relacion.Url,
                        reLibro => reLibro.Url,
                        (usuarioLibro, resultadoLibro) => resultadoLibro);
           
            return query.ToList();
        }
        

    }
}