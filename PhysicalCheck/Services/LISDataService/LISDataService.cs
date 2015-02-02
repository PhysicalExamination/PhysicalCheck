﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using Quartz;
using Quartz.Impl;
using LISDataService.Job;

namespace LISDataService {

    partial class LISDataService : ServiceBase {

        IScheduler m_Scheduler;

        public LISDataService() {
            InitializeComponent();
            ISchedulerFactory sf = new StdSchedulerFactory();
            m_Scheduler = sf.GetScheduler();
            BuildJob();		
        }

        protected override void OnStart(string[] args) {
            base.OnStart(args);
            m_Scheduler.Start();
        }

        protected override void OnStop() {
            m_Scheduler.Shutdown();	
        }

        internal void BuildJob() {
            DateTimeOffset date = DateTime.Now;          
            IJobDetail job;          
            ICronTrigger trigger;


            job = JobBuilder.Create<GetCheckedResultJob>()
                    .WithIdentity("GetCheckedResultJob", "GetCheckedResultJobGroup")
                    .Build();

            //每小时执行一次
            trigger = (ICronTrigger)TriggerBuilder.Create()
                      .WithIdentity("GetCheckedResultJobTrigger", "GetCheckedResultJobTriggerGroup")                    
                      .WithCronSchedule("0 0/10 * * * ?")
                      .Build();
            m_Scheduler.ScheduleJob(job, trigger);            
        }
    }
}