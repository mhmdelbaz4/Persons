using Persons.DTOs;
using Persons.Services;
using System;
using System.Collections.Generic;

namespace PersonsTest;

public class CountriesServiceTest
{
    private readonly ICountriesService _countriesService;

    public CountriesServiceTest()
    {
        _countriesService =new CountriesService(false);
    }


    #region AddCountry

    //when countryAddRequest is null ,it should throw ArguementNullException
    [Fact]
    public void AddRequest_CountryIsNull()
    {

        CountryAddRequest? countryAddRequest = null;

        Assert.Throws<ArgumentNullException>(() =>
        {
            _countriesService.AddCountry(countryAddRequest);
        });
    }

    //when countryAddRequest.Name is null ,it should throw ArguementException
    [Fact]
    public void AddRequest_CountryNameIsNull()
    {

        CountryAddRequest? countryAddRequest = new CountryAddRequest() { Name = null };

        Assert.Throws<ArgumentException>(() =>
        {
            _countriesService.AddCountry(countryAddRequest);
        });
    }

    //when adding duplicate countries ,it should throw AgruementException
    [Fact]
    public void AddRequest_DuplicateCountries()
    {

        CountryAddRequest? countryAddRequest1 = new CountryAddRequest() { Name = "UK" };
        CountryAddRequest? countryAddRequest2 = new CountryAddRequest() { Name = "UK" };



        Assert.Throws<ArgumentException>(() =>
        {
            _countriesService.AddCountry(countryAddRequest1);
            _countriesService.AddCountry(countryAddRequest2);
        });

    }


    //when Add countryAddRequest with correct properties ,it should be added successfully

    [Fact]
    public void AddRequest_ProperDetalis()
    {

        CountryAddRequest? countryAddRequest = new CountryAddRequest() { Name = "USA" };
        
        CountryResponse countryResponse =_countriesService.AddCountry(countryAddRequest);

        IEnumerable<CountryResponse> allCountries = _countriesService.GetAllCountries();

        Assert.True(countryResponse.Id != Guid.Empty);

        Assert.Contains(countryResponse , allCountries);
    }
    #endregion


    #region GetAllCountries
    //when a countries collection is empty, it should return an empty enumerable
    [Fact]
    public void AddRequest_CollectionIsEmpty()
    {
        List<CountryResponse> allCountries = _countriesService.GetAllCountries().ToList();

        if(_countriesService.CountriesCount() == 0)
        {
            Assert.Empty(allCountries);
        }
    }


    //when adding collection of countries ,it should be retuned 
    [Fact]
    public void AddRequest_AddProperCollection()
    {
        CountryAddRequest countryAddRequest1 = new CountryAddRequest() { Name = "USA" };
        CountryAddRequest countryAddRequest2 = new CountryAddRequest() { Name = "UK" };
        CountryAddRequest countryAddRequest3 = new CountryAddRequest() { Name = "Egypt" };


        List<CountryAddRequest> countryAddRequestList = new List<CountryAddRequest>()
        { countryAddRequest1, countryAddRequest2 ,countryAddRequest3};


        List<CountryResponse> expectedCountryResponseList = new List<CountryResponse>();


        foreach (CountryAddRequest countryAddRequest in countryAddRequestList)
        {
            expectedCountryResponseList.Add(_countriesService.AddCountry(countryAddRequest));
        }

        List<CountryResponse> actualCountryResponseList = _countriesService.GetAllCountries().ToList();

        foreach (CountryResponse countryResponse in expectedCountryResponseList)
        {
            Assert.Contains(countryResponse, expectedCountryResponseList);
        }

    }

    #endregion


    #region GetCountryById
    [Fact]
    //when Id is null ,it should throws arguementNullException
    public void GetCountryById_IdIsNull()
    {
        Guid? countryId = null;

        Assert.Throws<ArgumentNullException>(() =>
        {
            _countriesService.GetCountryById(countryId);
        });
    }

    [Fact]
    //when Id is invalid ,it should throws arguementException
    public void GetCountryById_InvalidId()
    {
        Guid countryId = Guid.NewGuid();

        Assert.Throws<ArgumentException>(() =>
        {
            _countriesService.GetCountryById(countryId);
        });
    }

    [Fact]
    //when Id is invalid ,it should throws arguementException
    public void GetCountryById_CorrectId()
    {
        CountryAddRequest countryAddRequest = new CountryAddRequest() { Name = "UK" };

        CountryResponse expectedCountryResponse = _countriesService.AddCountry(countryAddRequest);

        CountryResponse actualCountryResponse = _countriesService.GetCountryById(expectedCountryResponse.Id);

        Assert.Equal(expectedCountryResponse, actualCountryResponse);
    }

    #endregion


}
