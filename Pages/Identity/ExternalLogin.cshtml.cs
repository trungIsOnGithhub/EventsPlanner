using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace gcsharpRPC.Pages.Identity
{
    public class ExternalLoginModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;

        public ExternalLoginModel(SignInManager<IdentityUser> signInManager, ILogger<LoginModel> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        // public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ProviderDisplayName { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        public async Task<IActionResult> OnPost(string provider, string returnUrl = null)
        {
                var listprovider = (await _signInManager.GetExternalAuthenticationSchemesAsync ()).ToList ();
                var provider_process = listprovider.Find ((m) => m.Name == provider);

                if (provider_process == null) {
                    return NotFound ("Not Found: " + provider);
                }

                // call OnGetCallbackAsync after authenticate
                var redirectUrl = Url.Page ("./ExternalLogin", pageHandler: "Callback", values : new { returnUrl });

                var properties = _signInManager.ConfigureExternalAuthenticationProperties (provider, redirectUrl);

                return new ChallengeResult(provider, properties);
        }

        public void OnGet(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl = returnUrl ?? Url.Content("~/");

            // ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
        }

        // #region snippet
        // public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        // {
        //     returnUrl = returnUrl ?? Url.Content("~/");

        //     if (ModelState.IsValid)
        //     {
        //         var result = await _signInManager.PasswordSignInAsync(Input.Email, 
        //             Input.Password, Input.RememberMe, lockoutOnFailure: true);
        //         if (result.Succeeded)
        //         {
        //             _logger.LogInformation("User logged in.");
        //             return LocalRedirect(returnUrl);
        //         }
        //         if (result.RequiresTwoFactor)
        //         {
        //             return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
        //         }
        //         if (result.IsLockedOut)
        //         {
        //             _logger.LogWarning("User account locked out.");
        //             return RedirectToPage("./Lockout");
        //         }
        //         else
        //         {
        //             ModelState.AddModelError(string.Empty, "Invalid or Error Credential!");
        //             return Page();
        //         }
        //     }

        //     // If we got this far, something failed, redisplay form
        //     return Page();
        // }
        // #endregion
    }
}