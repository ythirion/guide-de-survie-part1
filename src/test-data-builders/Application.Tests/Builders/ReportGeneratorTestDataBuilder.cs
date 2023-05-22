using Application.Report;
using Application.Tests.Builders;
using Application.Tests.Storage;

namespace Application.Tests.Report
{
    public class ReportGeneratorTestDataBuilder
    {
        private readonly InMemoryRepository _invoiceRepository;

        private ReportGeneratorTestDataBuilder(InMemoryRepository invoiceRepository) =>
            _invoiceRepository = invoiceRepository;

        public static ReportGeneratorTestDataBuilder AReport(InMemoryRepository inMemoryRepository)
            => new ReportGeneratorTestDataBuilder(inMemoryRepository);

        public ReportGeneratorTestDataBuilder Containing(InvoiceTestDataBuilder anInvoice)
        {
            _invoiceRepository.AddInvoice(anInvoice.Build());
            return this;
        }

        public ReportGenerator Build() => new ReportGenerator();
    }
}