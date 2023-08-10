using PersonsWebApp.DTOs;
using PersonsWebApp.Enums;
using PersonsWebApp.ServiceContracts;
using PersonsWebApp.Services;
using System.Text;
using Xunit;

namespace PersonsTest;

public class PersonServicesTest
{
    // private readonly IPersonServices _personServices;

    // public PersonServicesTest()
    // {
    //     _personServices = new PersonServices(false);
    // }

    // #region AddPerson
    // [Fact]
    // public void AddPerson_personIsNull()
    // {
    //     PersonRequest? personRequest = null;

    //     Assert.Throws<ArgumentNullException>(() =>
    //     {
    //         _personServices.AddPerson(personRequest);
    //     });

    // }

    // [Fact]
    // public void AddPerson_personNameIsEmpty()
    // {
    //     PersonRequest? personRequest = CreatePersonRequest();
    //     personRequest.Name = string.Empty;

    //     Assert.Throws<ArgumentException>(() =>
    //     {
    //         _personServices.AddPerson(personRequest);
    //     });

    // }

    // [Fact]
    // public void AddPerson_personNameLessThan3Chars()
    // {
    //     PersonRequest? personRequest = CreatePersonRequest();
    //     personRequest.Name = "Mo";

    //     Assert.Throws<ArgumentException>(() =>
    //     {
    //         _personServices.AddPerson(personRequest);
    //     });

    // }

    // [Fact]
    // public void AddPerson_personNameMoreThan100Chars()
    // {
    //     PersonRequest? personRequest = CreatePersonRequest();
    //     StringBuilder nameSB = new StringBuilder();

    //     for (int i = 0; i < 110; i++)
    //     {
    //         nameSB.Append("A");
    //     }

    //     personRequest.Name = nameSB.ToString();

    //     Assert.Throws<ArgumentException>(() =>
    //     {
    //         _personServices.AddPerson(personRequest);
    //     });

    // }

    // [Fact]
    // public void AddPerson_personEmailIsEmpty()
    // {
    //     PersonRequest? personRequest = CreatePersonRequest();
    //     personRequest.Email = string.Empty;

    //     Assert.Throws<ArgumentException>(() =>
    //     {
    //         _personServices.AddPerson(personRequest);
    //     });

    // }

    // [Fact]
    // public void AddPerson_DuplicatePersons()
    // {
    //     PersonRequest personRequest1 = CreatePersonRequest();
    //     PersonRequest personRequest2 = CreatePersonRequest();

    //     Assert.Throws<ArgumentException>(() =>
    //     {
    //         _personServices.AddPerson(personRequest1);
    //         _personServices.AddPerson(personRequest2);
    //     });

    // }

    // [Fact]
    // public void AddPerson_CorrectDetails()
    // {
    //     PersonRequest personRequest = CreatePersonRequest();

    //     PersonResponse personResponse = _personServices.AddPerson(personRequest);
    //     Assert.True(personResponse?.Id != Guid.Empty);

    //     IEnumerable<PersonResponse> allPersons = _personServices.GetAllPersons();
    //     Assert.Contains(personResponse , allPersons);

    //     PersonResponse actualPersonResponse = _personServices.GetPersonById(personResponse?.Id);
    //     Assert.Equal(personResponse ,actualPersonResponse);

    // }

    // #endregion

    // #region getAllPersons
    // [Fact]
    // public void getAllPersons_PersonsIsEmpty()
    // {

    //     Assert.Empty(_personServices.GetAllPersons());
    // }

    // [Fact]
    // public void getAllPersons_PersonsNotEmpty()
    // {
    //     IEnumerable<PersonRequest> personRequestList = CreatePersonRequestCollection();
    //     List<PersonResponse> expectedPersonResponseList = new List<PersonResponse>();

    //     foreach (PersonRequest personRequest in personRequestList)
    //     {
    //         expectedPersonResponseList.Add(_personServices.AddPerson(personRequest));
    //     }

    //     IEnumerable<PersonResponse> actualPersonResponse = _personServices.GetAllPersons();

    //     foreach (PersonResponse personResponse in expectedPersonResponseList)
    //     {
    //         Assert.Contains(personResponse, actualPersonResponse);
    //     }
    // }

