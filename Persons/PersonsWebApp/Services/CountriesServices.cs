using PersonsWebApp.DTOs;
using PersonsWebApp.Helper;
using PersonsWebApp.Models;
using PersonsWebApp.ServiceContracts;

namespace PersonsWebApp.Services;

public class CountriesServices : ICountriesServices
{

    private readonly List<Country> _countries;
    public CountriesServices(bool initialize =true)
    {
        _countries = new List<Country>();

        if (initialize)
        {
            _countries.AddRange(new List<Country>()
            {
                new Country()
                {
                    Id = Guid.Parse("B2E49413-2AC7-409D-9E8B-4D8D12714821") , Name ="USA"
                },
                 new Country()
                {
                    Id = Guid.Parse("29F50A60-9705-4393-87B0-2B4B9CFCF436") , Name ="UK"
                },
                new Country()
                {
                    Id = Guid.Parse("B195C6E7-9EE1-4FEB-93F5-AB2F69F5C54F") , Name ="Egypt"
                },
                new Country()
                {
                    Id = Guid.Parse("71377960-3362-4057-B42A-D5404D3799D7") , Name ="Saudia Arabia"
                },
                new Country()
                {
                    Id = Guid.Parse("DB1A7D2E-98AB-431E-B1F5-70632A423A0F") , Name ="Canada"
                },
            });
        }
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
