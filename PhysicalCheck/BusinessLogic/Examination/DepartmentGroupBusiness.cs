using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Examination;
using DataEntity.Examination;
using DataAccess.SysConfig;
using DataEntity.SysConfig;

namespace BusinessLogic.Examination {


    /// <summary>
    /// 体检单位分组业务逻辑对象
    /// </summary>
    public class DepartmentGroupBusiness : BaseBusinessLogic<DepartmentGroupDataAccess> {

        #region 构造器

        public DepartmentGroupBusiness() {

        }

        #endregion

        #region 公共方法

        public List<DepartmentGroupViewEntity> GetDepartmentGroups(int deptID) {
            return DataAccess.GetDepartmentGroups(deptID);
        }

        public DepartmentGroupViewEntity GetDepartmentGroup(int DeptID, int GroupID) {
            return DataAccess.GetDepartmentGroup(DeptID, GroupID);
        }

        /// <summary>
        /// 保存单位分组明细信息
        /// </summary>
        /// <param name="Group"></param>
        public void SaveDepartmentGroup(DepartmentGroupEntity Group) {
            DataAccess.SaveDepartmentGroup(Group);
            DepartmentPackageDataAccess DeptPackage = new DepartmentPackageDataAccess();
            DeptPackage.DeleteDepartmentPackages(Group.ID.DeptID.Value, Group.ID.GroupID.Value);
            using (PackageGroupDataAccess PackageGroup = new PackageGroupDataAccess()) {
                List<PackageGroupViewEntity> PackageGroups = PackageGroup.GetPackageGroups(Group.PackageID.Value);
                var q = from p in PackageGroups
                        select new DepartmentPackageEntity {
                            ID = new DepartmentPackagePK {
                                DeptID = Group.ID.DeptID,
                                DeptGorupID = Group.ID.GroupID,
                                ItemID = p.ID.GroupID
                            },
                            Category = "1",//组合项目
                            Enabled = true
                        };
                List<DepartmentPackageEntity> DeptPackages = q.ToList();
                DeptPackages.Add(new DepartmentPackageEntity {
                    ID = new DepartmentPackagePK {
                        DeptID = Group.ID.DeptID,
                        DeptGorupID = Group.ID.GroupID,
                        ItemID = Group.PackageID
                    },
                    Category = "0",//套餐
                    Enabled = true
                });
                foreach (DepartmentPackageEntity entity in DeptPackages) {
                    DeptPackage.SaveDepartmentPackage(entity);
                }
                //DeptPackage.DeleteDepartmentPackage();
            }
        }

        public void DeleteDepartmentGroup(DepartmentGroupEntity Group) {
            DataAccess.DeleteDepartmentGroup(Group);
            using (DepartmentPackageDataAccess DeptPackage = new DepartmentPackageDataAccess()) {
                DeptPackage.DeleteDepartmentPackages(Group.ID.DeptID.Value, Group.ID.GroupID.Value);
            }
        }

        #endregion
    }

}
