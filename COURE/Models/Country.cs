namespace COURE.Models
{
    public class Country
    {
       public int Id { get; set; }
       public string Name { get; set; }
       public string CountryIso { get; set; }
       public int CountryCode { get; set; }

       public ICollection<CountryDetail> CountryDetails { get; set; } = new List<CountryDetail>();      
    }
}
