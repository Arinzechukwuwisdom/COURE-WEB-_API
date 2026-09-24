namespace COURE.Dtos
{
    public class CountryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CountryIso { get; set; }
        public int CountryCode { get; set; }

        public CountryDetailDto? CountryDetail { get; set; }
    }
}
