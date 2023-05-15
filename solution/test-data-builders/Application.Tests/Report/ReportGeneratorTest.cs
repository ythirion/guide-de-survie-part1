using Application.Domain.Book;
using Application.Domain.Country;
using Application.Purchase;
using Application.Report;
using Application.Tests.Storage;
using FluentAssertions;
using Xunit;
using static Application.Tests.Builders.Countries;
using static Application.Tests.Builders.PurchasedBookTestDataBuilder;
using static Application.Tests.Builders.InvoiceTestDataBuilder;
using static Application.Tests.Report.ReportGeneratorTestDataBuilder;

namespace Application.Tests.Report
{
    public class ReportGeneratorTest
    {
        private readonly InMemoryRepository _inMemoryRepository;

        public ReportGeneratorTest()
        {
            _inMemoryRepository = new InMemoryRepository();
            MainRepository.Override(_inMemoryRepository);
        }

        [Fact]
        public void Converts_total_amount_to_usd()
        {
            // Arrange
            var reportGenerator = new ReportGenerator();
            var book = new EducationalBook(
                "Clean Code",
                25,
                new Author(
                    "Uncle Bob",
                    new Country("USA", Currency.UsDollar, Language.English)
                ),
                Language.English,
                Category.Computer);

            var purchasedBook = new PurchasedBook(book, 2);

            var invoice = new Invoice(
                "John Doe",
                new Country(
                    "USA",
                    Currency.UsDollar,
                    Language.English
                )
            );

            // Act
            invoice.AddPurchasedBook(purchasedBook);
            _inMemoryRepository.AddInvoice(invoice);

            // Assert
            reportGenerator.GetTotalAmount().Should().Be(57.5);
            reportGenerator.GetNumberOfIssuedInvoices().Should().Be(1);
            reportGenerator.GetTotalSoldBooks().Should().Be(2);
        }

        [Fact]
        public void Converts_total_amount_to_usd_with_test_data_builders()
        {
            var reportGenerator =
                AReport(_inMemoryRepository)
                    .Containing(
                        AnInvoice()
                            .Containing(
                                ANovel(_ => _.Costing(12.99)).InQuantity(2),
                                AnEducationalBook(_ => _.Costing(29.87)).InQuantity(7)
                            )
                            .From(France)
                    )
                    .Build();

            reportGenerator.GetTotalAmount().Should().Be(334.97);
            reportGenerator.GetNumberOfIssuedInvoices().Should().Be(1);
            reportGenerator.GetTotalSoldBooks().Should().Be(9);
        }
    }
}