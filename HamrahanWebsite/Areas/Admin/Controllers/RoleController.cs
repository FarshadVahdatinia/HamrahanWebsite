using HamrahanTemplate.Application.DTOs;
using HamrahanTemplate.Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HamrahanWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : Controller

    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }


        // GET: RoleController1
        public ActionResult Index()
        {
            
            var roles = _roleManager.Roles.Select(p=>
              new RoleDTO
              {

                  Id = p.Id,
                  Name = p.Name,
                  ConcurrencyStamp = p.ConcurrencyStamp,
                  NormalizedName = p.NormalizedName
              }).ToList();
            
            
            return View(roles);
        }

        // GET: RoleController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RoleController1/Create
        public ActionResult Create()
        {
            return View();

        }

        // POST: RoleController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RoleDTO roleDTO)
        {
            try
            {
                IdentityRole role = new()
                {

                   
                    Name = roleDTO.Name
                   
                };
                var result = _roleManager.CreateAsync(role).Result;
                if (result.Succeeded)
                {
                    return RedirectToAction("index", "Role", new { Areas = "admin" });
                }
                ViewBag.Errors = result.Errors.Select(p=> new { p.Description, p.Code }).ToList();
                return View(roleDTO);
            }
            catch
            {
                return View();
            }
        }

        // GET: RoleController1/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var role = _roleManager.FindByIdAsync(id).Result;
            if (role == null)
            {
                return NotFound();
            }
            RoleDTO roleDTO = new()
            {
                Id = role.Id,
                Name = role.Name,
                ConcurrencyStamp = role.ConcurrencyStamp,
                NormalizedName = role.NormalizedName
            };


            return View(roleDTO);
        }
    

        // POST: RoleController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, RoleDTO roleDTO )
        {
      

            if (id != roleDTO.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var role = _roleManager.FindByIdAsync(id).Result;

                    role.Name = roleDTO.Name;
                
                    var result = _roleManager.UpdateAsync(role).Result;
                    if (result.Succeeded)
                    {
                        return RedirectToAction("index", "Role", new { Areas = "admin" });
                    }
                    ViewBag.Errors = result.Errors.Select(p => new { p.Description, p.Code }).ToList();
                    return View(roleDTO);

                }
                catch (Exception)
                {
                   
                }   
            }

            return NoContent();
        }

    // GET: RoleController1/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var role = _roleManager.FindByIdAsync(id).Result;
            if (role == null)
            {
                return NotFound();
            }
            RoleDTO roleDTO = new()
            {
                Id = role.Id,
                Name = role.Name,
                ConcurrencyStamp = role.ConcurrencyStamp,
                NormalizedName = role.NormalizedName
            };


            return View(roleDTO);
        }

        // POST: RoleController1/Delete/5
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
