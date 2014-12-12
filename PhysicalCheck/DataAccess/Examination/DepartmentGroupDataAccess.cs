using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;
using DataEntity.Examination;

namespace DataAccess.Examination {

    /// <summary>
    /// 数据访问类:DepartmentGroupDataAccess
    /// 文  件  名:DepartmentGroupDataAccess.cs
    /// 说      明:体检单位分组数据访问对象
    /// </summary>
    public class DepartmentGroupDataAccess : BaseDataAccess<DepartmentGroupEntity> {

        #region 构造器

        public DepartmentGroupDataAccess() {

        }

        #endregion

        #region 公共方法

        /// <summary>
        ///获取体检单位的分组数据
        ///<param name="DeptID">体检单位编号</param>
        /// </summary>
        public List<DepartmentGroupViewEntity> GetDepartmentGroups(int DeptID) {
            var q = from p in Session.Query<DepartmentGroupViewEntity>()
                    where p.Enabled == true && p.ID.DeptID == DeptID
                    select p;
            List<DepartmentGroupViewEntity> Result = q.ToList<DepartmentGroupViewEntity>();
            CloseSession();
            return Result;
        }

        /// <summary>
        /// 获取体检单位分组数据
        /// </summary>
        /// <param name="GroupID"></param> 
        /// <param name="DeptID"></param> 
        /// <returns>体检单位分组实体</returns>
        public DepartmentGroupViewEntity GetDepartmentGroup(int DeptID, int GroupID) {
            DepartmentGroupPK ID = new DepartmentGroupPK{DeptID=DeptID,GroupID=GroupID};
            DepartmentGroupViewEntity Result = Session.Get<DepartmentGroupViewEntity>(ID);
            CloseSession();           
            return Result;

        }

        /// <summary>
        /// 保存体检单位分组数据
        /// </summary>
        /// <param name="DepartmentGroup">体检单位分组实体</param>
        public void SaveDepartmentGroup(DepartmentGroupEntity DepartmentGroup) {
            if (DepartmentGroup.ID.GroupID == int.MinValue) DepartmentGroup.ID.GroupID = GetLineID("DepartmentGroup");
            DepartmentGroup.Enabled = true;
            Session.SaveOrUpdate(DepartmentGroup);
            Session.Flush();
            CloseSession();
        }

        /// <summary>
        /// 删除体检单位分组数据
        /// </summary>
        /// <param name="DepartmentGroup">体检单位分组实体</param>
        public void DeleteDepartmentGroup(DepartmentGroupEntity DepartmentGroup) {
            DepartmentGroup.Enabled = false;
            Session.SaveOrUpdate(DepartmentGroup);
            Session.Flush();
            CloseSession();
        }

        #endregion
    }
}
