using Persons.Enums;
using Persons.DTOs;

namespace Persons.Models;

public class Person
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }
    public string? Address { get; set; }
    public GenderOptions? Gender { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public bool? ReceivesNewsLetter { get; set; }
    public Guid? CountryId { get; set; }



    /// <summary>
    /// override explicit operator to convert from personAddReqiest to person explicitly
    /// </summary>
    /// <param name="personAddRequest">personAddRequest object</param>
    public static explicit operator Person(PersonAddRequest? personAddRequest)
    {
       if(personAddRequest == null)
        {
            throw new ArgumentNullException(nameof(personAddRequest));
        }

        Person person = new Person()
        {
            Id = Guid.NewGuid(),
            Name = personAddRequest.Name,
            Address = personAddRequest.Address,
            DateOfBirth = personAddRequest.DateOfBirth,
            Gender = personAddRequest.Gender,
            Email = personAddRequest.Email,
            ReceivesNewsLetter = personAddRequest.ReceivesNewsLetter,
            CountryId = personAddRequest.CountryId

        };

        return person;
    }

}
