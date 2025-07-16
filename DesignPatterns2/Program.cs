using System;
using DesignPatterns2.Adapter_design;
using DesignPatterns2.Bridge_design;
using DesignPatterns2.Decorator__design;
using DesignPatterns2.Flyweight_design;
using DesignPatterns2.Proxy_design;
using DesignPatterns2.Facade_design;
using DesignPatterns2;

class Program
{
    static void Main(string[] args)
    {
        //בתחילה הצגנו את כל הספרים גם הנדירים, ורק לאחר מכן המשתמש אומר אם הוא פרימיום או לא ובתפריט שהוא בוחר זה יתייחס אליו בהתאם

        // יצירת הספרייה והוספת ספרים אליה
        Library library = new Library();
        Book book1 = new Book("Mevukash", "Yona Sapir", BookCategory.Adult);
        Book book2 = new Book("Agur Habronza", "Maya Keinan", BookCategory.YoungAdult);
        Book book3 = new Book("Komix Saba", "M. Safra", BookCategory.Children | BookCategory.Thriller);
        Book book4 = new Book("Mevukash", "Yona Sapir", BookCategory.Adult); // ספר זהה לבדיקה

        library.AddBook(book1);
        library.AddBook(book2);
        library.AddBook(book3);
        library.AddBook(book4);

        IBookService bookService = new ProxyBookService(library);
        LibraryFacade libraryFacade = new LibraryFacade(library);

        Console.WriteLine($"Are book1 and book4 the same instance? {ReferenceEquals(book1.baseBook, book4.baseBook)}");
        Console.WriteLine($"Are book1 and book2 the same instance? {ReferenceEquals(book1.baseBook, book2.baseBook)}\n");


        Console.WriteLine("\nDisplaying Books with Colored Background:");
        book1.PrintDetailsOfBook(1);
        book2.PrintDetailsOfBook(1);
        book3.PrintDetailsOfBook(1);
        book4.PrintDetailsOfBook(1);
        ResetConsoleColors();

        Console.WriteLine("\nDisplaying Books with Colored Text:");
        book1.PrintDetailsOfBook(2);
        book2.PrintDetailsOfBook(2);
        book3.PrintDetailsOfBook(2);
        book4.PrintDetailsOfBook(2);
        ResetConsoleColors();

        Console.WriteLine("\nAdding Decorators to Books:");
        BookDecorator rareBook = new RareBookDecorator(book1);
        BookDecorator recommendedBook = new RecommendedBookDecorator(book2);
        library.AddSpecialBook(rareBook);
        library.AddSpecialBook(recommendedBook);


        rareBook.PrintBookDecorator(1);
        rareBook.PrintBookDecorator(2);
        recommendedBook.PrintBookDecorator(1);
        recommendedBook.PrintBookDecorator(2);



        Console.Write("Are you a premium user? (y/n): ");
        string isPremiumInput = Console.ReadLine();
        User.HasPermission = isPremiumInput.Equals("y", StringComparison.OrdinalIgnoreCase);

        ResetConsoleColors();
        while (true)
        {
            Console.WriteLine("\nChoose an option: ");
            Console.WriteLine("1. Search for a book");
            Console.WriteLine("2. Borrow a book");
            Console.WriteLine("3. Return a book");
            Console.WriteLine("4. Design all books");
            Console.WriteLine("5. Design one book");
            Console.WriteLine("6. Exit");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter ID: ");
                    int searchId = int.Parse(Console.ReadLine());
                    Console.WriteLine(library.FindBookById(searchId) ? "The book was found" : "The book was not found");
                    break;

                case "2":
                    Console.Write("Enter ID: ");
                    int borrowId = int.Parse(Console.ReadLine());
                    libraryFacade.BorrowBook(borrowId);
                    break;

                case "3":
                    Console.Write("Enter ID: ");
                    int returnId = int.Parse(Console.ReadLine());
                    libraryFacade.ReturnBook(returnId);
                    break;

                case "4":
                    List<Book> books;
                    //צריך לבדוק פה איך המשתמש מוגדר ולפי זה לדעת איזה ספרים להדפיס לו
                    Console.Write("choose how to display: 1 for background and 2 for text ");
                    int num1= int.Parse(Console.ReadLine());
                    if (isPremiumInput.Equals("y"))
                    {
                        books = library.GetAllBooks();
                    }
                    else books = library.GetAllSimpleBooks();

                    foreach(Book book in books)
                    {
                        book.PrintDetailsOfBook(num1);
                    }
                    break;

                case "5":
                    Console.Write("Enter ID: ");
                    int designId = int.Parse(Console.ReadLine());
                    Console.Write("choose how to display: 1 for background and 2 for text ");
                    int num2 = int.Parse(Console.ReadLine());
                    library.ReturnBookById(designId).PrintDetailsOfBook(num2);
                    break;

                case "6":
                    return;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }

    private static void ResetConsoleColors()
    {
        if (Console.BackgroundColor != ConsoleColor.Black)
            Console.BackgroundColor = ConsoleColor.Black;
        if (Console.ForegroundColor != ConsoleColor.White)
            Console.ForegroundColor = ConsoleColor.White;
    }
    
}