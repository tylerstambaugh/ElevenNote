using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ElevenNote.Data.Category;

namespace ElevenNote.Models
{
    public class CategoryCreate //category create model
    {
        [Required, MinLength(2, ErrorMessage = "Category must be at least 2 charaters in length."), MaxLength(50, ErrorMessage = "Category cannoth exceed 50 characters in length")]
        public string CategoryName { get; set; }
        [Required, Range(1, 4)]
        public CategoryLevel CategoryLevel { get; set; }

       // public DateTime CreatedDate { get; set; }
    }
}
