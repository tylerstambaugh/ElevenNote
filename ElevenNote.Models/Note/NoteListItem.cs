using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Models
{
    public class NoteListItem //model - class that you pick and choose the properties you want from the entity. This has less than all of the propties, for a list view, then you can call to get details for a specific note
    {

        public int NoteID { get; set; }
        public string Title { get; set; }

        [Display(Name="Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
