using SGB_BS.Models;


namespace SGB_BS.Algorithms
{
    public class BookSearcher
    {
        /// <summary>Comparaciones de la última búsqueda realizada.</summary>
        public int Comparisons { get; private set; }

        /// <summary>
        /// Búsqueda binaria iterativa. Opera solo sobre books[0..count-1].
        /// Devuelve el libro encontrado o null si no existe.
        /// </summary>
        public Book? BinarySearchById(Book[] books, int count, int id)
        {
            int left = 0;
            int right = count - 1;
            Comparisons = 0;

            while (left <= right)
            {
                int middle = left + (right - left) / 2;

                Comparisons++; // un elemento central examinado

                if (books[middle].Id == id)
                    return books[middle];

                if (books[middle].Id < id)
                    left = middle + 1;
                else
                    right = middle - 1;
            }

            return null;
        }
    }
}