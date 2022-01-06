
using log4net;
using log4net.Core;
using MailBox.Web.Providers;
using MailBoxBackgroundJob.Schedules;
using MailBoxEntity;
using MailBoxService;
using MailBoxUtil;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace MailBox.Web.Controllers
{
    public class LoginController : Controller
    {
        private IConfiguration _config;
        private readonly ILoggerManager _logger;

        public LoginController(IConfiguration config, ILog log, ILoggerManager logger)
        {
            _config = config;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string eMail, string password)
        {
            UserService userService = new UserService();
            var user = userService.LoginUser(eMail, password);
            if (user.Status == false)
            {
                ViewBag.Message = user.Message;
            }
            else
            {
                var user1 = userService.UserSession(eMail);
                if (user.Status == true && user1.EMail == eMail)
                {
                    HttpContext.Session.SetString("user_email", user1.EMail);
                    HttpContext.Session.SetString("user_name", user1.Name);
                    HttpContext.Session.SetString("user_lastName", user1.LastName);
                    HttpContext.Session.SetInt32("user_userId", user1.UserId);
                    var name = user1.Name;
                    _logger.LogInformation($"{name} isimli kullanıcı giriş yaptı.");
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Message = user.Message;
                }
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Login", "Login");
        }


        [HttpGet]
        public IActionResult RegisterUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterUser(string name, string lastName, DateTime birthday, string eMail, string password)
        {

            UserService userService = new UserService();
            MailBoxEntity.User user = new MailBoxEntity.User()
            {
                Name = name,
                LastName = lastName,
                Birthday = birthday,
                EMail = eMail,
                Password = password,
            };

            var savedUser = userService.RegisterUser(user);
            if (savedUser.Status)
            {
                DelayedJobs.SendMailRegisterJobs(Helper.ConvertType<User>(savedUser.OpeartionClass).UserId);

                return Json("Sisteme kayıt olundu. Lütfen giriş yapınız!");
            }
            else
            {
                ViewBag.Message = savedUser.Message;
                return Json("Sisteme kayıt olunamadı. Tekrar deneyiniz!");
            }
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ForgotPassword(string eMail)
        {
            UserService userService = new UserService();
            var user = userService.GetUserByEmail(eMail);
            if (user.Status == false)
            {
                ViewBag.Message = user.Message;
            }
            else
            {
                var user1 = userService.GetUserByEmailForPassword(eMail);
                var token = GenerateJSONWebToken();
                var link = Url.Action("ResetPassword", "Login", new { token, eMail = user1.EMail }, Request.Scheme);
                if (user1 != null)
                {
                    DelayedJobs.SendPasswordResetMailJob(Helper.ConvertType<User>(user1).EMail, link);
                    return RedirectToAction("ForgotPasswordConfirmation", "Login");
                }
                else
                {
                    return RedirectToAction("ForgotPassword", "Login");
                }
            }
            return View(eMail);
        }

        private string GenerateJSONWebToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [AllowAnonymous]
        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPassword(string token, string email)
        {
            var model = new ResetPassword { Token = token, Email = email };
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult ResetPassword(ResetPassword resetPassword)
        {
            UserService userService = new UserService();
            var user = userService.GetUserByEmail(resetPassword.Email);
            if (user == null)
                RedirectToAction("ResetPasswordConfirmation");
            if (resetPassword.Token != null)
            {
                userService.ResetPassword(resetPassword.Email, resetPassword.Password);
            }
            return RedirectToAction("ResetPasswordConfirmation");
        }

        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }
    }
}
