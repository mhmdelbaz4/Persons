using PersonsWebApp.DTOs;
using PersonsWebApp.Enums;
using PersonsWebApp.Helper;
using PersonsWebApp.Models;
using PersonsWebApp.ServiceContracts;

namespace PersonsWebApp.Services;

public class PersonServices : IPersonServices
{
    private readonly List<Person> _persons;
    private readonly ICountriesServices _countriesServices;
    public PersonServices(bool initialize = true)
    {
        _persons = new List<Person>();
        _countriesServices = new CountriesServices();

        if (initialize)
        {
            _persons.Add(new Person() 
            { 
                Id = Guid.Parse("608F490D-FF79-4DBE-84EE-193FF3EC7F5E"),
                Name = "Freedman",
                Address = "Suite 26",
                DateOfBirth =new DateTime(1995,04,11),
                Email = "fokie0@cdbaby.com",
                Gender = GenderOptions.Male,
                ReceivesNewsLetter = true,
                CountryId = Guid.Parse("B2E49413-2AC7-409D-9E8B-4D8D12714821")

            });

            _persons.Add(new Person()
            {
                Id = Guid.Parse("30D53D18-D3A8-4AA3-A928-3F680474EBD1"),
                Name = "Jamaal",
                Address = "Apt 1881",
                DateOfBirth = new DateTime(1995, 05, 31),
                Email = "jwinyard1@wp.com",
                Gender = GenderOptions.Male,
                ReceivesNewsLetter = false,
                CountryId = Guid.Parse("29F50A60-9705-4393-87B0-2B4B9CFCF436")

            });

            _persons.Add(new Person()
            {
                Id = Guid.Parse("B829E4BE-94F9-4F02-9CAC-250C64976D1E"),
                Name = "Cahra",
                Address = "Suite 26",
                DateOfBirth = new DateTime(1992, 12, 31) ,
                Email = "cbennet2@hud.gov",
                Gender = GenderOptions.Female,
                ReceivesNewsLetter = false,
                CountryId = Guid.Parse("B195C6E7-9EE1-4FEB-93F5-AB2F69F5C54F")

            });

            _persons.Add(new Person()
            {
                Id = Guid.Parse("3678EE3A-F2D7-4254-B99B-628615722549"),
                Name = "Matt",
                Address = "Suite 26",
                DateOfBirth = new DateTime(1996, 12, 09),
                Email = "mbransom3@nasa.gov",
                Gender = GenderOptions.Male,
                ReceivesNewsLetter = false,
                CountryId = Guid.Parse("71377960-3362-4057-B42A-D5404D3799D7")

            });

            _persons.Add(new Person()
            {
                Id = Guid.Parse("524D9CAF-5321-4762-A27F-AD3CDD003A23"),
                Name = "Randene",
                Address = "18th Floor",
                DateOfBirth = new DateTime(1999, 10, 30),
                Email = "rmaith4@admin.ch",
                Gender = GenderOptions.Female,
                ReceivesNewsLetter = true,
                CountryId = Guid.Parse("DB1A7D2E-98AB-431E-B1F5-70632A423A0F")

            });

            _persons.Add(new Person()
            {
                Id = Guid.Parse("CFC9A6BB-86EB-41A3-BC91-E53EB2539C57"),
                Name = "Laurie",
                Address = "PO Box 11377",
                DateOfBirth = new DateTime(1996, 06, 01),
                Email = "ldenty5@seesaa.net",
                Gender = GenderOptions.Female,
                ReceivesNewsLetter = true,
                CountryId = Guid.Parse("B2E49413-2AC7-409D-9E8B-4D8D12714821")

            });

            _persons.Add(new Person()
            {
                Id = Guid.Parse("B5423624-A048-43C7-B6E4-0E3DBDA9BBFB"),
                Name = "Pierre",
                Address = "PO Box 32263",
                DateOfBirth = new DateTime(1997, 06, 23),
                Email = "pgianotti6@etsy.com",
                Gender = GenderOptions.Male,
                ReceivesNewsLetter = false,
                CountryId = Guid.Parse("29F50A60-9705-4393-87B0-2B4B9CFCF436")

            });

            _persons.Add(new Person()
            {
                Id = Guid.Parse("A21D6500-C67B-444A-906E-03BEC39A28DD"),
                Name = "Dina",
                Address = "16th Floor",
                DateOfBirth = new DateTime(2000, 10, 18),
                Email = "dberardt7@soundcloud.com",
                Gender = GenderOptions.Female,
                ReceivesNewsLetter = true,
                CountryId = Guid.Parse("B195C6E7-9EE1-4FEB-93F5-AB2F69F5C54F")

            });

            _persons.Add(new Person()
            {
                Id = Guid.Parse("A92A7C88-DBF4-48E0-94A1-5C6976E4F782"),
                Name = "Dale",
                Address = "17th Floor",
                DateOfBirth = new DateTime(1994, 12, 28),
                Email = "dlidierth8@g.co",
                Gender = GenderOptions.Male,
                ReceivesNewsLetter = false,
                CountryId = Guid.Parse("71377960-3362-4057-B42A-D5404D3799D7")

            });

            _persons.Add(new Person()
            {
                Id = Guid.Parse("85859073-B0F1-450A-9FB3-96BB014FB10F"),
                Name = "Eirena",
                Address = "Room 1568",
                DateOfBirth = new DateTime(1995, 11, 10),
                Email = "emcguinley9@ed.gov",
                Gender = GenderOptions.Female,
                ReceivesNewsLetter = true,
                CountryId = Guid.Parse("DB1A7D2E-98AB-431E-B1F5-70632A423A0F")

            });

        }

    }

