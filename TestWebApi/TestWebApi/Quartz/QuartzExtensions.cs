using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using TestWebApi.Jobs;

namespace TestWebApi.Quartz
{
    public static class QuartzExtensions
    {
        public static void ConfigureQurtz(this IServiceCollection services)
        {
            services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
            services.AddSingleton<IJobFactory, JobFactory>();

            services.AddScoped<JobSample>();
            services.AddScoped<JobSampleTwo>();

            services.AddSingleton(_ => 
            {
                return new TaskInfo(typeof(JobSample), "0 0/1 * * * ?");
            });

            services.AddSingleton(_ =>
            {
                return new TaskInfo(typeof(JobSampleTwo), "0 0/1 * * * ?");
            });

            services.AddHostedService<QuartzHostedService>();
        }
    }
}