    // #endregion

    // #region getPersonById
    // [Fact]
    // public void getPersonById_personIdIsNull()
    // {
    //     Guid? personId = null;

    //     Assert.Throws<ArgumentNullException>(() =>
    //     {
    //         _personServices.GetPersonById(personId);
    //     });
    // }

    // [Fact]
    // public void getPersonById_personIdIsIncorrect()
    // {
    //     Guid? personId = Guid.NewGuid();

    //     Assert.Throws<ArgumentException>(() =>
    //     {
    //         _personServices.GetPersonById(personId);
    //     });
    // }

    // [Fact]
    // public void getPersonById_personIdIsCorrect()
    // {
    //     PersonRequest personRequest = CreatePersonRequest();
    //     PersonResponse expectedPersonResponse = _personServices.AddPerson(personRequest);

    //     PersonResponse actualPersonResponse = _personServices.GetPersonById(expectedPersonResponse.Id);

    //     Assert.Equal(expectedPersonResponse, actualPersonResponse);

    // }

    // #endregion

    // #region UpdatePerson
    // [Fact]
    // public void UpdatePerson_PersonIdIsNull()
    // {
    //     PersonRequest updatePersonRequest = UpdatePersonRequest();

    //     Assert.Throws<ArgumentNullException>(() =>
    //     {
    //         _personServices.UpdatePerson(personId: null , updatePersonRequest);
    //     });
    // }

    // [Fact]
    // public void UpdatePerson_PersonIdIsIncorrect()
    // {
    //     PersonRequest updatePersonRequest = UpdatePersonRequest();

    //     Assert.Throws<ArgumentException>(() =>
    //     {
    //         _personServices.UpdatePerson(personId: Guid.NewGuid(), updatePersonRequest);
    //     });

    // }

    // [Fact]
    // public void UpdatePerson_PersonIsNull()
    // {
    //     PersonRequest personRequest = CreatePersonRequest();
    //     PersonResponse personResponse = _personServices.AddPerson(personRequest);

    //     Assert.Throws<ArgumentNullException>(() =>
    //     {
    //         _personServices.UpdatePerson(personResponse.Id, personRequest: null);
    //     });
    // }

    // [Fact]
    // public void UpdatePerson_PersonNameIsEmpty()
    // {
    //     PersonRequest personRequest = CreatePersonRequest();
    //     PersonResponse personResponse = _personServices.AddPerson(personRequest);

    //     PersonRequest updatePersonRequest = UpdatePersonRequest();
    //     updatePersonRequest.Name = string.Empty;

    //     Assert.Throws<ArgumentException>(() =>
    //     {
    //         _personServices.UpdatePerson(personResponse.Id, updatePersonRequest);
    //     });

    // }
    // [Fact]
    // public void UpdatePerson_PersonNameLessThan3Chars()
    // {
    //     PersonRequest personRequest = CreatePersonRequest();
    //     PersonResponse personResponse = _personServices.AddPerson(personRequest);

    //     PersonRequest updatePersonRequest = UpdatePersonRequest();
    //     updatePersonRequest.Name = "AA";

    //     Assert.Throws<ArgumentException>(() =>
    //     {
    //         _personServices.UpdatePerson(personResponse.Id, updatePersonRequest);
    //     });
    // }
    // [Fact]
    // public void UpdatePerson_PersonNameMoreThan100Chars()
    // {
    //     PersonRequest personRequest = CreatePersonRequest();
    //     PersonResponse personResponse = _personServices.AddPerson(personRequest);

    //     PersonRequest updatePersonRequest = UpdatePersonRequest();
        
    //     StringBuilder NameSB = new StringBuilder();
    //     for (int i = 0; i < 110; i++)
    //     {
    //         NameSB.Append("a");           
    //     }

    //     updatePersonRequest.Name = NameSB.ToString();

    //     Assert.Throws<ArgumentException>(() =>
    //     {
    //         _personServices.UpdatePerson(personResponse.Id, updatePersonRequest);
    //     });
    // }
    // [Fact]
    // public void UpdatePerson_PersonEmailIsEmpty()
    // {
    //     PersonRequest personRequest = CreatePersonRequest();
    //     PersonResponse personResponse = _personServices.AddPerson(personRequest);

