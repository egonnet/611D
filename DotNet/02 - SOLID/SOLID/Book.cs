namespace SOLID
{
    public class Book
    {
        private readonly string _name;
        private readonly double _price;
        private readonly BookType _type;

        public Book(string name, BookType type, double price)
        {
            _name = name;
            _type = type;
            _price = price;
        }

        public string Name()
        {
            return _name;
        }

        public BookType Type()
        {
            return _type;
        }

        public double Price()
        {
            return _price;
        }


        public override string ToString()
        {
            return "Book(" +
                   "_name='" + _name + '\'' +
                   ", type='" + _type + '\'' +
                   ", price='" + _price + '}';
        }
    }
}