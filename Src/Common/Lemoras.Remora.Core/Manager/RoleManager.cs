using OYASAR.Framework.Core.Interface;

namespace Lemoras.Remora.Core.Manager
{
    public static class RoleManager
    {
        public static bool IsAcceptableAsRole(System.Attribute primitiveRoleSetAttr)
        {
            var roleSetAttr = (IRoleSetAttribute)primitiveRoleSetAttr;

            return roleSetAttr.IsAcceptable();
        }
    }
}
