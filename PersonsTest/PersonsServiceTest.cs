using Persons.DTOs;
using Persons.Services;
using System;
using System.Collections.Generic;
using Xunit.Abstractions;
using Xunit.Sdk;
using Persons.Enums;

namespace PersonsTest;

public class PersonsServiceTest
{
    private readonly ICountriesService _countriesService;
    private readonly IPersonsService _personsService;
    private readonly ITestOutputHelper _outputHelper;


    public PersonsServiceTest()
    {
        _countriesService = new CountriesService(false);
        _personsService = new PersonsService(false);
        _outputHelper = new TestOutputHelper();
    }

    #region AddPerson
    //case 1: if person is null
    [Fact]
    public void AddPerson_PersonIsNull()
    {
        PersonAddRequest? personAddRequest = null;

        Assert.Throws<ArgumentNullException>(() =>
        {
            _personsService.AddPerson(personAddRequest);
        });
    
    }
    

    //case 2: if person name is null
    [Fact]
    public void AddPerson_PersonNameIsNull()
    {
        PersonAddRequest personAddRequest = CreatePersonAddRequest();
        personAddRequest.Name = null;

        Assert.Throws<ArgumentException>(() =>
        {
            _personsService.AddPerson(personAddRequest);
        });
    }
    

    //case 3: if person email is null
    [Fact]
    public void AddPerson_PersonEmailIsNull()
    {
        PersonAddRequest personAddRequest = CreatePersonAddRequest();
        personAddRequest.Email = null;

        Assert.Throws<ArgumentException>(() =>
        {
            _personsService.AddPerson(personAddRequest);
        });
    }


    //case 5 : if person properties are correct
    [Fact]
    public void AddPerson_ProperDetails()
    {
        PersonAddRequest personAddRequest = CreatePersonAddRequest();

        PersonResponse actualPersonResponse = _personsService.AddPerson(personAddRequest);

        PersonResponse personResponse_fromGetById = _personsService.GetPersonById(actualPersonResponse.Id);
        List<PersonResponse> personResponseList_fromGetAll = _personsService.GetAllPersons().ToList();


        int age = 0;
        if (personAddRequest.DateOfBirth != null)
        {
            age = (int)Math.Round((DateTime.Now - personAddRequest.DateOfBirth).Value.TotalDays / 365.25, 0);
        }


        Assert.True(actualPersonResponse.Id != Guid.Empty);
        Assert.Equal(age, actualPersonResponse.Age);
        Assert.Equal(personResponse_fromGetById, actualPersonResponse);
        Assert.Contains(actualPersonResponse, personResponseList_fromGetAll);

    }
    #endregion


    #region GetAllPersons

    //case 1 :if persons collection is empty 
    [Fact]
    public void GetAllPersons_EmptyCollection()
    {
        List<PersonResponse> actualPersonResponse = _personsService.GetAllPersons().ToList();

        if (_personsService.PersonsCount() == 0)
        {
            Assert.Empty(actualPersonResponse);
        }

    }



    //case 2 :when adding proper collection of persons
    [Fact]
    public void GetAllPersons_AddProperCollection()
    {
        List<PersonAddRequest> personAddRequestList =CreatePersonAddRequestList();

        List<PersonResponse> expectedPersonResponseList = new List<PersonResponse>();

        foreach (PersonAddRequest personAddRequest in personAddRequestList)
        {
            expectedPersonResponseList.Add(_personsService.AddPerson(personAddRequest));
        }

        List<PersonResponse> actualPersonResponseList = _personsService.GetAllPersons().ToList();

        foreach (PersonResponse personResponse in expectedPersonResponseList)
        {
            Assert.Contains(personResponse, actualPersonResponseList);
        }

    }



    #endregion


    #region GetPersonById

    //case 1: if person Id is null
    [Fact]
    public void GetPersonById_PersonIdIsNull()
    {
        Guid? personId = null;

        Assert.Throws<ArgumentNullException>(() =>
        {
            _personsService.GetPersonById(personId);
        });

    }