    public PersonResponse AddPerson(PersonRequest? personRequest)
    {

        ArgumentNullException.ThrowIfNull(personRequest, nameof(personRequest));

        ModelValidation.Validate(personRequest);

        Person person = (Person)personRequest;

        if (_persons.Contains(person))
        {
            throw new ArgumentException("this person is already exists");
        }

        _persons.Add(person);

        PersonResponse personResponse = convertFromPersonToPersonResponse(person);

        return personResponse;

    }

    public bool DeletePerson(Guid? personId)
    {
        ArgumentNullException.ThrowIfNull(personId ,nameof(personId));

        Person? person = _persons.Where(person => person.Id == personId).FirstOrDefault();
        if(person == null)
        {
            return false;
        }

        bool isDeleted  = _persons.Remove(person);
        return isDeleted;

    }

    public IEnumerable<PersonResponse> GetAllPersons()
    {
        if (_persons.Count == 0)
        {
            return Enumerable.Empty<PersonResponse>();
        }

        IEnumerable<PersonResponse> allPersonResponse = _persons.Select(person => convertFromPersonToPersonResponse(person));

        return allPersonResponse;
    }

    public IEnumerable<PersonResponse> GetFilteredPersons(string searchBy, string? searchText)
    {
        ArgumentNullException.ThrowIfNull(searchBy, nameof(searchBy));

        IEnumerable<PersonResponse> allPersons =_persons.Select(person => convertFromPersonToPersonResponse(person));

        if (string.IsNullOrEmpty(searchBy) || string.IsNullOrEmpty(searchText))
        {
            return allPersons;
        }

        List<PersonResponse> filteredPersonResponseList = new List<PersonResponse>();  
        switch (searchBy)
        {
            case nameof(PersonResponse.Name):
                filteredPersonResponseList = allPersons.Where(person =>
                {
                    if (string.IsNullOrEmpty(person.Name))
                    {
                        return true;
                    }
                    else
                    {
                        return person.Name.Contains(searchText ,StringComparison.OrdinalIgnoreCase);
                    }
                }).ToList();
                break;

            case nameof(PersonResponse.Email):
                filteredPersonResponseList = allPersons.Where(person =>
                {
                    if (string.IsNullOrEmpty(person.Email))
                    {
                        return true;
                    }
                    else
                    {
                        return person.Email.Contains(searchText, StringComparison.OrdinalIgnoreCase);
                    }
                }).ToList();
                break;

            case nameof(PersonResponse.Address):
                filteredPersonResponseList = allPersons.Where(person =>
                {
                    if (string.IsNullOrEmpty(person.Address))
                    {
                        return true;
                    }
                    else
                    {
                        return person.Address.Contains(searchText, StringComparison.OrdinalIgnoreCase);
                    }
                }).ToList();
                break;

            case nameof(PersonResponse.Gender):
                filteredPersonResponseList = allPersons.Where(person =>
                {
                    if (person.Gender is null)
                    {
                        return true;
                    }
                    else
                    {
                        return person.Gender.Value.ToString().Equals(searchText ,StringComparison.OrdinalIgnoreCase);
                    }
                }).ToList();
                break;

            case nameof(PersonResponse.ReceivesNewsLetter):
                filteredPersonResponseList = allPersons.Where(person =>
                {
                    if (person.ReceivesNewsLetter is null)
                    {
                        return true;
                    }
                    else
                    {
                        return person.ReceivesNewsLetter.Value.ToString().Equals(searchText, StringComparison.OrdinalIgnoreCase);
                    }
                }).ToList();
                break;

            case nameof(PersonResponse.DateOfBirth):
                filteredPersonResponseList = allPersons.Where(person =>
                {
                    if (person.DateOfBirth is null)
                    {
                        return true;
                    }
                    else
                    {
                        return person.DateOfBirth.Value.ToString("dd/MM/yyyy").Contains(searchText);
                    }
                }).ToList();
                break;

            case nameof(PersonResponse.Age):
                filteredPersonResponseList = allPersons.Where(person =>
                {
                    if (person.Age == 0 || person.Age == null)
                    {
                        return true;
                    }
                    else
                    {
                        return person.Age.ToString().Equals(searchText, StringComparison.OrdinalIgnoreCase);
                    }
                }).ToList();
                break;

            case nameof(PersonResponse.CountryName):
                filteredPersonResponseList = allPersons.Where(person =>
                {
                    if (person.CountryId is null)
                    {
                        return true;
                    }
                    else
                    {
                        return person.CountryId.Value.ToString().Equals(searchText, StringComparison.OrdinalIgnoreCase);
                    }
                }).ToList();
                break;
        }


        return filteredPersonResponseList;

    }

