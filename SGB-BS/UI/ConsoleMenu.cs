using SGB_BS.Models;
using SGB_BS.Services;

namespace SGB_BS.UI
{
    /// <summary>
    /// Interfaz de consola. Solo lee entradas, muestra salidas y delega
    /// la lógica en LibraryManager.
    /// </summary>
    public class ConsoleMenu
    {
        private readonly LibraryManager library;

        public ConsoleMenu(LibraryManager library)
        {
            this.library = library;
        }

        public void Run()
        {
            bool running = true;

            while (running)
            {
                ShowMenu();
                string? option = Console.ReadLine()?.Trim();

                switch (option)
                {
                    case "1":
                        SearchBookById();
                        break;
                    case "2":
                        ListBooks();
                        break;
                    case "0":
                        running = false;
                        Console.WriteLine("Hasta luego.");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.\n");
                        break;
                }
            }
        }

        private void ShowMenu()
        {
            Console.WriteLine("===== CATÁLOGO DE LIBROS =====");
            Console.WriteLine("1. Buscar libro por ID (binaria)");
            Console.WriteLine("2. Listar libros");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");
        }

        private void SearchBookById()
        {
            Console.Write("Ingrese el ID a buscar: ");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Entrada inválida: debe ingresar un número entero.\n");
                return;
            }

            Book? book = library.SearchById(id);

            if (book != null)
            {
                Console.WriteLine("Estado: Encontrado");
                Console.WriteLine(book);
            }
            else
            {
                Console.WriteLine($"Estado: No encontrado. No existe un libro con ID {id}.");
            }

            Console.WriteLine($"Comparaciones realizadas: {library.LastComparisons}\n");
        }

        private void ListBooks()
        {
            Console.WriteLine("--- Libros registrados ---");

            for (int i = 0; i < library.Count; i++)
            {
                Console.WriteLine(library.GetBookAt(i));
            }

            Console.WriteLine();
        }
    }
}
