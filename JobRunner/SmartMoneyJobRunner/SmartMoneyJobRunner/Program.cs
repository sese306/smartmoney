using System;
using System.IO;
using System.Reactive.Linq;

namespace SmartMoneyJobRunner
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SetDataDirectory();
            RunJobs();
            Console.ReadLine();
        }

        private static void RunJobs()
        {
            Observable.Timer(DateTimeOffset.Now, TimeSpan.FromSeconds(2))
                .Do(timeStamp => new DetectPOI().Run())
                .Subscribe();
            Observable.Timer(DateTimeOffset.Now, TimeSpan.FromSeconds(2))
                .Do(timeStamp => new EstimateExpenses().Run())
                .Subscribe();
        }

        private static void SetDataDirectory()
        {
            var executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var path = Path.GetDirectoryName(executable);
            var dataDirectoryPath = Path.Combine(path, "../../../../../WebApi/test/App_Data");
            dataDirectoryPath = Path.GetFullPath((new Uri(dataDirectoryPath)).LocalPath);
            AppDomain.CurrentDomain.SetData("DataDirectory", dataDirectoryPath);
        }
    }
}
