namespace SOLID.Test
{
    public class BasketBuilder
    {
        private Book[] _books = {};

        public static BasketBuilder ABasket()
        {
            return new BasketBuilder();
        }

        public BasketBuilder With(params Book[] books)
        {
            _books = books;
            return this;
        }

        public Basket Build()
        {
            var basket = new Basket();
            AddBooksTo(basket);
            return basket;
        }

        private void AddBooksTo(Basket basket)
        {
            foreach (var book in _books)
            {
                basket.Add(book);
            }
        }
    }
}