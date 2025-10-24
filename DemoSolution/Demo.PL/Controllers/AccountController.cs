using Demo.DAL.Models.IdentityModels;
using Demo.PL.Utilities;
using Demo.PL.ViewModels.IdentityViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Demo.PL.Controllers
{
    public class AccountController(UserManager<ApplicationUser> _userManager,
                                   SignInManager<ApplicationUser> _signInManager
                                   ) : Controller
    {
        #region Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var user = new ApplicationUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.UserName,
                Email = model.Email,
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Login");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(model);
            }
        }
        #endregion

        #region LogIn
        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LoginViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user is not null)
            {
                var isPasswordValid = await _userManager.CheckPasswordAsync(user, model.Password);
                if (isPasswordValid)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
                    if (result.IsNotAllowed) ModelState.AddModelError(string.Empty, "You are not allowed to log in.");
                    if (result.IsLockedOut) ModelState.AddModelError(string.Empty, "Your account is locked out.");
                    if (result.Succeeded) return RedirectToAction("Index", "Home");
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Login failed. Please try again.");
                        return View(model);
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid password.");
                    return View(model);
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Email not found.");
                return View(model);
            }
        }
        #endregion

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("LogIn");
        }

        #region ForgetPassword
        [HttpGet]
        public IActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SendResetPasswordLink(ForgetPasswordViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user is not null)
            {
                // create password reset link
                // BaseURL/Action/ResetPassword?email=user.Email&token=generatedToken
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var tokenEncoded = WebUtility.UrlEncode(token);
                var resetPasswordLink = Url.Action("ResetPasswordLink", "Account", new
                {
                    email = user.Email,
                    token = tokenEncoded
                },
                Request.Scheme // to get http or https
                );

                // create email
                var email = new Email()
                {
                    To = user.Email!,
                    Subject = "Reset Password",
                    Body = $"Please reset your password by clicking here: {resetPasswordLink}"
                };
                // send email with the token link to reset password
                var isSent = await EmailSettings.SendEmailAsync(email);
                if (isSent)
                {
                    return RedirectToAction(nameof(CheckYourInbox));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Failed to send email. Please try again.");
                    return View(model);
                }
            }
            ModelState.AddModelError(string.Empty, "Invalid Operation");
            return View(model);
        }
        #endregion

        [HttpGet]
        public IActionResult CheckYourInbox()
        {
            return View();
        }

        #region Reset Password Link
        [HttpGet]
        public IActionResult ResetPasswordLink(string email, string token)
        {
            // Keep token and email in ViewData so they are posted back as hidden fields
            ViewData["email"] = email;
            ViewData["token"] = token;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResetPasswordLink(ResetPasswordViewModel model, string email, string token)
        {
            if (!ModelState.IsValid) return View(model);

            // token received from the form will be URL-encoded; decode before using
            var decodedToken = WebUtility.UrlDecode(token);
            var user = await _userManager.FindByEmailAsync(email);

            if (user is not null)
            {
                var result = await _userManager.ResetPasswordAsync(user, decodedToken, model.NewPassword);
                if (result.Succeeded)
                {
                    return RedirectToAction("LogIn");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View(model);
                }
            }
            ModelState.AddModelError(string.Empty, "Invalid Operation");
            return View(model);
        } 
        #endregion
    }
}
