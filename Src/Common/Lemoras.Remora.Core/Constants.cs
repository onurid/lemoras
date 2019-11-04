namespace Lemoras.Remora.Core
{
    public struct Constants
    {
        public struct Message
        {
            public struct Exception
            {
                public const string NotAttachDatabaseToApp = "Uygulamaya özel database atanmamış";
                public const string NotMatchAppRole = "Current role not mact roles of application.";
                public const string PasswordNotMatch = "Password no match";
                public const string UserNotFound = "User is not found!";
                public const string PhoneNumberNotFound = "PhoneNumber is not found!";
                public const string ContactInfoNotFound = "ContactInfo is not found!";
                public const string CustomerNotFound = "Customer is not found!";
                public const string CompanyNotFound = "Company is not found!";
                public const string LogObjectIsNull = "log object is null, log object can not create instance!";
                public const string ApplicationNotFound = "Application is not found!";
                public const string UsernameAlreadyExists = "The username already exists.";
                public const string CompanyAlreadyExists = "The company already exists.";
                public const string ApplcationAlreadyExists = "The application already exists.";
                public const string KeySentNotFound = "The key sent was not found.";
                public const string NotFound = "not found";
                public const string NotFound404 = "404 not found";
                public const string Unauthorized = "401 Unauthorized";
                public const string LocationNotFound = "Konumunuzu bulamadık, lütfen konumunuzu tekrar seçiniz.";
                public const string IsNullOrEmpty = "is null or empty";
                public const string HasNotAccess = "It has not acceess module inside current application";
                public const string UnkownError = "Unkown an error! Please, contact your administrator.";
                public const string NotFoundAppModuleOrBusinessLogic = "Could not find application-owned module or business logic.";
                public const string ConfigFail = "An error occurred while retrieving the config.";
                public const string NoApplicationNoRole = "You don't have any applications or roles!";
                public const string NoApplicationModule = "Application doesn't has any modules!";


                public enum Code
                {
                    NotFound = 120014,
                    IsNUllOrEmpty = 120015
                }
            }

            public struct Sucess
            {
                public const string Ok = "İşlem tamamlanmıştır";
                public const string UpdateProfile = "Profil güncellenmiştir.";
                public const string RegisteredUser = "User registered successfull!";
                public const string UpddatedUser = "User updated successfull!";
                public const string RegisteredCompany = "Company registered successfull!";
                public const string RegisteredApplication = "Application registered successfull!";
                public const string RegisteredBusinessLogic = "BusinessLogic registered successfull!";
                public const string RegisteredCommand = "Command registered successfull!";
                public const string RegisteredModule = "Module registered successfull!";
                public const string RegisteredPage = "Page registered successfull!";
                public const string RegisteredMicroservice = "Microservice registered successfull!";
                public const string SetUserActive = "User activated!";
                public const string SetUserPassive = "User passived!";
                public const string SetCompanyActive = "Company activated!";
                public const string SetCompanyPassive = "Comapny passived!";
                public const string SetApplicationActive = "Application activated!";
                public const string SetApplicationPassive = "Application passived!";
                public const string AttachedUserApplicationRole = "User attached to role of application successfull!";
                public const string RemovedUserApplicationRole = "User removed from role of application successfull!";
                public const string RemoveApplicationFromCompany = "Application removed from company successfull!";
                public const string RemoveRoleFromApplication = "Role removed from company successfull!";
            }

            public const string ProcessSuccess = "İşlem başarılı";
            public const string RejectAppointment = "Gönderi iptal işleminiz alınmıştır.";
        }

        public struct System
        {
            public struct Microservice
            {
                public const string Application = "F5DD4AB3-96E2-4B71-AADA-B0CB32892D91";
                public const string Product = "F2B24855-46CF-4BD6-8E40-7D0483A1836A";
                public const string Order = "BB5303B3-3FCE-4DEC-9645-A2E1C16A524D";
                public const string Payment = "520E615E-F1E0-4D76-9B12-12A79BDE2030";
                public const string Auth = "4010FFE4-8461-41C2-A022-005B96638C81";
            }
        }
    }
}
