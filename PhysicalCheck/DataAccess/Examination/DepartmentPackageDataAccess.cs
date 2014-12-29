using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Linq;
using DataEntity.Examination;
using NHibernate;


namespace DataAccess.Examination {

    /// <summary>
    /// 数据访问类:DepartmentPackageDataAccess
    /// 文  件  名:DepartmentPackageDataAccess.cs
    /// 说      明:单位分组套餐明细数据访问对象
    /// </summary>
    public class DepartmentPackageDataAccess : BaseDataAccess<DepartmentPackageEntity> {

        #region 构造器

        public DepartmentPackageDataAccess() {

        }

        #endregion

        #region 公共方法

        /// <summary>
        ///获取所有单位分组套餐明细数据
        /// </summary>
        public List<DepartmentPackageViewEntity> GetDepartmentPackages(int DeptID) {
            var q = from p in Session.Query<DepartmentPackageViewEntity>()
                    where p.ID.DeptID == DeptID
                    select p;
            List<DepartmentPackageViewEntity> Result = q.ToList<DepartmentPackageViewEntity>();
            CloseSession();
            return Result;
        }

        /// <summary>
        ///获取所有单位分组套餐明细数据
        /// </summary>
        public List<DepartmentPackageViewEntity> GetDepartmentPackages(int DeptID, int DeptGorupID) {
            var q = from p in Session.Query<DepartmentPackageViewEntity>()
                    where p.ID.DeptID == DeptID && p.ID.DeptGorupID == DeptGorupID
                    select p;
            List<DepartmentPackageViewEntity> Result = q.ToList<DepartmentPackageViewEntity>();
            CloseSession();
            return Result;
        }

        /// <summary>
        /// 获取单位分组套餐明细数据
        /// </summary>
        /// <param name="DeptID"></param> 
        /// <param name="DeptGorupID"></param> 
        /// <param name="ItemID"></param> 
        /// <returns>单位分组套餐明细实体</returns>
        public DepartmentPackageViewEntity GetDepartmentPackage(int DeptID, int DeptGorupID, int ItemID) {
            DepartmentPackagePK ID = new DepartmentPackagePK { 
                DeptID = DeptID, 
                DeptGorupID = DeptGorupID, 
                ItemID = ItemID };
            DepartmentPackageViewEntity Result = Session.Get<DepartmentPackageViewEntity>(ID);
            return Result;
        }

        /// <summary>
        /// 保存单位分组套餐明细数据
        /// </summary>
        /// <param name="DepartmentPackage">单位分组套餐明细实体</param>        
        /// <returns>成功保存的行数</returns>
        public void SaveDepartmentPackage(DepartmentPackageEntity DepartmentPackage) {
            Session.SaveOrUpdate(DepartmentPackage);
            Session.Flush();
            CloseSession();
        }

        /// <summary>
        /// 删除单位分组套餐明细数据
        /// </summary>
        /// <param name="DepartmentPackage">单位分组套餐明细实体</param>        
        /// <returns>删除的数据行数</returns>
        public void DeleteDepartmentPackage(DepartmentPackageEntity DepartmentPackage) {
            Session.Delete(DepartmentPackage);
            Session.Flush();
            CloseSession();
        }

        public void DeleteDepartmentPackages(int DeptID, int DeptGorupID) {
            String HQL = String.Format(@"from DepartmentPackageEntity where 
                            ID.DeptID={0} AND ID.DeptGorupID={1}", DeptID,DeptGorupID);
            ITransaction tx = Session.BeginTransaction();
            try {
                Session.Delete(HQL);
                Session.Flush();
                tx.Commit();
            }
            catch (Exception ex) {
                if (tx != null) tx.Rollback();
                throw ex;
            }
            finally {
                CloseSession();
            }
        }

        #endregion

        #region IDisposable 成员

        public override void Dispose() {

        }

        #endregion
    }
}
