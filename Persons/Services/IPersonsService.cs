using Persons.DTOs;
using Persons.Enums;

namespace Persons.Services;

public interface IPersonsService
{

    /// <summary>
    /// gets all persons stored in the collection
    /// </summary>
    /// <returns>returns collection of existing persons</returns>
    IEnumerable<PersonResponse> GetAllPersons();

    /// <summary>
    /// returns the person whose Id matches the given Id
    /// </summary>
    /// <param name="personId">person Id</param>
    /// <returns>retruns a person whose Id matches the given Id ,if Id doesn't match any existing persons throw an exception</returns>
    PersonResponse GetPersonById(Guid? personId);


    /// <summary>
    /// gets a list of persons after filtered it by a specific property and value
    /// </summary>
    /// <param name="sortBy">the property name to sort the list based on</param>
    /// <param name="searchText">the value of the property</param>
    /// <returns>returns a list of persons after filtering the list based on a specific property </returns>
    IEnumerable<PersonResponse> GetFilteredPersons(string? searchBy, string? searchText);



    IEnumerable<PersonResponse> GetSortedPersons(string? sortBy, SortOptions sortOption);

    /// <summary>
    /// Add person to persons collection
    /// </summary>
    /// <param name="personAddRequest">PersonAddRequest objects</param>
    /// <returns>returns PersonResponse object if it added successfully ,if not throws exception</returns>

    PersonResponse AddPerson(PersonAddRequest? personAddRequest);


    /// <summary>
    /// update a specific person in the collection whose id matches the update Person object Id
    /// </summary>
    /// <param name="personUpdateRequest">person update object</param>
    /// <returns>retruns an object of person Response if updation completed successfully ,if not throws an exception</returns>
    PersonResponse UpdatePerson(PersonUpdateRequest? personUpdateRequest);
    
    /// <summary>
    /// delete a person from the collection whose Id matches the given Id
    /// </summary>
    /// <param name="personId">Id of the person you wanna delete</param>
    /// <returns>returns true if deletion completed successfully, if not returns false</returns>
    bool DeletePerson(Guid? personId);

    
    /// <summary>
    /// gets number of persons in the collection
    /// </summary>
    /// <returns>returns number of persons in the collection</returns>
    int PersonsCount();




}
