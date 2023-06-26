using Persons.Enums;
using Persons.Models;

namespace Persons.DTOs;

public record PersonResponse
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }

    public string? Address { get; set; }
    public GenderOptions? Gender { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public int Age { get; set; }
    public bool? ReceivesNewsLetter { get; set; }
    public Guid? CountryId { get; set; }

    public String? CountryName { get; set; }



    /// <summary>
    /// override explicit operator to convert from person to personAddRequest explicitly
    /// </summary>
    /// <param name="person">Person Object</param>


    public static explicit operator PersonResponse(Person? person)
    {
        if (person == null)
            throw new ArgumentNullException(nameof(person));

        int age = 0;
        if (person.DateOfBirth != null)
        {
            age = (int) Math.Round((DateTime.Now - person.DateOfBirth).Value.TotalDays / 365.25, 0);
        }

        PersonResponse personResponse = new PersonResponse()
        {
            Id = person.Id,
            Name = person.Name,
            Email = person.Email,
            Address = person.Address,
            Age = age,
            DateOfBirth = person.DateOfBirth,
            Gender = person.Gender,
            ReceivesNewsLetter = person.ReceivesNewsLetter,
            CountryId = person.CountryId,
        };

        return personResponse;

    }


}
