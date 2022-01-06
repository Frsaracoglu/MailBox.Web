using Microsoft.AspNetCore.Mvc;
using MailBoxService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailBoxEntity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using MailBoxBackgroundJob.Schedules;

namespace MailBox.Web.Controllers
{
    public class ContactController : Controller
    {
        private IConfiguration Configuration;
        public ContactController(IConfiguration _configuration)
        { Configuration = _configuration; }
        public IActionResult Index()
        {
            ContactService contactService = new();
            var result = contactService.ListContact();
            var groups = contactService.ListGroups();
            groups.Insert(0, new ContactGroups { GroupId = 0, Name = "Seçiniz" });
            ViewBag.Groups = groups;
            return View(result);
        }

        public JsonResult GetResults(int groupId)
        {
            ContactService contactService = new();
            var list = contactService.GetContactGroupId(groupId);
            return Json(list);
        }

        public SelectList ToContactSelectList(DataTable table, string contactId, string name, string lastName)
        {
            List<SelectListItem> list = new List<SelectListItem>();

            foreach (DataRow row in table.Rows)
            {
                list.Add(new SelectListItem()
                {
                    Value = row[contactId].ToString(),
                    Text = row[name].ToString() + " " + row[lastName].ToString()
                });
            }

            return new SelectList(list, "Value", "Text");
        }

        public SelectList ToSelectList(DataTable table, string groupId, string name)
        {
            List<SelectListItem> list = new List<SelectListItem>();

            foreach (DataRow row in table.Rows)
            {
                list.Add(new SelectListItem()
                {
                    Value = row[groupId].ToString(),
                    Text = row[name].ToString()
                });
            }

            return new SelectList(list, "Value", "Text");
        }

        public IActionResult NewContact()
        {
            ContactService cs = new();
            ViewBag.ContactGroups = cs.ListGroups();
            return View();
        }


        [HttpPost]
        public IActionResult NewContact(Contact contact)
        {
            ContactService pls = new();
            Contact list = new()
            {
                Name = contact.Name,
                LastName = contact.LastName,
                Birthday = contact.Birthday,
                EMail = contact.EMail,
                GroupId = Convert.ToInt32(HttpContext.Request.Form["ContactGroups"].ToString()),
                UserId = (int)HttpContext.Session.GetInt32("user_userId")
            };
            var isSave = pls.AddNewContact(list);

            if (isSave.Status)
            {
                //TODO:kayıt oluşturulmuştur mesajı swal ile
                return RedirectToAction("Index", "Contact");
            }
            else
            {
                ContactService cs = new();
                ViewBag.ContactGroups = cs.ListGroups();
                ViewBag.Message = isSave.Message;
            }

            return View();
        }

        [HttpGet]
        public IActionResult Update(int contactId)
        {
            ContactService contactService = new();
            ViewBag.ContactGroups = contactService.ListGroups();
            var people = contactService.GetContactInfo(contactId);

            return View(people);
        }

        [HttpPost]
        public IActionResult Update(string name, string lastName, DateTime birthday, string eMail, int groupId)
        {
            ContactService cs = new();
            Contact list = new()
            {
                Name = name,
                LastName = lastName,
                EMail = eMail,
                Birthday = birthday,
                GroupId = groupId
            };
            var isUpdate = cs.UpdateContact(list);
            if (isUpdate.Status)
            {
                return RedirectToAction("Index", "Contact");
            }
            else
            {
                ContactService contactService = new();
                ViewBag.ContactGroups = contactService.ListGroups();
                ViewBag.Message = isUpdate.Message;
            }
            return View();
        }

        [HttpPost]
        public IActionResult DeleteContact(int id)
        {
            ContactService cs = new();
            var result = cs.DeleteContact(id);
            return Json("Kisi Silindi!");
        }

        [HttpPost]
        public IActionResult AddNewGroup(string name)
        {
            ContactService contactService = new();
            ContactGroups group = new()
            {
                Name = name
            };
            var isSave = contactService.AddNewGroup(group);

            if (isSave.Status == true)
            {
                return RedirectToAction("NewContact", "Contact");
            }
            else
            {
                ViewBag.Message = isSave.Message;
            }

            return View();
        }


        public IActionResult SendMailToContact()
        {
            ContactService contactService = new();
            ViewBag.Contact = contactService.GetAllContact();
            MailMessageDto mailMessageDto = new MailMessageDto { From = this.Configuration.GetSection("SmtpConfig")["User"] };
            return View(mailMessageDto);
        }

        [HttpPost]
        public IActionResult SendMailToContact(MailMessageDto mailMessageDto)
        {
            ContactService contactService = new();
            ViewBag.Contact = contactService.GetAllContact();
            MailService mailService = new();
            MailMessageDto messageDto = new()
            {
                To = mailMessageDto.To,
                From = mailMessageDto.From,
                Subject = mailMessageDto.Subject,
                Body = mailMessageDto.Body,
                SendDate = mailMessageDto.SendDate,
                UseSSL = true
            };
            if (mailMessageDto.To == null || mailMessageDto.Subject == null || mailMessageDto.Body == null)
            {
                ViewBag.Message = "Boş alan bırakmayınız";
            }
            else
            {
                var isMailSend = mailService.SendMail(mailMessageDto);
                if (isMailSend != null)
                {
                    FireAndForgetJobs.SendMailJob(mailMessageDto);
                    ViewBag.Message = isMailSend.Message;
                }
                else
                {
                    ViewBag.Message = isMailSend.Message;
                }
            }
            return View();
        }
    }
}
