using System;
using System.Collections.Generic;

namespace SOLID
{
    public class Basket
    {
        private readonly List<Book> _books = new List<Book>();

        public void Add(Book book)
        {
            _books.Add(book);
        }

        public IList<Book> Books()
        {
            return _books.AsReadOnly();
        }

        public double PriceWithDiscount()
        {
            double it_books_discount = 0;
            double travel_books_discount = 0;

            double number_of_it_books = 0;
            double number_of_travel_books = 0;

            double total_price_for_it_books = 0;
            double total_price_for_travel_books = 0;
            double total_price_for_other_books = 0;

            foreach (var book in _books)
            {
                if (BookType.IT.Equals(book.Type()))
                {
                    number_of_it_books += 1;
                    total_price_for_it_books += book.Price();
                }
                else if (BookType.TRAVEL.Equals(book.Type()))
                {
                    number_of_travel_books += 1;
                    total_price_for_travel_books += book.Price();
                }
                else
                {
                    total_price_for_other_books += book.Price();
                }
            }

            if (number_of_it_books > 2)
            {
                it_books_discount = 0.7; // 30% discount when buying more than 2 IT books
            }
            else if (number_of_it_books > 0)
            {
                it_books_discount = 0.9; // 10% discount when buying up to 2 IT books
            }

            if (number_of_travel_books > 3)
            {
                travel_books_discount = 0.6; // 40% discount when buying more than 3 travel books
            }

            if (travel_books_discount > 0)
            {
                total_price_for_travel_books *= travel_books_discount;
            }

            return ToDecimal(total_price_for_it_books*it_books_discount
                             + total_price_for_travel_books
                             + total_price_for_other_books);
        }

        public double FullPrice()
        {
            double price = 0;

            foreach (var book in _books)
            {
                price += book.Price();
            }
            return ToDecimal(price);
        }

        private double ToDecimal(double number)
        {
            return Math.Round(number*100)/100.0;
        }
    }
}