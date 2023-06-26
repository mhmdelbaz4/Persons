using Persons.DTOs;

namespace Persons.Services;

public interface ICountriesService
{

    /// <summary>
    /// gets all existing countries from Countries Collection
    /// </summary>
    /// <returns>returns all existing countries</returns>
    IEnumerable<CountryResponse> GetAllCountries();


    /// <summary>
    /// gets a specific country that matches the given Id
    /// </summary>
    /// <param name="countryId">Id of the country</param>
    /// <returns>returns a country whose Id matches the given Id, and if there is no country matches Id it will throw ArguementException </returns>
    CountryResponse GetCountryById(Guid? countryId);


    /// <summary>
    /// Add a new country to the countries collection
    /// </summary>
    /// <param name="countryAddRequest">accepts a countryAddRequest to be added</param>
    /// <returns>returns  CountryResponse after adding it to the collection (including newly generated ID), if it faild it throws an Exception</returns>
    CountryResponse AddCountry(CountryAddRequest? countryAddRequest);

    /// <summary>
    /// gets number of countries in the collection
    /// </summary>
    /// <returns>returns number of countries stored in the coolection</returns>
    int CountriesCount();

}
