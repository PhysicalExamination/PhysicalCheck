using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LISDataService{

    /// <summary>
    /// 实体类:LisEntity
    /// 文件名:LisEntity.cs
    /// 说  明:LIS接口实体
    /// </summary>
    public class LisEntity {

        /// <summary>
        /// 体检登记号
        /// </summary>
        public String RegisterNo {
            get;
            set;
        }

        /// <summary>
        /// 体检组合项编号
        /// </summary>
        public String GroupID {
            get;
            set;
        }

        /// <summary>
        /// 体检组合项名称
        /// </summary>
        public String GroupName {
            get;
            set;
        }

        /// <summary>
        /// 体检明细项编号
        /// </summary>
        public String ItemID {
            get;
            set;
        }

        /// <summary>
        /// 体检明细项名称
        /// </summary>
        public String ItemName {
            get;
            set;
        }

        /// <summary>
        /// 定量结果
        /// </summary>
        public String QuantitativeResult {
            get;
            set;
        }

        /// <summary>
        /// 定性结果
        /// </summary>
        public String QualitativeResult {
            get;
            set;
        }

        /// <summary>
        /// 体检明细项参考值
        /// </summary>
        public String Reference {
            get;
            set;
        }

        /// <summary>
        /// 体检明细项单位
        /// </summary>
        public String MeasureUnit {
            get;
            set;
        }

        /// <summary>
        /// 检验人员
        /// </summary>
        public String InspectionPerson {
            get;
            set;
        }

        /// <summary>
        /// 审核人员
        /// </summary>
        public String CheckPerson {
            get;
            set;
        }
    }
}
