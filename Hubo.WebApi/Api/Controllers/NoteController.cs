using Abp.Web.Models;
using Abp.WebApi.Controllers;
using Hubo.Notes;
using Hubo.Notes.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Hubo.Api.Controllers
{
    public class NoteController : AbpApiController
    {

        private NoteAppService _noteService;

        public NoteController()
        {
            _noteService = new NoteAppService();
        }

        [HttpPost]
        public async Task<AjaxResponse> GetNotesAsync([FromBody] int shiftId)
        {
            return await Task<AjaxResponse>.Run(() => GetNotes(shiftId));
        }

        private AjaxResponse GetNotes(int shiftId)
        {
            AjaxResponse ar = new AjaxResponse();
            Tuple<List<NoteOutputDto>, string, int> result = _noteService.GetNotes(shiftId);

            if(result.Item3 == 1)
            {
                ar.Success = true;
                ar.Result = result.Item1;
            }
            else
            {
                ar.Success = false;
                ar.Result = result.Item2;
            }

            return ar;
        }

        [HttpPost]
        public async Task<AjaxResponse> InsertNoteAsync([FromBody] Note note)
        {
            return await Task<AjaxResponse>.Run(() => InsertNote(note));
        }

        private AjaxResponse InsertNote(Note note)
        {
            AjaxResponse ar = new AjaxResponse();
            Tuple<int, string> result = _noteService.InsertNote(note);

            if(result.Item1 > 0)
            {
                ar.Success = true;
                ar.Result = result.Item1;
            }
            else
            {
                ar.Success = false;
                ar.Result = result.Item2;
            }

            return ar;

        }
    }
}
