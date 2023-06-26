using Persons.DTOs;
using Persons.Models;

namespace Persons.Services;


public class CountriesService : ICountriesService
{
    private readonly List<Country> _countries;

    public CountriesService(bool initialize = true)
    {
        _countries = new List<Country>();
    
        if(initialize)
        {
            _countries.Add(new Country() { Id = Guid.Parse("8775DA8E-36CA-4955-A1B4-91720341BEBB"), Name = "USA" });

            _countries.Add(new Country() { Id = Guid.Parse("FD7CF373-9B82-407B-A870-0FEC07F9A7A1"), Name = "UK" });

            _countries.Add(new Country() { Id = Guid.Parse("556125E7-2CBF-4D50-B1EE-605174794860"), Name = "Canada" });

            _countries.Add(new Country() { Id = Guid.Parse("110695FC-B97A-4869-BC43-370AF10F7E46"), Name = "Egypt" });

            _countries.Add(new Country() { Id = Guid.Parse("7455AEE4-5668-4FE9-BDB2-44CFE3DCCC15"), Name = "France" });
        }

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
