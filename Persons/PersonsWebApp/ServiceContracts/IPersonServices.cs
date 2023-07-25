using PersonsWebApp.DTOs;
using PersonsWebApp.Enums;

namespace PersonsWebApp.ServiceContracts;

public interface IPersonServices
{
    /// <summary>
    /// gets a specific person whose Id equals to the given Id
    /// </summary>
    /// <param name="personId">Id of the person you wanna return</param>
    /// <returns>returns a personResponse of the person whose Id equals to the given Id.
    ///           If Id is incorrect ,throws agruementException.
    ///           IfId is null ,throws arguementNullException. </returns>
    PersonResponse GetPersonById(Guid? personId);


    /// <summary>
    /// gets all persons exist
    /// </summary>
    /// <returns>returns a collection of personseResponse of the existing persons</returns>
    IEnumerable<PersonResponse> GetAllPersons();
    

    /// <summary>
    /// add a person to persons collection
    /// </summary>
    /// <param name="personAddRequest">a person to be added to persons collection</param>
    /// <returns>returns a personResponse after adding the person to the collection.
    ///          Validate person data ,and if there are invalid data throws arguementException.</returns>
    PersonResponse AddPerson(PersonRequest? personAddRequest);


    /// <summary>
    /// Update an existing person with a new data
    /// </summary>
    /// <param name="personId">Id of the person you wanna update</param>
    /// <param name="personRequest">the new person data you wanna replace the old one with it</param>
    /// <returns>returns a personRespone after updatin the existing persons.
    ///           if the personId is incorrect or the new person data is invalid ,throws arguementException</returns>
    PersonResponse UpdatePerson(Guid? personId, PersonRequest? personRequest);


    /// <summary>
    /// delete a person frpm the collection whose Id equals the given Id
    /// </summary>
    /// <param name="personId">the Id of the person you wanna delete</param>
    /// <returns>returns true if it's actually deleted, otherwise returns false</returns>
    bool DeletePerson(Guid? personId);


    /// <summary>
    /// gets a subset collection of persons filtered by a specific property and a value
    /// </summary>
    /// <param name="searchBy">the name of the property you wanna search by</param>
    /// <param name="searchText">the value of the property you wanna search by</param>
    /// <returns>returns a subset collection of persons filtered by a specific property and a value.
    ///          If the searchText is empty ,it returns all collecion</returns>
    IEnumerable<PersonResponse> GetFilteredPersons(string searchBy ,string? searchText);

    /// <summary>
    /// sorts a collection of persons based on a property and value 
    /// </summary>
    /// <param name="persons">persons collection you wanna sort</param>
    /// <param name="sortBy">the property you wanna sort the collection by</param>
    /// <param name="searchText">the value that filter the collection</param>
    /// <param name="sortOptions">Asc or Desc</param>
    /// <returns>returns a collection of personResponse after sorting it by a specific property and value</returns>
    IEnumerable<PersonResponse> GetSortedPersons(IEnumerable<PersonResponse> persons, string sortBy,
                                                string? searchText, sortOptions sortOptions);

}