    //     PersonRequest updatePersonRequest = UpdatePersonRequest();
    //     updatePersonRequest.Email = string.Empty;

    //     Assert.Throws<ArgumentException>(() =>
    //     {
    //         _personServices.UpdatePerson(personResponse.Id, updatePersonRequest);
    //     });
    // }

    // [Fact]
    // public void UpdatePerson_DuplicatePerson()
    // {
    //     PersonRequest personRequest1 = CreatePersonRequest();
    //     PersonResponse personResponse1 = _personServices.AddPerson(personRequest1);

    //     PersonRequest personRequest2 = CreatePersonRequest();
    //     personRequest2.Name = "Osama";
    //     PersonResponse personResponse2 = _personServices.AddPerson(personRequest2);

    //     PersonRequest updatePersonRequest = personRequest2;
    //     Assert.Throws<ArgumentException>(() =>
    //     {
    //         _personServices.UpdatePerson(personResponse1.Id , updatePersonRequest);
    //     });
    // }
    // [Fact]
    // public void UpdatePerson_CorrectDetails()
    // {
    //     PersonRequest personRequest = CreatePersonRequest();

    //     PersonResponse personResponse_beforeUpdate = _personServices.AddPerson(personRequest);

    //     PersonRequest updatePersonRequest = UpdatePersonRequest();

    //     PersonResponse personResponse_afterUpdate = _personServices.UpdatePerson(personResponse_beforeUpdate.Id, updatePersonRequest);

    //     Assert.Equal(personResponse_beforeUpdate.Id ,personResponse_afterUpdate.Id);

    //     PersonResponse personResponse_getById = _personServices.GetPersonById(personResponse_beforeUpdate.Id);

    //     Assert.Equal(personResponse_afterUpdate, personResponse_getById);


    //     IEnumerable<PersonResponse> personResponseList_getAllPersons = _personServices.GetAllPersons();
    //     Assert.Contains(personResponse_afterUpdate, personResponseList_getAllPersons);

    // }

    // #endregion

    // #region DeletePerson
    // [Fact]
    // public void DeletePerson_PersonIdIsNull()
    // {
    //     Guid? personId = null;

    //     Assert.Throws<ArgumentNullException>(() =>
    //     {
    //         _personServices.DeletePerson(personId);
    //     });
    // }
    // [Fact]
    // public void DeletePerson_PersonIdIsIncorrect()
    // {
    //     Guid? personId = Guid.NewGuid();

    //     bool deletedSuccessfully =_personServices.DeletePerson(personId);

    //     Assert.False(deletedSuccessfully);

    // }
    // [Fact]
    // public void DeletePerson_PersonIdIsCorrect()
    // {
    //     PersonRequest personRequest = CreatePersonRequest();
    //     PersonResponse personResponse = _personServices.AddPerson(personRequest);

    //     bool deletedSuccessfully = _personServices.DeletePerson(personResponse.Id);

    //     Assert.True(deletedSuccessfully);

    //     IEnumerable<PersonResponse> personResponseList_getAllPersons = _personServices.GetAllPersons();
    //     Assert.DoesNotContain(personResponse ,personResponseList_getAllPersons);

    //     Assert.Throws<ArgumentException>(() =>
    //     {
    //         _personServices.GetPersonById(personResponse.Id);
    //     });

    // }

    // #endregion

    // #region GetFilteredPersons

    // [Fact]
    // public void GetFilteredPersons_searchStringIsEmpty()
    // {
    //     IEnumerable<PersonRequest> personRequestList = CreatePersonRequestCollection();
    //     List<PersonResponse> expectedPersonResponseList = new List<PersonResponse>();
    //     foreach (PersonRequest personRequest in personRequestList)
    //     {
    //         expectedPersonResponseList.Add(_personServices.AddPerson(personRequest));
    //     }

    //     List<PersonResponse> actualPersonResponseList = _personServices.
    //                                             GetFilteredPersons(nameof(PersonResponse.Name), searchText: string.Empty).ToList();
 
