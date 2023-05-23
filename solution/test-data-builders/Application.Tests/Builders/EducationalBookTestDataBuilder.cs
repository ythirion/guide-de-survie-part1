using Application.Domain.Book;
using Application.Domain.Country;

namespace Application.Tests.Builders
{
    public class EducationalBookTestDataBuilder
    {
        private double _price = 10;

        public EducationalBookTestDataBuilder Costing(double price)
        {
            _price = price;
            return this;
        }

        public EducationalBook Build()
            => new("Clean Code",
                _price,
                new Author("Uncle Bob", Countries.Usa),
                Language.English,
                Category.Computer
            );

        public static EducationalBookTestDataBuilder AnEducationalBook() => new();
    }
}