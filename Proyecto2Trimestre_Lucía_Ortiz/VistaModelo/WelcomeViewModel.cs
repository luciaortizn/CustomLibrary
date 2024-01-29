using CommunityToolkit.Mvvm.ComponentModel;
using Proyecto2Trimestre_Lucía_Ortiz.Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2Trimestre_Lucía_Ortiz.VistaModelo
{
    public class WelcomeViewModel : ObservableObject
    {
        public const string RecargarContenido = "RecargarContenido";

        private Usuario _usuario;
        private ObservableCollection<Usuario> _usuarios;

        private UsuarioLibroFavorito _usuarioLibroFavorito;
        
      
        private ResultadoLibros _resultadoLibros;

        
        public Usuario Usuario
        {
            get => _usuario;
            set => SetProperty(ref _usuario, value);

        }
        
        public ObservableCollection<Usuario> Usuarios
        {
            get => _usuarios;
            set => SetProperty(ref _usuarios, value);
        }

        public ResultadoLibros ResultadoLibros
        {
            get => _resultadoLibros;
            set => SetProperty(ref _resultadoLibros, value);
        }

        public UsuarioLibroFavorito UsuarioLibroFavorito
        {
            get => _usuarioLibroFavorito;
            set => SetProperty(ref _usuarioLibroFavorito, value);

        }
        

        /*
        public WelcomeViewModel()
        {
            CargarUsuarios();
        }*/


        private void CargarUsuarios()
        {
           
            string rutaBD = ObtenerRuta.devolverRuta("libros");

            // Crear una instancia del repositorio
            var userRepositorio = new Repositorio.UserRepositorio(rutaBD);

            // Cargar la lista de usuarios
            Usuarios = userRepositorio.listarUsuarios();
        }
    }
}
