using Application.Domain.Country;

namespace Application.Tests.Builders
{
    public static class Countries
    {
        public static readonly Country France = new Country("France", Currency.Euro, Language.French);
        public static readonly Country Usa = new Country("USA", Currency.UsDollar, Language.English);
    }
}