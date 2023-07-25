using PersonsWebApp.Enums;
using System.ComponentModel.DataAnnotations;

namespace PersonsWebApp.DTOs;

public class PersonRequest
{
    [Required]
    [StringLength(100 , MinimumLength =3)]
    public string? Name { get; set; }

    [Required]
    [EmailAddress]
    public string? Email { get; set; }
    public string? Address { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public GenderOptions? Gender { get; set; }
    public bool? ReceivesNewsLetter { get; set; }
    public Guid? CountryId { get; set; }
}
