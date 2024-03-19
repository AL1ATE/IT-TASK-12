using System;
using System.Collections.Generic;

namespace Library
{
    // Перечисление для текущего состояния книги
    public enum BookStatus
    {
        InLibrary,
        Issued,
        UnderRestoration
    }

    // Класс "Библиотечная книга"
    public class LibraryBook
    {
        // Свойства
        public string LibraryCode { get; private set; }
        public string Title { get; private set; }
        public List<string> Authors { get; private set; }
        public int PageCount { get; private set; }
        public string Theme { get; private set; }
        public BookStatus Status { get; private set; }

        // Конструктор
        public LibraryBook(string libraryCode, string title, List<string> authors, int pageCount, string theme, BookStatus status)
        {
            LibraryCode = libraryCode;
            Title = title;
            Authors = authors;
            PageCount = pageCount;
            Theme = theme;
            Status = status;
        }

        // Методы
        public void ChangeStatus(BookStatus newStatus)
        {
            Status = newStatus;
        }

        public void ChangeLibraryCode(string newCode)
        {
            LibraryCode = newCode;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите код библиотечного учета:");
            string libraryCode = Console.ReadLine();

            Console.WriteLine("Введите название книги:");
            string title = Console.ReadLine();

            Console.WriteLine("Введите имена авторов (разделяйте запятой):");
            string authorsInput = Console.ReadLine();
            List<string> authors = new List<string>(authorsInput.Split(','));

            Console.WriteLine("Введите количество страниц:");
            int pageCount = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите тематический раздел:");
            string theme = Console.ReadLine();

            Console.WriteLine("Выберите текущее состояние книги (0 - в фонде, 1 - выдана, 2 - на реставрации):");
            BookStatus status = (BookStatus)int.Parse(Console.ReadLine());

            // Создание объекта книги с введенными значениями
            LibraryBook book = new LibraryBook(libraryCode, title, authors, pageCount, theme, status);

            // Вывод информации о книге
            Console.WriteLine("\nИнформация о книге:");
            Console.WriteLine($"Код библиотечного учета: {book.LibraryCode}");
            Console.WriteLine($"Название: {book.Title}");
            Console.Write("Авторы: ");
            foreach (var author in book.Authors)
            {
                Console.Write(author + ", ");
            }
            Console.WriteLine();
            Console.WriteLine($"Количество страниц: {book.PageCount}");
            Console.WriteLine($"Тематический раздел: {book.Theme}");

            // Вывод текущего состояния книги
            string statusString = "";
            switch (book.Status)
            {
                case BookStatus.InLibrary:
                    statusString = "в фонде";
                    break;
                case BookStatus.Issued:
                    statusString = "выдана";
                    break;
                case BookStatus.UnderRestoration:
                    statusString = "на реставрации";
                    break;
            }
            Console.WriteLine($"Текущее состояние: {statusString}");

            // Изменение состояния книги
            Console.WriteLine("\nВведите новое состояние книги (0 - в фонде, 1 - выдана, 2 - на реставрации):");
            BookStatus newStatus = (BookStatus)int.Parse(Console.ReadLine());
            book.ChangeStatus(newStatus);
            Console.WriteLine($"Новое состояние книги: {newStatus}");

            // Изменение кода библиотечного учета
            Console.WriteLine("\nВведите новый код библиотечного учета:");
            string newLibraryCode = Console.ReadLine();
            book.ChangeLibraryCode(newLibraryCode);
            Console.WriteLine($"Новый код библиотечного учета: {book.LibraryCode}");
        }
    }
}
