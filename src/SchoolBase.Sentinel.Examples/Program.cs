using System;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolBase.Sentinel.Examples
{
    class Program
    {
        static async Task<int> Main(string[] args)
        {
            var client = SchoolBaseClient.WithTokenAndDomain("", "");

            var activities = await client.Activities.GetEventDetailsList();

            Console.WriteLine(activities.FirstOrDefault().EventName);
            Console.ReadLine();

            return 0;
        }
    }
}
