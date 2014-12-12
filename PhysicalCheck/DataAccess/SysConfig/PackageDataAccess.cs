using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;
using DataEntity.SysConfig;

namespace DataAccess.SysConfig {

    /// <summary>
    /// 数据访问类:PackageDataAccess
    /// 文  件  名:PackageDataAccess.cs
    /// 说      明:体检套餐数据访问对象
    /// </summary>
    public class PackageDataAccess : BaseDataAccess<PackageEntity> {

        #region 构造器

        public PackageDataAccess() {

        }

        #endregion

        #region 公共方法

        /// <summary>
        ///获取所有体检套餐数据
        /// </summary>
        public List<PackageEntity> GetPackages() {
            var q = from p in Session.Query<PackageEntity>()                  
                    select p;
            List<PackageEntity> Result = q.ToList<PackageEntity>();
            CloseSession();
            return Result;
        }

        /// <summary>
        ///获取所有体检套餐数据
        /// </summary>
        public List<PackageEntity> GetPackages(int pageIndex, int pageSize, out int RecordCount) {
            String hql = "select count(PackageID) from PackageEntity";
            IQuery query = Session.CreateQuery(hql);
            object obj = query.UniqueResult();
            int.TryParse(obj.ToString(), out RecordCount);
           
            List<PackageEntity> Result = Session.CreateQuery(@" from PackageEntity")                                               
                                                .SetFirstResult((pageIndex - 1) * pageSize)
                                                .SetMaxResults(pageSize)
                                                .List<PackageEntity>().ToList<PackageEntity>();
            CloseSession();
            return Result;
        }

        /// <summary>
        /// 获取体检套餐数据
        /// </summary>
        /// <param name="PackageID"></param> 
        /// <returns>体检套餐实体</returns>
        public PackageEntity GetPackage(int PackageID) {
            PackageEntity Result = Session.Get<PackageEntity>(PackageID);
            CloseSession();
            return Result;

        }

        /// <summary>
        /// 保存体检套餐数据
        /// </summary>
        /// <param name="Package">体检套餐实体</param> 
        public void SavePackage(PackageEntity Package) {
            if (Package.PackageID == int.MinValue) Package.PackageID = GetLineID("Package");
            Session.SaveOrUpdate(Package);
            Session.Flush();
            CloseSession();
        }

        /// <summary>
        /// 删除体检套餐数据
        /// </summary>
        /// <param name="Package">体检套餐实体</param> 
        public void DeletePackage(PackageEntity Package) {
            Session.Delete(Package);
            Session.Flush();
            CloseSession();
        }

        #endregion
    }
}
