using System.Collections.Generic;
using Application.Domain.Book;
using Application.Domain.Country;

namespace Application.Tests.Builders
{
    public class NovelTestDataBuilder
    {
        private double _price = 10;
        public static NovelTestDataBuilder ANovel() => new();

        public NovelTestDataBuilder Costing(double price)
        {
            _price = price;
            return this;
        }

        public Novel Build()
            => new(Faker.Lorem.Paragraph(),
                _price,
                new Author(Faker.Name.FullName(), Countries.France),
                Language.French,
                new List<Genre>
                {
                    Genre.Romance
                });
    }
}