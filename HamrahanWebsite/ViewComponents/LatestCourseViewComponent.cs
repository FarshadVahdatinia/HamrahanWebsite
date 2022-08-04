using HamrahanTemplate.Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HamrahanWebsite.ViewComponents
{
    public class LatestCourseViewComponent : ViewComponent
    {
        private readonly IUow _uow;

        public LatestCourseViewComponent(IUow uow)
        {
            _uow = uow;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var topCourses = _uow.Course.GetLatestItems(a => a.UpdateDate, 6);

            return await Task.FromResult((IViewComponentResult)View("LatestCourse", topCourses));
        }
    }
}
