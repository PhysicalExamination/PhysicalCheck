using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagedList;
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
            var q = Session.Query<PackageEntity>();
            q = q.Where(p => p.Enabled == true);
            List<PackageEntity> Result = q.ToPagedList<PackageEntity>(pageIndex, pageSize).ToList();
            RecordCount = q.Count();
            CloseSession();
            return Result;            
        }

        public List<PackageEntity> GetPackages(int pageIndex, int pageSize, String PackageName,
            String Sex,out int RecordCount) {
            var q = Session.Query<PackageEntity>();
            q = q.Where(p => p.Enabled == true);
            if (!String.IsNullOrWhiteSpace(PackageName)) {
                q = q.Where(p => p.PackageName.Contains(PackageName));
            }
            if (!String.IsNullOrWhiteSpace(Sex)) {
                q = q.Where(p => p.Category == "0" || p.Category == Sex);
            }
            List<PackageEntity> Result = q.ToPagedList<PackageEntity>(pageIndex, pageSize).ToList();
            RecordCount = q.Count();
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
        /// 返回套餐编码
        /// </summary>
        /// <returns></returns>
        //public int GetPackageID() {
        //    return GetLineID("Package");
        //}

        /// <summary>
        /// 保存体检套餐数据
        /// </summary>
        /// <param name="Package">体检套餐实体</param> 
        public void SavePackage(PackageEntity Package) {
            if (Package.PackageID == int.MinValue) Package.PackageID = GetLineID("Package");
            Package.DisplayOrder = Package.PackageID;
            Package.Enabled = true;
            Session.SaveOrUpdate(Package);
            Session.Flush();
            CloseSession();
        }

        /// <summary>
        /// 删除体检套餐数据
        /// </summary>
        /// <param name="Package">体检套餐实体</param> 
        public void DeletePackage(PackageEntity Package) {
            //Session.Delete(Package);
            Package.Enabled = false;
            Session.SaveOrUpdate(Package);
            Session.Flush();
            CloseSession();
        }

        #endregion
    }
}
