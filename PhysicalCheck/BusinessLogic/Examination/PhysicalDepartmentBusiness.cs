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

        #endregion
    }
}
