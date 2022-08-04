using Contexts;
using FarshadTools;
using Hamrahan.Models;
using HamrahanTemplate.Application.DTOs;
using HamrahanTemplate.Application.Pagination;
using HamrahanTemplate.Infrastructure.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HamrahanTemplate.Infrastructure.Repository
{
    public class PersonRepository:Repository<Person>,IPersonRepository
    {
        private readonly HamrahanDbContext _db;

        public PersonRepository(HamrahanDbContext db):base(db)
        {
            _db = db;
        }

        public async Task UpdatePerson( ApiUpdateDTO dto)
        {
            var person = await _db.Person.SingleOrDefaultAsync(x=>x.Id == dto.id);
            if (person == null)
                throw new Exception("شخص یافت نشد");

            person.FirstName = dto.FirstName ?? person.FirstName;

            person.Lastname = dto.Lastname ?? person.Lastname;
            person.PhoneNumber = dto.PhoneNumber ?? person.PhoneNumber;
            person.TelePhone = dto.TelePhone ?? person.TelePhone;
            person.NationalCode = dto.NationalCode ?? person.NationalCode;
            person.Email = dto.Email ?? person.Email;
            person.Birthdate = dto.Birthdate ?? person.Birthdate;
            person.Age = dto.Age ?? person.Age;
            person.Gender = dto.Gender ?? person.Gender;
            person.EducationGradecode = dto.EducationGradeCode ?? person.EducationGradecode;
            person.UserName = dto.UserName ?? person.UserName;
            _db.Update(person);
            //var originalUser =await _db.Person.FirstOrDefaultAsync(o => o.Id == id);
            //_db.Entry(originalUser).CurrentValues.SetValues(user);

            //_db.SaveChanges();

        }
        /// <summary>
        /// متد سرچ با آیدی
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Person> FindById(string? id)
        {
            return await _db.Person.Where(t => t.Id == id).FirstOrDefaultAsync();
        }
        /// <summary>
        /// متد سرچ با ایمیل
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<Person> FindByEmail(string email)
        {
           return await _db.Person.Where(t => t.Email == email).FirstOrDefaultAsync();
          
        }
        public Pagination<Person> FindAllByPagination(PersonPaginationParameters parameters)
        {
            Pagination<Person> p= new(_db.Person.OrderBy(n => n.RegisterDate), parameters.PageNumber, parameters.PageSize);
            return p;
        }
     
        public async Task<bool> IsExists(string id)
        {
            return await _db.Person.AnyAsync(p=>p.Id == id);
        } 
       
        
        public async Task<bool> IsExistsByEmail(string email)
        {
            return await _db.Person.AnyAsync(p => p.Email == email);
        }
        public  string Gender(bool gender)
        {
            if (gender)
            {
                return "جناب آقا";

            }
            return "سرکار خانم";
        }
    }
}