    public PersonResponse GetPersonById(Guid? personId)
    {
        ArgumentNullException.ThrowIfNull(personId, nameof(personId));

        Person? person = _persons.Where(person => person.Id == personId).FirstOrDefault();
        if (person == null)
        {
            throw new ArgumentException("person Id is incorrect");
        }

        PersonResponse personResponse = convertFromPersonToPersonResponse(person);

        return personResponse;
    }

    public IEnumerable<PersonResponse> GetSortedPersons(IEnumerable<PersonResponse> persons, string sortBy, sortOptions sortOptions)
    {
        if(persons.Count() == 0)
            return Enumerable.Empty<PersonResponse>();

        if (string.IsNullOrEmpty(sortBy))
            return persons;

        List<PersonResponse> sortedPersons = new List<PersonResponse> ();   
            
            
        switch(sortBy , sortOptions)
        {
            case (nameof(PersonResponse.Name), sortOptions.Asc):
                sortedPersons = persons.OrderBy(person => person.Name ,StringComparer.OrdinalIgnoreCase).ToList();
                break;
            case (nameof(PersonResponse.Name), sortOptions.Desc):
                sortedPersons = persons.OrderByDescending(person => person.Name, StringComparer.OrdinalIgnoreCase).ToList();
                break;



            case (nameof(PersonResponse.Email), sortOptions.Asc):
                sortedPersons = persons.OrderBy(person => person.Email ,StringComparer.OrdinalIgnoreCase).ToList();
                break;
            case (nameof(PersonResponse.Email), sortOptions.Desc):
                sortedPersons = persons.OrderByDescending(person => person.Email, StringComparer.OrdinalIgnoreCase).ToList();
                break;


            case (nameof(PersonResponse.Address), sortOptions.Asc):
                sortedPersons = persons.OrderBy(person => person.Address ,StringComparer.OrdinalIgnoreCase)
                  .ToList();
                break;
            case (nameof(PersonResponse.Address), sortOptions.Desc):
                sortedPersons = persons.OrderByDescending(person => person.Address, StringComparer.OrdinalIgnoreCase)
                 .ToList();
                break;


            case (nameof(PersonResponse.DateOfBirth), sortOptions.Asc):
                sortedPersons = persons.OrderBy(person => person.DateOfBirth)
                  .ToList();
                break;
            case (nameof(PersonResponse.DateOfBirth), sortOptions.Desc):
                sortedPersons = persons.OrderByDescending(person => person.DateOfBirth)
                   .ToList();
                break;


            case (nameof(PersonResponse.Gender), sortOptions.Asc):
                sortedPersons = persons.OrderBy(person => person.Gender).ToList();
                break;
            case (nameof(PersonResponse.Gender), sortOptions.Desc):
                sortedPersons = persons.OrderByDescending(person => person.Gender).ToList();
                break;



            case (nameof(PersonResponse.Age), sortOptions.Asc):
                sortedPersons = persons.OrderBy(person => person.Age).ToList();
                break;
            case (nameof(PersonResponse.Age), sortOptions.Desc):
                sortedPersons = persons.OrderByDescending(person => person.Age).ToList();
                break;


            case (nameof(PersonResponse.ReceivesNewsLetter), sortOptions.Asc):
                sortedPersons = persons.OrderBy(person => person.ReceivesNewsLetter).ToList();
                break;
            case (nameof(PersonResponse.ReceivesNewsLetter), sortOptions.Desc):
                sortedPersons = persons.OrderByDescending(person => person.ReceivesNewsLetter).ToList();
                break;


            case (nameof(PersonResponse.CountryName), sortOptions.Asc):
                sortedPersons = persons.OrderBy(person => person.CountryName ,StringComparer.OrdinalIgnoreCase)
                  .ToList();
                break;
            case (nameof(PersonResponse.CountryName), sortOptions.Desc):
                sortedPersons = persons.OrderByDescending(person => person.CountryName ,StringComparer.OrdinalIgnoreCase)
                  .ToList();
                break;

        };

        return sortedPersons;

    }

