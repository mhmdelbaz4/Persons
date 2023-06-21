using System.ComponentModel.DataAnnotations;

namespace Persons.DTOs;

public record CountryAddRequest
{
    [Required(ErrorMessage ="Name can't be blank" )]
    [StringLength(50 ,MinimumLength = 2)]
    public string Name { get; set; }


}
