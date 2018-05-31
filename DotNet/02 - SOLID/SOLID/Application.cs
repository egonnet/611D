using System.Collections.Generic;

namespace SOLID
{
    public class Application
    {
        private static void Main(string[] args)
        {
            Book fantasy_book_1 = new Book("The Hobbit", BookType.FANTASY, 20.00);
            Book fantasy_book_2 = new Book("Game of Thrones", BookType.FANTASY, 15.00);
            Book it_book_1 = new Book("Software Craftsmanship", BookType.IT, 18.00);
            Book it_book_2 = new Book("GOOS", BookType.IT, 25.00);
            Book it_book_3 = new Book("Clean Code", BookType.IT, 28.00);
            Book travel_book_1 = new Book("Notes from a Small Island", BookType.TRAVEL, 10.00);
            Book cooking_book_1 = new Book("Brazilian Flavous", BookType.COOKING, 10.00);


            Basket basket = new Basket();
            basket.Add(fantasy_book_1);
            basket.Add(fantasy_book_2);
            basket.Add(it_book_1);
            basket.Add(it_book_2);
            basket.Add(it_book_3);
            basket.Add(travel_book_1);
            basket.Add(cooking_book_1);

            foreach (var book in basket.Books())
            {
                Println(book);
            }
        }

        private static void Println(string text)
        {
            System.Console.WriteLine(text);
        }

        private static void Println(Book book)
        {
            Println(book.ToString());
        }
    }
}