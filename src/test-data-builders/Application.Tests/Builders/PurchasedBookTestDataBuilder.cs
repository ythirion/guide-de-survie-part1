using System;
using Application.Domain.Book;
using Application.Purchase;

namespace Application.Tests.Builders
{
    public class PurchasedBookTestDataBuilder
    {
        private IBook _book;
        private int _quantity = 1;

        public PurchasedBookTestDataBuilder InQuantity(int quantity)
        {
            this._quantity = quantity;
            return this;
        }

        public PurchasedBook Build() => new PurchasedBook(_book, _quantity);

        private static PurchasedBookTestDataBuilder APurchasedBook() => new PurchasedBookTestDataBuilder();

        public static PurchasedBookTestDataBuilder ANovel(Action<NovelTestDataBuilder> settings)
        {
            var novel = NovelTestDataBuilder.ANovel();
            settings(novel);

            return APurchasedBook()
                .Of(novel.Build());
        }

        public static PurchasedBookTestDataBuilder AnEducationalBook(Action<EducationalBookTestDataBuilder> settings)
        {
            var educationalBook = EducationalBookTestDataBuilder.AnEducationalBook();
            settings(educationalBook);

            return APurchasedBook().Of(educationalBook.Build());
        }

        private PurchasedBookTestDataBuilder Of(IBook book)
        {
            _book = book;
            return this;
        }
    }
}