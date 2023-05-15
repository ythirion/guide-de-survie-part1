using Application.Domain.Book;
using Application.Domain.Country;
using Application.Purchase;
using Application.Report;
using Application.Tests.Storage;
using FluentAssertions;
using Xunit;

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
        public void Test_Data_Builders_Constraint_Converts_total_amount_to_usd()
        {
            // Using the Test Data Builder pattern:
            // Instantiate a ReportGenerator
            // It needs to use a data source that contains one invoice in a non-USD currency
            // Assert that the amount returned by ReportGenerator is converted to USD currency
            //
            // Regarding the data source, take a look at MainRepository: it'll allow you to plug a test data source to ReportGenerator
            // Don't forget to reset the data source at the end of your test!
        }
    }
}