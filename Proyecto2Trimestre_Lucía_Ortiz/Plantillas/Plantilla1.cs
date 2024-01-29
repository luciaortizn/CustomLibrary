
using System.Collections.Generic;

namespace Proyecto2Trimestre_Lucía_Ortiz.Plantillas;

public class Plantilla1 : ContentPage
{
    public Plantilla1()
    {
       // uso key del controlador para definir la vista
        var plantilla = Application.Current.Resources["Plantilla1"] as ControlTemplate;

        ControlTemplate = plantilla;
    }
}