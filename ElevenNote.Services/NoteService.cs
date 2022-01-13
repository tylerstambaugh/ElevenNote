﻿using ElevenNote.Data;
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

        public bool CreateNote(NoteCreate noteModel)
        {
            //using inline constructor 
            Note noteEntity = new Note()
            {
                OwenrId = _userId,
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
                    ctx
                        .Notes
                        .Where(e => e.OwenrId == _userId)
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
    }
}