    //case 2: if person Id is incorrect
    [Fact]
    public void GetPersonById_PersonIdIsIncorrect()
    {
        Guid? personId = Guid.NewGuid();

        Assert.Throws<ArgumentException>(() =>
        {
            _personsService.GetPersonById(personId);
        });

    }

    
    //case 3: if person Id is correct
    [Fact]
    public void GetPersonById_PersonIdIsCorrect()
    {
        PersonAddRequest personAddRequest = CreatePersonAddRequest();
        
        PersonResponse expectedPersonResponse = _personsService.AddPerson(personAddRequest);

        PersonResponse actualPersonResponse = _personsService.GetPersonById(expectedPersonResponse.Id);

        Assert.Equal(expectedPersonResponse, actualPersonResponse);

    }

    #endregion


    #region UpdatePerson
    //case 1: if person id is incorrect
    [Fact]
    public void UpdatePerson_IdIsIncorrect()
    {
        PersonUpdateRequest personUpdateRequest = new PersonUpdateRequest() { Id = Guid.Empty };

        Assert.Throws<ArgumentException>(() =>
        {
            _personsService.UpdatePerson(personUpdateRequest);
        });
    }


    //case 2: if name is null

    [Fact]
    public void UpdatePerson_NameIsNull()
    {

        PersonUpdateRequest personUpdateRequest = CreatePersonUpdateRequest();
        personUpdateRequest.Name = null;

       
        Assert.Throws<ArgumentException>(() =>
        {
            _personsService.UpdatePerson(personUpdateRequest);
        });
    }


    //case 3: if email is null
    [Fact]
    public void UpdatePerson_EmailIsNull()
    {

        PersonUpdateRequest personUpdateRequest = CreatePersonUpdateRequest();
        personUpdateRequest.Email = null;


        Assert.Throws<ArgumentException>(() =>
        {
            _personsService.UpdatePerson(personUpdateRequest);
        });
    }


    //case 4: if update details are correct
    [Fact]
    public void UpdatePerson_ProperDetails()
    {

        PersonUpdateRequest personUpdateRequest = CreatePersonUpdateRequest();

        PersonResponse actualPersonResponse = _personsService.UpdatePerson(personUpdateRequest);

        PersonResponse expectedPersonResponse = _personsService.GetPersonById(personUpdateRequest.Id);

        IEnumerable<PersonResponse> personResponseList_FromGetAll = _personsService.GetAllPersons();

        Assert.Equal(expectedPersonResponse, actualPersonResponse);

        Assert.Contains(actualPersonResponse, personResponseList_FromGetAll);

    }

    #endregion


    #region GetFilteredPersons

    //case 1: when searchBy is null
    [Fact]
    public void GetFilteredPersons_searchByIsNull()
    {
        string? searchBy = null;
        string? searchText = "ne";

        IEnumerable<PersonResponse> actualPersonResponseList = _personsService.GetFilteredPersons(searchBy, searchText);

        IEnumerable<PersonResponse> expectedPersonResponseList = _personsService.GetAllPersons();


        Assert.Equal(expectedPersonResponseList, actualPersonResponseList);
    }

    //case 2: when searchBy is incorrect
    [Fact]
    public void GetFilteredPersons_searchByIsIncorrect()
    {
        string? searchBy = "Incorrect";
        string? searchText = "ne";

        IEnumerable<PersonResponse> actualPersonResponseList = _personsService.GetFilteredPersons(searchBy, searchText);

        IEnumerable<PersonResponse> expectedPersonResponseList = _personsService.GetAllPersons();


        Assert.Equal(expectedPersonResponseList, actualPersonResponseList);
    }

    //case 3: when searchText is null
    [Fact]
    public void GetFilteredPersons_searchTextIsNull()
    {
        string? searchBy = nameof(PersonResponse.Name);
        string? searchText = null;

        IEnumerable<PersonResponse> actualPersonResponseList = _personsService.GetFilteredPersons(searchBy, searchText);

        IEnumerable<PersonResponse> expectedPersonResponseList = _personsService.GetAllPersons();


        Assert.Equal(expectedPersonResponseList, actualPersonResponseList);
    }

