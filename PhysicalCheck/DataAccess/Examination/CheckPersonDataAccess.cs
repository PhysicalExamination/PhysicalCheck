using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataEntity.Examination;
using NHibernate.Linq;
using NHibernate.Criterion;
using NHibernate;

namespace DataAccess.Examination {

    /// <summary>
    /// 数据访问类:CheckPersonDataAccess
    /// 文  件  名:CheckPersonDataAccess.cs
    /// 说      明:体检人员数据访问对象
    /// </summary>
    public class CheckPersonDataAccess : BaseDataAccess<CheckPersonEntity> {

        #region 构造器

        public CheckPersonDataAccess() {

        }

        #endregion

        #region 公共方法

        /// <summary>
        ///获取所有体检人员数据
        /// </summary>
        public IList<CheckPersonViewEntity> GetCheckPersons(int pageIndex, int pageSize,
            String DeptName, out int RecordCount) {
            ICriteria Criteria = Session.CreateCriteria<CheckPersonViewEntity>();
            Criteria.SetProjection(Projections.RowCount());
            if (!String.IsNullOrWhiteSpace(DeptName)) {
                Criteria.Add(Restrictions.Like("DeptName", DeptName, MatchMode.Anywhere));
            }
            RecordCount = Convert.ToInt32(Criteria.UniqueResult());

            Criteria = Session.CreateCriteria<CheckPersonViewEntity>();
            Criteria.SetFirstResult((pageIndex - 1) * pageSize)
                    .SetMaxResults(pageSize);
            if (!String.IsNullOrWhiteSpace(DeptName)) {
                Criteria.Add(Restrictions.Like("DeptName", DeptName, MatchMode.Anywhere));
            }
            IList<CheckPersonViewEntity> Result = Criteria.List<CheckPersonViewEntity>();
            CloseSession();
            return Result;
        }

        /// <summary>
        /// 获取体检人员数据
        /// </summary>
        /// <param name="PersonID"></param> 
        /// <returns>体检人员实体</returns>
        public CheckPersonViewEntity GetCheckPerson(int PersonID) {
            CheckPersonViewEntity Result = Session.Get<CheckPersonViewEntity>(PersonID);
            CloseSession();
            return Result;
        }

        public CheckPersonViewEntity GetCheckPerson(String IDNumber) {
            ICriteria Criteria = Session.CreateCriteria<CheckPersonViewEntity>();
            Criteria.Add(Restrictions.Eq("IDNumber", IDNumber));
            CheckPersonViewEntity Result = Criteria.UniqueResult<CheckPersonViewEntity>();         
            CloseSession();
            return Result;
        }

        /// <summary>
        /// 保存体检人员数据
        /// </summary>
        /// <param name="CheckPerson">体检人员实体</param>
        public void SaveCheckPerson(CheckPersonEntity CheckPerson) {
            var person = GetCheckPerson(CheckPerson.IDNumber);
            if (person != null) {
                CheckPerson.PersonID = person.PersonID;
                return;
            }
            if (CheckPerson.PersonID == int.MinValue) CheckPerson.PersonID = GetLineID("CheckPerson");
            if (CheckPerson.PersonID == null) CheckPerson.PersonID = GetLineID("CheckPerson");
            Session.SaveOrUpdate(CheckPerson);
            Session.Flush();
            CloseSession();
        }

        /// <summary>
        /// 删除体检人员数据
        /// </summary>
        /// <param name="CheckPerson">体检人员实体</param>
        public void DeleteCheckPerson(CheckPersonEntity CheckPerson) {
            Session.Delete(CheckPerson);
            Session.Flush();
            CloseSession();
        }

        #endregion
    }
}
