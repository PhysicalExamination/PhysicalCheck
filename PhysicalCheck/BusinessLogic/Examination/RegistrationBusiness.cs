﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Examination;
using DataEntity.Examination;
using BusinessLogic.SysConfig;
using DataEntity.SysConfig;

namespace BusinessLogic.Examination {

    public class RegistrationBusiness : BaseBusinessLogic<RegistrationDataAccess> {

        #region 构造器

        public RegistrationBusiness() {
        }

        #endregion

        #region 公共方法

        /// <summary>
        ///获取所有体检登记数据
        /// </summary>
        public IList<RegistrationViewEntity> GetRegistrations(int pageIndex, int pageSize,
            DateTime? CheckDate, String DeptName, String RegisterNo, out int RecordCount) {
            return DataAccess.GetRegistrations(pageIndex, pageSize, CheckDate, DeptName,
                RegisterNo, out RecordCount);
        }

        /// <summary>
        /// 返回所有通过体检但未总检的登记信息
        /// </summary>
        /// <param name="pageIndex">页号</param>
        /// <param name="pageSize">页面大小</param>
        /// <param name="CheckDate">体检日期</param>
        /// <param name="DeptName">单位名称</param>
        /// <param name="RegisterNo">登记号或身份证号</param>
        /// <param name="RecordCount">总记录数</param>
        /// <returns></returns>
        public IList<RegistrationViewEntity> GetOveralls(int pageIndex, int pageSize,
            DateTime? CheckDate, String DeptName, String RegisterNo, out int RecordCount) {
                GroupResultDataAccess GroupDataAccess = new GroupResultDataAccess();
            IList<RegistrationViewEntity> List = DataAccess.GetOveralls(pageIndex, pageSize, CheckDate,
                DeptName, RegisterNo, out RecordCount);
            List<String> Items,Summary;
            foreach (RegistrationViewEntity Register in List) {
                Items = GroupDataAccess.GetUncheckedGroup(Register.RegisterNo);
                Summary = GroupDataAccess.GetGroupSummary(Register.RegisterNo);
                Register.UncheckedItems = String.Join(";",Items.ToArray());
                Register.Summary = String.Join(";", Summary.ToArray());
            }
            return List;
        }

        public IList<RegistrationViewEntity> GetCheckReports(int pageIndex, int pageSize,
            DateTime? CheckDate, String DeptName, String RegisterNo, out int RecordCount) {
                return DataAccess.GetCheckReports(pageIndex, pageSize, CheckDate, DeptName, 
                    RegisterNo, out RecordCount);
        }

        /// <summary>
        /// 返回复检人员信息
        /// </summary>
        /// <param name="pageIndex">页号</param>
        /// <param name="pageSize">页面大小</param>
        /// <param name="StartDate">开始日期</param>
        /// <param name="EndDate">截止日期</param>       
        /// <param name="RecordCount">总记录数</param>
        /// <returns></returns>
        public IList<RegistrationViewEntity> GetReviews(int pageIndex, int pageSize,
            DateTime StartDate, DateTime EndDate, out int RecordCount) {
                return DataAccess.GetReviews(pageIndex, pageSize, StartDate, EndDate,out RecordCount);
        }

        /// <summary>
        /// 获取体检登记数据
        /// </summary>
        /// <param name="PersonID"></param> 
        /// <param name="RegisterNo"></param> 
        /// <returns>体检登记实体</returns>
        public RegistrationViewEntity GetRegistration(string RegisterNo) {
            return DataAccess.GetRegistration(RegisterNo);
        }

        /// <summary>
        /// 保存体检登记数据
        /// </summary>
        /// <param name="Registration">体检登记实体</param>
        public void SaveRegistration(RegistrationViewEntity Registration) {
            CheckPersonEntity PersonInfo = new CheckPersonEntity {
                PersonID = Registration.PersonID,
                Age = Registration.Age,
                Address = Registration.Address,
                Birthday = Registration.Birthday,
                IDNumber = Registration.IDNumber,
                Sex = Registration.Sex,
                Education = Registration.Education,
                LinkTel = Registration.LinkTel,
                EMail = Registration.EMail,
                Job = Registration.Job,
                Nation = Registration.Nation,
                Marriage = Registration.Marriage,
                Name = Registration.Name,
                DeptID = Registration.DeptID,
                Mobile = Registration.Mobile,
                Enabled = true
            };
            using (CheckPersonDataAccess CheckPerson = new CheckPersonDataAccess()) {
                CheckPerson.SaveCheckPerson(PersonInfo);
            }

            RegistrationEntity RegEntity = new RegistrationEntity {
                RegisterNo = Registration.RegisterNo,
                CheckDate = Registration.CheckDate,
                RegisterDate = Registration.RegisterDate,
                IsCheckOver = false,
                PersonID = PersonInfo.PersonID,
                PackageID = Registration.PackageID,
                Enabled = true
            };
            DataAccess.SaveRegistration(RegEntity);
            SaveCheckGroups(RegEntity.RegisterNo, RegEntity.PackageID.Value);
        }

