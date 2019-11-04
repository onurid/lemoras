using System.Collections.Generic;
using System.Linq;
using Lemoras.Remora.Kernel.Domain.BoundedContext;
using Lemoras.Remora.Kernel.Domain.User;
using OYASAR.Framework.Core.Abstract;
using OYASAR.Framework.Core.Interface;

namespace Lemoras.Remora.Kernel.Infrastructure.Repositories.UserContext
{
    public class UserRepository : BaseRepository<IEFRepository<IUserContext>, IUserModelKey>, IUserRepository
    {
        public User AddNewUser(User user, bool isPassive = true)
        {
            this.Add<User, int>(user);
            return user;
        }

        public User GetUser(int userId)
        {
            return GetByKey<User>(userId);
        }

        public User DeleteUser(User user)
        {
            this.Delete<User, int>(user);
            return user;
        }

        public void RowDeleteUser(int userId)
        {
            this.RowDelete<User>(userId);
        }

        public bool IfExistsUser(string username)
        {
            return GetAll<User>(x => x.Username == username).Any();
        }

        public bool IfExistsUser(string username, string email)
        {
            return GetAll<User>(x => x.Username == username || x.Email == email).Any();
        }

        public User IfExistsUserDom(string username, string email)
        {
            return GetAll<User>(x => x.Username == username || x.Email == email).FirstOrDefault();
        }

        public bool IfExistsUser(int userId)
        {
            return GetAll<User>(x => x.Id == userId).Any();
        }

        public UserRole AttachToUserAtApplicationAndRole(int userId, int applicationId, int roleId)
        {
            var userRole = new UserRole {
                UserId = userId,
                ApplicationInstanceId = applicationId,
                RoleId = roleId
            };

            this.Add<UserRole, int>(userRole);

            return userRole;
        }

        public void RemoveUserFromApplicationAndRole(int userRoleId)
        {
            this.RowDelete<UserRole>(userRoleId);
        }

        public User UpdateUser(User user)
        {
            this.Edit<User, int>(user);
            return user;
        }

        public List<User> GetUsersOfApplication(int applicationId, bool isActive = true)
        {
            var query = (from u in GetAll<User>(x => x.Active == isActive)
                         join ur in GetAll<UserRole>(x => x.ApplicationInstanceId == applicationId) on u.Id equals ur.UserId
                         select u);

            return query.ToList();
        }

        public List<User> GetUsers(bool isActive)
        {
            return GetAll<User>(x => x.Active == isActive).ToList();
        }

        public List<User> GetUsers()
        {
            return GetAll<User>().ToList();
        }

        public List<UserRole> GetUserRole(int userId, bool isActive = true)
        {
            var query = (from u in GetAll<User>(x => x.Id == userId && x.Active == isActive)
                         join ur in GetAll<UserRole>() on u.Id equals ur.UserId
                         select ur);

            return query.ToList();
        }

        public List<UserRole> GetUserRole(bool isActive = true)
        {
            var query = (from u in GetAll<User>(x => x.Active == isActive)
                         join ur in GetAll<UserRole>() on u.Id equals ur.UserId
                         select ur);

            return query.ToList();
        }
    }
}