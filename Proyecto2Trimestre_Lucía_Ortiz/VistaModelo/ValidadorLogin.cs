using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Proyecto2Trimestre_Lucía_Ortiz.Modelo;
using Proyecto2Trimestre_Lucía_Ortiz.Repositorio;
using Proyecto2Trimestre_Lucía_Ortiz.Vista;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Proyecto2Trimestre_Lucía_Ortiz.VistaModelo {


    public partial class ValidadorLogin : ObservableValidator

    {
        public static String nombreUser = "";
        public ObservableCollection<string> ErroresLogin { get; set; } = new ObservableCollection<string>();
        public RelayCommand IrAWelcomePageCommand { get; private set; }
        public RelayCommand IrARegistroCommand { get; private set; }

        private String username;
        //no se que tipo de error poner, es que si user y contraseña se encuentran en bd se valida
        [Required(ErrorMessage = "Campo vacío: Username")]
        public String Username
        {
            get => username;
            set => SetProperty(ref (username), value);
        }

        private String contrasena;
        [Required(ErrorMessage = "Campo vacío: Contraseña")]
        public String Contrasena
        {
            get => contrasena;
            set => SetProperty(ref (contrasena), value);
        }

        public ValidadorLogin()
        {
            IrAWelcomePageCommand = new RelayCommand(IrAWelcomePage);
            IrARegistroCommand = new RelayCommand(IrARegistro);
        }

        [RelayCommand]
        //el método sería sincrónico si quisiese pasar entre vistas
        public void validar()
        {
            ValidateAllProperties();
            ErroresLogin.Clear();
            GetErrors(nameof(Username)).ToList().ForEach(f => ErroresLogin.Add(f.ErrorMessage));
            GetErrors(nameof(Contrasena)).ToList().ForEach(f => ErroresLogin.Add(f.ErrorMessage));

            if (ErroresLogin.Count == 0)
            {
                if (AutenticarUsuario(Username, Contrasena))
                {
                    //obtener usuario que inicia sesión en una Observ List 


                    string rutaBD = ObtenerRuta.devolverRuta("libros");
                    /* var userRepositorio = new Repositorio.UserRepositorio(rutaBD);
                       ObservableCollection<Usuario> listaU =  userRepositorio.listarUsuarios();
                       foreach (Usuario u in listaU) {
                           if (Username == u.Username && Contrasena == Contrasena) { 
                               ObservableCollection<String> miUser = new ObservableCollection<String>();
                       }
                     */
                    var usuarioExistente = App.userRepositorio.listarUsuarios().FirstOrDefault(u => u.Username == Username);
                    ObservableCollection<String> miUser = new ObservableCollection<String>();   
                    miUser.Add(usuarioExistente.Username);
                    miUser.Add(usuarioExistente.Nombre);
                    miUser.Add((usuarioExistente.Edad).ToString());
                    miUser.Add((usuarioExistente.Contrasena));

                    Preferences.Default.Set("id", usuarioExistente.Nombre);
                    System.Diagnostics.Debug.WriteLine(Preferences.Default.Get("id", "Hola"));

                    nombreUser = usuarioExistente.Nombre;
                    App.Username = nombreUser;

                    IrAWelcomePage();
                }
                else
                {
                    ErroresLogin.Add("Credenciales inválidas");
                    MostrarMensajeEmergente("Error", "Credenciales inválidas");
                }
            }
            else
            {
                MostrarMensajeEmergente("Error", "Complete todos los campos");
            }

        }
        
        private bool AutenticarUsuario(string username, string password)
        {
            var usuarioExistente = App.userRepositorio.listarUsuarios().FirstOrDefault(u => u.Username == username && u.Contrasena == Encriptador.ObtenerHash(password));
            return usuarioExistente != null;
        }

        private async void MostrarMensajeEmergente(string titulo, string mensaje)
        {
            await Application.Current.MainPage.DisplayAlert(titulo, mensaje, "OK");
        }

        private async void IrAWelcomePage()
        {
            
            Template.DataTemplate._listaFavoritos.Clear();
            var  navigation = App.Current.MainPage.Navigation;
            await navigation.PushAsync(new Vista.WelcomePage());

            
        }

        private void IrARegistro()
        {
            var navigation = App.Current.MainPage.Navigation;
            navigation.PushAsync(new Vista.Registro());
           
        }
    }
}