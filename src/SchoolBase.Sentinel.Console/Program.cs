using System.Linq;
using System.Threading.Tasks;

namespace SchoolBase.Sentinel.Console
{
    class Program
    {
        static async Task<int> Main(string[] args)
        {
            var client = SchoolBaseClient.WithTokenAndDomain("", "");

            var activities = await client.Activities.GetEventDetailsList();

            System.Console.WriteLine(activities.FirstOrDefault().EventName);
            System.Console.ReadLine();

            return 0;
        }
    }
}
