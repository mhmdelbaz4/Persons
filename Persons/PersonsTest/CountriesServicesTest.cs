using PersonsWebApp.DTOs;
using PersonsWebApp.ServiceContracts;
using PersonsWebApp.Services;
using System;
using System.Diagnostics.Metrics;

namespace PersonsTest;

public class CountriesServicesTest
{
    private readonly ICountriesServices _countriesServices;

    public CountriesServicesTest()
    {
        _countriesServices = new CountriesServices(false);
    }


    #region AddCountryTest


    //case 1 : country is null
    [Fact]
    public void AddCountry_CountryIsNull()
    {
        CountryAddRequest? countryAddRequest = null;

        Assert.Throws<ArgumentNullException>(() =>
        {
            _countriesServices.AddCountry(countryAddRequest);   
        }); 

    }

    //case 2 : country name is null
    [Fact]
    public void AddCountry_CountryNameIsNull()
    {
        CountryAddRequest? countryAddRequest = new CountryAddRequest()
        {
            Name = null
        };

        Assert.Throws<ArgumentException>(() =>
        {
            _countriesServices.AddCountry(countryAddRequest);
        });
    }

    //case 3 : country name is incorrect
    [Fact]
    public void AddCountry_CountryNameLengthIsIncorrect()
    {
        CountryAddRequest? countryAddRequest = new CountryAddRequest()
        {
            Name = "A"
        };

        Assert.Throws<ArgumentException>(() =>
        {
            _countriesServices.AddCountry(countryAddRequest);
        });

    }

    //case 4 : country name is duplicated
    [Fact]
    public void AddCountry_DuplicateName()
    {
        CountryAddRequest? countryAddRequest1 = new CountryAddRequest()
        {
            Name = "USA"
        };

        CountryAddRequest? countryAddRequest2 = new CountryAddRequest()
        {
            Name = "USA"
        };

        Assert.Throws<ArgumentException>(() =>
        {
            _countriesServices.AddCountry(countryAddRequest1);
            _countriesServices.AddCountry(countryAddRequest2);
        });

    }

    //case 5 : correct details
    [Fact]
    public void AddCountry_ProperDetails()
    {
        CountryAddRequest? countryAddRequest = new CountryAddRequest()
        {
            Name = "UK" 
        };

        CountryResponse? countryResponse = _countriesServices.AddCountry(countryAddRequest);

        Assert.True(countryResponse?.Id != Guid.Empty);

    }

    #endregion

    #region GetAllCountries

    //case 1: countries collection is empty
    [Fact]
    public void GetAllCountries_CountriesAreEmpty()
    {
        IEnumerable<CountryResponse> actualcountryResponseList;

        actualcountryResponseList = _countriesServices.GetAllCountries();

        Assert.True(actualcountryResponseList == Enumerable.Empty<CountryResponse>());        
        
    }


    //case 2: countries collection is not empty
    [Fact]
    public void GetAllCountries_CountriesAreNotEmpty()
    {
        CountryAddRequest countryAddRequest1 = new CountryAddRequest()
        {
            Name = "USA"
        };

        CountryAddRequest countryAddRequest2 = new CountryAddRequest()
        {
            Name = "UK"
        };

        List<CountryAddRequest> countryAddRequestList = new List<CountryAddRequest> 
        {
            countryAddRequest1, countryAddRequest2 
        };

        List<CountryResponse> expectedCountryResponseList = new List<CountryResponse>();

        foreach (CountryAddRequest countryAddRequest in countryAddRequestList)
        {
            expectedCountryResponseList.Add(_countriesServices.AddCountry(countryAddRequest) !);
        }

        List<CountryResponse> actualcountryResponseList = _countriesServices.GetAllCountries().ToList();

        foreach (CountryResponse countryResponse in expectedCountryResponseList)
        {
            Assert.Contains(countryResponse, actualcountryResponseList);
        }

    }
    #endregion

    #region GetCountryById

    //case 1: when Id is null
    [Fact]
    public void GetCountryById_IdIsNull()
    {
        Guid? countryId = null;

        Assert.Throws<ArgumentNullException>( () =>
        {
            _countriesServices.GetCountryById(countryId);
        });
    }

    //case 2: when Id is incorrect
    [Fact]
    public void GetCountryById_IdIsIncorrect()
    {
        Guid? countryId = Guid.NewGuid();

        Assert.Throws<ArgumentException>(() =>
        {
            _countriesServices.GetCountryById(countryId);
        });
    }

    //case 3: correct Id
    [Fact]
    public void GetCountryById_IdIsCorrect()
    {
        CountryAddRequest countryAddRequest = new CountryAddRequest()
        {
            Name = "USA"
        };
        
        CountryResponse? expectedCountryResponse = _countriesServices.AddCountry(countryAddRequest);

        CountryResponse? actualCountryResponse = _countriesServices.GetCountryById(expectedCountryResponse?.Id);

        Assert.Equal(expectedCountryResponse, actualCountryResponse);

    }

    #endregion


}
