using PersonsWebApp.Models;

namespace PersonsWebApp.DTOs;

/// <summary>
/// represents the response structure from country services
/// </summary>
public record CountryResponse
{
    public Guid Id { get; set; }

    public string? Name { get; set; }



    /// <summary>
    /// explicit casting from country to countryResponse
    /// </summary>
    /// <param name="country">accepts country object</param>
    
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