    //     foreach(PersonResponse personResponse in expectedPersonResponseList)
    //     {
    //         Assert.Contains(personResponse, expectedPersonResponseList);
    //     }

    // }

    // [Fact]
    // public void GetFilteredPersons_searchStringIsValid()
    // {

    //     IEnumerable<PersonRequest> personRequestList = CreatePersonRequestCollection();
    //     List<PersonResponse> PersonResponseList = new List<PersonResponse>();
    //     foreach (PersonRequest personRequest in personRequestList)
    //     {
    //         PersonResponseList.Add(_personServices.AddPerson(personRequest));
    //     }

    //     string searchText = "ma";
    //     List<PersonResponse> expectedPersonResponseList =
    //                                                 _personServices.GetAllPersons()
    //                                                                 .Where(person => 
    //                                                                 {
    //                                                                     if (string.IsNullOrEmpty(person.Name))
    //                                                                     {
    //                                                                         return true;
    //                                                                     }
    //                                                                     else
    //                                                                     {
    //                                                                         return person.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase);
    //                                                                     }
                                                                    
    //                                                                 } )
    //                                                                 .ToList();  

    //     List<PersonResponse> actualPersonResponseList = _personServices.
    //                                             GetFilteredPersons(nameof(PersonResponse.Name), searchText).ToList();

    //     foreach (PersonResponse personResponse in expectedPersonResponseList)
    //     {
    //         Assert.Contains(personResponse, actualPersonResponseList);
    //     }

    // }




    // #endregion

    // #region getSortedPerons
    // [Fact]
    // public void getFilteredPersons_EmptyCollection()
    // {
    //     IEnumerable<PersonResponse> personList = Enumerable.Empty<PersonResponse>();
    //     string sortBy = nameof(PersonResponse.Name);

    //     IEnumerable<PersonResponse> personResponseList = _personServices.GetSortedPersons(personList, sortBy, sortOptions.Asc);
    //     Assert.Empty(personResponseList);
    // }


    // [Fact]
    // public void getFilteredPersons_subsetDateAsSearchBy()
    // {
    //     IEnumerable<PersonRequest> PersonRequestList = CreatePersonRequestCollection();
    //     List<PersonResponse> allPersons = new List<PersonResponse>();

    //     foreach (PersonRequest personRequest in PersonRequestList)
    //     {
    //         allPersons.Add(_personServices.AddPerson(personRequest));
    //     }

    //     string sortBy = nameof(PersonResponse.DateOfBirth);

    //     List<PersonResponse> actualPersonList = _personServices.GetSortedPersons(allPersons, sortBy, sortOptions.Asc).ToList();  

    //     List<PersonResponse> expectedPersonList = allPersons.OrderBy(person => person.DateOfBirth)
    //                                                         .ToList();

    //     for (int i = 0; i < expectedPersonList.Count; i++)
    //     {
    //         Assert.Equal(expectedPersonList[i], actualPersonList[i]);
    //     }

    // }

    // [Fact]
    // public void getFilteredPersons_completeDateAsSearchBy()
    // {
    //     IEnumerable<PersonRequest> PersonRequestList = CreatePersonRequestCollection();
    //     List<PersonResponse> allPersons = new List<PersonResponse>();

    //     foreach (PersonRequest personRequest in PersonRequestList)
    //     {
    //         allPersons.Add(_personServices.AddPerson(personRequest));
    //     }

    //     string sortBy = nameof(PersonResponse.DateOfBirth);

    //     List<PersonResponse> actualPersonList = _personServices.GetSortedPersons(allPersons, sortBy,sortOptions.Asc).ToList();

    //     List<PersonResponse> expectedPersonList = allPersons.OrderBy(person => person.DateOfBirth)
    //       .ToList();

    //     for (int i = 0; i < expectedPersonList.Count; i++)
    //     {
    //         Assert.Equal(expectedPersonList[i], actualPersonList[i]);
    //     }

    // }

    // [Fact]
    // public void getFilteredPersons_AgeAsSearchBy()
    // {
    //     IEnumerable<PersonRequest> PersonRequestList = CreatePersonRequestCollection();
    //     List<PersonResponse> allPersons = new List<PersonResponse>();

