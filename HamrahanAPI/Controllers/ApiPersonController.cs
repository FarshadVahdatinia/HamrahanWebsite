using AutoMapper;
using Hamrahan.Models;
using HamrahanTemplate.Application.DTOs;
using HamrahanTemplate.Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HamrahanAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ApiPersonController : ControllerBase
    {
        private readonly IUow _uow;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<Person> _userManager;
        private readonly IMapper _mapper;
        private readonly Microsoft.Extensions.Logging.ILogger _logger;

        public ApiPersonController(ILogger<ApiPersonController> logger, IUow uow, RoleManager<IdentityRole> roleManager, UserManager<Person> userManager, IMapper mapper)
        {
            _logger = logger;
            _uow = uow;
            _roleManager = roleManager;
            _userManager = userManager;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // GET: api/<PersonController>
        [HttpGet]
      //  [Authorize(Policy="Read_Person")]
     
        public IActionResult GetUser()
        {

            var person = _uow.Person.GetAll().ToList();


            List<ApiUserDTO> personDTO = new();
            foreach (var item in person)
            {
                personDTO.Add(new ApiUserDTO
                {

                    FirstName = item.FirstName,
                    Lastname = item.Lastname,
                    TelePhone = item.TelePhone,
                    PhoneNumber = item.PhoneNumber,
                    EducationGradeName = _uow.Grade.Find(t => t.Code == item.EducationGradecode).Result.FirstOrDefault().Grade,
                    Age = item.Age,
                    Gender = item.Gender,
                    UserName = item.Email,


                });
            }
            var user = new ObjectResult(personDTO)
            {
                
                StatusCode = (int)HttpStatusCode.OK
               
            };

            return Ok(user);
        }

        // GET api/<PersonController>/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> Get([FromRoute] string id)
        {
            if (await _uow.Person.IsExists(id))
            {
                var customer = await _uow.Person.FindById(id);
                var personDto = new ApiUserDTO
                {

                    FirstName = customer.FirstName,
                    Lastname = customer.Lastname,
                    TelePhone = customer.TelePhone,
                    PhoneNumber = customer.PhoneNumber,
                    Age = customer.Age,
                    UserName = customer.Email,
                    EducationGradeName = _uow.Grade.Find(t => t.Code == customer.EducationGradecode).Result.FirstOrDefault().Grade,
                    Gender = customer.Gender
                };
                return Ok(personDto);
            }

            else
            {
                return NotFound();
            }

        }

        //[HttpGet("{email}")]
        //public async Task<IActionResult> GetByEmail([FromBody] string email)
        //{
        //    if (await _uow.Person.IsExistsByEmail(email))
        //    {
        //        var customer = await _uow.Person.FindById(email);
        //        var personDto = new ApiUserDTO
        //        {

        //            FirstName = customer.FirstName,
        //            Lastname = customer.Lastname,
        //            TelePhone = customer.TelePhone,
        //            PhoneNumber = customer.PhoneNumber,
        //            Age = customer.Age,
        //            UserName = customer.Email,
        //            EducationGradeName = _uow.Grade.Find(t => t.Code == customer.EducationGradecode).Result.FirstOrDefault().Grade,
        //            Gender = customer.Gender
        //        };
        //        return Ok(personDto);
        //    }

        //    else
        //    {
        //        return NotFound();
        //    }



        //}

        // POST api/<PersonController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ApiUserDTO user)
        {
            try
            {


                Person person = new()
                {
                    FirstName = user.FirstName,
                    Lastname = user.Lastname,
                    TelePhone = user.TelePhone,
                    PhoneNumber = user.PhoneNumber,
                    EducationGradecode = user.EducationGradeCode,
                    UserName = user.Email,
                    Birthdate = user.Birthdate,
                    NationalCode = user.NationalCode,
                    Email = user.Email,
                    Gender = user.Gender,


                };

                var result = await _userManager.CreateAsync(person, user.Password);
                var addRole = await _userManager.AddToRoleAsync(person, "Customer");
                if (result.Succeeded && addRole.Succeeded)
                {
                    return CreatedAtAction("GetByEmail", new { email = user.Email }, new ApiUserDTO
                    {
                        
                        Email = user.Email,
                        Age = user.Age,
                        EducationGradeName = _uow.Grade.Find(p => p.Code == user.EducationGradeCode).Result.FirstOrDefault().Grade,
                        id = user.id,
                        GenderForShow = _uow.Person.Gender(user.Gender),
                        UserName =  $"{_uow.Person.Gender(user.Gender)} {user.FirstName} {user.Lastname}",
                    }) ;

                }
                else
                {
                    string message = "";
                    foreach (var item in result.Errors.ToList())
                    {
                        message += item.Description + Environment.NewLine;
                    }

                    return BadRequest(message);
                }
            }
                 
                catch(Exception e)
            {
              
                return BadRequest(e)  ;
            }


        }

            

// PUT api/<PersonController>/5
        [HttpPut]
        public async Task<IActionResult> Put( [FromBody] ApiUpdateDTO user)
        {


            try
            {

                await _uow.Person.UpdatePerson(user);
                _uow.save();
                return Ok();
                //if (await _uow.Person.IsExists(user.id))
                //{
                    
                   
                //    Person person = new()
                //    {
                      
                //        FirstName = user.FirstName ,
                //        Lastname = user.Lastname ,
                //        TelePhone = user.TelePhone,
                //        PhoneNumber = user.PhoneNumber ,
                //        UserName = user.Email ,
                //        Birthdate = user.Birthdate,
                //        NationalCode = user.NationalCode ,
                //        Email = user.Email ,
                       



                //    };
                //   await _uow.Person.UpdatePerson(user.id, person);
                    
                //    if (ModelState.IsValid)
                //    {
                //        return Ok(person);
                //    }
                //    else
                //    {
                //        return BadRequest("Something went Wrong!!");
                //    }
                //}
                //else
                //{
                //    return NotFound();
                //}
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        // DELETE api/<PersonController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpPatch ]
        public IActionResult UpdateWithPatch(string id,[FromBody] JsonPatchDocument<ApiUpdateDTO> patchDocument)
        {
            if (patchDocument == null)
            {
                return BadRequest();

            }

            if (!_uow.Person.IsExists(id).Result)
            {
                return NotFound();

            }
            var user = _uow.Person.FindById(id).Result;
            
            var userToPatch = _mapper.Map<ApiUpdateDTO>(user);
            
            patchDocument.ApplyTo(userToPatch);
           var a= _mapper.Map(userToPatch, user);
            _uow.Person.Update(user);
            return Ok() ;

        }
    }
}
