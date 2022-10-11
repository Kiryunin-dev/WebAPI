namespace TestWebApi.Quartz
{
    public class TaskInfo
    {
        public TaskInfo(Type jobType, string extension)
        {
            JobType = jobType;
            Extension = extension;
        }

        public Type JobType { get; set; }
        public string Extension { get; set; }
    }
}
