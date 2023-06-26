using Persons.Enums;
using System.ComponentModel.DataAnnotations;

namespace Persons.DTOs;

public class PersonUpdateRequest
{

    public Guid Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [MinLength(3, ErrorMessage = "Minumum length of person name is 3 char")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Email is required")]
    public string? Email { get; set; }

    public string? Address { get; set; }
    public GenderOptions? Gender { get; set; }
    public DateTime? DateOfBirth { get; set; }

    public bool? ReceivesNewsLetter { get; set; }
    public Guid? CountryId { get; set; }

}
