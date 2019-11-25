using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Lemoras.Remora.Admin.Business.Base;
using Lemoras.Remora.Admin.Business.UserModel;
using Lemoras.Remora.Admin.Domain.Application;
using Lemoras.Remora.Admin.Domain.Role;
using Lemoras.Remora.Admin.Domain.User;
using OYASAR.Framework.Core.Exceptions;
using OYASAR.Framework.Core.Extensions;
using Constants = Lemoras.Remora.Core.Constants;

namespace Lemoras.Remora.Admin.Business
{
    public class LimitedUserService : BaseUserService, IUserService
    {
        private readonly int appInsId;

        public LimitedUserService() :base ()
        {
            appInsId = workContext.GetCurrentUserSession().ApplicationInsId;
        }

        public override User AddNewUser(AddNewUserContract contract)
        {
            var repo = repositories.GetUserRepository();

            if (repo.IfExistsUser(contract.Username, contract.Email))
                throw new BusinessException(Constants.Message.Exception.UsernameAlreadyExists);

            var newUser = new User
            {
                Username = contract.Username,
                Password = contract.Passwd,
                Email = contract.Email,
                Firstname = contract.Firstname,
                Lastname = contract.Lastname,
                Active = contract.Active
            };

            repo.AddNewUser(newUser);

            var result = repo.AttachToUserAtApplicationAndRole(newUser.Id, appInsId, 0); // yeni bir method;

            repo.Save();

            return newUser;
        }

        public override UserRole AttachToUserAtApplicationAndRole(UserApplicationRoleContract contract)
        {
            var repo = repositories.GetUserRepository();

            var roleRepo = repositories.GetRoleRepository();

            var appRepo = repositories.GetApplicationRepository();

            var applicationInstance = appRepo.GetAll<ApplicationInstance>(x=> x.Id == contract.ApplicationId)
                .SingleOrDefault();

            if (!roleRepo.GetCheckApplicatonRole(contract.RoleId, applicationInstance.ApplicationId))
                throw new BusinessException(Constants.Message.Exception.NotMatchAppRole);

            var result = repo.AttachToUserAtApplicationAndRole(contract.UserId, appInsId, contract.RoleId);
            repo.Save();

            return result;
        }

        public override void DeleteUser(int userId)
        {
            var repo = repositories.GetUserRepository();

            if (!repo.IfExistsUser(userId))
                throw new BusinessException(Constants.Message.Exception.UserNotFound);

            var res = repo.GetAll<UserRole>(x=> x.UserId == userId && x.ApplicationInstanceId == appInsId).Any();

            if (!res)
                throw new BusinessException("User not match  with application instance id");

            repo.RowDeleteUser(userId); // application instance id eşleştir
            repo.Save();
        }

        public override IEnumerable GetUserRole()
        {
            var repo = repositories.GetUserRepository();

            var repoApp = repositories.GetApplicationRepository();

            var repoRole = repositories.GetRoleRepository();

            var data = (from u in repo.GetAll<User>()
                       join ur in repo.GetAll<UserRole>() on u.Id equals ur.UserId
                       join ai in repoApp.GetAll<ApplicationInstance>() on ur.ApplicationInstanceId equals ai.Id
                       join a in repoApp.GetAll<Application>() on ai.ApplicationId equals a.Id
                       join r in repoRole.GetAll<Role>() on ur.RoleId equals r.Id
                       where ur.ApplicationInstanceId == appInsId && ur.RoleId != 0                      
                       select new {
                           Id = ur.Id,
                           Username = u.Username,
                           ApplicationName = a.ApplicationName,
                           ApplicationTagName = ai.ApplicationTagName,
                           RoleName = r.RoleName
                       }).ToList();
            
            return data;
        }

        public override IEnumerable<User> GetUsers()
        {
            var repo = repositories.GetUserRepository();

            var repoApp = repositories.GetApplicationRepository();

            var repoRole = repositories.GetRoleRepository();

            var data = (from u in repo.GetAll<User>()
                       join ur in repo.GetAll<UserRole>() on u.Id equals ur.UserId
                       join ai in repoApp.GetAll<ApplicationInstance>() on ur.ApplicationInstanceId equals ai.Id
                       where ur.ApplicationInstanceId == appInsId
                       select u).ToList();

            return data;
        }

        public override void RemoveUserFromApplicationAndRole(int userRoleId)
        {
            var repo = repositories.GetUserRepository();

            var userRole = repo.GetAll<UserRole>(x=> x.Id == userRoleId && x.ApplicationInstanceId == appInsId)
                .SingleOrDefault().ToCheck("user role could not be found!");

            repo.RemoveUserFromApplicationAndRole(userRole.Id);
            repo.Save();
        }
    }
}
