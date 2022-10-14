using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Spi;

namespace TestWebApi.Quartz
{
    public class JobFactory : IJobFactory
    {
        IServiceScopeFactory serviceScopeFactory;

        public JobFactory(IServiceScopeFactory _serviceScopeFactory)
        {
            serviceScopeFactory = _serviceScopeFactory;
        }

        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            using (var scope = serviceScopeFactory.CreateScope())
            {
                var job = scope.ServiceProvider.GetService(bundle.JobDetail.JobType) as IJob;
                return job;
            }
        }

        public void ReturnJob(IJob job)
        {
            
        }
    }
}
