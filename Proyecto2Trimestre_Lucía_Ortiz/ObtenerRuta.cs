namespace Proyecto2Trimestre_Lucía_Ortiz
{
    public static class ObtenerRuta
    {
        public static string devolverRuta(String nombreBD)
        {
            return System.IO.Path.Combine(FileSystem.AppDataDirectory, nombreBD);
        }
    }
}