    //     foreach (PersonRequest personRequest in PersonRequestList)
    //     {
    //         allPersons.Add(_personServices.AddPerson(personRequest));
    //     }

    //     string sortBy = nameof(PersonResponse.Age);

    //     List<PersonResponse> actualPersonList = _personServices.GetSortedPersons(allPersons, sortBy,sortOptions.Asc).ToList();

    //     List<PersonResponse> expectedPersonList = allPersons.OrderBy(person => person.Age)
    //       .ToList();

    //     for (int i = 0; i < expectedPersonList.Count; i++)
    //     {
    //         Assert.Equal(expectedPersonList[i], actualPersonList[i]);
    //     }

    // }

    // [Fact]
    // public void getFilteredPersons_GenderAsSearchBy()
    // {
    //     IEnumerable<PersonRequest> PersonRequestList = CreatePersonRequestCollection();
    //     List<PersonResponse> allPersons = new List<PersonResponse>();

    //     foreach (PersonRequest personRequest in PersonRequestList)
    //     {
    //         allPersons.Add(_personServices.AddPerson(personRequest));
    //     }

    //     string sortBy = nameof(PersonResponse.Gender);

    //     List<PersonResponse> actualPersonList = _personServices.GetSortedPersons(allPersons, sortBy,sortOptions.Asc).ToList();

    //     List<PersonResponse> expectedPersonList = allPersons.OrderBy(person => person.Gender)
    //       .ToList();

    //     for (int i = 0; i < expectedPersonList.Count; i++)
    //     {
    //         Assert.Equal(expectedPersonList[i], actualPersonList[i]);
    //     }

    // }
    // [Fact]
    // public void getFilteredPersons_RecievesNewsLetterAsSearchBy()
    // {
    //     IEnumerable<PersonRequest> PersonRequestList = CreatePersonRequestCollection();
    //     List<PersonResponse> allPersons = new List<PersonResponse>();

    //     foreach (PersonRequest personRequest in PersonRequestList)
    //     {
    //         allPersons.Add(_personServices.AddPerson(personRequest));
    //     }

    //     string sortBy = nameof(PersonResponse.ReceivesNewsLetter);

    //     List<PersonResponse> actualPersonList = _personServices.GetSortedPersons(allPersons, sortBy, sortOptions.Asc).ToList();

    //     List<PersonResponse> expectedPersonList = allPersons.OrderBy(person => person.ReceivesNewsLetter)
    //       .ToList();

    //     for (int i = 0; i < expectedPersonList.Count; i++)
    //     {
    //         Assert.Equal(expectedPersonList[i], actualPersonList[i]);
    //     }
    // }
    // [Fact]
    // public void getFilteredPersons_subsetNameAsSearchBy()
    // {
    //     IEnumerable<PersonRequest> PersonRequestList = CreatePersonRequestCollection();
    //     List<PersonResponse> allPersons = new List<PersonResponse>();

    //     foreach (PersonRequest personRequest in PersonRequestList)
    //     {
    //         allPersons.Add(_personServices.AddPerson(personRequest));
    //     }

    //     string sortBy = nameof(PersonResponse.Name);

    //     List<PersonResponse> actualPersonList = _personServices.GetSortedPersons(allPersons, sortBy,sortOptions.Asc).ToList();

    //     List<PersonResponse> expectedPersonList = allPersons.OrderBy(person => person.Name)
    //       .ToList();

    //     for (int i = 0; i < expectedPersonList.Count; i++)
    //     {
    //         Assert.Equal(expectedPersonList[i], actualPersonList[i]);
    //     }
    // }
    // [Fact]
    // public void getFilteredPersons_totalNameAsSearchBy()
    // {
    //     IEnumerable<PersonRequest> PersonRequestList = CreatePersonRequestCollection();
    //     List<PersonResponse> allPersons = new List<PersonResponse>();

    //     foreach (PersonRequest personRequest in PersonRequestList)
    //     {
    //         allPersons.Add(_personServices.AddPerson(personRequest));
    //     }

    //     string sortBy = nameof(PersonResponse.Name);

    //     List<PersonResponse> actualPersonList = _personServices.GetSortedPersons(allPersons, sortBy,sortOptions.Asc).ToList();

