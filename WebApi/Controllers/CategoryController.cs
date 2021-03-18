using Microsoft.AspNetCore.Mvc;
using ProjetStageSTIB.Application.Service;
using ProjetStageSTIB.Domain.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetStageSTIB.WebApi.Controllers
{
    //controller, c'est ici qu'on va etablir les appels que pourra faire le FT pour avoir accès aux éléments de la db

    [ApiController]
    [Route("api/category")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        //creation d'une instance de categoryService
        public CategoryController(ICategoryService category)
        {
            _categoryService = category;
        }

        //renvoie toutes les catory de la db
        [HttpGet]
        public ActionResult<ICategory> GetCategory()
        {
            return Ok(_categoryService.GetCategory());
        }

    }
}
