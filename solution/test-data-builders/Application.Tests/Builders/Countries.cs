using Application.Domain.Country;

namespace Application.Tests.Builders
{
    public static class Countries
    {
        public static readonly Country France = new("France", Currency.Euro, Language.French);
        public static readonly Country Usa = new("USA", Currency.UsDollar, Language.English);
    }
}