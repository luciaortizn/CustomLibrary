namespace Proyecto2Trimestre_Lucía_Ortiz.Template;

public partial class BestsellerTemplate : ContentView
{
	public BestsellerTemplate()
	{
		InitializeComponent();
	}

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        if (sender is Label label)
        {

            string url = (BindingContext as Modelo.Book)?.Amazon_Product_Url;


            if (!string.IsNullOrEmpty(url))
            {

                //string url_substring = url.Length > 4 ? url.Substring(4) : string.Empty;
                System.Diagnostics.Debug.WriteLine(url);
                System.Diagnostics.Debug.WriteLine("");
                // Abre la URL en el navegador
                Launcher.OpenAsync(new Uri(url));
            }

        }
    }
}