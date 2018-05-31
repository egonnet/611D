using System;
using System.Collections.Generic;
using NFluent;
using NUnit.Framework;

namespace SOLID.Test
{
    [TestFixture]
    public class BasketShould
    {
        [Test]
        [ExpectedException(typeof (NotSupportedException))]
        public void
            Return_an_unmodifiable_list_of_books()
        {
            BasketBuilder.ABasket().Build().Books().Add(BookBuilder.ACookingBook().Build());
        }


        private Basket emptyBasket()
        {
            return new Basket();
        }

        [Test]
        public void
            Calculate_the_total_price_with_no_discount_when_containing_multiple_books()
        {
            var basket = BasketBuilder.ABasket()
                .With(
                    BookBuilder.ACookingBook().Costing(10.0).Build(),
                    BookBuilder.AnITBook().Costing(30.0).Build(),
                    BookBuilder.AnITBook().Costing(20.0).Build(),
                    BookBuilder.ATravelBook().Costing(20.0).Build())
                .Build();

            Check.That(basket.FullPrice()).IsEqualTo(80.0);
        }

        [Test]
        public void
            Combine_10_percent_discount_for_1_IT_book_and_40_percent_discount_for_4_Travel_books()
        {
            var basket = BasketBuilder.ABasket()
                .With(
                    BookBuilder.AnITBook().Costing(10.0).Build(),
                    BookBuilder.ATravelBook().Costing(30.0).Build(),
                    BookBuilder.ATravelBook().Costing(10.0).Build(),
                    BookBuilder.ATravelBook().Costing(20.0).Build(),
                    BookBuilder.ATravelBook().Costing(10.0).Build())
                .Build();

            Check.That(basket.PriceWithDiscount()).IsEqualTo(51.0);
        }

        [Test]
        public void
            Give_10_percent_discount_for_IT_books_when_containing_one_of_them()
        {
            var basket = BasketBuilder.ABasket()
                .With(
                    BookBuilder.AnITBook().Costing(10.0).Build())
                .Build();

            Check.That(basket.PriceWithDiscount()).IsEqualTo(9.0);
        }


        [Test]
        public void
            Give_10_percent_discount_for_IT_books_when_containing_two_of_them()
        {
            var basket = BasketBuilder.ABasket()
                .With(
                    BookBuilder.AnITBook().Costing(30.0).Build(),
                    BookBuilder.AnITBook().Costing(10.0).Build())
                .Build();

            Check.That(basket.PriceWithDiscount()).IsEqualTo(36.0);
        }

        [Test]
        public void
            Give_30_percent_discount_for_IT_books_when_containing_multiple_books()
        {
            var basket = BasketBuilder.ABasket()
                .With(
                    BookBuilder.AnITBook().Costing(30.0).Build(),
                    BookBuilder.AnITBook().Costing(10.0).Build(),
                    BookBuilder.AnITBook().Costing(20.0).Build())
                .Build();

            Check.That(basket.PriceWithDiscount()).IsEqualTo(42.0);
        }

        [Test]
        public void
            Give_40_percent_discount_for_Travel_books_when_containing_more_than_three_of_them()
        {
            var basket = BasketBuilder.ABasket()
                .With(
                    BookBuilder.ATravelBook().Costing(30.0).Build(),
                    BookBuilder.ATravelBook().Costing(10.0).Build(),
                    BookBuilder.ATravelBook().Costing(20.0).Build(),
                    BookBuilder.ATravelBook().Costing(10.0).Build())
                .Build();

            Check.That(basket.PriceWithDiscount()).IsEqualTo(42.0);
        }

        [Test]
        public void
            Give_no_discount_when_book_is_not_eligible_for_a_discount()
        {
            var aBookWithNoDiscount = BookBuilder.ACookingBook().Costing(10.00).Build();
            var basket = BasketBuilder.ABasket().With(aBookWithNoDiscount).Build();

            Check.That(basket.PriceWithDiscount()).IsEqualTo(10.0);
            Check.That(basket.FullPrice()).IsEqualTo(10.0);
        }

        [Test]
        public void
            Not_give_discount_for_Travel_books_when_containing_less_than_four_of_them()
        {
            var basket = BasketBuilder.ABasket()
                .With(
                    BookBuilder.ATravelBook().Costing(30.0).Build(),
                    BookBuilder.ATravelBook().Costing(10.0).Build(),
                    BookBuilder.ATravelBook().Costing(20.0).Build())
                .Build();

            Check.That(basket.FullPrice()).IsEqualTo(60.0);
        }

        [Test]
        public void
            Return_total_price_of_zero_when_empty()
        {
            Check.That(emptyBasket().FullPrice()).IsEqualTo(0.0);
        }

        [Test]
        public void
            Return_zero_discount_when_empty()
        {
            Check.That(emptyBasket().PriceWithDiscount()).IsEqualTo(0.0);
        }
    }

}