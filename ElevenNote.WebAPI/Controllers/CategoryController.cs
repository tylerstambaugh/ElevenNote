using ElevenNote.Models;
using ElevenNote.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ElevenNote.WebAPI.Controllers
{
    [Authorize]
    public class CategoryController : ApiController
    {

        //create a local, private category service to pass the API request to, to create the models.
        private CategoryService CreateCategoryService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var categoryService = new CategoryService(userId);
            return categoryService;
        }

        //HTTP endpoint for POSTing a new category to. The body of the request is 
        // put into a service call to map to an entity and save to the DB.
        
        [HttpPost]
        public IHttpActionResult PostACategory([FromBody] CategoryCreate categoryModel)
        {
            //check the model
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            //call createCategory method on CategoryService
            CategoryService categoryService = CreateCategoryService();

            if (!categoryService.CreateCategory(categoryModel))
                return InternalServerError();

            return Ok($"Categroy {categoryModel.CategoryName} was added successfully");
        }

    }
}
