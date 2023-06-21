using Persons.DTOs;
using Persons.Models;

namespace Persons.Services;

public class CountriesService : ICountriesService
{
    private readonly List<Country> _countries;

    public CountriesService()
    {
        _countries = new List<Country>();
    }

    public CountryResponse AddCountry(CountryAddRequest? countryAddRequest)
    {
        ArgumentNullException.ThrowIfNull(countryAddRequest, nameof(countryAddRequest));

        ValidationHelper.Validate(countryAddRequest);

        Country country = (Country)countryAddRequest;

        if( _countries.Contains(country))
        {
            throw new ArgumentException(nameof(country) ,"Country is already exist");
        }

        _countries.Add(country);

        CountryResponse countryResponse = (CountryResponse) country;    

        return countryResponse;

    }

    public IEnumerable<CountryResponse> GetAllCountries()
    {
        if( _countries.Count == 0)
        {
            return Enumerable.Empty<CountryResponse>();
        }

        IEnumerable<CountryResponse> countriesResponse = _countries.Select(country => (CountryResponse)country);

        return countriesResponse;
    }

    public CountryResponse GetCountryById(Guid? countryId)
    {
        ArgumentNullException.ThrowIfNull(countryId , nameof(countryId));

        Country? country =_countries.SingleOrDefault(country => country.Id == countryId);

        if(country == null)
        {
            throw new ArgumentException("Id is incorrect");
        }

        return (CountryResponse) country;

    }

    public int CountriesCount()
    {
        return _countries.Count;
    }




}
