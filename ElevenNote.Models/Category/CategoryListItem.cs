using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ElevenNote.Data.Category;

namespace ElevenNote.Models.Category
{
    public class CategoryListItem
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        [Display(Name = "Category Level")]
        public CategoryLevel CategoryLevel { get; set; }
    }
}
