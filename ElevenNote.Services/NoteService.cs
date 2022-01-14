using ElevenNote.Data;
using ElevenNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Services
{

    //The service layer is how our application interacts with the database. 
    public class NoteService
    {
        private readonly Guid _userId;

        public NoteService(Guid userId)
        {
            _userId = userId;
            
        }

        //create a note in the database 
        //take the NoteCreate model properties and assign them to and entity, then write the 
        //entity to the DB
        public bool CreateNote(NoteCreate noteModel)
        {
            //using inline constructor 
            Note noteEntity = new Note()
            {
                OwnerId = _userId,
                Title = noteModel.Title,
                Content = noteModel.Content,
                CreatedUtc = DateTimeOffset.Now
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Notes.Add(noteEntity);
                return (ctx.SaveChanges() == 1);
            }
        }

        //get all the notes for this user.
        public IEnumerable<NoteListItem> GetNotes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                //linq query
                var query =
                    ctx     //query Notes table
                        .Notes
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                        e =>
                            new NoteListItem
                            {
                                NoteID = e.NoteId,
                                Title = e.Title,
                                CreatedUtc = e.CreatedUtc
                            }
                        );

                return query.ToArray();

            }
        }

        //get a note by ID
        public NoteDetail GetNoteDetailById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Notes
                        .Single(e => e.NoteId == id && e.OwnerId == _userId); ;
                return
                    new NoteDetail
                    {
                        NoteId = entity.NoteId,
                        Title = entity.Title,
                        Content = entity.Content,
                        CreateUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };

            }
        }

        //update a note based on the noteId and owner of the NoteEdit model being passed in
        public bool UpdateNote(NoteEdit updatedNoteModel)
        {
            using(var ctx = new ApplicationDbContext())
            {
                Note noteToUpdate =
                    ctx
                        .Notes                  //get the note that has the ID and owner of the                             note model being                                                             passed in
                            .Single(e => e.NoteId == updatedNoteModel.NoteId && e.OwnerId == _userId);

                noteToUpdate.Title = updatedNoteModel.Title;
                noteToUpdate.Content = updatedNoteModel.Content;
                noteToUpdate.ModifiedUtc = DateTimeOffset.Now;

                return ctx.SaveChanges() == 1;
                    
            }
        }
    }
}
