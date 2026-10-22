using SGB_BS.Services;
using SGB_BS.UI;

namespace SGB_BS
{
    /// <summary>
    /// Punto de entrada. Solo ensambla los objetos y arranca la aplicación;
    /// no contiene lógica de negocio ni de interfaz.
    /// </summary>
    public class Program
{
    public static void Main(string[] args)
    {
        LibraryManager library = new LibraryManager();
        ConsoleMenu menu = new ConsoleMenu(library);
        menu.Run();
    }
}
}
