using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quartz;
using LISDataService.Job;
using Quartz.Impl;

namespace LISDataService {

    class Program {
        static void Main(string[] args) {
            GetData();
        }

        internal static void GetData() {
            GetCheckedResultJob job = new GetCheckedResultJob();
            job.run();
        }
    }
}
