using Persons.Enums;
using Persons.DTOs;

namespace Persons.Models;

public class Person
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }
    public string? Address { get; set; }
    public GenderOptions? Gender { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public bool? ReceivesNewsLetter { get; set; }
    public string? CountryName { get; set; }

}
