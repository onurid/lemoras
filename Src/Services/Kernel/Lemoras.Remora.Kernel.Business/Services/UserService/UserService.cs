using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Lemoras.Remora.Kernel.Business.Base;
using Lemoras.Remora.Kernel.Business.UserModel;
using Lemoras.Remora.Kernel.Domain.Application;
using Lemoras.Remora.Kernel.Domain.Role;
using Lemoras.Remora.Kernel.Domain.User;
using OYASAR.Framework.Core.Exceptions;
using Constants = Lemoras.Remora.Core.Constants;

namespace Lemoras.Remora.Kernel.Business
{
    public class UserService : BaseUserService, IUserService
    {
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
            repo.Save();

            return newUser;
        }

        public override void UpdateUser(UpdateUserContract contract)
        {
            var repo = repositories.GetUserRepository();

            var existUser = repo.IfExistsUserDom(contract.Username, contract.Email);
            if (existUser != null && existUser.Id != contract.Id)
                throw new BusinessException(Constants.Message.Exception.UsernameAlreadyExists);

            var updateUser = new User
            { 
                Username = contract.Username,
                Password = contract.Passwd,
                Email = contract.Email,
                Firstname = contract.Firstname,
                Lastname = contract.Lastname,
                Active = contract.Active
            };
            updateUser.SetId(contract.Id);
            repo.UpdateUser(updateUser);
            repo.Save();
        }


        public override UserRole AttachToUserAtApplicationAndRole(UserApplicationRoleContract contract)
        {
            var repo = repositories.GetUserRepository();

            var roleRepo = repositories.GetRoleRepository();

            var appRepo = repositories.GetApplicationRepository();

            var applicationInstance = appRepo.GetAll<ApplicationInstance>(x => x.Id == contract.ApplicationId)
                .SingleOrDefault();

            if (!roleRepo.GetCheckApplicatonRole(contract.RoleId, applicationInstance.ApplicationId))
                throw new BusinessException(Constants.Message.Exception.NotMatchAppRole);

            var result = repo.AttachToUserAtApplicationAndRole(contract.UserId, contract.ApplicationId, contract.RoleId);
            repo.Save();

            return result;
        }

        public override void DeleteUser(int userId)
        {
            var repo = repositories.GetUserRepository();

            if (!repo.IfExistsUser(userId))
                throw new BusinessException(Constants.Message.Exception.UserNotFound);

            repo.RowDeleteUser(userId);
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
                        select new
                        {
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

            var data = repo.GetUsers();

            return data;
        }

        public override User GetUser(int id)
        {
            var repo = repositories.GetUserRepository();

            var data = repo.GetUser(id);

            return data;
        }

        public override IEnumerable<User> GetUsersOfApplication(int applicationId)
        {
            var repo = repositories.GetUserRepository();

            var data = repo.GetUsersOfApplication(applicationId, true);

            return data;
        }

        public override IEnumerable<User> GetUsersOfCompany(int companyId)
        {
            var repo = repositories.GetCompanyRepository();
            
            return default(IEnumerable<User>);
        }

        public override void RemoveUserFromApplicationAndRole(int userRoleId)
        {
            var repo = repositories.GetUserRepository();

            repo.RemoveUserFromApplicationAndRole(userRoleId);
            repo.Save();
        }
    }
}
