using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Examination;
using DataEntity.Examination;
using BusinessLogic.SysConfig;
using DataEntity.SysConfig;
using System.Text.RegularExpressions;
using DataAccess.SysConfig;

namespace BusinessLogic.Examination {

    public class RegistrationBusiness : BaseBusinessLogic<RegistrationDataAccess> {

        #region 构造器

        public RegistrationBusiness() {
        }

        #endregion

        #region 公共方法

        /// <summary>
        /// 返回团体体检未预约数据
        /// </summary>
        /// <param name="pageIndex">页号</param>
        /// <param name="pageSize">页面大小</param>
        /// <param name="RegisterDate">登记日期</param>
        /// <param name="DeptName">体检单位</param>
        /// <param name="RecordCount">总记录数</param>
        /// <returns></returns>
        public List<RegistrationViewEntity> GetAppointments(int pageIndex, int pageSize,
            DateTime? RegisterDate, String DeptName, out int RecordCount) {
            return DataAccess.GetAppointments(pageIndex, pageSize, RegisterDate, DeptName, out RecordCount);
        }

        /// <summary>
        /// 返回团体登记数据
        /// </summary>
        /// <param name="pageIndex">页号</param>
        /// <param name="pageSize">页面大小</param>
        /// <param name="RegisterDate">登记日期</param>
        /// <param name="DeptName">体检单位</param>
        /// <param name="RecordCount">总记录数</param>
        /// <returns></returns>
        public List<RegistrationViewEntity> GetGroupRegistrations(int pageIndex, int pageSize,
            DateTime? RegisterDate, String DeptName, out int RecordCount) {
            return DataAccess.GetGroupRegistrations(pageIndex, pageSize, RegisterDate, DeptName, out RecordCount);
        }
        /// <summary>
        ///获取所有体检登记数据
        /// </summary>
        public List<RegistrationViewEntity> GetRegistrations(int pageIndex, int pageSize,
            DateTime? RegisterDate, String DeptName, String RegisterNo, out int RecordCount) {
            return DataAccess.GetRegistrations(pageIndex, pageSize, RegisterDate, DeptName,
            RegisterNo, out RecordCount);
        }


