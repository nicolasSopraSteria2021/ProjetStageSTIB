using Microsoft.AspNetCore.Mvc;
using ProjetStageSTIB.Application.Service;
using ProjetStageSTIB.Domain.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetStageSTIB.WebApi.Controllers
{
    [ApiController]
    [Route("api/Category")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService category)
        {
            _categoryService = category;
        }

        [HttpGet]
        public ActionResult<ICategory> GetCategory()
        {
            return Ok(_categoryService.GetCategory());
        }

    }
}
