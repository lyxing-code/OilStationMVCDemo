using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace HelperTools
{
    public class SendEmailHelp
    {
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="strHost">发送方发送方服务器地址</param>
        /// <param name="strAccount">发送方帐号</param>
        /// <param name="strPwd">发送方密码</param>
        ///  <param name="strFrom">发送方邮件地址</param>
        /// <param name="to">接收方邮件地址</param>
        /// <param name="title">邮件标题</param>
        /// <param name="content">邮件正文内容</param>
        /// <param name="sfile">邮件附件</param>
        /// <returns></returns>
        public bool SendMail(MyEmail e)//string strHost, string strAccount, string strPwd, string strFrom, string to, string title, string content
        {
            SmtpClient smtpClient = new SmtpClient();
            if (string.IsNullOrEmpty(e.StrHost))
            {
                e.StrHost = "smtp.sina.cn";//新浪测试
            }
            if (string.IsNullOrEmpty(e.StrAccount))
            {
                e.StrAccount = "xxx";
            }
            if (string.IsNullOrEmpty(e.StrPwd))
            {
                e.StrPwd = "xxx";
            }
            if (string.IsNullOrEmpty(e.StrFrom))
            {
                e.StrFrom = "xxx";
            }
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;//指定电子邮件发送方式
            smtpClient.Host = e.StrHost; ;//指定SMTP服务器
            smtpClient.Credentials = new System.Net.NetworkCredential(e.StrAccount, e.StrPwd);//用户名和密码

            MailMessage mailMessage = new MailMessage(e.StrFrom, e.ToEmailAddress);
            mailMessage.Subject = e.Title;//主题
            mailMessage.Body = e.Content;//内容
            mailMessage.BodyEncoding = System.Text.Encoding.UTF8;//正文编码
            mailMessage.IsBodyHtml = true;//设置为HTML格式
            mailMessage.Priority = MailPriority.High;//优先级
            //// 添加附件
            if (!string.IsNullOrEmpty(e.Sfile))
            {
                mailMessage.Attachments.Add(new Attachment(e.Sfile));
            }
            try
            {
                smtpClient.Send(mailMessage);
                mailMessage.Dispose();//释放资源
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}