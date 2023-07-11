using System.ComponentModel.DataAnnotations;

namespace PersonsWebApp.DTOs;


/// <summary>
/// represents the structure of a country request of countries services 
/// </summary>
public class CountryAddRequest
{

    [Required(ErrorMessage ="Country name is required")]
    [StringLength(50 , MinimumLength = 2 ,ErrorMessage ="Country name length is between 2 and 50 characters")]
    public string? Name { get; set; }

}
