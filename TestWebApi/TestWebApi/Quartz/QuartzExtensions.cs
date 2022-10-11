namespace TestWebApi.Quartz
{
    public static class QuartzExtensions
    {
        public static void ConfigureQurtz(this IServiceCollection services)
        {
            services.AddSingleton<I>;
        }
    }
}