        /// <summary>
        /// 保存复查通知数据
        /// </summary>
        /// <param name="RegisterNo">登记号</param>
        /// <param name="InformResult">通知情况0-未留联系方式、1-未联系到、2-已通知</param>
        /// <param name="InformPerson">通知人</param>
        public void SaveReview(String RegisterNo, String InformResult, String InformPerson) {
            DataAccess.SaveReview(RegisterNo, InformResult, InformPerson);
        }

        /// <summary>
        /// 删除体检登记数据
        /// </summary>
        /// <param name="Registration">体检登记实体</param>
        public void DeleteRegistration(RegistrationViewEntity Registration) {
            RegistrationEntity RegEntity = new RegistrationEntity {
                RegisterNo = Registration.RegisterNo,
                CheckDate = Registration.CheckDate,
                RegisterDate = Registration.RegisterDate,
                IsCheckOver = false,
                PersonID = Registration.PersonID,
                PackageID = Registration.PackageID              
            };
            DataAccess.DeleteRegistration(RegEntity);
            /*using (GroupResultDataAccess GroupResult = new GroupResultDataAccess()) {
                GroupResult.DeleteGroupResults(Registration.RegisterNo);
            }
            using (ItemResultDataAccess ItemResult = new ItemResultDataAccess()) {
                ItemResult.DeleteItemResults(Registration.RegisterNo);
            }*/
        }

        #endregion

        #region 检查结果

        public List<GroupResultViewEntity> GetGroupResults(string RegisterNo) {
            using (GroupResultDataAccess Group = new GroupResultDataAccess()) {
                return Group.GetGroupResults(RegisterNo);
            }
        }

        public List<GroupResultViewEntity> GetGroupResults(string RegisterNo, int DeptID) {
            using (GroupResultDataAccess Group = new GroupResultDataAccess()) {
                return Group.GetGroupResults(RegisterNo, DeptID);
            }
        }

        public GroupResultViewEntity GetGroupResult(string RegisterNo, int GroupID) {
            using (GroupResultDataAccess Group = new GroupResultDataAccess()) {
                return Group.GetGroupResult(RegisterNo, GroupID);
            }
        }

        public void SaveGroupResult(GroupResultEntity GroupResult) {
            using (GroupResultDataAccess Group = new GroupResultDataAccess()) {
                Group.SaveGroupResult(GroupResult);
            }
        }

        public void DeleteGroupResult(GroupResultEntity GroupResult) {
            using (GroupResultDataAccess Group = new GroupResultDataAccess()) {
                Group.DeleteGroupResult(GroupResult);
            }
        }

        public List<ItemResultViewEntity> GetItemResults(string RegisterNo, int GroupID) {
            using (ItemResultBusiness ItemResult = new ItemResultBusiness()) {
                return ItemResult.GetItemResults(RegisterNo, GroupID);
            }
        }

        #endregion

        #region 私有方法

        private void SaveCheckGroups(String RegisterNo, int PackageID) {
            GroupResultDataAccess GroupDataAccess = new GroupResultDataAccess();
            using (PackageBusiness Package = new PackageBusiness()) {
                List<PackageGroupViewEntity> Groups = Package.GetPackageGroups(PackageID);
                foreach (PackageGroupViewEntity Group in Groups) {
                    GroupResultEntity GroupResult = new GroupResultEntity {
                        ID = new GroupResultPK { GroupID = Group.ID.GroupID, RegisterNo = RegisterNo },
                        DeptID = Group.DeptID,
                        IsOver = false,
                        PackageID = PackageID
                    };
                    GroupDataAccess.SaveGroupResult(GroupResult);
                    SaveCheckItems(RegisterNo, Group.ID.GroupID.Value);
                }
            }
        }

        private void SaveCheckItems(String RegisterNo, int GroupID) {
            ItemResultDataAccess ResultDataAccess = new ItemResultDataAccess();
            using (ItemGroupBusiness ItemGroups = new ItemGroupBusiness()) {
                List<ItemGroupDetailViewEntity> Items = ItemGroups.GetItemGroupDetails(GroupID);
                foreach (ItemGroupDetailViewEntity Item in Items) {
                    ItemResultEntity ItemResult = new ItemResultEntity {
                        ID = new ItemResultPK { GroupID = GroupID, ItemID = Item.ID.ItemID, RegisterNo = RegisterNo },
                        DeptID = Item.DeptID
                    };
                    ResultDataAccess.SaveItemResult(ItemResult);
                }
            }
        }

        #endregion
    }
}