    //     List<PersonResponse> expectedPersonList = allPersons.OrderBy(person => person.Name).ToList();

    //     for (int i = 0; i < expectedPersonList.Count; i++)
    //     {
    //         Assert.Equal(expectedPersonList[i], actualPersonList[i]);
    //     }
    // }

    // [Fact]
    // public void getFilteredPersons_totalNameAsSearchByDesc()
    // {
    //     IEnumerable<PersonRequest> PersonRequestList = CreatePersonRequestCollection();
    //     List<PersonResponse> allPersons = new List<PersonResponse>();

    //     foreach (PersonRequest personRequest in PersonRequestList)
    //     {
    //         allPersons.Add(_personServices.AddPerson(personRequest));
    //     }

    //     string sortBy = nameof(PersonResponse.Name);

    //     List<PersonResponse> actualPersonList = _personServices.GetSortedPersons(allPersons, sortBy,sortOptions.Desc).ToList();

    //     List<PersonResponse> expectedPersonList = allPersons.OrderByDescending(person => person.Name)
    //       .ToList();

    //     for (int i = 0; i < expectedPersonList.Count; i++)
    //     {
    //         Assert.Equal(expectedPersonList[i], actualPersonList[i]);
    //     }
    // }

    // #endregion

    // #region HelperMethods

    // private PersonRequest CreatePersonRequest()
    // {
    //     PersonRequest personRequest = new PersonRequest()
    //     {
    //         Name = "Mohamed Elbaz",
    //         Email = "mhmdelbaz57@gmail.com",
    //         Address = "Mansoura ,Egypt",
    //         DateOfBirth = new DateTime(2000,4,15),
    //         Gender = GenderOptions.Male,
    //         ReceivesNewsLetter = true 
    //     };

    //     return personRequest;

    // }

    // private PersonRequest UpdatePersonRequest()
    // {
    //     PersonRequest personRequest = new PersonRequest()
    //     {
    //         Name = "Osama Ibrahim",
    //         Email = "osamaibrahim@gmail.com",
    //         Address = "Giza ,Egypt",
    //         DateOfBirth = new DateTime(1999, 1, 1),
    //         Gender = GenderOptions.Male,
    //         ReceivesNewsLetter = false
    //     };

    //     return personRequest;

    // }


    // private IEnumerable<PersonRequest> CreatePersonRequestCollection()
    // {
    //     PersonRequest personRequest1 = new PersonRequest()
    //     {
    //         Name = "Mohamed Elbaz",
    //         Email ="mhmdelbaz@gmail.com",
    //         Address ="Mansoura ,Egypt",
    //         Gender = GenderOptions.Male,
    //         DateOfBirth=new DateTime(2000,4,15),
    //         ReceivesNewsLetter = true
    //     };

    //     PersonRequest personRequest2 = new PersonRequest()
    //     {
    //         Name = "Abdo Alsayed",
    //         Email = "abdoalsayed@gmail.com",
    //         Address = "Cairo ,Egypt",
    //         Gender = GenderOptions.Male,
    //         DateOfBirth = new DateTime(1995, 6, 7),
    //         ReceivesNewsLetter = false
    //     };

    //     PersonRequest personRequest3 = new PersonRequest()
    //     {
    //         Name = "Amira Osama",
    //         Email = "amiraosama@gmail.com",
    //         Address = "Alex ,Egypt",
    //         Gender = GenderOptions.Female,
    //         DateOfBirth = new DateTime(1998, 8, 16),
    //         ReceivesNewsLetter = false
    //     };

    //     PersonRequest personRequest4 = new PersonRequest()
    //     {
    //         Name = "Tarek Mahmoud",
    //         Email = "tarekmahmoud@gmail.com",
    //         Address = "Aswan ,Egypt",
    //         Gender = GenderOptions.Male,
    //         DateOfBirth = new DateTime(2002, 5, 22),
    //         ReceivesNewsLetter = true
    //     };

    //     List<PersonRequest> personRequestList = new List<PersonRequest>()
    //     {
    //         personRequest1, personRequest2, personRequest3, personRequest4
    //     };

    //     return personRequestList;

    // }

    // #endregion
}
