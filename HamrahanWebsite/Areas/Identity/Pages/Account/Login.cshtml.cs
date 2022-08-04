using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Hamrahan.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace HamrahanWebsite.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly UserManager<Person> _userManager;
        private readonly SignInManager<Person> _signInManager;
        private readonly ILogger<LoginModel> _logger;
        //private IHttpClientFactory _httpClientFactory;
        public LoginModel(SignInManager<Person> signInManager, 
            ILogger<LoginModel> logger,
            UserManager<Person> userManager)
        //IHttpClientFactory httpClientFactory
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            //_httpClientFactory = httpClientFactory;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage {  get; set; }

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

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl ??= Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(InputModel input,string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true

                //var _client = _httpClientFactory.CreateClient("HamrahanClient");
                //var jsonBody = JsonConvert.SerializeObject(input);
                //var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
                //var response = _client.PostAsync("/Api/Auth", content).Result;

                //var result = await _signInManager.PasswordSignInAsync(input.Email, input.Password, input.RememberMe, false);
                var user = await _userManager.FindByEmailAsync(input.Email);
                if (await _userManager.CheckPasswordAsync(user,input.Password))
                {
                    var claims = new List<Claim>(){
                        new Claim(ClaimTypes.NameIdentifier,input.Email),
                        new Claim(ClaimTypes.Email,input.Email),
                        new Claim(ClaimTypes.Role,"Student") };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    var properties = new AuthenticationProperties
                    {

                        IsPersistent = input.RememberMe,
                        AllowRefresh = true
                    };

                    await _signInManager.SignInWithClaimsAsync(user, properties, claims);
                    
                        _logger.LogInformation("User logged in.");
                        return LocalRedirect(returnUrl);
                    

                  
                };

                //var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, Input.RememberMe, lockoutOnFailure: false);
                //var SigninReult = HttpContext.SignInAsync(principal, properties);

                //var user = _userManager.GetUserAsync(principal).Result;



                //if (result.RequiresTwoFactor)
                //{
                //    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
                //}
                //if (result.IsLockedOut)
                //{
                //    _logger.LogWarning("User account locked out.");
                //    return RedirectToPage("./Lockout");
                //}
                return Page();
            }

            else
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
                return Page();
            }
            

        }
    }
}

   