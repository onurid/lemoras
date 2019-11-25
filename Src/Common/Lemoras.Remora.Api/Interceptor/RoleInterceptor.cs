using System.Reflection;
using Castle.DynamicProxy;
using Lemoras.Remora.Core.Attribute;
using Lemoras.Remora.Core.Interfaces;
using Lemoras.Remora.Core.Manager;
using OYASAR.Framework.Core.Exceptions;
using Constants = Lemoras.Remora.Core.Constants;

namespace Lemoras.Remora.Api.Interceptor
{
    public class RoleInterceptor : IRoleInterceptor, IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            if (IsAcceptableAsRole(invocation))
            {
                invocation.Proceed();
            }
            else
            {
                throw new BusinessException(Constants.Message.Exception.HasNotAccess);
            }
        }

        public bool IsAcceptableAsRole(IInvocation invocation)
        {
            var primitiveRoleSetAttr = invocation.Method.GetCustomAttribute(typeof(RoleSetAttribute));
            return RoleManager.IsAcceptableAsRole(primitiveRoleSetAttr);
        }
    }
}
