using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;
using DataEntity.Examination;

namespace DataAccess.Examination {

    /// <summary>
    /// 数据访问类:ItemResultDataAccess
    /// 文  件  名:ItemResultDataAccess.cs
    /// 说      明:体检项目结论数据访问对象
    /// </summary>
    public class ItemResultDataAccess : BaseDataAccess<ItemResultEntity> {

        #region 构造器

        public ItemResultDataAccess() {

        }

        #endregion

        #region 公共方法

        /// <summary>
        ///获取所有体检项目结论数据
        /// </summary>
        public List<ItemResultViewEntity> GetItemResults(string RegisterNo, int GroupID) {
            var q = from p in Session.Query<ItemResultViewEntity>()
                    where p.ID.RegisterNo == RegisterNo && p.ID.GroupID == GroupID
                    select p;
            List<ItemResultViewEntity> Result = q.ToList<ItemResultViewEntity>();
            CloseSession();
            return Result;
        }

        /// <summary>
        ///获取体检科室所有体检项目结论数据
        /// </summary>
        public IList<ItemResultViewEntity> GetDeptItemResults(int pageIndex, int pageSize,
            string RegisterNo, int DeptID, out int RecordCount) {
            String hql = @"select count(ItemID) from ItemResultViewEntity where RegisterNo=? and DeptID=? ";
            IQuery query = Session.CreateQuery(hql)
                .SetString(0, RegisterNo)
                .SetInt32(1, DeptID);
            object obj = query.UniqueResult();
            int.TryParse(obj.ToString(), out RecordCount);
            hql = @" from ItemResultViewEntity where RegisterNo=? and DeptID=? ";
            IList<ItemResultViewEntity> Result = Session.CreateQuery(hql)
                                                .SetString(0, RegisterNo)
                                                .SetInt32(1, DeptID)
                                                .SetFirstResult((pageIndex - 1) * pageSize)
                                                .SetMaxResults(pageSize)
                                                .List<ItemResultViewEntity>();
            CloseSession();
            return Result;
        }

        /// <summary>
        /// 获取体检项目结论数据
        /// </summary>
        /// <param name="RegisterNo"></param> 
        /// <param name="GroupID"></param> 
        /// <param name="ItemID"></param> 
        /// <returns>体检项目结论实体</returns>
        public ItemResultViewEntity GetItemResult(string RegisterNo, int GroupID, int ItemID) {
            ItemResultPK ID = new ItemResultPK { RegisterNo = RegisterNo, GroupID = GroupID, ItemID = ItemID };
            ItemResultViewEntity Result = Session.Get<ItemResultViewEntity>(ID);
            CloseSession();
            return Result;
        }

        /// <summary>
        /// 保存体检项目结论数据
        /// </summary>
        /// <param name="ItemResult">体检项目结论实体</param>
        public void SaveItemResult(ItemResultEntity ItemResult) {
            Session.SaveOrUpdate(ItemResult);
            Session.Flush();
            CloseSession();
        }

        /// <summary>
        /// 删除体检项目结论数据
        /// </summary>
        /// <param name="ItemResult">体检项目结论实体</param>
        public void DeleteItemResult(ItemResultEntity ItemResult) {
            Session.Delete(ItemResult);
            Session.Flush();
            CloseSession();
        }

        public void DeleteItemResults(String RegisterNo) {
            String hql = @"DELETE ItemResultEntity WHERE ID.RegisterNo=?";
            ITransaction tx = Session.BeginTransaction();
            try {
                Session.CreateQuery(hql)
                    .SetString(0, RegisterNo)
                    .ExecuteUpdate();
                tx.Commit();
            }
            catch {
                tx.Rollback();
            }
            finally {
                CloseSession();
            }
        }

        #endregion
    }
}
