using AutoMapper;
using Hubo.Breaks.Dto;
using Hubo.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubo.Breaks
{
    public class BreakAppService
    {
        private BreakRepository _breakRepository;
        public BreakAppService()
        {
            _breakRepository = new EntityFramework.BreakRepository();
        }
        public Tuple<List<BreakDto>, string, int> GetBreaks(int shiftId)
        {
            Tuple<List<Break>, string, int> result = _breakRepository.GetBreaks(shiftId);
            List<BreakDto> listOfBreakDto = new List<BreakDto>();
            foreach(Break breakItem in result.Item1)
            {
                listOfBreakDto.Add(Mapper.Map<Break, BreakDto>(breakItem));
            }

            return Tuple.Create(listOfBreakDto, result.Item2, result.Item3);
        }

        public Tuple<int, string> StartBreak(Break newBreak)
        {
            return _breakRepository.StartBreak(newBreak);
        }
    }
}
