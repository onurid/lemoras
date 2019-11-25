using System.Collections.Generic;
using System.Linq;
using Lemoras.Remora.Core.Interfaces;
using Lemoras.Remora.Core.Models.KernelContext;
using Microsoft.EntityFrameworkCore;
using OYASAR.Framework.Core.Abstract;
using OYASAR.Framework.Core.Interface;

namespace Lemoras.Remora.Infrastructure.Repositories.RentContext
{
    public class KernelRepository : BaseRepository<IEFRepository<IKernelContext>, IKernelModelKey>, IKernelRepository
    {
        public ApplicationModule GetApplicationModule(int applicationId, string serviceKey)
        {
            return base.GetAll<ApplicationModule>(x => x.ApplicationId == applicationId
                    &&  x.BusinessLogic.BusinessService.BusinessServiceKey == serviceKey)
               .Include(x => x.BusinessLogic)
               .ThenInclude(x => x.BusinessService)
               .FirstOrDefault();
        }

        public bool CheckAnyRoleAuthorises(int roleId, string commandName)
        {
            return base.GetAll<RoleAuthorise>(x => 
                        x.RoleId == roleId
                        && commandName
                            .Contains(x.Command.CommandName))
                       .Include(x=> x.Command)
                       .Any();
        }

        public IEnumerable<ApplicationModule> LoadAllApplicationModule(int applicationId)
        {
            return base.GetAll<ApplicationModule>(x => x.ApplicationId == applicationId)
               .Include(x => x.BusinessLogic)
               .ToList();
        }

        public IEnumerable<BusinessService> LoadAllBusinessService()
        {
            return base.GetAll<BusinessService>()
               .Include(x => x.BusinessLogics)
               .ToList();
        }

        public IEnumerable<RoleAuthorise> LoadAllRoleAuthorise(int roleId)
        {
            return base.GetAll<RoleAuthorise>(x => x.RoleId == roleId)
               .Include(x => x.Command)
               .ToList();
        }
    }
}