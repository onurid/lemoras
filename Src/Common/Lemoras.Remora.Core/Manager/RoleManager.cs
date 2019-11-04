using OYASAR.Framework.Core.Exceptions;
using OYASAR.Framework.Core.Interface;
using OYASAR.Framework.Core.Utils;

namespace Lemoras.Remora.Core.Manager
{
    public static class RoleManager
    {
        public static bool LockStatus = false;

        public static bool IsAcceptableAsRole(System.Attribute primitiveRoleSetAttr)
        {
            var roleSetAttr = (IRoleSetAttribute)primitiveRoleSetAttr;

            return roleSetAttr.IsAcceptable();
        }

        public static void IsAccess()
        {
            if (!LockStatus)
            {
                var workContextService = Invoke<IWorkContextService>.Call();

                var isAccess = workContextService.HasMicroserviceAccess();

                if (!isAccess)
                    throw new BusinessException(Constants.Message.Exception.HasNotAccess);
            }
        }

        public static void CreateRoleConfig(int roleId)
        {
            
        }
    }
}
