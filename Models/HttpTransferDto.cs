using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailBox.Web.Models
{
    public class HttpTransferDto
    {
        public HttpContext HttpInfo { get; set; }
    }
}
