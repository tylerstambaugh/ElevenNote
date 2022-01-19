using ElevenNote.Data;
using ElevenNote.Models;
using ElevenNote.Models.Category;
//using ElevenNote.Models.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Services
{
    public class CategoryService //services are how we write models to the DB. The CRUD operations called from the controller. The controller calls with a model and we map it to an entity then call the DB context to write the entity to the dB.
    {
        private readonly Guid _userId;

        public CategoryService(Guid userId)
        {
            _userId = userId;
        }

        //Create a category in the DB:
        public bool CreateCategory(CategoryCreate categoryModel)
        {
            Category categoryEntity = new Category()
            {
                CategoryName = categoryModel.CategoryName,
                CatLevel = categoryModel.CategoryLevel,
               // CreatedDate = categoryModel.CreatedDate
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Categories.Add(categoryEntity);
                    return (ctx.SaveChanges() == 1);
            }
        }

        // Read out all the categories from the DB and return as an array

        public IEnumerable<CategoryListItem> GetAllCategories()
        {
            //  List<Category> listOfCategories = new List<Category>;
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Categories
                    .Select(
                        e =>
                            new CategoryListItem
                            {
                                CategoryID = e.CategoryID,
                                CategoryName = e.CategoryName,
                                CategoryLevel = e.CatLevel
                            }
                        );
                return query.ToArray();
            }
        }


        //update a category by it's ID and return the updated category.
        public Category UpdateACategoryByID(int categoryID, UpdateCategory updatedCategory)
        {
            using (var ctx = new ApplicationDbContext())
            {
                Category categoryToUpdate =
                    ctx
                    .Categories
                    .Single(e => e.CategoryID == categoryID);

                categoryToUpdate.CategoryName = updatedCategory.CategoryName;
                categoryToUpdate.CatLevel = updatedCategory.CategoryLevel;

                if(ctx.SaveChanges() == 1)
                {
                    Category categoryToReturn =
                        ctx
                        .Categories
                        .Single(e => e.CategoryID == categoryID);

                    return categoryToReturn;
                }
                else
                {
                    return null;
                }
            }
        }

        //Delete a category
        public bool DeleteACategoryByID(int categoryID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                Category categoryToDelete =
                    ctx
                    .Categories
                    .Single(e => e.CategoryID == categoryID);
                ctx.Categories.Remove(categoryToDelete);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