    //case 4: when seachBy and searchText have values 
    [Fact]
    public void GetFilteredPersons_properDetails()
    {
        string? searchBy = nameof(PersonResponse.Name);
        string? searchText = "ne";
        
        IEnumerable<PersonResponse> actualPersonResponseList = _personsService.GetFilteredPersons(searchBy, searchText);

        IEnumerable<PersonResponse> expectedPersonResponseList = _personsService.GetAllPersons()
                                                                                .Where( p => (! string.IsNullOrEmpty(p.Name)) ? p.Name.Contains(searchText) : true);

        Assert.Equal(expectedPersonResponseList, actualPersonResponseList);
    }
    #endregion


    #region HelpfulMethods
    private PersonAddRequest CreatePersonAddRequest()
    {
        CountryAddRequest countryAddRequest = new CountryAddRequest() { Name = "USA" };
        CountryResponse countryResponse = _countriesService.AddCountry(countryAddRequest);

        PersonAddRequest personAddRequest = new PersonAddRequest()
        {
            Name = "Mohamed Elbaz",
            Email = "mhmdelbaz@gmail.com",
            Address = "shawaa, Mansoura",
            Gender = GenderOptions.Male,
            DateOfBirth = new DateTime(2000, 4, 15),
            ReceivesNewsLetter = true,
            CountryId = countryResponse.Id
        };

        return personAddRequest;
    }

     private List<PersonAddRequest> CreatePersonAddRequestList()
    {
        CountryAddRequest countryAddRequest1 = new CountryAddRequest() { Name = "USA" };
        CountryAddRequest countryAddRequest2 = new CountryAddRequest() { Name = "EGY" };

        CountryResponse countryResponse1 = _countriesService.AddCountry(countryAddRequest1);
        CountryResponse countryResponse2 = _countriesService.AddCountry(countryAddRequest2);

        PersonAddRequest personAddRequest1 = new PersonAddRequest()
        {
            Name = "Mohamed Elbaz",
            Email = "mhmdelbaz@gmail.com",
            Address = "Mansoura",
            DateOfBirth = new DateTime(2000, 4, 15),
            Gender = GenderOptions.Male,
            ReceivesNewsLetter = true,
            CountryId = countryResponse2.Id
        };
        PersonAddRequest personAddRequest2 = new PersonAddRequest()
        {
            Name = "Abdo Alsayed",
            Email = "abdoAlsayed@gmail.com",
            Address = "Maadi",
            DateOfBirth = new DateTime(2005, 8, 28),
            Gender = GenderOptions.Male,
            ReceivesNewsLetter = false,
            CountryId = countryResponse1.Id
        };
        PersonAddRequest personAddRequest3 = new PersonAddRequest()
        {
            Name = "Ali Elmongy",
            Email = "alielmongy@gmail.com",
            Address = "Cairo",
            DateOfBirth = new DateTime(1995, 6, 11),
            Gender = GenderOptions.Male,
            ReceivesNewsLetter = false,
            CountryId = countryResponse2.Id
        };
        PersonAddRequest personAddRequest4 = new PersonAddRequest()
        {
            Name = "Amira Elbaz",
            Email = "amiraelbaz@gmail.com",
            Address = "Giza",
            DateOfBirth = new DateTime(1998, 8, 25),
            Gender = GenderOptions.Female,
            ReceivesNewsLetter = true,
            CountryId = countryResponse1.Id
        };

        List<PersonAddRequest> personAddRequests = new List<PersonAddRequest>()
        {
            personAddRequest1, personAddRequest2,personAddRequest3,personAddRequest4
        };

        return personAddRequests;

    }

     private PersonUpdateRequest CreatePersonUpdateRequest()
        {
            PersonAddRequest personAddRequest = CreatePersonAddRequest();
            PersonResponse personResponse = _personsService.AddPerson(personAddRequest);


            PersonUpdateRequest personUpdateRequest = new PersonUpdateRequest()
            {
                Id = personResponse.Id,
                Name = "Mohamed ELbaz",
                Email = "mhmdelbaz@gmail.com",
                Address = "Mansoura",
                DateOfBirth = new DateTime(2000, 4, 15),
                CountryId = personResponse.CountryId,
                Gender = GenderOptions.Male,
                ReceivesNewsLetter = true

            };

            return personUpdateRequest;
        }

    #endregion

}
