using Hamrahan.Models;
using HamrahanTemplate.Application.DTOs;
using HamrahanTemplate.Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HamrahanWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GradeController : Controller
    {
        private readonly IUow _uow;

        public GradeController(IUow uow)
        {
            _uow = uow;
        }

        // GET: GradeController
        public ActionResult Index()
        {


            List<EducatinGradeDTO> GradeDto = new();
            var Grades = _uow.Grade.GetAll().ToList();
            foreach (var item in Grades)
            {
                GradeDto.Add(new EducatinGradeDTO
                {
                    Code = item.Code,
                    Grade = item.Grade


                });
            }
            return View(GradeDto);
        } 
    

        // GET: GradeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GradeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GradeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EducatinGradeDTO educatinGradeDTO)
        {
            if (ModelState.IsValid)
            {
          
                try
                {
                    EducationGrade educationGrade = new()
                    {
                        
                        Grade=educatinGradeDTO.Grade
                    };
                    _uow.Grade.Insert(educationGrade);
                    _uow.save();
                    return RedirectToAction(nameof(Index));

                }
                catch
                {
                    return View();
                }
            }
            return View();
        }

        // GET: GradeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GradeController/Edit/5
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

        // GET: GradeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GradeController/Delete/5
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
