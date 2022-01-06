using MailBoxBackgroundJob.Schedules;
using MailBoxEntity;
using MailBoxService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MailBox.Web.Controllers
{
    public class CalenderController : Controller
    {
        private IConfiguration Configuration;

        public IActionResult Index()
        {

            return View();
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

        [HttpGet]
        public IActionResult GetContacts()
        {
            CalenderMainModel calenderMain = new();
            ContactService cs = new();
            calenderMain.Contact = cs.GetListContact();
            calenderMain.Task = cs.GetTasks();
            return Json(calenderMain);

        }

        [HttpPost]
        public IActionResult GetCalenderOperation(MailBoxEntity.Task task)
        {
            ContactService contactService = new();
            MailBoxEntity.Task task1 = new()
            {
                TaskId = task.TaskId,
                TaskTitle = task.TaskTitle,
                TaskStart = task.TaskStart,
                TaskEnd = task.TaskEnd,
                TaskUser = task.TaskUser,
                RecurrenceRule = task.RecurrenceRule,
                Description = task.Description
            };
            contactService.CalenderOperation(task1);
            return Json("Kaydedildi!");
        }

        [HttpPost]
        public IActionResult DeleteTask(int taskId)
        {
            ContactService cs = new();
            var result = cs.DeleteTask(taskId);
            return Json("Kisi Silindi!");
        }

        public IActionResult SendMails(MailBoxEntity.Task task)
        {
            MailService mailService = new();
            ContactService cs = new();
            var taskRule = cs.GetTaskWithRule(task);
            MailMessageDto messageDto = new()
            {
                To = taskRule.TaskUser.ToString(),
                From = "",
                Subject = taskRule.TaskTitle,
                Body = taskRule.Description,
                SendDate = taskRule.TaskStart,
                UseSSL = true
            };
            switch (taskRule.RecurrenceRule)
            {
                case "null":
                    FireAndForgetJobs.SendMailJob(messageDto);
                    break;

                case "Daily":
                    RecurringJobs.SendDailyRecurringJobs(messageDto);
                    break;

                case "Weekly":
                    RecurringJobs.SendWeeklyRecurringJobs(messageDto);
                    break;

                case "Monthly":
                    RecurringJobs.SendMonthlyRecurringJobs(messageDto);
                    break;
            }
            return View();
        }
    }
}
