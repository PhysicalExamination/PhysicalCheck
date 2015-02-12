using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quartz;
using LISDataService.Job;
using Quartz.Impl;
using System.ServiceProcess;
using log4net;

namespace LISDataService {

    class Program {

        static void Main(string[] args)
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
            { 
                new LISDataService() 
            };
            ServiceBase.Run(ServicesToRun);
            LISDataService s = new LISDataService();

           // GetData();
        }

        internal static void GetData() {
            GetCheckedResultJob job = new GetCheckedResultJob();
            job.run();
        }
    }
}
