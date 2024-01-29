namespace Proyecto2Trimestre_Lucía_Ortiz.Vista;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
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
                    break;  
            }

        }
    } 

}