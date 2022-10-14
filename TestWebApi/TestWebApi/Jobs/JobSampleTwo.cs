﻿using Quartz;

namespace TestWebApi.Jobs
{
    /// <summary>
    /// Job1
    /// </summary>
    public class JobSample : IJob
    {
        /// <summary>
        ///  Execute Job1 Description
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public Task Execute(IJobExecutionContext context)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"JOB1 RUN {DateTime.Now}");
            });
        }
    }
}
