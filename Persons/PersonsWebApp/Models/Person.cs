using PersonsWebApp.Enums;

namespace PersonsWebApp.Models;

public class Person
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public GenderOptions? Gender { get; set; }
    public string? ReceivesNewsLetter { get; set; }
    public Guid CountryId { get; set; }

}
