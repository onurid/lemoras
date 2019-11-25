using System.Collections.Generic;
using OYASAR.Framework.Core.Interface;

namespace Lemoras.Remora.Admin.Domain.User
{
    public interface IUserRepository : IBaseRepository<IUserModelKey>, ITransientDependency
    {
        bool IfExistsUser(string username);
        bool IfExistsUser(string username, string email);
        User IfExistsUserDom(string username, string email);

        bool IfExistsUser(int userId);

        User AddNewUser(User user, bool isPassive = true);
        User DeleteUser(User user);
        User GetUser(int userId);

        void RowDeleteUser(int userId);
        UserRole AttachToUserAtApplicationAndRole(int userId ,int applicationId, int roleId);
        void RemoveUserFromApplicationAndRole(int userRoleId);
        User UpdateUser(User user);

        List<User> GetUsersOfApplication(int applicationId, bool isActive = true);
        List<User> GetUsers(bool isActive);
        List<UserRole> GetUserRole(int userId, bool isActive = true);

        List<UserRole> GetUserRole(bool isActive = true);
        List<User> GetUsers();
    }
}