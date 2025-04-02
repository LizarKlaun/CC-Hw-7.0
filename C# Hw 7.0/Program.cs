namespace C__Hw_7._0
{
    internal class Program
    {
        class Book : IDisposable
        {
            public string Title { get; set; }
            public string Author { get; set; }
            public int Year { get; set; }
            public int Pages { get; set; }
            private bool disposed = false;

            public Book(string title, string author, int year, int pages)
            {
                Title = title;
                Author = author;
                Year = year;
                Pages = pages;
            }

            public void DisplayInfo()
            {
                Console.WriteLine($"Книга: {Title}\nАвтор: {Author}\nРік видання: {Year}\nКількість сторінок: {Pages}\n");
            }

            ~Book()
            {
                Console.WriteLine($"Фіналізатор викликано для книги: {Title}");
            }

            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            protected virtual void Dispose(bool disposing)
            {
                if (!disposed)
                {
                    if (disposing)
                    {
                        Console.WriteLine($"Метод Dispose викликано для книги: {Title}");
                    }
                    disposed = true;
                }
            }
        }

        static void Main(string[] args)
        {
            using (Book book1 = new Book("Майстер і Маргарита", "Михайло Булгаков", 1967, 480))
            {
                book1.DisplayInfo();
            }

            Book book2 = new Book("1984", "Джордж Оруелл", 1949, 328);
            book2.DisplayInfo();
            book2.Dispose();

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
