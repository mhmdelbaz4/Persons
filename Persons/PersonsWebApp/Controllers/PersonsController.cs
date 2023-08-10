using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PersonsWebApp.DTOs;
using PersonsWebApp.Enums;
using PersonsWebApp.ServiceContracts;

namespace PersonsWebApp.Controllers
{
    public class PersonsController : Controller
    {
        private readonly IPersonServices _personServices;
        private readonly ICountriesServices _countriesServices;

        public PersonsController(IPersonServices personServices ,ICountriesServices countriesServices)
        {
            _personServices = personServices;            
            _countriesServices = countriesServices;
        }


        [Route("/")]
        [Route("Persons/Index")]
        public IActionResult Index(string? searchText , string searchBy = nameof(PersonResponse.Name) ,
                                   string sortBy = nameof(PersonResponse.Name) , sortOptions sortOption = sortOptions.Asc)
        {
            List<PersonResponse> persons = _personServices.GetFilteredPersons(searchBy,searchText).ToList();
            List<PersonResponse> sortedPersons = _personServices.GetSortedPersons(persons,sortBy,sortOption).ToList();

            Dictionary<string ,string> PersonPropertiesDict = new ()
            {
                {nameof(PersonResponse.Name) , "Person Name"},
                { nameof(PersonResponse.Email) , "Email"},
                { nameof(PersonResponse.Address) , "Address"},
                { nameof(PersonResponse.DateOfBirth) , "Date Of Birth"},
                { nameof(PersonResponse.Gender) , "Gender"},
                { nameof(PersonResponse.CountryId) , "Country"},
                { nameof(PersonResponse.Age) , "Age"},
                { nameof(PersonResponse.ReceivesNewsLetter) , "Recieve News Letter"}

            };
            ViewBag.personProperties = PersonPropertiesDict;

            ViewBag.CurrentSearchBy = searchBy;
            ViewBag.CurrentSearchText = searchText;
            ViewBag.CurrentSortBy = sortBy;
            ViewBag.CurrentSortOptions = sortOption;

            return View(sortedPersons);
        }



        [HttpGet]
        [Route("persons/create")]
        public IActionResult Create()
        {
            
            ViewBag.Countries = _countriesServices.GetAllCountries()
                                                .Select(country => new SelectListItem()
                                                {
                                                    Text = country.Name ,Value =country.Id.ToString()
                                                });

            return View();
        }

        [HttpPost]
        [Route("persons/create")]
        public IActionResult Create(PersonRequest personRequest)
        {
            if(! ModelState.IsValid)
            {

                ViewBag.Countries =_countriesServices.GetAllCountries()
                                                .Select(country => new SelectListItem()
                                                {
                                                    Text = country.Name ,Value =country.Id.ToString()
                                                });

                ViewBag.Errors = ModelState.Values.SelectMany(e => e.Errors)
                                                   .Select(e => e.ErrorMessage) 
                                                   .ToList();

                return View();
            }

            _personServices.AddPerson(personRequest);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("Persons/Edit/{personId}")]
        public IActionResult Edit(Guid? personId)
        {
            PersonResponse? personResponse = _personServices.GetPersonById(personId);
            if(personResponse is null)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Countries = _countriesServices.GetAllCountries()
                                                   .Select(country => new SelectListItem()
                                                   {
                                                        Text = country.Name ,Value =country.Id.ToString()
                                                   });


            PersonUpdateRequest personUpdateRequest = new ()
            {
                Id = personResponse.Id,
                Address = personResponse.Address,
                Email = personResponse.Email,
                Name = personResponse.Name,
                DateOfBirth = personResponse.DateOfBirth,
                CountryId = personResponse.CountryId,
                Gender = personResponse.Gender,
                ReceivesNewsLetter = personResponse.ReceivesNewsLetter
            };

            return View(personUpdateRequest);
        }

        [HttpPost]
        [Route("persons/Edit")]
        public IActionResult Edit(PersonUpdateRequest personUpdateRequest)
        {
            if(! ModelState.IsValid)
            {
                ViewBag.Errors = ModelState.Values
                                            .SelectMany(value => value.Errors)
                                            .Select(error => error.ErrorMessage);


                ViewBag.Countries = _countriesServices.GetAllCountries()
                                                      .Select(country => new SelectListItem()
                                                      {
                                                         Text = country.Name , Value = country.Id.ToString()
                                                      });


                return View();
            }

            _personServices.UpdatePerson(personUpdateRequest);


            return RedirectToAction(nameof(Index));
        }        
    }   
}
