using System;
using System.Collections.Generic;
using static System.Reflection.Metadata.BlobBuilder;

namespace DesignPatterns2.Composite_design
{
    public class Category
    {
        // תכונות:
        public BookCategory categoryName { get; set; }
        public List<Book> Books { get; set; }       // רשימת הספרים בקטגוריה
        public List<Category> SubCategories { get; set; }  // רשימת תתי קטגוריות

        // קונסטרקטור:
        public Category()
        {
            
        }
        public Category(BookCategory c)
        {
            categoryName = c;
            Books = new List<Book>();
            SubCategories = new List<Category>();
        }

        // הוספת ספר לקטגוריה
        public void AddBook(Book b)
        {
            if (b != null)
            {
                Books.Add(b);
                Console.WriteLine($"The book '{b.baseBook.Name}' has been added to the category '{categoryName}'.");
            }
            else
            {
                Console.WriteLine("Error! The book cannot be added to the category.");
            }
        }

        // הסרת ספר מהקטגוריה
        public void RemoveBook(Book b)
        {
            if (Books.Contains(b))
            {
                Books.Remove(b);
                Console.WriteLine($"The book '{b.baseBook.Name}' has been removed from the category '{categoryName}'.");
            }
            else
            {
                Console.WriteLine($"The book '{b.baseBook.Name}' was not found in the category '{categoryName}'.");
            }
        }

        // הוספת קטגוריה משנה
        public void AddSubCategory(Category subCategory)
        {
            if (subCategory != null)
            {
                SubCategories.Add(subCategory);
                Console.WriteLine($"The subcategory '{subCategory}' has been added to '{categoryName}'.");
            }
            else
            {
                Console.WriteLine("Error! The subcategory cannot be added.");
            }
        }

        // הסרת קטגוריה משנה
        public void RemoveSubCategory(Category subCategory)
        {
            if (SubCategories.Contains(subCategory))
            {
                SubCategories.Remove(subCategory);
                Console.WriteLine($"The subcategory '{subCategory.categoryName}' has been removed from '{categoryName}'.");
            }
            else
            {
                Console.WriteLine($"The subcategory '{subCategory.categoryName}' was not found.");
            }
        }

        // הצגת כל הספרים בקטגוריה
        public void DisplayBooks()
        {
            if (Books.Count == 0)
            {
                Console.WriteLine($"There are no books in the category '{categoryName}'.");
                return;
            }

            Console.WriteLine($"Books in the category '{categoryName}':");
            foreach (var book in Books)
            {
                Console.WriteLine($"- {book.baseBook.Name} by {book.baseBook.Author}");
            }
        }

        // הצגת כל תתי הקטגוריות
        public void DisplaySubCategories()
        {
            if (SubCategories.Count == 0)
            {
                Console.WriteLine($"There are no subcategories in '{categoryName}'.");
                return;
            }

            Console.WriteLine($"Subcategories of '{categoryName}':");
            foreach (var subCategory in SubCategories)
            {
                Console.WriteLine($"- {subCategory.categoryName}");
            }
        }
     
    }
}
