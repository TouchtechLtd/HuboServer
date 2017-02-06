using Hubo.EntityFramework;
using Hubo.Notes.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Hubo.Notes
{
    public class NoteAppService
    {
        private NoteRepository _noteRepository;

        public NoteAppService()
        {
            _noteRepository = new EntityFramework.NoteRepository();
        }

        public Tuple<List<NoteOutputDto>, string, int> GetNotes(int shiftId)
        {
            Tuple<List<Note>, string, int> result = _noteRepository.GetNotes(shiftId);

            List<NoteOutputDto> listOfNoteDto = new List<NoteOutputDto>(); 

            foreach(Note note in result.Item1)
            {
                listOfNoteDto.Add(Mapper.Map<Note, NoteOutputDto>(note));
            }

            return Tuple.Create(listOfNoteDto, result.Item2, result.Item3);
        }
    }
}
