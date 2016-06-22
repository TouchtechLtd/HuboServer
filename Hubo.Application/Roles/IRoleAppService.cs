using System.Threading.Tasks;
using Abp.Application.Services;
using Hubo.Roles.Dto;

namespace Hubo.Roles
{
    public interface IRoleAppService : IApplicationService
    {
        Task UpdateRolePermissions(UpdateRolePermissionsInput input);
    }
}
