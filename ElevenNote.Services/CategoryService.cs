using ElevenNote.Data;
using ElevenNote.Models;
//using ElevenNote.Models.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Services
{
    public class CategoryService //services are how we write models to the DB
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
                CatLevel = categoryModel.CategoryLevel
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Categories.Add(categoryEntity); ;
                    return (ctx.SaveChanges() == 1);
            }
        }

    }
}
