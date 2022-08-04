using FarshadTools;
using Hamrahan.Models;
using HamrahanTemplate.Application.DTOs;
using HamrahanTemplate.Application.Pagination;
using HamrahanTemplate.Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HamrahanWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize()]
    public class PersonController : Controller
    {

        private readonly IUow _uow;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<Person> _userManager;
        private string apiUrl = "https://localhost:44396/api/ApiPerson";
        private HttpClient _client;
        public PersonController(IUow uow, RoleManager<IdentityRole> roleManager, UserManager<Person> userManager)
        {
            _uow = uow;
            _roleManager = roleManager;
            _userManager = userManager;
            _client = new HttpClient();

        }

        // GET: PersonController
        public ActionResult Index([FromQuery] PersonPaginationParameters parameters)
        {
            if (parameters.PageNumber < 1)
            {
                parameters.PageNumber = 1;
            }

            var person = _uow.Person.FindAllByPagination(parameters);
            ViewBag.CurrentPage = person.CurrentPage;
            ViewBag.TotalPages = person.TotalPages;






            ///only in case if bad page entered

            List<PersonDTO> personDTO = new();

       
            
            foreach (var item in person)
            {
                personDTO.Add(new PersonDTO
                {

                    FirstName = item.FirstName,
                    Lastname = item.Lastname,
                    TelePhone = item.TelePhone,
                    PhoneNumber = item.PhoneNumber,
                    EducationGradeName = _uow.Grade.Find(t => t.Code == item.EducationGradecode).Result.FirstOrDefault().Grade,
                    PersianBirthdate = item.Birthdate.ToPersianDate(),
                    Age = item.Age,
                    Gender = item.Gender,
                    UserName = item.Email,
                    

                }) ;
            }
            return View(personDTO);

        }

        // GET: PersonController/Details/5
        public async Task<ActionResult> Details(string? id)
        {

            var  person = await _uow.Person.FindById(id);
            var personDto = new PersonDTO
            {

                FirstName = person.FirstName,
                Lastname = person.Lastname,
                TelePhone = person.TelePhone,
                PhoneNumber = person.PhoneNumber,
                Age = person.Age,
                UserName = person.Email,
                PersianBirthdate = person.Birthdate.ToPersianDate(),
                NationalCode = person.NationalCode,
                Address = person.Address,
                //Roles = roles



            };

         

            return View(personDto);
        }

        // GET: PersonController/Create
        public ActionResult Create()
        {
      
            ViewData["EducationGradeCode"] = new SelectList(_uow.Grade.GetAll(), "Code", "Grade");

           


            return View();
            
        }

        // POST: PersonController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public ActionResult Create( PersonDTO personDTO)
        {
            try
            {
                #region OldCreateMethod
                Person person = new()
                {
                    FirstName = personDTO.FirstName,
                    Lastname = personDTO.Lastname,
                    TelePhone = personDTO.TelePhone,
                    PhoneNumber = personDTO.PhoneNumber,
                    EducationGradecode = personDTO.EducationGradeCode,
                    UserName = personDTO.Email,
                    Birthdate = new DateTime(personDTO.Birthdate.Year, personDTO.Birthdate.Month, personDTO.Birthdate.Day, new PersianCalendar()),
                    NationalCode = personDTO.NationalCode,
                    Email = personDTO.Email,
                    Address = personDTO.Address,
                    Gender = personDTO.Gender,


                };
                var result = _userManager.CreateAsync(person, personDTO.Password).Result;
                var addRole = _userManager.AddToRoleAsync(person, Roles.Customer).Result;


                if (result.Succeeded && addRole.Succeeded)
                {
                    return RedirectToAction("Index", "Person", new { area = "Admin" });

                }
                else
                {
                    return View(personDTO);
                }
                #endregion



                //string jsonCustomer = JsonConvert.SerializeObject(personDTO);

                //StringContent content = new StringContent(jsonCustomer, Encoding.UTF8, "application/json");

                //var res = _client.PostAsync(apiUrl, content).Result;
       
                //return View(personDTO);
            }

            catch
            {
                return View(personDTO);
            }
        }

        // GET: PersonController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PersonController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize("Admin")]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PersonController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}
