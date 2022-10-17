using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using TestWebApi.Jobs;

namespace TestWebApi.Quartz
{
    using Microsoft.Extensions.DependencyInjection;
    using TestWebApi.Common.Configurations;

    public static class QuartzExtensions
    {
        public static void ConfigureQuartz(this IServiceCollection services, IConfiguration config)
        {
            var setiings = config.GetSection("SchedulerConfig").Get<SchedulerConfig>();

            services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
            services.AddSingleton<IJobFactory, JobFactory>();

            services.AddScoped<JobSample>();
            services.AddScoped<JobSampleTwo>();

            services.AddSingleton(_ => 
            {
                return new TaskInfo(typeof(JobSample), setiings.JobExtension);
            });

            services.AddSingleton(_ =>
            {
                return new TaskInfo(typeof(JobSampleTwo), setiings.JobTwoExtension);
            });

            services.AddHostedService<QuartzHostedService>();
        }
    }
}
