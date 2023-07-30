using PersonsWebApp.DTOs;
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
    public bool? ReceivesNewsLetter { get; set; }
    public Guid? CountryId { get; set; }


    public static explicit operator Person(PersonRequest? personRequest)
    {
        ArgumentNullException.ThrowIfNull(personRequest, nameof(personRequest));

        Person person = new Person()
        {
            Id = Guid.NewGuid(),
            Name = personRequest.Name,
            Address = personRequest.Address,
            DateOfBirth = personRequest.DateOfBirth,
            Email = personRequest.Email,
            Gender = personRequest.Gender,
            ReceivesNewsLetter = personRequest.ReceivesNewsLetter,
            CountryId = personRequest.CountryId
        };

        return person;
    }


    public override bool Equals(object? obj)
    {
        Person? other = obj as Person;

        if (other is null)
        {
            return false;
        }

        if(other.GetType() != typeof(Person))
        {
            return false;
        }

        bool isEqual = this.Name == other.Name
                       && this.Address == other.Address
                       && this.Email == other.Email
                       && this.ReceivesNewsLetter == other.ReceivesNewsLetter
                       && this.DateOfBirth == other.DateOfBirth
                       && this.CountryId == other.CountryId
                       && this.Gender == other.Gender;

        return isEqual;        
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}