    public PersonResponse UpdatePerson(Guid? personId, PersonRequest? personRequest)
    {
        ArgumentNullException.ThrowIfNull(personId, nameof(personId));

        ArgumentNullException.ThrowIfNull(personRequest, nameof(personRequest));

        Person? person = _persons.Where(person => person.Id == personId).FirstOrDefault();
        if (person == null)
        {
            throw new ArgumentException("person Id is incorrect");
        }

        ModelValidation.Validate(personRequest);

        if(_persons.Contains( (Person) personRequest))
        {
            throw new ArgumentException("this person with this information is already exists");
        }

        person.Name = personRequest.Name;
        person.Email = personRequest.Email;
        person.Address = personRequest.Address;
        person.Gender = personRequest.Gender;
        person.CountryId = personRequest.CountryId;
        person.ReceivesNewsLetter = personRequest.ReceivesNewsLetter;
        person.DateOfBirth = personRequest.DateOfBirth;

        
        PersonResponse personResponse = convertFromPersonToPersonResponse(person);
        return personResponse;
    }

    private PersonResponse convertFromPersonToPersonResponse(Person? person)
    {
        ArgumentNullException.ThrowIfNull(person, nameof(person));
        PersonResponse personResponse = (PersonResponse)person;

        personResponse.CountryName = _countriesServices.GetCountryById(personResponse.CountryId)?.Name;
        return personResponse;
    }
}
