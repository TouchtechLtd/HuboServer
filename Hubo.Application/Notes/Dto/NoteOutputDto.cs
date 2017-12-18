using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubo.Notes.Dto
{
    [AutoMap(typeof(Note))]
    public class NoteOutputDto
    {
        public int Id { get; set; }
        public long ShiftId { get; set; }
        public string NoteText { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
