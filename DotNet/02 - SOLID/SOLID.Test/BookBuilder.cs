namespace SOLID.Test
{
    public class BookBuilder
    {
        private const string A_NAME = "book name";

        private readonly BookType _bookType;
        private double _price;

        private BookBuilder(BookType bookType)
        {
            _bookType = bookType;
        }

        public static BookBuilder ACookingBook()
        {
            return new BookBuilder(BookType.COOKING);
        }

        public static BookBuilder AnITBook()
        {
            return new BookBuilder(BookType.IT);
        }

        public static BookBuilder AFantasyBook()
        {
            return new BookBuilder(BookType.FANTASY);
        }

        public static BookBuilder ATravelBook()
        {
            return new BookBuilder(BookType.TRAVEL);
        }

        public BookBuilder Costing(double price)
        {
            _price = price;
            return this;
        }

        public Book Build()
        {
            return new Book(A_NAME, _bookType, _price);
        }

    }
}