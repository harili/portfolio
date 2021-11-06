//using MailKit.Net.Smtp;
//using MimeKit;
//using System;
//using System.IO;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Hubos.Library.Tools
//{
//    public static class Mail
//    {
//        private static readonly string fromAddress = "";
//        private static readonly string fromAddressTitle = "PORTFOLIO";
//        private static readonly string smtpServer = "";
//        private static readonly int smtpPortNumber = 587;
//        private static readonly string credentialLogin = "";
//        private static readonly string credentialPassword = "";

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="targetList"></param>
//        /// <param name="subject"></param>
//        /// <param name="body"></param>
//        public static async Task SendAsync(string[] targetList, string subject, string body, string[] attachmentList = null)
//        {
//            var message = new MimeMessage();
//            var builder = new BodyBuilder();

//            message.From.Add(new MailboxAddress(fromAddressTitle, fromAddress));
//            foreach (string target in targetList)
//            {
//                message.To.Add(new MailboxAddress(target.Split("@").First(), target));
//            }
//            message.Subject = subject;
//            builder.HtmlBody = body;

//            if (attachmentList != null && attachmentList.Length > 0)
//            {
//                foreach (string attachment in attachmentList)
//                {
//                    builder.Attachments.Add(attachment);
//                }
//            }

//            message.Body = builder.ToMessageBody();

//            var client = new SmtpClient();
//            client.AuthenticationMechanisms.Remove("XOAUTH2");
//            await client.ConnectAsync(smtpServer, smtpPortNumber);
//            await client.AuthenticateAsync(credentialLogin, credentialPassword);
//            await client.SendAsync(message);
//            await client.DisconnectAsync(true);
//        }

//        public static void Send(string[] targetList, string subject, string body)
//        {
//            var message = new MimeMessage();
//            var builder = new BodyBuilder();

//            message.From.Add(new MailboxAddress(fromAddressTitle, fromAddress));
//            foreach (string target in targetList)
//            {
//                message.To.Add(new MailboxAddress(target.Split("@").First(), target));
//            }
//            message.Subject = subject;
//            builder.HtmlBody = body;
//            message.Body = builder.ToMessageBody();

//            var client = new SmtpClient();
//            client.AuthenticationMechanisms.Remove("XOAUTH2");
//            client.Connect(smtpServer, smtpPortNumber);
//            client.Authenticate(credentialLogin, credentialPassword);
//            client.Send(message);
//            client.Disconnect(true);
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="targetList"></param>
//        /// <param name="error"></param>
//        /// <param name="extra"></param>
//        public static void Send(string[] targetList, Exception error, string extra = null)
//        {
//            var message = new MimeMessage();
//            var builder = new BodyBuilder();

//            message.From.Add(new MailboxAddress(fromAddressTitle, fromAddress));
//            foreach (string target in targetList)
//            {
//                message.To.Add(new MailboxAddress(target.Split("@").First(), target));
//            }
//            message.Subject = "ERROR " + DateTime.Now.ToString("yyyy-MM-dd");
//            if (error.InnerException != null)
//            {
//                error = error.InnerException;
//            }
//            string body = "<h4>" + error.Message + "</h4><h5>TRACE CODE</h5>" + "<pre>" + error.StackTrace + "</pre>";
//            if (!string.IsNullOrEmpty(extra))
//            {
//                body += "<h5>OTHER</h5><pre>" + extra + "</pre>";
//            }
//            builder.HtmlBody = body;
//            message.Body = builder.ToMessageBody();

//            var client = new SmtpClient();
//            client.AuthenticationMechanisms.Remove("XOAUTH2");
//            client.Connect(smtpServer, smtpPortNumber);
//            client.Authenticate(credentialLogin, credentialPassword);
//            client.Send(message);
//            client.Disconnect(true);
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="targetList"></param>
//        /// <param name="error"></param>
//        /// <param name="extra"></param>
//        public static async Task SendAsync(string[] targetList, Exception error, string extra = null)
//        {
//            var message = new MimeMessage();
//            var builder = new BodyBuilder();

//            message.From.Add(new MailboxAddress(fromAddressTitle, fromAddress));
//            foreach (string target in targetList)
//            {
//                message.To.Add(new MailboxAddress(target.Split("@").First(), target));
//            }
//            message.Subject = "ERROR " + DateTime.Now.ToString("yyyy-MM-dd");
//            if (error.InnerException != null)
//            {
//                error = error.InnerException;
//            }
//            string body = "<h4>" + error.Message + "</h4><h5>TRACE CODE</h5>" + "<pre>" + error.StackTrace + "</pre>";
//            if (!string.IsNullOrEmpty(extra))
//            {
//                body += "<h5>OTHER</h5><pre>" + extra + "</pre>";
//            }
//            builder.HtmlBody = body;
//            message.Body = builder.ToMessageBody();

//            var client = new SmtpClient();
//            client.AuthenticationMechanisms.Remove("XOAUTH2");
//            client.Connect(smtpServer, smtpPortNumber);
//            client.Authenticate(credentialLogin, credentialPassword);
//            await client.SendAsync(message);
//            client.Disconnect(true);
//        }
//    }
//}
