
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
    public class NoteController : ApiController
    {
        //private - can only be called from within this class
        private NoteService CreateNoteService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var noteService = new NoteService(userId);
            return noteService;
        }

        [HttpGet]
        public IHttpActionResult GetNotesForAUser()
        {
            NoteService noteService = CreateNoteService();
            var notes = noteService.GetNotes(); //returns IEnumerable of <NoteListItem>
            return Ok(notes);
        }


        //HTTP endpoint for POSTing a noteModel that is passed to the NoteService to make a Note entity to write to the database.
        [HttpPost]
        public IHttpActionResult PostANote(NoteCreate noteModel)
        {
            //
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            NoteService noteService = CreateNoteService();

            if (!noteService.CreateNote(noteModel))
                return InternalServerError();

            return Ok($"Note created successfully");
        }
    }
}
