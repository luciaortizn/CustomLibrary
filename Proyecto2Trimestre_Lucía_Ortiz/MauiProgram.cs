using Microsoft.Extensions.Logging;
using Proyecto2Trimestre_Lucía_Ortiz.Repositorio;


namespace Proyecto2Trimestre_Lucía_Ortiz
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
		builder.Logging.AddDebug();

#endif
            
             String ruta = ObtenerRuta.devolverRuta("libros");
            builder.Services.AddSingleton<UserRepositorio>(
                s => ActivatorUtilities.CreateInstance<UserRepositorio>(s, ruta)
            );
             
            

            return builder.Build();
        }
    }
}