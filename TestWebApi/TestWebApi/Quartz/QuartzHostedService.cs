using Quartz;
using Quartz.Spi;

namespace TestWebApi.Quartz
{
    public class QuartzHostedService: IHostedService
    {
        private readonly IJobFactory jobFactory;
        private readonly ISchedulerFactory schedulerFactory;
        private readonly IEnumerable<TaskInfo> tasksInfo;

        public QuartzHostedService(IJobFactory jobFactory, ISchedulerFactory schedulerFactory, IEnumerable<TaskInfo> tasksInfo)
        {
            this.jobFactory = jobFactory;
            this.schedulerFactory = schedulerFactory;
            this.tasksInfo = tasksInfo;
        }

        private IScheduler scheduler;

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            scheduler = await schedulerFactory.GetScheduler(cancellationToken);

            scheduler.JobFactory = jobFactory;

            foreach (var info in tasksInfo)
            {
                var job = CreateJob(info);
                var trigger = CreateTrigger(info);

                await scheduler.ScheduleJob(job, trigger);
            }

            await scheduler.Start(cancellationToken);
        }

        public IJobDetail CreateJob(TaskInfo info)
        {
            return JobBuilder
                .Create(info.JobType)
                .WithDescription("Test job Sample")
                .WithIdentity(info.JobType.Name)
                .Build();     
        }

        public ITrigger CreateTrigger(TaskInfo info)
        {
            return TriggerBuilder
                .Create()
                .WithCronSchedule(info.Extension)
                .WithDescription("Test trigger Sample")
                .WithIdentity(info.JobType.Name)
                .Build();
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await scheduler.Shutdown(cancellationToken);
        }
    }
}
