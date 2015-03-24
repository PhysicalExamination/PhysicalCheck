using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DataEntity.Examination {

    [DataContract]
    public class RegisterTreeData {

        public RegisterTreeData() {
        }

        [DataMember(Name = "id")]
        public String GroupID {
            get;
            set;
        }

        [DataMember(Name = "text")]
        public String GroupName {
            get;
            set;
        }

        [DataMember(Name = "children")]
        public List<RegisterTreeData> CheckedGroups {
            get;
            set;
        }
    }
}
