using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using DataEntity.SysConfig;
using DataAccess.SysConfig;

namespace BusinessLogic.SysConfig {

    /// <summary>
    /// 业务逻辑类:PackageBusiness
    /// 文  件  名:PackageBusiness.cs
    /// 说      明:体检套餐业务逻辑对象
    /// </summary>
    public class PackageBusiness : BaseBusinessLogic<PackageDataAccess> {

        #region 私有成员
        private PackageGroupDataAccess m_PackageGroup;
        #endregion

        #region 构造器

        public PackageBusiness() {
            m_PackageGroup = new PackageGroupDataAccess();
        }

        #endregion

        #region 公共方法

        public List<PackageEntity> GetPackages() {
            return DataAccess.GetPackages();
        }

        public List<PackageEntity> GetPackages(int pageIndex, int pageSize, out int RecordCount) {
            return DataAccess.GetPackages(pageIndex, pageSize, out RecordCount);
        }

        public List<PackageEntity> GetPackages(int pageIndex, int pageSize, String PackageName,
            String Sex, out int RecordCount) {
            return DataAccess.GetPackages(pageIndex, pageSize, PackageName, Sex,out RecordCount);
        }

        public PackageEntity GetPackage(int PackageID) {
            return DataAccess.GetPackage(PackageID);
        }

        public void UpdatePackagePrice(int PackageID, decimal Price) {
            PackageEntity Package = DataAccess.GetPackage(PackageID);
            Package.Price = Price;
            DataAccess.SavePackage(Package);
        }

        public void SavePackage(PackageEntity Package) {
            DataAccess.SavePackage(Package);
        }

        public void DeletePackage(PackageEntity Package) {
            DataAccess.DeletePackage(Package);
        }

        //public int GetPackageID() {
        //    return DataAccess.GetPackageID();
        //}
        #endregion

        #region 套餐组合项目

        public List<PackageGroupViewEntity> GetPackageGroups(int pageIndex, int pageSize, int PackageID,
            out int RecordCount) {
            return m_PackageGroup.GetPackageGroups(pageIndex, pageSize, PackageID, out RecordCount);

        }

        public List<PackageGroupViewEntity> GetPackageGroups(int PackageID) {
            return m_PackageGroup.GetPackageGroups(PackageID);
        }

        /// <summary>
        /// 返回套餐价格
        /// </summary>
        /// <param name="PackageID">套餐编号</param>
        /// <returns>套餐价格</returns>
        public decimal GetPackagePrice(int PackageID) {
            List<PackageGroupViewEntity> List = m_PackageGroup.GetPackageGroups(PackageID);
            decimal? Result = List.Sum(p => p.Price);
            if (Result == null) return 0.0m;
            return Result.Value;
        }

        public void SavePackageGroup(PackageGroupEntity PackageGroup) {
            m_PackageGroup.SavePackageGroup(PackageGroup);
        }

        public void DeletePackageGroup(PackageGroupEntity PackageGroup) {
            m_PackageGroup.DeletePackageGroup(PackageGroup);
        }

        #endregion
    }
}
