using HamrahanTemplate.Application.DTOs;
using HamrahanTemplate.Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HamrahanWebsite.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize(Policy = "PostReader")]
    public class PostController : Controller
    {
        private readonly IUow _uow;

        public PostController(IUow uow)
        {
            _uow = uow;
        }

        // GET: PostController
        [Authorize]
        public  IActionResult Index(int id)
        {
            List<PostDTO> postDto = new();
            var posts = _uow.Post.GetAll();

            foreach (var item in posts)
            {
                postDto.Add(new PostDTO()
                {
                    PersonID = item.PersonId,
                    Topic = item.Topic,
                    Content = item.Content,
                    Summary = item.Content.Substring(0, ((int)(item.Content.Length / 3))),
                    ImagesLink = item.ImagesLink,



                });
            }
            return View(postDto);

        }

        // GET: PostController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _uow.Post.FindById(id).FirstOrDefaultAsync();
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }
    }

    }

