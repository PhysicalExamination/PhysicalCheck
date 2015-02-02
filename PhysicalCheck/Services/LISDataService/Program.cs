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
            IScheduler m_Scheduler;
            IJobDetail job;
            ICronTrigger trigger;

            ISchedulerFactory sf = new StdSchedulerFactory();
            m_Scheduler = sf.GetScheduler();

            job = JobBuilder.Create<GetCheckedResultJob>()
                    .WithIdentity("GetCheckedResultJob", "GetCheckedResultJobGroup")
                    .Build();

            //每小时执行一次
            trigger = (ICronTrigger)TriggerBuilder.Create()
                      .WithIdentity("GetCheckedResultJobTrigger", "GetCheckedResultJobTriggerGroup")
                      .WithCronSchedule("0 0/10 * * * ?")
                      .Build();
            m_Scheduler.ScheduleJob(job, trigger);
            m_Scheduler.Start();
        }
    }
}
