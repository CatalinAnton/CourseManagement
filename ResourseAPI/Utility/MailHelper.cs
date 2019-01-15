using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ResourseAPI.Utility
{
    public class MailHelper
    {
        public static void SendMail(string SendTo, string Message)
        {
            var fromAddress = new MailAddress("coursemanagement123456@gmail.com", "CourseManagement");
            var toAddress = new MailAddress(SendTo, "User");
            const string fromPassword = "TestPassword1234";
            const string subject = "Subject";
            string body = Message;

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }
    }
}
