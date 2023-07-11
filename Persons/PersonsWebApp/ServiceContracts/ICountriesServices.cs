using PersonsWebApp.DTOs;

namespace PersonsWebApp.ServiceContracts;


/// <summary>
/// represents the services applicable on countries 
/// </summary>
public interface ICountriesServices
{

    /// <summary>
    /// gets all countries stored in database
    /// </summary>
    /// <returns>returns collection of countryResponse</returns>
    IEnumerable<CountryResponse> GetAllCountries();


    /// <summary>
    /// gets a country whose Id matches the input Id
    /// </summary>
    /// <param name="countryId">Id of the required country</param>
    /// <returns>returns a countryResponse whose id equal the given id ,and if no countries matches this Id, returns null</returns>
    CountryResponse? GetCountryById(Guid? countryId);

    /// <summary>
    /// add a new country to countries stored in the database
    /// </summary>
    /// <param name="countryAddRequest">the country you wannna add</param>
    /// <returns>returns countryresponse if it successfully added ,otherwise returns null</returns>

    CountryResponse? AddCountry(CountryAddRequest? countryAddRequest);

}
