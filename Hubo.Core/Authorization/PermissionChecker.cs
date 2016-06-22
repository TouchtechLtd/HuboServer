using Abp.Authorization;
using Hubo.Authorization.Roles;
using Hubo.MultiTenancy;
using Hubo.Users;

namespace Hubo.Authorization
{
    public class PermissionChecker : PermissionChecker<Tenant, Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
