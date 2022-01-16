using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Data
{
    public class Category //category entity, FK on Note entity
    {
        public enum CategoryLevel {Sever = 1, High, Normal, Low }

        [Key]
        public int CategoryID { get; set; }

        [Required]
        public string CategoryName { get; set; }
        
        [Required, Display(Name = "Category Level")]
        public CategoryLevel CatLevel { get; set; }

    }
}
