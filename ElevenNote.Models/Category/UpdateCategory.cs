using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ElevenNote.Data.Category;

namespace ElevenNote.Models
{
    public class UpdateCategory
    {
        public string CategoryName { get; set; }
        public CategoryLevel CategoryLevel { get; set; }
    }
}
