using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;
using DataEntity.SysConfig;

namespace DataAccess.SysConfig {

    /// <summary>
    /// 数据访问类:PackageGroupDataAccess
    /// 文  件  名:PackageGroupDataAccess.cs
    /// 说      明:套餐组合项目数据访问对象
    /// </summary>
    public class PackageGroupDataAccess : BaseDataAccess<PackageGroupEntity> {

        #region 构造器

        public PackageGroupDataAccess() {

        }

        #endregion

        #region 公共方法

        /// <summary>
        ///分页获取套餐所有组合项数据
        /// </summary>
        public List<PackageGroupViewEntity> GetPackageGroups(int pageIndex, int pageSize, int PackageID,
            out int RecordCount) {
                String hql = "select count(PackageID) from PackageGroupViewEntity where PackageID=?";
            IQuery query = Session.CreateQuery(hql).SetInt32(0,PackageID);
            object obj = query.UniqueResult();
            int.TryParse(obj.ToString(), out RecordCount);
            hql = @" from PackageGroupViewEntity where PackageID=? ";
            List<PackageGroupViewEntity> Result = Session.CreateQuery(hql)
                                                .SetInt32(0, PackageID)
                                                .SetFirstResult((pageIndex - 1) * pageSize)
                                                .SetMaxResults(pageSize)
                                                .List<PackageGroupViewEntity>().ToList<PackageGroupViewEntity>();
            CloseSession();
            return Result;
        }

        /// <summary>
        /// 获取套餐所有组合项
        /// </summary>
        /// <param name="PackageID">套餐编号</param>
        /// <returns></returns>
        public List<PackageGroupViewEntity> GetPackageGroups(int PackageID) {          
            String hql = @" from PackageGroupViewEntity where PackageID=? ";
            List<PackageGroupViewEntity> Result = Session.CreateQuery(hql)
                                                .SetInt32(0, PackageID)                                               
                                                .List<PackageGroupViewEntity>().ToList<PackageGroupViewEntity>();
            CloseSession();
            return Result;
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="PackageGroup">实体</param>
        public void SavePackageGroup(PackageGroupEntity PackageGroup) {
            Session.SaveOrUpdate(PackageGroup);
            Session.Flush();
            CloseSession();
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="PackageGroup">实体</param>
        public void DeletePackageGroup(PackageGroupEntity PackageGroup) {
            Session.Delete(PackageGroup);
            Session.Flush();
            CloseSession();
        }

        #endregion
    }
}
