using System;
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
        /// 删除体检登记数据
        /// </summary>
        /// <param name="Registration">体检登记实体</param>
        public void DeleteRegistration(RegistrationViewEntity Registration) {
            //DataAccess.DeleteRegistration(Registration);
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
