using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using BusinessLogic.Admin;
using System.Text.RegularExpressions;
using DataEntity.Admin;
using System.Web.Security;
using System.Diagnostics;
//using System.Web.Mail;

public partial class Admin_SendPassword : System.Web.UI.Page {

    protected void ShowMessage(string message) {
        ScriptManager.RegisterClientScriptBlock(this, GetType(), "Information", "alert('" + message + "')", true);
    }

    protected void btnSend_Click(object sender, EventArgs e) {
        /*SysUserBusiness SysUser = new SysUserBusiness();
        String UserAccount = txtUserAccount.Text.Trim();
        String ValidateCode = txtValidateCode.Text.Trim().ToLower();
        String CheckCode = ((String)Session["CheckCode"]).ToLower();
        SysUserEntity UserInfo = SysUser.GetUserByAccount(UserAccount);
        if (UserInfo == null) {
            ShowMessage(string.Format("账号{0}不存在请重新输入", UserAccount));
            return;
        }
        if (CheckCode != ValidateCode) {
            ShowMessage("您输入的验证码不匹配请重新输入。");
            return;
        }
        String ReceiveEMail = UserInfo.EMail;
        String patten = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
        Regex r = new Regex(patten, RegexOptions.IgnoreCase);
        if (String.IsNullOrEmpty(ReceiveEMail)) {
            ShowMessage("您没有提供有效的电子邮件请与管理员联系，为您录入正确的邮件地址。");
            return;
        }
        if (!r.IsMatch(ReceiveEMail)) {
            ShowMessage("您的电子邮件地址有误请与管理员联系，重新核对电子邮件。");
            return;
        }
        //WebMailSend();
        //CheckSmtp("mail.tmrd.com.cn", 25, "sis@tmrd.com.cn", "tongmeisis123");        
        //生成新的登录密码
        String newPassword = GenerateCheckCode();  
        String MailFromHost = "mail.tmrd.com.cn";
        String MailFromName = "SIS系统管理员";
        String MailFrom = "sis@tmrd.com.cn";
        String MailPwd = "tongmeisis";
        String MailTo =  ReceiveEMail;
        String MailSubject = "重置后的SIS系统登录密码";
        String MailBody = String.Format("{0}，您好！您登录SIS系统的密码被重置为{1}", UserInfo.UserName, newPassword);
        bool IsHtml = false;
        bool Succeed  = SendOK(MailTo, MailSubject, MailBody, IsHtml, MailFrom, MailFromName, MailPwd, MailFromHost);
        if (Succeed) {
            ShowMessage("重置后的密码已发送到您的邮件请注意查收！");
            //更新用户信息
            UserInfo.PassWord = FormsAuthentication.HashPasswordForStoringInConfigFile(newPassword, "MD5"); ;
            SysUser.SaveSysUser(UserInfo);
        }
        else {
            ShowMessage("重置密码失败请联系管理员！");
            return;
        }  */      
    }

    private string GenerateCheckCode() {
        int number;
        char code;
        string checkCode = string.Empty;
        Random random = new Random();
        for (int i = 0; i < 8; i++) {
            number = random.Next();
            if (number % 2 == 0)
                code = (char)('0' + (char)(number % 10));
            else
                code = (char)('A' + (char)(number % 26));
            checkCode += code.ToString();
        }
        return checkCode;
    }

    private  bool SendOK(string MailTo, string MailSubject, string MailBody, bool IsHtml, 
        string MailFrom, string MailFromName, string MailPwd, string MailFromHost) {
            return false;
        /*MailMessage message = new MailMessage();
        message.From = MailFrom;
        message.FromName = MailFromName;
        string[] _mail = MailTo.Split(',');
        for (int j = 0; j < _mail.Length; j++) {
            message.AddRecipients(_mail[j]);
        }
        message.Subject = MailSubject;
        if (IsHtml)
            message.BodyFormat =MailFormat.HTML;
        else
            message.BodyFormat = MailFormat.Text;
        message.Priority = MailPriority.Normal;
        message.Body = MailBody;
       SmtpClient smtp = new SmtpClient(MailFromHost);
        if (smtp.Send(message, MailFrom, MailPwd))
            return true;
        else {
            SaveErrLog(MailTo, MailFrom, MailFromName, MailFromHost, smtp.ErrMsg);
            return false;
        } */       
    }

    /// <summary>
    /// 保存正确日志
    /// </summary>
    /// <param name="MailFrom"></param>
    /// <param name="MailFromName"></param>
    /// <param name="MailFromHost"></param>
    private void SaveSucLog(string MailTo, string MailFrom, string MailFromName, string MailFromHost) {
        System.IO.StreamWriter sw = new System.IO.StreamWriter(HttpContext.Current.Server.MapPath("~/_data/log/mailsuccess_" + DateTime.Now.ToString("yyyyMMdd") + ".txt"), true, System.Text.Encoding.UTF8);
        sw.WriteLine(System.DateTime.Now.ToString());
        sw.WriteLine("\t收 信 人：" + MailTo);
        sw.WriteLine("\tSMTP服务器：" + MailFromHost);
        sw.WriteLine("\t发 信 人：" + MailFromName + "<" + MailFrom + ">");
        sw.WriteLine("---------------------------------------------------------------------------------------------------");
        sw.Close();
        sw.Dispose();
    }

    /// <summary>
    /// 保存错误日志
    /// </summary>
    /// <param name="MailFrom"></param>
    /// <param name="MailFromName"></param>
    /// <param name="MailFromHost"></param>
    /// <param name="ErrMsg"></param>
    private static void SaveErrLog(string MailTo, string MailFrom, string MailFromName, string MailFromHost, string ErrMsg) {
        System.IO.StreamWriter sw = new System.IO.StreamWriter(HttpContext.Current.Server.MapPath("~/_data/log/mailerror_" + DateTime.Now.ToString("yyyyMMdd") + ".txt"), true, System.Text.Encoding.UTF8);
        sw.WriteLine(System.DateTime.Now.ToString());
        sw.WriteLine("\t收 信 人：" + MailTo);
        sw.WriteLine("\tSMTP服务器：" + MailFromHost);
        sw.WriteLine("\t发 信 人：" + MailFromName + "<" + MailFrom + ">");
        sw.WriteLine("\t错误信息：\r\n" + ErrMsg);
        sw.WriteLine("---------------------------------------------------------------------------------------------------");
        sw.Close();
        sw.Dispose();
    }
 

}