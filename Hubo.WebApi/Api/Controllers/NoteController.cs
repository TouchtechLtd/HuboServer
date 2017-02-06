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

        public NoteController()
        {

        }

        [HttpPost]
        public async Task<AjaxResponse> GetNotesAsync([FromBody] int shiftId)
        {
            return await Task<AjaxResponse>.Run(() => GetNotes(shiftId));
        }

        private AjaxResponse GetNotes(int shiftId)
        {
            AjaxResponse ar = new AjaxResponse();
            NoteAppService noteService = new NoteAppService();
            Tuple<List<NoteOutputDto>, string, int> result = noteService.GetNotes(shiftId);

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
    }
}
