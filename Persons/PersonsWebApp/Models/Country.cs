using PersonsWebApp.DTOs;

namespace PersonsWebApp.Models;

/// <summary>
/// represents the country entity in the database
/// </summary>
public class Country
{
    public Guid Id { get; set; }

    public string? Name { get; set; }


    /// <summary>
    /// explict casting from countryAddRequest to country 
    /// </summary>
    /// <param name="countryAddRequest">accepts personAddRequst object</param>
    public static explicit operator Country(CountryAddRequest countryAddRequest)
    {
        Country country = new Country()
        {
            Id =Guid.NewGuid(),
            Name = countryAddRequest.Name
        };

        return country;

    }
}