        /// <summary>
        ///获取某天或体检单位的所有体检登记数据
        /// </summary>
        public List<RegistrationViewEntity> GetRegistrationForReport(DateTime? RegisterDate, String DeptName) {
            return DataAccess.GetRegistrationForReport(RegisterDate, DeptName);
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
            List<String> Items, Summary;
            foreach (RegistrationViewEntity Register in List) {
                Items = GroupDataAccess.GetUncheckedGroup(Register.RegisterNo);
                Summary = GroupDataAccess.GetGroupSummary(Register.RegisterNo);
                Register.UncheckedItems = String.Join(";", Items.ToArray());
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
            return DataAccess.GetReviews(pageIndex, pageSize, StartDate, EndDate, out RecordCount);
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
        /// 获取总检数据
        /// </summary>
        /// <param name="RegisterNo"></param>
        /// <returns></returns>
        public RegistrationViewEntity GetOverall(string RegisterNo) {
            RegistrationViewEntity Result = DataAccess.GetRegistration(RegisterNo);
            using (GroupResultDataAccess Group = new GroupResultDataAccess()) {
                //Result.Summary=  String.Join(Environment.NewLine, Group.GetGroupSummary(RegisterNo).ToArray());
                Result.Summary = String.Join(Environment.NewLine, Group.GetGroupSummary(RegisterNo).ToArray());
            }
            return Result;
        }

        /// <summary>
        /// 保存体检登记数据
        /// </summary>
        /// <param name="Registration">体检登记实体</param>
        public void SaveRegistration(RegistrationViewEntity Registration) {
            CheckPersonEntity PersonInfo = new CheckPersonEntity {
                PersonID = Registration.PersonID,
                Age = Registration.Age.HasValue ? Registration.Age : GetAgeByIDNumber(Registration.IDNumber),
                Address = Registration.Address,
                Birthday = Registration.Birthday.HasValue ? Registration.Birthday : GetBirthdayByIDNumber(Registration.IDNumber),
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
                Photo = Registration.Photo
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
                PackageID = Registration.PackageID
            };
            DataAccess.SaveRegistration(RegEntity);
            SaveCheckedGroups(RegEntity.RegisterNo, Registration.PackageID.Value, Registration.Groups);
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

        public void SaveOverallChecked(RegistrationEntity OverallChecked) {
            DataAccess.SaveRegistration(OverallChecked);
        }

        /// <summary>
        /// 删除体检登记数据
        /// </summary>
        /// <param name="Registration">体检登记实体</param>
        public void DeleteRegistration(String RegisterNo) {
            DataAccess.DeleteRegistration(RegisterNo);
            /*using (GroupResultDataAccess GroupResult = new GroupResultDataAccess()) {
                GroupResult.DeleteGroupResults(Registration.RegisterNo);
            }
            using (ItemResultDataAccess ItemResult = new ItemResultDataAccess()) {
                ItemResult.DeleteItemResults(Registration.RegisterNo);
            }*/
        }

        /// <summary>
        /// 保存批量体检结果
        /// </summary>
        /// <param name="RegisterNo">登记号</param>
        /// <param name="OverallDate">总检日期</param>
        /// <param name="OverallDoctor">总检医生</param>
        /// <param name="Summary">综述</param>
        /// <param name="Recommend">体检建议</param>
        /// <param name="Conclusion">体检结论</param>
        public void SaveOverall(String RegisterNo, DateTime OverallDate, String OverallDoctor, String Summary,
                                String Recommend, String Conclusion) {
            DataAccess.SaveOverall(RegisterNo, OverallDate, OverallDoctor, Summary, Recommend, Conclusion);
        }

        /// <summary>
        /// 体检预约
        /// </summary>
        /// <param name="RegisterNo">档案号</param>
        /// <param name="CheckDate">预约体检日期</param>
        public void SaveCheckAppointment(String RegisterNo, DateTime CheckDate) {
            DataAccess.SaveCheckAppointment(RegisterNo, CheckDate);
        }

        /// <summary>
        /// 撤销总检
        /// </summary>
        /// <param name="RegisterNo">登记号</param>
        /// <param name="Doctor">总检医生</param>
        /// <returns></returns>
        public int CancelOverallCheck(String RegisterNo, String Doctor) {
            return DataAccess.CancelOverallCheck(RegisterNo, Doctor);
        }

        #endregion

        #region 检查项

        /// <summary>
        /// 返回体检人员检查组合项
        /// </summary>
        /// <param name="RegisterNo"></param>
        /// <returns></returns>
        public List<ItemGroupViewEntity> GetCheckedGroups(String RegisterNo) {
            ItemGroupBusiness ItemGroup = new ItemGroupBusiness();
            GroupResultDataAccess GroupResult = new GroupResultDataAccess();
            var q = from a in ItemGroup.GetItemGroups()
                    join b in GroupResult.GetGroupResults(RegisterNo) on a.GroupID equals b.ID.GroupID
                    select a;
            return q.ToList();
        }

        public void DeleteCheckedGroup(String RegisterNo, int GroupID) {
            using (GroupResultDataAccess Group = new GroupResultDataAccess()) {
                Group.DeleteCheckedGroup(RegisterNo, GroupID);
            }
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
                SaveCheckItems(GroupResult.ID.RegisterNo, GroupResult.ID.GroupID);
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

        private void SaveCheckedGroups(String RegisterNo, int PackageID, List<int> ItemGroups) {
            //自定义套餐保存体检组合项
            if ((ItemGroups != null) && (ItemGroups.Count > 0)) {
                SaveCheckedGroups(RegisterNo, ItemGroups);
                return;
            }
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
                    SaveCheckItems(RegisterNo, Group.ID.GroupID);
                }
            }
        }

        private void SaveCheckedGroups(String RegisterNo, List<int> Groups) {
            ItemGroupDataAccess ItemGroupDA = new ItemGroupDataAccess();
            ItemGroupViewEntity ItemGroup;
            using (GroupResultDataAccess GroupDataAccess = new GroupResultDataAccess()) {
                foreach (int GroupID in Groups) {
                    ItemGroup = ItemGroupDA.GetItemGroup(GroupID);
                    GroupResultEntity GroupResult = new GroupResultEntity {
                        ID = new GroupResultPK { GroupID = GroupID, RegisterNo = RegisterNo },
                        DeptID = ItemGroup.DeptID,
                        IsOver = false,
                        PackageID = -1
                    };
                    GroupDataAccess.SaveGroupResult(GroupResult);
                    SaveCheckItems(RegisterNo, GroupID);
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

        /// <summary>
        /// 根据身份证号计算年龄
        /// </summary>
        /// <param name="IDNumber"></param>
        /// <returns></returns>
        private int? GetAgeByIDNumber(String IDNumber) {
            if (String.IsNullOrEmpty(IDNumber)) return null;
            Regex regex = new Regex(@"/(^\d{15}$)|(^\d{18}$)|(^\d{17}(\d|X|x)$)/");
            if (!regex.IsMatch(IDNumber)) return null;
            int CurrentYear = DateTime.Now.Year;
            int BirthYear = Convert.ToInt32(IDNumber.Substring(6, 4));
            return CurrentYear - BirthYear;
        }

        /// <summary>
        /// 根据身份证号计算出生日期
        /// </summary>
        /// <param name="IDNumber"></param>
        /// <returns></returns>
        private DateTime? GetBirthdayByIDNumber(String IDNumber) {
            if (String.IsNullOrEmpty(IDNumber)) return null;
            Regex regex = new Regex(@"/(^\d{15}$)|(^\d{18}$)|(^\d{17}(\d|X|x)$)/");
            if (!regex.IsMatch(IDNumber)) return null;
            int Year = Convert.ToInt32(IDNumber.Substring(6, 4));
            int Month = Convert.ToInt32(IDNumber.Substring(10, 2));
            int Day = Convert.ToInt32(IDNumber.Substring(12, 2));
            return new DateTime(Year, Month, Day);
        }

        #endregion
    }
}
