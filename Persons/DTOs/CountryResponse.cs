using Persons.Models;

namespace Persons.DTOs
{
    public record CountryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }



        public static explicit operator CountryResponse(Country country) 
        {
            CountryResponse countryResponse = new CountryResponse()
            {
                Id = country.Id,
                Name = country.Name
            };


            return countryResponse;
        }

    }
}
