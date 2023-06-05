using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CI_API.Models.ViewModels
{
    public class SendEmailModel
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public SendEmailModel(string To, string Subject, string Body)
        {
            this.To=To;
            this.Subject=Subject;
            this.Body=Body;
        }
    }
}
