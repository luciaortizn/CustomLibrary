namespace Proyecto2Trimestre_Lucía_Ortiz.Vista;

public partial class Registro : ContentPage
{
	public Registro()
	{
		InitializeComponent();
	}
    //si quiero validar desde codigo
    private void Button_Clicked(object sender, EventArgs e)
    {

        //	Errores.ItemsSource = Vista_Modelo.ValidadorRegistro.args
    }
    private async void OnDoubleTap(object sender, EventArgs e)
    {

        System.Diagnostics.Debug.WriteLine("Hola has clicado");
        if (sender is Frame frame)
        {
            var actionSheet = await DisplayActionSheet("Selecciona una opción", "Cancelar", null, "Copiar", "Pegar", "Cortar");

            switch (actionSheet)
            {

                case "Cortar":


                    if (frame == userFrame)
                    {
                        await Clipboard.SetTextAsync(Username.Text);
                        Username.Text = "";
                    }
                    else if (frame == passwFrame)
                    {
                        await Clipboard.SetTextAsync(Password.Text);
                        Password.Text = "";
                    }else if (frame == nombreFrame)
                    {
                        await Clipboard.SetTextAsync(Nombre.Text);
                        Nombre.Text = "";
                    }else if (frame == edadFrame)
                    {
                        await Clipboard.SetTextAsync(Edad.Text);
                        Edad.Text = "";
                    }
                    break;


                case "Copiar":

                    if (frame == userFrame)
                    {

                        await Clipboard.SetTextAsync(Username.Text);

                    }
                    else if (frame == passwFrame)
                    {
                        await Clipboard.SetTextAsync(Password.Text);

                    }
                    else if (frame == nombreFrame)
                    {
                        await Clipboard.SetTextAsync(Nombre.Text);
                        
                    }
                    else if (frame == edadFrame)
                    {
                        await Clipboard.SetTextAsync(Edad.Text);
                        
                    }
                    break;

                case "Pegar":

                    if (frame == userFrame)
                    {

                        Username.Text += await Clipboard.GetTextAsync(); ;

                    }
                    else if (frame == passwFrame)
                    {
                        Password.Text += await Clipboard.GetTextAsync();

                    }
                    else if (frame == nombreFrame)
                    {
                        Nombre.Text += await Clipboard.GetTextAsync();

                    }
                    else if (frame == edadFrame)
                    {
                        Edad.Text += await Clipboard.GetTextAsync();

                    }
                    break;
            }

        }
    }
}