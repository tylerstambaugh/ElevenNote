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


        //controller action to get the list of all categories
        [HttpGet]
        public IHttpActionResult GetAllCategories()
        {
            CategoryService categoryService = CreateCategoryService();
            return Ok (categoryService.GetAllCategories());
        }


        //delete a category by it's ID controller action.
        [HttpDelete]
        public IHttpActionResult DeleteCategoryByID(int categoryID)
        {
            CategoryService categoryService = CreateCategoryService();
            if (categoryService.DeleteACategoryByID(categoryID))
                return Ok();
            return InternalServerError();
        }

        //update a category controller action that takes in the category ID to update and the updated category model (catgory name and level)
        [HttpPut]
        public IHttpActionResult UpdateACateGoryByID([FromUri] int categoryId, [FromBody] UpdateCategory newCategory)
        {
            CategoryService categoryService = CreateCategoryService();
            var updatedCategory = categoryService.UpdateACategoryByID(categoryId, newCategory);
            if (updatedCategory != null)
                return Ok(updatedCategory);
            return InternalServerError();
        }

    }
}
