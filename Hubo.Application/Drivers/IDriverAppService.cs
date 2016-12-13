using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Hubo.Drivers.Dto;
using Hubo.Drivers;

namespace Hubo.Drivers
{
    public interface IDriverAppService : IApplicationService
    {
        

        Task RegisterDriver(Hubo.Drivers.Dto.CreateDriverInput input);
    }
}