using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity.Examination {

    /// <summary>
    /// 实体类:RegistrationViewEntity
    /// 文件名:RegistrationViewEntity.cs
    /// 说  明:体检登记
    public class RegistrationViewEntity : BaseEntity<RegistrationViewEntity> {

        #region 构造方法

        public RegistrationViewEntity() {
        }

        #endregion

        #region 属性

        /// <summary>
        /// 体检人
        /// </summary>		
        public virtual int? PersonID {
            get;
            set;
        }

        /// <summary>
        /// 登记号
        /// </summary>		
        public virtual string RegisterNo {
            get;
            set;
        }

        /// <summary>
        /// 登记日期
        /// </summary>		
        public virtual DateTime? RegisterDate {
            get;
            set;
        }

        /// <summary>
        /// 套餐编码
        /// </summary>		
        public virtual int? PackageID {
            get;
            set;
        }

        /// <summary>
        /// 套餐名称
        /// </summary>
        public virtual String PackageName {
            get;
            set;
        }

        /// <summary>
        /// 体检日期
        /// </summary>		
        public virtual DateTime? CheckDate {
            get;
            set;
        }

        /// <summary>
        /// 体检综述
        /// </summary>		
        public virtual string Summary {
            get;
            set;
        }

        /// <summary>
        /// 医生建议
        /// </summary>		
        public virtual string Recommend {
            get;
            set;
        }

        /// <summary>
        /// 总检医生
        /// </summary>		
        public virtual string OverallDoctor {
            get;
            set;
        }

        /// <summary>
        /// 总检日期
        /// </summary>		
        public virtual DateTime? OverallDate {
            get;
            set;
        }

        /// <summary>
        /// 总检结论
        /// </summary>		
        public virtual string Conclusion {
            get;
            set;
        }

        /// <summary>
        /// 办理健康证条件
        /// </summary>		
        public virtual string HealthCondition {
            get;
            set;
        }

        /// <summary>
        /// 职业能力评定
        /// </summary>		
        public virtual string EvaluateResult {
            get;
            set;
        }

        /// <summary>
        /// 体检是否结束
        /// </summary>		
        public virtual bool IsCheckOver {
            get;
            set;
        }

        /// <summary>
        /// 体检报告打印日期
        /// </summary>		
        public virtual DateTime? PrintDate {
            get;
            set;
        }

        /// <summary>
        /// 复查日期
        /// </summary>
        public virtual DateTime? ReviewDate {
            get;
            set;
        }

        /// <summary>
        /// 复查概要
        /// </summary>
        public virtual String ReviewSummary {
            get;
            set;
        }

        /// <summary>
        /// 通知人
        /// </summary>
        public virtual String InformPerson {
            get;
            set;
        }

        /// <summary>
        /// 通知情况
        /// </summary>
        public virtual String InformResult {
            get;
            set;
        }

        /// <summary>
        /// 是否启用
        /// </summary>		
        public virtual bool? Enabled {
            get;
            set;
        }

        public virtual String UncheckedItems {
            get;
            set;
        }

        /// <summary>
        /// 自定义套餐组合项集合
        /// </summary>
        public virtual List<int> Groups {
            get;
            set;
        }

        #endregion

        #region 个人信息
        
        /// <summary>
        /// 姓名
        /// </summary>		
        public virtual string Name {
            get;
            set;
        }

        /// <summary>
        /// 性别
        /// </summary>		
        public virtual string Sex {
            get;
            set;
        }

        /// <summary>
        /// 身份证号
        /// </summary>		
        public virtual string IDNumber {
            get;
            set;
        }

        /// <summary>
        /// 出生日期
        /// </summary>		
        public virtual DateTime? Birthday {
            get;
            set;
        }

        /// <summary>
        /// 年龄
        /// </summary>		
        public virtual int? Age {
            get;
            set;
        }

        /// <summary>
        /// 工作单位
        /// </summary>		
        public virtual int? DeptID {
            get;
            set;
        }

        /// <summary>
        /// 工作单位名称
        /// </summary>		
        public virtual string DeptName {
            get;
            set;
        }

        /// <summary>
        /// 婚姻
        /// </summary>		
        public virtual string Marriage {
            get;
            set;
        }

        /// <summary>
        /// 职业
        /// </summary>		
        public virtual string Job {
            get;
            set;
        }

        /// <summary>
        /// 学历
        /// </summary>		
        public virtual string Education {
            get;
            set;
        }

        /// <summary>
        /// 民族
        /// </summary>		
        public virtual string Nation {
            get;
            set;
        }

        /// <summary>
        /// 联系电话
        /// </summary>		
        public virtual string LinkTel {
            get;
            set;
        }

        /// <summary>
        /// 联系地址
        /// </summary>		
        public virtual string Address {
            get;
            set;
        }

        /// <summary>
        /// 手机
        /// </summary>		
        public virtual string Mobile {
            get;
            set;
        }

        /// <summary>
        /// 电子邮件
        /// </summary>		
        public virtual string EMail {
            get;
            set;
        }

        /// <summary>
        /// 个人照片
        /// </summary>
        public virtual String Photo {
            get;
            set;
        }


        /// <summary>
        /// 工种
        /// </summary>
        public virtual String TradeCode {
            get;
            set;
        }

        /// <summary>
        /// 行业
        /// </summary>
        public virtual int? IndustryID {
            get;
            set;
        }

        /// <summary>
        /// 所属地区
        /// </summary>
        public virtual String RegionCode {
            get;
            set;
        }
        #endregion
    }
}
