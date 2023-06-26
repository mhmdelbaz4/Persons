using Persons.DTOs;
using Persons.Enums;
using Persons.Models;

namespace Persons.Services;

public class PersonsService : IPersonsService
{
    private readonly List<Person> _persons;

    public PersonsService(bool initialize =true)
    {
        _persons = new List<Person>();

        if(initialize)
        {
            _persons.Add(new Person() { Id = Guid.Parse("F4617512-F82B-4372-97BF-6D945C0E8FE0") ,
                                        Name = "Jan" ,Address= "9th Floor",
                                        Email= "jsilcock0@thetimes.co.uk" ,
                                        DateOfBirth = new DateTime(1994 ,07,15) ,
                                        Gender=GenderOptions.Male,ReceivesNewsLetter=false,
                                        CountryId =Guid.Parse("8775DA8E-36CA-4955-A1B4-91720341BEBB")});

            _persons.Add(new Person()
            {
                Id = Guid.Parse("01F68DD2-40AB-47BD-AD14-B20007CF3D93"),
                Name = "Caye",
                Address = "Suite 97",
                Email = "cdifranceshci1@amazonaws.com",
                DateOfBirth = new DateTime(1991, 09, 10),
                Gender = GenderOptions.Female,
                ReceivesNewsLetter = false,
                CountryId = Guid.Parse("FD7CF373-9B82-407B-A870-0FEC07F9A7A1")
            });

            _persons.Add(new Person()
            {
                Id = Guid.Parse("20A917D3-E0BF-4BED-9F36-FCB3B019DD0F"),
                Name = "Benedetto",
                Address = "Room 235",
                Email = "bbernhard2@sbwire.com",
                DateOfBirth = new DateTime(1992, 12, 26),
                Gender = GenderOptions.Male,
                ReceivesNewsLetter = true,
                CountryId = Guid.Parse("556125E7-2CBF-4D50-B1EE-605174794860")
            });

            _persons.Add(new Person()
            {
                Id = Guid.Parse("F39B3A75-02FA-4C86-BD9A-38916BE2D2CB"),
                Name = "Linell",
                Address = "Suite 37",
                Email = "ladamowitz3@newyorker.com",
                DateOfBirth = new DateTime(1997, 02, 08),
                Gender = GenderOptions.Female,
                ReceivesNewsLetter = false,
                CountryId = Guid.Parse("110695FC-B97A-4869-BC43-370AF10F7E46")
            });

            _persons.Add(new Person()
            {
                Id = Guid.Parse("1678838C-7A53-4B47-833F-51F707AE7A43"),
                Name = "Benedick",
                Address = "Suite 83",
                Email = "bseeley4@domainmarket.com",
                DateOfBirth = new DateTime(1999, 11, 11),
                Gender = GenderOptions.Male,
                ReceivesNewsLetter = false,
                CountryId = Guid.Parse("7455AEE4-5668-4FE9-BDB2-44CFE3DCCC15")
            });

            _persons.Add(new Person()
            {
                Id = Guid.Parse("33608493-F97D-49DA-B4B5-C8BF524C8DCB"),
                Name = "Merlina",
                Address = "Apt 606",
                Email = "mcaddan5@altervista.org",
                DateOfBirth = new DateTime(1990, 11, 23),
                Gender = GenderOptions.Female,
                ReceivesNewsLetter = false,
                CountryId = Guid.Parse("8775DA8E-36CA-4955-A1B4-91720341BEBB")
            });

            _persons.Add(new Person()
            {
                Id = Guid.Parse("FBC9DFFC-7900-422F-BD40-548860144301"),
                Name = "Helaine",
                Address = "13th Floor",
                Email = "hmacgill6@example.com",
                DateOfBirth = new DateTime(1999, 03, 13),
                Gender = GenderOptions.Female,
                ReceivesNewsLetter = true,
                CountryId = Guid.Parse("FD7CF373-9B82-407B-A870-0FEC07F9A7A1")
            });

            _persons.Add(new Person()
            {
                Id = Guid.Parse("4D1E75A0-525F-409B-A0EE-339C768FD871"),
                Name = "Nannette",
                Address = "Suite 71",
                Email = "njeppensen7@google.ru",
                DateOfBirth = new DateTime(2000, 02, 07),
                Gender = GenderOptions.Female,
                ReceivesNewsLetter = true,
                CountryId = Guid.Parse("556125E7-2CBF-4D50-B1EE-605174794860")
            });

            _persons.Add(new Person()
            {
                Id = Guid.Parse("9711B9A0-433D-41B0-8D00-3B6B88C41E5B"),
                Name = "Alice",
                Address = "PO Box 228",
                Email = "awithams8@forbes.com",
                DateOfBirth = new DateTime(1990, 09, 16),
                Gender = GenderOptions.Female,
                ReceivesNewsLetter = false,
                CountryId = Guid.Parse("110695FC-B97A-4869-BC43-370AF10F7E46")
            });

            _persons.Add(new Person()
            {
                Id = Guid.Parse("14AE313E-B1A0-430F-B031-917E26BF3040"),
                Name = "Mariellen",
                Address = "PO Box 64683",
                Email = "mkensett9@arstechnica.com",
                DateOfBirth = new DateTime(1991, 09, 25),
                Gender = GenderOptions.Female,
                ReceivesNewsLetter = true,
                CountryId = Guid.Parse("7455AEE4-5668-4FE9-BDB2-44CFE3DCCC15")
            });
        }
    }


