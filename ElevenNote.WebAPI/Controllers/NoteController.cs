
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


        //API GET endpoint that returns all notes for a user
        [HttpGet]
        public IHttpActionResult GetNotesForAUser()
        {
            NoteService noteService = CreateNoteService();
            var notes = noteService.GetNotes(); //returns IEnumerable of <NoteListItem>
            return Ok(notes);
        }

        //API GET endpoint to get a note by ID
        [HttpGet]
        public IHttpActionResult GetNoteDetailById(int id)
        {
            NoteService noteService = CreateNoteService();
            var notes = noteService.GetNoteDetailById(id); //returns NoteDetail from the NoteService
            return Ok(notes);
        }

        // API PUT endpoint to update a note based on the 

        [HttpPut]
        public IHttpActionResult UpdateNote(NoteEdit updatedNote)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            NoteService noteService = CreateNoteService();
            if (!noteService.UpdateNote(updatedNote))
                return InternalServerError();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteNote(int id)
        {
            NoteService noteService = CreateNoteService();

            if (!noteService.DeleteNoteByID(id))
                return InternalServerError();

            return Ok();
        }

    }
}
