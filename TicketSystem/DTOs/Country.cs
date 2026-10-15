namespace TicketSystem.DTOs
{
    public class Country
    {
        public string? name { get; set; }
        public string? nativeName { get; set; }

        public string? capital { get; set; }
        public string? region { get; set; }
        public string? subregion { get; set; }

        public long population { get; set; }
        public double? area { get; set; }

        public string? alpha2Code { get; set; }
        public string? alpha3Code { get; set; }

        public string? flag { get; set; }
        public CountryFlags? flags { get; set; }

        public List<string>? borders { get; set; }
        public List<string>? callingCodes { get; set; }
        public List<string>? timezones { get; set; }
        public List<string>? topLevelDomain { get; set; }

        public List<CountryCurrency>? currencies { get; set; }
        public List<CountryLanguage>? languages { get; set; }

        public string? FlagUrl
        {
            get
            {
                return flags?.svg;
            }
        }
    }

    public class CountryFlags
    {
        public string? svg { get; set; }
        public string? png { get; set; }
    }

    public class CountryCurrency
    {
        public string? code { get; set; }
        public string? name { get; set; }
        public string? symbol { get; set; }
    }

    public class CountryLanguage
    {
        public string? name { get; set; }
        public string? nativeName { get; set; }
    }
}