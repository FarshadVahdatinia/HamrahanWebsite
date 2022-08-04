using HamrahanTemplate.Application.DTOs;
using HamrahanTemplate.Application.Pagination;
using HamrahanTemplate.Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HamrahanWebsite.Areas.Admin.Controllers
{
    public class CourseController : Controller
    {
        private readonly IUow _uow;

        public CourseController(IUow uow)
        {
            _uow = uow;
        }

        // GET: CourseController
        public ActionResult Index([FromQuery] CoursePaginationParameters parameters)
        {
            if (parameters.PageNumber < 1)
            {
                parameters.PageNumber = 1;
            }
            var person = _uow.Course.FindAllByPagination(parameters);
            ViewBag.CurrentPage = person.CurrentPage;
            ViewBag.TotalPages = person.TotalPages;


            List<CourseDTO> courseDto = new();
            var courses = _uow.Course.GetAll().ToList();
            foreach (var item in courses)
            {
                courseDto.Add(new CourseDTO
                {

                    Title = item.Title,
                    CourseDescription = item.CourseDescription,
                    CourseImageName = item.CourseImageName,
                    
                    CreateDate = item.CreateDate,
                    TeacherName = _uow.Person.Find(t => t.Id == item.TeacherId).Result.FirstOrDefault().FullName,
                    

                }) ;
            }
            return View(courseDto);
        }

        // GET: CourseController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CourseController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CourseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: CourseController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CourseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
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

        // GET: CourseController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CourseController/Delete/5
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
