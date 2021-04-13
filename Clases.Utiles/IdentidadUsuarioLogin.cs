namespace Clases.Utiles
{
    public static class IdentidadUsuarioLogin
    {
        public static long EmpleadoId { get; set; }
        public static long UsuarioId { get; set; }
        public static bool EstaLogueado { get; set; }
        public static string Nombre { get; set; }
        public static string Apellido {get; set; }
        public static string ApyNom => $"{Apellido}, {Nombre}";
    }
}