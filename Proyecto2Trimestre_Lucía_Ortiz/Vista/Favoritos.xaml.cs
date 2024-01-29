namespace Proyecto2Trimestre_Lucía_Ortiz.Vista;

using Proyecto2Trimestre_Lucía_Ortiz.Modelo;
using Proyecto2Trimestre_Lucía_Ortiz.Repositorio;
using Proyecto2Trimestre_Lucía_Ortiz.Template;
using Proyecto2Trimestre_Lucía_Ortiz.VistaModelo;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

public partial class Favoritos : Plantillas.Plantilla1
{
	public Favoritos()
	{
		InitializeComponent();
        iniciar();
	}
	
	public async void MenuFlyoutItem_Clicked(object sender, EventArgs e)
	{
        var menuItem = sender as MenuFlyoutItem;
      
       
        if (menuItem != null)
        {
            string textoMenu = menuItem.Text.ToLower();

            if (textoMenu.Contains("página principal"))
            {
                await Navigation.PushAsync(new WelcomePage());
                
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


    public void iniciar()
	{
		ObservableCollection<ResultadoLibros> listaFav = Template.DataTemplate._listaFavoritos;

		List<ResultadoLibros> rl = 	App.userRepositorio.obtenerLibrosPorRelacionYUser(DataTemplate.id_User);
		listaFav.Clear();
		foreach (ResultadoLibros libro in rl)
		{ //Execute code for each item in collectionName using variableName as you go. }
			if (!listaFav.Contains(libro))
			{
				listaFav.Add(libro);
			}
			
		}
        listaFavoritos.ItemsSource = listaFav;

    }
}