    public IEnumerable<PersonResponse> GetAllPersons()
    {
        if(_persons.Count == 0)
            return Enumerable.Empty<PersonResponse>();


        IEnumerable<PersonResponse> personResponseSequence = _persons.Select(person => (PersonResponse)person);

        return personResponseSequence;

    }

    
    public PersonResponse GetPersonById(Guid? personId)
    {
        if (personId == null)
            throw new ArgumentNullException(nameof(personId));

        Person? person = _persons.SingleOrDefault(person => person.Id == personId);

        if (person == null)
            throw new ArgumentException(nameof(Person.Id), "Person Id is incorrect");


        PersonResponse personResponse = (PersonResponse)person;

        return personResponse;

    }

    public IEnumerable<PersonResponse> GetFilteredPersons(string? searchBy, string? searchText)
    {
        IEnumerable<PersonResponse> allPersons =GetAllPersons();
        IEnumerable<PersonResponse> matchingPersons ;


        if (string.IsNullOrEmpty(searchBy) || string.IsNullOrEmpty(searchText))
            return allPersons;  
        
        switch(searchBy)
        {
            case nameof(PersonResponse.Name):
                matchingPersons = allPersons.Where(p => (! string.IsNullOrEmpty(p.Name)) ? p.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase) :true);
                break;

            case nameof(PersonResponse.Email):
                matchingPersons = allPersons.Where(p => (!string.IsNullOrEmpty(p.Email)) ? p.Email.Contains(searchText, StringComparison.OrdinalIgnoreCase) : true);
                break;

            case nameof(PersonResponse.Address):
                matchingPersons = allPersons.Where(p => (!string.IsNullOrEmpty(p.Address)) ? p.Address.Contains(searchText, StringComparison.OrdinalIgnoreCase) : true);
                break;

            case nameof(PersonResponse.DateOfBirth):
                matchingPersons = allPersons.Where(p => (p.DateOfBirth != null) ? p.DateOfBirth.Value.ToString("dd MMMM yyyy").Contains(searchText ,StringComparison.OrdinalIgnoreCase) : true);
                break;

            case nameof(PersonResponse.CountryId):
                matchingPersons = allPersons.Where(p => (!string.IsNullOrEmpty(p.CountryName)) ? p.CountryName.Contains(searchText, StringComparison.OrdinalIgnoreCase) : true);
                break;

            case nameof(PersonResponse.Gender):
                matchingPersons = allPersons.Where(p => (!string.IsNullOrEmpty(p.Gender.ToString()) ? p.Gender.ToString().Equals(searchText, StringComparison.OrdinalIgnoreCase) : true));
                break;


            default:
                matchingPersons = allPersons;
                break;

        }

        return matchingPersons;

    }

    public IEnumerable<PersonResponse> GetSortedPersons(string? sortBy, SortOptions sortOption)
    {
        throw new NotImplementedException();
    }

    public PersonResponse AddPerson(PersonAddRequest? personAddRequest)
    {
        if (personAddRequest == null)
            throw new ArgumentNullException(nameof(personAddRequest));

        ValidationHelper.Validate(personAddRequest);

        Person person = (Person)personAddRequest;

        _persons.Add(person);

        PersonResponse personResponse = (PersonResponse)person;

        return personResponse;

    }


    public int PersonsCount()
    {
        return _persons.Count;
    }

    public bool DeletePerson(Guid? personId)
    {
        throw new NotImplementedException();
    }

    public PersonResponse UpdatePerson(PersonUpdateRequest? personUpdateRequest)
    {
        if (personUpdateRequest == null)
            throw new ArgumentNullException(nameof(personUpdateRequest));

        Person? person = _persons.SingleOrDefault(person => person.Id == personUpdateRequest.Id);

        if(person == null)
            throw new ArgumentException(nameof(personUpdateRequest.Id),"Invalid Id");

        ValidationHelper.Validate(personUpdateRequest);

        person.Name = personUpdateRequest.Name;
        person.Email = personUpdateRequest.Email;
        person.Gender = personUpdateRequest.Gender;
        person.Address = personUpdateRequest.Address;
        person.ReceivesNewsLetter = personUpdateRequest.ReceivesNewsLetter;
        person.DateOfBirth = personUpdateRequest.DateOfBirth;
        person.CountryId = personUpdateRequest.CountryId;


        PersonResponse personResponse = (PersonResponse)person;

        return personResponse;

    }

   
}
