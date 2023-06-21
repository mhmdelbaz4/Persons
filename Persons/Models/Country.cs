using Persons.DTOs;

namespace Persons.Models;

public class Country
{
    public Guid Id { get; set; }

    public string Name { get; set; }


    public static explicit operator Country(CountryAddRequest countryAddRequest)
    {
        Country country = new Country()
        {
            Id = Guid.NewGuid(),
            Name = countryAddRequest.Name
        };

        return country;
    }


    public override bool Equals(object? obj)
    {
        Country? country = obj as Country;

        if(country == null)
        {
            return false;
        }

        if(country.GetType() != typeof(Country))
        {
            return false;
        }

        bool isEqual = country.Name == this.Name;

        return isEqual;

    }

}
