using System.Collections.Generic;
using Application.Domain.Book;
using Application.Domain.Country;

namespace Application.Tests.Builders
{
    public class NovelTestDataBuilder
    {
        private double _price = 10;
        public static NovelTestDataBuilder ANovel() => new NovelTestDataBuilder();

        public NovelTestDataBuilder Costing(double price)
        {
            this._price = price;
            return this;
        }

        public Novel Build()
            => new Novel("Le Horla",
                _price,
                new Author("Guy de Maupassant", Countries.France),
                Language.French,
                new List<Genre>
                {
                    Genre.Romance
                });
    }
}