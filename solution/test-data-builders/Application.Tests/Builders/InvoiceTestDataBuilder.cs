using System.Linq;
using Application.Domain.Country;
using Application.Purchase;

namespace Application.Tests.Builders
{
    public class InvoiceTestDataBuilder
    {
        private PurchasedBookTestDataBuilder[] _purchasedBooks;
        private Country _country;

        public static InvoiceTestDataBuilder AnInvoice() => new();

        public InvoiceTestDataBuilder Containing(params PurchasedBookTestDataBuilder[] purchasedBooks)
        {
            _purchasedBooks = purchasedBooks;
            return this;
        }

        public InvoiceTestDataBuilder From(Country country)
        {
            _country = country;
            return this;
        }

        public Invoice Build()
        {
            var invoice = new Invoice("John Doe", _country);
            invoice.AddPurchasedBooks(
                _purchasedBooks
                    .Select(builder => builder.Build())
                    .ToList()
            );
            return invoice;
        }
    }
}