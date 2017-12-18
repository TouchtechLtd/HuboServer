using Hubo.Breaks.Dto;
using Hubo.Notes.Dto;
using Hubo.Shifts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubo.Api.Models
{
    class DayShiftResponseModel
    {
        int id { get; set; }
        List<WorkShiftResponseModel> workShifts { get; set; }
    }

    class WorkShiftResponseModel
    {
        WorkShiftDto workShift { get; set; }
        List<DrivingShiftDto> listOfDrivingShifts { get; set; }
        List<BreakDto> listOfBreaks { get; set; }
        List<NoteOutputDto> listOfNotes { get; set; }
    }
}
