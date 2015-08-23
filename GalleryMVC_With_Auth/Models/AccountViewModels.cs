using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GalleryMVC_With_Auth.Resources;

namespace GalleryMVC_With_Auth.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = Defines.Email)]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = Defines.Code)]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = Defines.RemBrws)]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = Defines.Email)]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = Defines.Email)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = Defines.Passwd)]
        public string Password { get; set; }

        [Display(Name = Defines.RemMe)]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = Defines.Email)]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = Defines.PassMinLength)]
        [DataType(DataType.Password)]
        [Display(Name = Defines.Passwd)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = Defines.Passwd)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Name { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = Defines.Email)]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = Defines.PassMinLength)]
        [DataType(DataType.Password)]
        [Display(Name = Defines.Passwd)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = Defines.ConfNewPasswd)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = Defines.Email)]
        public string Email { get; set; }
    }
}
