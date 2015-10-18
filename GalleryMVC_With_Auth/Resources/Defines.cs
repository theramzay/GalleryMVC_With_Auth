using System.Collections.Generic;

namespace GalleryMVC_With_Auth.Resources
{
    public static class Defines
    {
        public const string DbConnName = "DBcon";
        public const string NPasswd = "Новый пароль";
        public const string ConfNewPasswd = "Подтвердите новый пароль";
        public const string CurPasswd = "Текущий(старый) пароль";
        public const string Passwd = "Пароль";
        public const string PhNumb = "Телефонный номер";
        public const string Code = "Код";
        public const string Email = "Электронная почта";
        public const string RemBrws = "Запомнить этот браузер?";
        public const string RemMe = "Запомнить меня?";
        public const int PassMinLength = 6;
        public const string ErrView = "Error";
        public const string LockOutView = "Lockout";
        public const string SendCodeView = "SendCode";
        public const string RolesName = "Name";
        public const string IndexView = "Index";
        public const string HomeControllerName = "Home";
        public const string AccountControllName = "Account";
        public const string ResetPasswdConfView = "ResetPasswordConfirmation";
        public const string ConfEmailView = "ConfirmEmail";
        public const string ForgotPasswdConfView = "ForgotPasswordConfirmation";
        public const string ExtLoginCallbackView = "ExternalLoginCallback";
        public const string ExtLogiConfView = "ExternalLoginConfirmation";
        public const string ManageControllerName = "Manage";
        public const string LoginView = "Login";
        public const string LoginPath = "/Account/Login";
        public const string ExtLoginFailView = "ExternalLoginFailure";
        public const string ManageLoginsView = "ManageLogins";
        public const string VerifPhoneNumbView = "VerifyPhoneNumber";
        public const string LinkLoginCallbackView = "LinkLoginCallback";
        public const int Painting = 3;
        public const int Watercolor = 5;
        public const int Gouache = 6;
        public const int Graphics = 1;
        public const int Batik = 2;
        public const int Pastel = 4;
    }
}