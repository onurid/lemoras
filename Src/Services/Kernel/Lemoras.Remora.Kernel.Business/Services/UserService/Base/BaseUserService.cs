using System;
using System.Collections;
using System.Collections.Generic;
using Lemoras.Remora.Core;
using Lemoras.Remora.Kernel.Business.Factory;
using Lemoras.Remora.Kernel.Business.UserModel;
using Lemoras.Remora.Kernel.Domain.Factory;
using Lemoras.Remora.Kernel.Domain.User;
using OYASAR.Framework.Core.Exceptions;
using OYASAR.Framework.Core.Extensions;
using OYASAR.Framework.Core.Utils;
using Constants = Lemoras.Remora.Core.Constants;

namespace Lemoras.Remora.Kernel.Business.Base
{
    public abstract class BaseUserService : IBaseUserService
    {
        protected readonly IRepositoryFactory repositories;

        protected readonly IWorkContextService workContext;

        public BaseUserService()
        {
            repositories = Invoke<IRepositoryFactory>.Call();
            workContext = Invoke<IServiceFactory>.Call().GetWorkContextService();
        }

        public virtual User AddNewUser(AddNewUserContract contract)
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }

        public virtual void UpdateUser(UpdateUserContract contract)
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }

        public virtual UserRole AttachToUserAtApplicationAndRole(UserApplicationRoleContract contract)
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }

        public virtual void DeleteUser(int userId)
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }

        public virtual User GetMyProfile()
        {
            var repo = repositories.GetUserRepository();

            var userId = Convert.ToInt32(workContext.GetCurrentUserSession().UserId);

            var data = repo.GetUser(userId);

            return data; 
        }

        public virtual IEnumerable GetUserRole()
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }

        public virtual IEnumerable<User> GetUsers()
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }

        public virtual User GetUser(int id)
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }

        public virtual IEnumerable<User> GetUsersOfApplication(int applicationId)
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }

        public virtual IEnumerable<User> GetUsersOfCompany(int companyId)
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }

        public virtual void RemoveUserFromApplicationAndRole(int userRoleId)
        {
            throw new BusinessException(Constants.Message.Exception.HasNotAccess);
        }

        public virtual void SetActiveToUser(int userId)
        {
            SetUserStatus(true, userId);

            throw new BusinessException(Constants.Message.Sucess.SetUserActive);
        }

        public virtual void SetPassiveToUser(int userId)
        {
            SetUserStatus(false, userId);

            throw new BusinessException(Constants.Message.Sucess.SetUserActive);
        }

        public virtual void UpdateProfile(UpdateProfileContract contract)
        {
            var repo = repositories.GetUserRepository();

            var userId = Convert.ToInt32(workContext.GetCurrentUserSession().UserId);

            var user = repo.GetUser(userId);

            user.Email = contract.Email;
            user.Firstname = contract.Firstname;
            user.Lastname = contract.Lastname;

            repo.UpdateUser(user);
            repo.Save();

            throw new BusinessException(Constants.Message.Sucess.UpdateProfile);
        }

        private void SetUserStatus(bool activeStatus, int userId)
        {
            var repo = repositories.GetUserRepository();

            var user = repo.GetUser(userId).ToCheck(Constants.Message.Exception.UserNotFound);

            user.Active = activeStatus;

            repo.UpdateUser(user);
            repo.Save();
        }
    }
}
