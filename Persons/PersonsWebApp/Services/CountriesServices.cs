using PersonsWebApp.DTOs;
using PersonsWebApp.Helper;
using PersonsWebApp.Models;
using PersonsWebApp.ServiceContracts;

namespace PersonsWebApp.Services;

public class CountriesServices : ICountriesServices
{

    private readonly List<Country> _countries;
    public CountriesServices()
    {
        _countries = new List<Country>();        
    }
    public CountryResponse? AddCountry(CountryAddRequest? countryAddRequest)
    {
        ArgumentNullException.ThrowIfNull(countryAddRequest, nameof(countryAddRequest));

        ModelValidation.Validate(countryAddRequest);

        bool isExist = _countries.Any(country => country.Name == countryAddRequest.Name);

        if(isExist)
        {
            throw new ArgumentException("This country name is already exists");
        }

        Country country = (Country)countryAddRequest;

        _countries.Add(country);

        CountryResponse countryResponse = (CountryResponse)country;

        return countryResponse;
    }

    public IEnumerable<CountryResponse> GetAllCountries()
    {
        if(_countries.Count == 0)
        {
            return Enumerable.Empty<CountryResponse>();
        }

        IEnumerable<CountryResponse> countryResponseList = _countries.Select(country => (CountryResponse) country);

        return countryResponseList;
    }

    public CountryResponse? GetCountryById(Guid? countryId)
    {
        ArgumentNullException.ThrowIfNull(countryId, nameof(countryId));

        Country? country = _countries.FirstOrDefault(country => country.Id == countryId);

        if(country == null)
        {
            throw new ArgumentException("Country Id is incorrect");
        }

        return (CountryResponse)country;

    }
}
