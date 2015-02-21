﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;
using DataEntity.Examination;

namespace DataAccess.Examination {
    /// <summary>
    /// 数据访问类:GroupResultDataAccess
    /// 文  件  名:GroupResultDataAccess.cs
    /// 说      明:体检组合项目结论数据访问对象
    /// </summary>
    public class GroupResultDataAccess : BaseDataAccess<GroupResultEntity> {

        #region 构造器

        public GroupResultDataAccess() {

        }

        #endregion

        #region 公共方法

        /// <summary>
        ///获取所有体检组合项目结论数据
        /// </summary>
        public List<GroupResultViewEntity> GetGroupResults(string RegisterNo) {
            var q = from p in Session.Query<GroupResultViewEntity>()
                    where p.ID.RegisterNo == RegisterNo
                    select p;
            List<GroupResultViewEntity> Result = q.OrderBy(p=>p.DeptID).ToList<GroupResultViewEntity>();
            CloseSession();
            return Result;
        }

        /// <summary>
        ///分科室获取个人体检结果
        ///<param name="RegisterNo">登记号</param>
        ///<param name="DeptID">科室编码</param>
        /// </summary>
        public List<GroupResultViewEntity> GetGroupResults(string RegisterNo,int DeptID) {
            var q = from p in Session.Query<GroupResultViewEntity>()
                    where p.ID.RegisterNo == RegisterNo && p.DeptID == DeptID
                    select p;
            List<GroupResultViewEntity> Result = q.ToList<GroupResultViewEntity>();
            CloseSession();
            return Result;
        }

        /// <summary>
        /// 返回体检人所有未检项目
        /// </summary>
        /// <param name="RegisterNo">登记号</param>
        /// <returns></returns>
        public List<String> GetUncheckedGroup(String RegisterNo) {
            var q = from p in Session.Query<GroupResultViewEntity>()
                    where p.ID.RegisterNo == RegisterNo && p.IsOver==false
                    select p.GroupName;
            List<String> Result = q.ToList<String>();
            CloseSession();
            return Result;
        }

        /// <summary>
        /// 返回体检人各检查项小结
        /// </summary>
        /// <param name="RegisterNo">登记号</param>
        /// <returns></returns>
        public List<String> GetGroupSummary(String RegisterNo) {
            var q = from p in Session.Query<GroupResultViewEntity>()
                    where p.ID.RegisterNo == RegisterNo && p.IsOver == true
                    select p.Summary;
            List<String> Result = q.ToList<String>();
            CloseSession();
            return Result;
        }

        /// <summary>
        /// 获取体检组合项目结论数据
        /// </summary>
        /// <param name="RegisterNo">登记号</param> 
        /// <param name="GroupID">组合项目编号</param> 
        /// <returns>体检组合项目结论实体</returns>
        public GroupResultViewEntity GetGroupResult(string RegisterNo, int GroupID) {
            GroupResultPK ID = new GroupResultPK { RegisterNo = RegisterNo, GroupID = GroupID };
            GroupResultViewEntity Result = Session.Get<GroupResultViewEntity>(ID);
            CloseSession();
            return Result;
        }

        /// <summary>
        /// 保存体检组合项目结论数据
        /// </summary>
        /// <param name="GroupResult">体检组合项目结论实体</param>
        public void SaveGroupResult(GroupResultEntity GroupResult) {
            GroupResultEntity OldGroupResult = Session.Get<GroupResultEntity>(GroupResult.ID);
            if (OldGroupResult != null) {
                OldGroupResult.CheckDate = GroupResult.CheckDate;
                OldGroupResult.CheckDoctor = GroupResult.CheckDoctor;
                OldGroupResult.Summary = GroupResult.Summary;
                OldGroupResult.IsOver = GroupResult.IsOver;
                Session.SaveOrUpdate(OldGroupResult);
                Session.Flush();
                CloseSession();
                return;
            }
            Session.SaveOrUpdate(GroupResult);
            Session.Flush();
            CloseSession();
        }

        /// <summary>
        /// 删除体检组合项目结论数据
        /// </summary>
        /// <param name="GroupResult">体检组合项目结论实体</param>
        public void DeleteGroupResult(GroupResultEntity GroupResult) {
            Session.Delete(GroupResult);
            Session.Flush();
            CloseSession();
        }

        public void DeleteGroupResults(String RegisterNo) {
            String hql = @"DELETE GroupResultEntity WHERE ID.RegisterNo=?";
            ITransaction tx = Session.BeginTransaction();
            try {
                Session.CreateQuery(hql)
                    .SetString(0, RegisterNo)
                    .ExecuteUpdate();
                tx.Commit();
            }
            catch {
                tx.Rollback();
            }
            finally {
                CloseSession();
            }
        }

        /// <summary>
        /// 删除体检组合项
        /// </summary>
        /// <param name="RegisterNo"></param>
        /// <param name="GroupID"></param>
        public void DeleteCheckedGroup(String RegisterNo, int GroupID) {
            String hql = @"DELETE GroupResultEntity WHERE ID.RegisterNo=? AND ID.GroupID=?";
            String ItemResult = @"DELETE ItemResultEntity WHERE ID.RegisterNo=? AND ID.GroupID=?";
            ITransaction tx = Session.BeginTransaction();
            try {
                Session.CreateQuery(hql)
                    .SetString(0, RegisterNo)
                    .SetInt32(1,GroupID)
                    .ExecuteUpdate();
                Session.CreateQuery(ItemResult)
                    .SetString(0, RegisterNo)
                    .SetInt32(1, GroupID)
                    .ExecuteUpdate();
                tx.Commit();
            }
            catch {               
                tx.Rollback();
            }
            finally {
                CloseSession();
            }
        }

        #endregion
    }
}
