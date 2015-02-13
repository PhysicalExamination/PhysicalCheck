<%@ WebHandler Language="C#" Class="Services" %>

using System;
using System.Linq;
using System.Web;
using System.Web.Security;
using Newtonsoft.Json;
using System.Collections.Generic;
using BusinessLogic.Admin;
using DataEntity.Admin;

public class Services : IHttpHandler {

    private ModuleBusiness m_Module = new ModuleBusiness();
    private RoleBusiness m_Role = new RoleBusiness();

    public void ProcessRequest(HttpContext context) {
        context.Response.ContentType = "json/plain";
        HttpRequest Request = context.Request;
        String Action = Request.Params["Action"];
        if (Action == "GetModueTree") BuildModuleTree(context);
        if (Action == "SaveModue") SaveModule(context);
        if (Action == "DeleteModule") DeleteModule(context);
        if (Action == "GetRoleModuleTree") GetRoleModuleTree(context);
        if (Action == "SaveRoleModule") SaveRoleModule(context);
        if (Action == "UserLogin") UserLogin(context);
    }

    #region 数据提取

    private void BuildModuleTree(HttpContext context) {
        List<ModuleEntity> Modules = m_Module.GetModules("");
        foreach (ModuleEntity Module in Modules) {
            Module.Attributes = new ModuleAttribute {
                ModuleIcon = Module.ModuleIcon,
                URL = Module.URL,
                Description = Module.Description,
                ParentModuleNo = Module.ParentModuleNo,
                OrderNo = Module.OrderNo
            };
            Module.SubModules = GetSubModules(Module.ModuleNo);
        }
        context.Response.Write(JsonConvert.SerializeObject(Modules));
    }

    private List<ModuleEntity> GetSubModules(String ParentModuleNo) {
        List<ModuleEntity> Result = m_Module.GetModules(ParentModuleNo);
        foreach (ModuleEntity Module in Result) {
            Module.Attributes = new ModuleAttribute {
                ModuleIcon = Module.ModuleIcon,
                URL = Module.URL,
                ParentModuleNo = Module.ParentModuleNo,
                Description = Module.Description,
                OrderNo = Module.OrderNo
            };
            Module.SubModules = GetSubModules(Module.ModuleNo);
        }
        return Result;
    }

    #endregion

    #region 保存&删除

    private void SaveModule(HttpContext context) {
        ModuleEntity Module = new ModuleEntity();
        HttpRequest Request = context.Request;
        Module.ParentModuleNo = Request.Params["ParentModuleNo"];
        Module.ModuleNo = Request.Params["ModuleNo"];
        Module.ModuleName = Request.Params["ModuleName"];
        Module.URL = Request.Params["ModueURL"];
        Module.ModuleIcon = Request.Params["ModuleIcon"];
        Module.Description = Request.Params["Description"];
        Module.OrderNo = 0;
        if (!String.IsNullOrEmpty(Request.Params["OrderNo"])) {
            Module.OrderNo = Convert.ToInt32(Request.Params["OrderNo"]);       
        }
        Module.Attributes = new ModuleAttribute {
            ModuleIcon = Module.ModuleIcon,
            URL = Module.URL,
            ParentModuleNo = Module.ParentModuleNo,
            Description = Module.Description,
            OrderNo = Module.OrderNo
        };
        Msg msg = new Msg();
        try {
            m_Module.SaveModule(Module);
            msg.Data = new List<ModuleEntity>();
            msg.Data.Add(Module);
            msg.Succeed = true;
            msg.Message = "模块信息保存成功！";
        }
        catch  {
            msg.Succeed = false;
            msg.Message = "模块信息保存失败！";
        }
        context.Response.Write(JsonConvert.SerializeObject(msg));
    }

    private void DeleteModule(HttpContext context) {
        ModuleEntity Module = new ModuleEntity();
        Module.ParentModuleNo = context.Request.Params["ParentModuleNo"];
        Module.ModuleNo = context.Request.Params["ModuleNo"];
        Module.ModuleName = context.Request.Params["ModuleName"];
        Module.URL = context.Request.Params["ModueURL"];
        Module.ModuleIcon = context.Request.Params["ModuleIcon"];
        Module.Description = context.Request.Params["Description"];
        Msg msg = new Msg();
        try {
            m_Module.DeleteModule(Module);
            msg.Succeed = true;
            msg.Message = "模块信息删除成功！";
        }
        catch {
            msg.Succeed = false;
            msg.Message = "模块信息删除失败！";
        }
        context.Response.Write(JsonConvert.SerializeObject(msg));
    }

