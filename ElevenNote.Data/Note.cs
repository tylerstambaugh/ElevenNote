using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Data
{
    public class Note // primary DB entity for the project. 
    {

        //Validation attributes [Required], [Range], [MaxLength]...
        // [Range(1,5, ErroMessage="please input a number between 1 and 5")]

        //display attributes [Display(Name)] [Display]
        //[Display(name = "Your note)]
        
        [Key]
        public int NoteId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
