using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;
using DataEntity.SysConfig;

namespace DataAccess.SysConfig {

    /// <summary>
    /// 健康行业
    /// </summary>
    public class IndustryDataAccess:BaseDataAccess<IndustryEntity> {

        #region 构造器

        public IndustryDataAccess() {
        }

        #endregion

        #region 公共方法

        /// <summary>
        /// 返回健康行业实体
        /// </summary>
        /// <param name="IndustryID">健康行业编号</param>
        /// <returns>健康行业实体信息</returns>
        public IndustryEntity GetIndustry(int IndustryID) {
            IndustryEntity Result = Session.Get<IndustryEntity>(IndustryID);
            CloseSession();
            return Result;
        }

        /// <summary>
        /// 返回所有健康行业实体列表
        /// </summary>
        /// <returns>健康行业实体列表</returns>
        public List<IndustryEntity> GetIndustrys() {
            var q = from p in Session.Query<IndustryEntity>()
                    where p.Enabled == true
                    select p;
            List<IndustryEntity> Result = q.ToList<IndustryEntity>();
            CloseSession();
            return Result;
        }

        /// <summary>
        /// 保存健康行业信息
        /// </summary>
        /// <param name="Industry">健康行业实体</param>
        public void SaveIndustry(IndustryEntity Industry) {
            Industry.Enabled = true;
            if (Industry.IndustryID == int.MinValue) Industry.IndustryID = GetLineID("Industry");
            Session.SaveOrUpdate(Industry);
            Session.Flush();
            CloseSession();
        }

        /// <summary>
        /// 删除健康行业信息
        /// </summary>
        /// <param name="Industry">健康行业实体</param>
        public void DeleteIndustry(IndustryEntity Industry) {
            Industry.Enabled = false;
            Session.SaveOrUpdate(Industry);
            Session.Flush();
            CloseSession();
        }

        #endregion
    }
}
