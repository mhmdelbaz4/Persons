using Microsoft.AspNetCore.Mvc;
using Persons.DTOs;
using Persons.Services;

namespace Persons.Controllers;

public class PersonsController : Controller
{
    private readonly IPersonsService _personsServices;
    public PersonsController(IPersonsService personsService)
    {
        _personsServices = personsService;
    }


    [Route("/")]
    [Route("Persons/Index")]
    public IActionResult Index(string? searchBy ,string? searchText)
    {
        ViewBag.SearchDict = new Dictionary<string, string>()
        {
            {nameof(PersonResponse.Name), "Person Name"},
            {nameof(PersonResponse.Email), "Email"},
            {nameof(PersonResponse.Address), "Address"},
            {nameof(PersonResponse.Gender), "Gender"},
            {nameof(PersonResponse.CountryName), "Country Name"},
            {nameof(PersonResponse.ReceivesNewsLetter), "Receive news letter"},
        };

        ViewBag.CurrentSearchBy = searchBy;
        ViewBag.CurrentSearchText = searchText;

        List<PersonResponse> PersonResponseList = _personsServices.GetFilteredPersons(searchBy,searchText).ToList();

        return View(PersonResponseList);
    }
}
