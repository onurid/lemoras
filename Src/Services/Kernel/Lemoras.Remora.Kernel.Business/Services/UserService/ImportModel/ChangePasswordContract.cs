﻿namespace Lemoras.Remora.Kernel.Business.UserModel
{
    public class ChangePasswordContract
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ReNewPassword { get; set; }
    }
}
