using System.Collections;
using System.Collections.Generic;
using Lemoras.Remora.Core.Attribute;
using Lemoras.Remora.Core.Interceptor;
using Lemoras.Remora.Kernel.Business.UserModel;
using Lemoras.Remora.Kernel.Domain.User;
using OYASAR.Framework.Core.Interface;

namespace Lemoras.Remora.Kernel.Business.Base
{
    public interface IUserService : IBaseUserService, IRoleInterceptor, ITransientDependency
    {
    }

    public interface IBaseUserService
    {
        [RoleSet("AddNewUser")]
        User AddNewUser(AddNewUserContract contract);

        [RoleSet("UpdateUser")]
        void UpdateUser(UpdateUserContract contract);

        [RoleSet("DeleteUser")]
        void DeleteUser(int userId);

        [RoleSet("RemoveUserFromApplicationAndRole")]
        void RemoveUserFromApplicationAndRole(int userRoleId);

        [RoleSet("AttachToUserAtApplicationAndRole")]
        UserRole AttachToUserAtApplicationAndRole(UserApplicationRoleContract contract);

        [RoleSet("SetActiveToUser")]
        void SetActiveToUser(int userId);

        [RoleSet("SetPassiveToUser")]
        void SetPassiveToUser(int userId);

        [RoleSet("GetUsersOfCompany")]
        IEnumerable<User> GetUsersOfCompany(int companyId);

        [RoleSet("GetUsersOfApplication")]
        IEnumerable<User> GetUsersOfApplication(int applicationId);

        [RoleSet("GetUsers")]
        IEnumerable<User> GetUsers();

        [RoleSet("GetUser")]
        User GetUser(int id);

        [RoleSet("GetUserRole")]
        IEnumerable GetUserRole();

        [RoleSet("GetMyProfile")]
        User GetMyProfile();

        [RoleSet("UpdateProfile")]
        void UpdateProfile(UpdateProfileContract contract);
    }
}
