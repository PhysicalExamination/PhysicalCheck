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
            List<GroupResultViewEntity> Result = q.ToList<GroupResultViewEntity>();
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

        #endregion
    }
}