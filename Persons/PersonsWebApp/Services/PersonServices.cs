using PersonsWebApp.DTOs;
using PersonsWebApp.Enums;
using PersonsWebApp.Helper;
using PersonsWebApp.Models;
using PersonsWebApp.ServiceContracts;

namespace PersonsWebApp.Services;

public class PersonServices : IPersonServices
{
    private readonly List<Person> _persons;
    public PersonServices()
    {
        _persons = new List<Person>();
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

        PersonResponse personResponse = (PersonResponse)person;

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

        IEnumerable<PersonResponse> allPersonResponse = _persons.Select(person => (PersonResponse)person);

        return allPersonResponse;
    }

    public IEnumerable<PersonResponse> GetFilteredPersons(string searchBy, string? searchText)
    {
        ArgumentNullException.ThrowIfNull(searchText, nameof(searchText));

        IEnumerable<PersonResponse> filteredPersonResponseList =_persons.Select(person => (PersonResponse) person);

        if (string.IsNullOrEmpty(searchBy) || string.IsNullOrEmpty(searchText))
        {
            return filteredPersonResponseList;
        }

        switch (searchBy)
        {
            case nameof(PersonResponse.Name):
                filteredPersonResponseList = _persons.Where(person =>
                {
                    if (string.IsNullOrEmpty(person.Name))
                    {
                        return true;
                    }
                    else
                    {
                        return person.Name.Contains(searchText ,StringComparison.OrdinalIgnoreCase);
                    }
                }).Select(Person => (PersonResponse) Person) 
                  .ToList();
                break;

            case nameof(PersonResponse.Email):
                filteredPersonResponseList = _persons.Where(person =>
                {
                    if (string.IsNullOrEmpty(person.Email))
                    {
                        return true;
                    }
                    else
                    {
                        return person.Email.Contains(searchText, StringComparison.OrdinalIgnoreCase);
                    }
                }).Select(Person => (PersonResponse)Person)
                  .ToList();
                break;

            case nameof(PersonResponse.Address):
                filteredPersonResponseList = _persons.Where(person =>
                {
                    if (string.IsNullOrEmpty(person.Address))
                    {
                        return true;
                    }
                    else
                    {
                        return person.Address.Contains(searchText, StringComparison.OrdinalIgnoreCase);
                    }
                }).Select(Person => (PersonResponse)Person)
                  .ToList();
                break;

            case nameof(PersonResponse.Gender):
                filteredPersonResponseList = _persons.Where(person =>
                {
                    if (person.Gender is null)
                    {
                        return true;
                    }
                    else
                    {
                        return person.Gender.Value.ToString().Equals(searchText ,StringComparison.OrdinalIgnoreCase);
                    }
                }).Select(Person => (PersonResponse)Person)
                  .ToList();
                break;

            case nameof(PersonResponse.ReceivesNewsLetter):
                filteredPersonResponseList = _persons.Where(person =>
                {
                    if (person.ReceivesNewsLetter is null)
                    {
                        return true;
                    }
                    else
                    {
                        return person.ReceivesNewsLetter.Value.ToString().Equals(searchText, StringComparison.OrdinalIgnoreCase);
                    }
                }).Select(Person => (PersonResponse)Person)
                  .ToList();
                break;

            case nameof(PersonResponse.DateOfBirth):
                filteredPersonResponseList = _persons.Where(person =>
                {
                    if (person.DateOfBirth is null)
                    {
                        return true;
                    }
                    else
                    {
                        return person.DateOfBirth.Value.ToString("dd/MM/yyyy").Contains(searchText);
                    }
                }).Select(Person => (PersonResponse)Person)
                  .ToList();
                break;

            case nameof(PersonResponse.Age):
                filteredPersonResponseList = _persons.Where(person =>
                {
                    if (person.Age == 0)
                    {
                        return true;
                    }
                    else
                    {
                        return person.Age.ToString().Equals(searchText, StringComparison.OrdinalIgnoreCase);
                    }
                }).Select(Person => (PersonResponse)Person)
                  .ToList();
                break;

            case nameof(PersonResponse.CountryName):
                filteredPersonResponseList = _persons.Where(person =>
                {
                    if (person.CountryId is null)
                    {
                        return true;
                    }
                    else
                    {
                        return person.CountryId.Value.ToString().Equals(searchText, StringComparison.OrdinalIgnoreCase);
                    }
                }).Select(Person => (PersonResponse)Person)
                  .ToList();
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

        PersonResponse personResponse = (PersonResponse)person;

        return personResponse;
    }

    public IEnumerable<PersonResponse> GetSortedPersons(IEnumerable<PersonResponse> persons, string sortBy, string? searchText, sortOptions sortOptions)
    {
        if(persons.Count() == 0)
            return Enumerable.Empty<PersonResponse>();

        if (string.IsNullOrEmpty(sortBy) || string.IsNullOrEmpty(searchText))
            return persons;

        List<PersonResponse> sortedPersons = new List<PersonResponse> ();   
            
            
        switch(sortBy , sortOptions)
        {
            case (nameof(PersonResponse.Name), sortOptions.Asc):
                sortedPersons = persons.Where(person =>
                {
                    if (string.IsNullOrEmpty(person.Name))
                        return true;
                    else
                        return person.Name.Contains(searchText ,StringComparison.OrdinalIgnoreCase);
                }).OrderBy(person => person.Name)
                  .ToList ();
                break;
            case (nameof(PersonResponse.Name), sortOptions.Desc):
                sortedPersons = persons.Where(person =>
                {
                    if (string.IsNullOrEmpty(person.Name))
                        return true;
                    else
                        return person.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase);
                }).OrderByDescending(person => person.Name)
                  .ToList();
                break;



            case (nameof(PersonResponse.Email), sortOptions.Asc):
                sortedPersons = persons.Where(person =>
                {
                    if (string.IsNullOrEmpty(person.Email))
                        return true;
                    else
                        return person.Email.Contains(searchText);
                }).OrderBy(person => person.Email)
                  .ToList();
                break;
            case (nameof(PersonResponse.Email), sortOptions.Desc):
                sortedPersons = persons.Where(person =>
                {
                    if (string.IsNullOrEmpty(person.Email))
                        return true;
                    else
                        return person.Email.Contains(searchText);
                }).OrderByDescending(person => person.Email)
                  .ToList();
                break;



            case (nameof(PersonResponse.Address), sortOptions.Asc):
                sortedPersons = persons.Where(person =>
                {
                    if (string.IsNullOrEmpty(person.Address))
                        return true;
                    else
                        return person.Address.Contains(searchText);
                }).OrderBy(person => person.Address)
                  .ToList();
                break;
            case (nameof(PersonResponse.Address), sortOptions.Desc):
                sortedPersons = persons.Where(person =>
                {
                    if (string.IsNullOrEmpty(person.Address))
                        return true;
                    else
                        return person.Address.Contains(searchText);
                }).OrderByDescending(person => person.Address)
                  .ToList();
                break;



            case (nameof(PersonResponse.DateOfBirth), sortOptions.Asc):
                sortedPersons = persons.Where(person =>
                {
                    if (! person.DateOfBirth.HasValue)
                        return true;
                    else
                        return person.DateOfBirth.Value.ToString("dd-MM-yyyy").Contains(searchText);
                }).OrderBy(person => person.DateOfBirth)
                  .ToList();
                break;
            case (nameof(PersonResponse.DateOfBirth), sortOptions.Desc):
                sortedPersons = persons.Where(person =>
                {
                    if (!person.DateOfBirth.HasValue)
                        return true;
                    else
                        return person.DateOfBirth.Value.ToString("dd-MM-yyyy").Contains(searchText);
                }).OrderByDescending(person => person.DateOfBirth)
                  .ToList();
                break;

            case (nameof(PersonResponse.Gender), sortOptions.Asc):
                sortedPersons = persons.Where(person =>
                {
                    if (!person.Gender.HasValue)
                        return true;
                    else
                        return person.Gender.Value.ToString().Equals(searchText ,StringComparison.OrdinalIgnoreCase);
                }).OrderBy(person => person.Gender)
                  .ToList();
                break;
            case (nameof(PersonResponse.Gender), sortOptions.Desc):
                sortedPersons = persons.Where(person =>
                {
                    if (!person.Gender.HasValue)
                        return true;
                    else
                        return person.Gender.Value.ToString().Equals(searchText, StringComparison.OrdinalIgnoreCase);
                }).OrderByDescending(person => person.Gender)
                  .ToList();
                break;



            case (nameof(PersonResponse.Age), sortOptions.Asc):
                sortedPersons = persons.Where(person =>
                {
                    if (!person.Age.HasValue)
                        return true;
                    else
                        return person.Age.Value.ToString() == searchText;
                }).OrderBy(person => person.Age)
                  .ToList();
                break;
            case (nameof(PersonResponse.Age), sortOptions.Desc):
                sortedPersons = persons.Where(person =>
                {
                    if (!person.Age.HasValue)
                        return true;
                    else
                        return person.Age.Value.ToString() == searchText;
                }).OrderByDescending(person => person.Age)
                  .ToList();
                break;



           
            case (nameof(PersonResponse.ReceivesNewsLetter), sortOptions.Asc):
                sortedPersons = persons.Where(person =>
                {
                    if (!person.ReceivesNewsLetter.HasValue)
                        return true;
                    else
                        return person.ReceivesNewsLetter.Value.ToString().Equals(searchText ,StringComparison.OrdinalIgnoreCase);
                }).OrderBy(person => person.ReceivesNewsLetter)
                  .ToList();
                break;
            case (nameof(PersonResponse.ReceivesNewsLetter), sortOptions.Desc):
                sortedPersons = persons.Where(person =>
                {
                    if (!person.ReceivesNewsLetter.HasValue)
                        return true;
                    else
                        return person.ReceivesNewsLetter.Value.ToString().Equals(searchText, StringComparison.OrdinalIgnoreCase);
                }).OrderByDescending(person => person.ReceivesNewsLetter)
                  .ToList();
                break;



            case (nameof(PersonResponse.CountryName), sortOptions.Asc):
                sortedPersons = persons.Where(person =>
                {
                    if (string.IsNullOrEmpty(person.CountryName))
                        return true;
                    else
                        return person.CountryName.Contains(searchText);
                }).OrderBy(person => person.CountryName)
                  .ToList();
                break;
            case (nameof(PersonResponse.CountryName), sortOptions.Desc):
                sortedPersons = persons.Where(person =>
                {
                    if (string.IsNullOrEmpty(person.CountryName))
                        return true;
                    else
                        return person.CountryName.Contains(searchText);
                }).OrderByDescending(person => person.CountryName)
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
        person.Age = (int)((DateTime.Now - personRequest.DateOfBirth).GetValueOrDefault().TotalDays / 365.25);

        
        PersonResponse personResponse = (PersonResponse)person;
        return personResponse;
    }
}