    #endregion

    #region 角色权限

    private void GetRoleModuleTree(HttpContext context) {
        String RoleNo = context.Request.Params["RoleNo"];
        List<RolePermissionEntity> RolePermissList = m_Role.GetRolePermissions(RoleNo);
        List<String> RoleModules = (from c in RolePermissList
                                    select c.ModuleNo).ToList<String>();
        List<ModuleEntity> Modules = m_Module.GetModules("root");
        foreach (ModuleEntity Module in Modules) {
            Module.Checked = false;
            if (RoleModules.Contains(Module.ModuleNo)) Module.Checked = true;
            Module.SubModules = GetRoleSubModules(Module.ModuleNo, RoleModules);
        }
        context.Response.Write(JsonConvert.SerializeObject(Modules));
        context.Response.Flush();
    }

    private List<ModuleEntity> GetRoleSubModules(String ParentModuleNo, List<String> RoleModules) {
        List<ModuleEntity> Result = m_Module.GetModules(ParentModuleNo);
        foreach (ModuleEntity Module in Result) {
            Module.Checked = false;
            if (RoleModules.Contains(Module.ModuleNo)) Module.Checked = true;
            Module.SubModules = GetRoleSubModules(Module.ModuleNo, RoleModules);
        }
        return Result;
    }

    private void SaveRoleModule(HttpContext context) {
        HttpRequest Request = context.Request;
        RolePermissionEntity RolePermission;
        String RoleNo = Request.Params["RoleNo"];
        Msg msg;
        if (String.IsNullOrEmpty(RoleNo)) {
            msg = new Msg { Succeed = true, Message = "数据保存失败，请选择角色后再保存！" };
            context.Response.Write(JsonConvert.SerializeObject(msg));
            return;
        }
        String Modules = Request.Params["Modules"];
        m_Role.DeleteRolePermissions(RoleNo);
        if (String.IsNullOrEmpty(Modules)) {
            msg = new Msg { Succeed = true, Message = "数据保存成功！" };
            context.Response.Write(JsonConvert.SerializeObject(msg));
            return;
        }
        String[] ModuleList = Modules.Split(',');
        foreach (String Module in ModuleList) {
            RolePermission = new RolePermissionEntity { RoleNo = RoleNo, ModuleNo = Module };
            m_Role.SaveRolePermission(RolePermission);
        }
        msg = new Msg { Succeed = true, Message = "数据保存成功！" };
        context.Response.Write(JsonConvert.SerializeObject(msg));

    }

    private void UserLogin(HttpContext context) {
        Msg msg = new Msg { Succeed = true, Message = "" };
        HttpRequest Request = context.Request;
        HttpResponse Response = context.Response;
        Response.ContentType = "application/json";
        String userAccount = Request.Params["UserName"];
        String password = FormsAuthentication.HashPasswordForStoringInConfigFile(Request.Params["Password"], "MD5");
        using (SysUserBusiness user = new SysUserBusiness()) {
            bool passed = user.Authentication(userAccount, password);
            if (passed) {
                FormsAuthentication.SetAuthCookie(userAccount, true);
                HttpCookie authCookie = FormsAuthentication.GetAuthCookie(userAccount, true);
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
                FormsAuthenticationTicket newTicket = new FormsAuthenticationTicket(ticket.Version, ticket.Name, ticket.IssueDate, ticket.Expiration, ticket.IsPersistent, "");
                authCookie.Value = FormsAuthentication.Encrypt(newTicket);
                Response.Cookies.Remove(authCookie.Name);
                Response.Cookies.Add(authCookie);
                msg.Message = FormsAuthentication.DefaultUrl;
            }
            else {
                msg.Succeed = false;
                msg.Message = "用户账号或密码不争取请重新登录！";
            }
            
        }      
        context.Response.Write(JsonConvert.SerializeObject(msg));
    }

    #endregion

    public bool IsReusable {
        get {
            return false;
        }
    }

}

public class Msg {

    public bool Succeed {
        get;
        set;
    }

    public String Message {
        get;
        set;
    }

    public List<ModuleEntity> Data {
        get;
        set;
    }
}

