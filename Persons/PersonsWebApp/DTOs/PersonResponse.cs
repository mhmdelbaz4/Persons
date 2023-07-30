using PersonsWebApp.Enums;
using PersonsWebApp.Models;

namespace PersonsWebApp.DTOs;

public class PersonResponse
{

    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public int? Age { get; set; }
    public GenderOptions? Gender { get; set; }
    public bool? ReceivesNewsLetter { get; set; }
    public Guid? CountryId { get; set; }
    public string? CountryName { get; set; }


    public static explicit operator PersonResponse(Person? person)
    {
        ArgumentNullException.ThrowIfNull(person);

        PersonResponse personResponse = new PersonResponse()
        {
            Id = person.Id,
            Name = person.Name,
            Address = person.Address,
            DateOfBirth = person.DateOfBirth,
            Age =(person.DateOfBirth.HasValue) ? (int) ((DateTime.Now - person.DateOfBirth).Value.TotalDays / 365.25)  : 0,
            Gender = person.Gender,
            Email = person.Email,
            ReceivesNewsLetter = person.ReceivesNewsLetter,   
            CountryId = person.CountryId,
        };

        return personResponse;  
    }

    public override bool Equals(object? obj)
    {
        PersonResponse? other = obj as PersonResponse;
        if (other is null)
        {
            return false;
        }
        if(other.GetType() != typeof(PersonResponse))
        {
            return false;
        }

        bool isEqual = this.Id == other.Id
                    && this.Name == other.Name
                    && this.Address == other.Address
                    && this.Email == other.Email
                    && this.ReceivesNewsLetter == other.ReceivesNewsLetter
                    && this.DateOfBirth == other.DateOfBirth
                    && this.Age == other.Age
                    && this.Gender == other.Gender
                    && this.CountryId == other.CountryId
                    && this.CountryName == other.CountryName;

        return isEqual;

    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}

