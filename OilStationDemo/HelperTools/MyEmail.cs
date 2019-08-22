using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelperTools
{
    /// <summary>
    /// 我的邮件
    /// </summary>
    public class MyEmail
    {
        /// <summary>
        /// 发送方发送方服务器地址
        /// </summary>
        public string StrHost { get; set; }

        /// <summary>
        /// 发送方帐号
        /// </summary>
        public string StrAccount { get; set; }

        /// <summary>
        /// 发送方密码
        /// </summary>
        public string StrPwd { get; set; }

        /// <summary>
        /// 发送方邮件地址
        /// </summary>
        public string StrFrom { get; set; }

        /// <summary>
        /// 接收方邮件地址
        /// </summary>
        public string ToEmailAddress { get; set; }

        /// <summary>
        /// 邮件标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 邮件正文内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 附件
        /// </summary>
        public string Sfile { get; set; }
    }
}