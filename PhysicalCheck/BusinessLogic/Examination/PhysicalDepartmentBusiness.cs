using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Examination;
using DataEntity.Examination;

namespace BusinessLogic.Examination {

    public class PhysicalDepartmentBusiness : BaseBusinessLogic<PhysicalDepartmentDataAccess> {

        #region 构造器

        public PhysicalDepartmentBusiness() {

        }

        #endregion

        #region 公共方法

        public IList<PhysicalDepartmentEntity> GetPhysicalDepartments(int pageIndex, int pageSize,
            String DeptName, out int RecordCount) {
            return DataAccess.GetPhysicalDepartments(pageIndex, pageSize, DeptName, out RecordCount);
        }

        public PhysicalDepartmentEntity GetPhysicalDepartment(int DeptID) {
            return DataAccess.GetPhysicalDepartment(DeptID);
        }

        public void SavePhysicalDepartment(PhysicalDepartmentEntity PhysicalDepartment) {
            DataAccess.SavePhysicalDepartment(PhysicalDepartment);
        }

        public void DeletePhysicalDepartment(PhysicalDepartmentEntity PhysicalDepartment) {
            DataAccess.DeletePhysicalDepartment(PhysicalDepartment);
        }

        /// <summary>
        /// 通过体检单位名称返回体检单位编码
        /// </summary>
        /// <param name="DeptName"></param>
        /// <returns></returns>
        public int GetPhysicalDepartmentID(String DeptName) {
            return DataAccess.GetPhysicalDepartmentID(DeptName);
        }

        #endregion
    }
}
