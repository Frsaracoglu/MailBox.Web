using MailBoxEntity;
using MailBoxService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailBox.Web.Controllers
{
    public class SettingController : Controller
    {
        public IActionResult Index(int userId)
        {
            UserService userService = new();
            var user = userService.GetUser(userId);
            return View(user);
        }

        [HttpPost]
        public IActionResult UpdateUser(string name, string lastName, string eMail, DateTime birthDay, string password, int userId)
        {
            UserService userService = new UserService();
            User user = new User()
            {
                Name = name,
                LastName = lastName,
                EMail = eMail,
                Birthday=birthDay,
                Password = password,
                UserId = userId
            };
            var isUpdate = userService.UpdateUser(user);

            if (isUpdate.Status)
            {
                return Json("Kullanıcı Güncellendi");
            }
            else
            {
                ViewBag.Message = isUpdate.Message;
                return Json("Kullanıcı Güncellenemedi");
            }
        }
    }
}
