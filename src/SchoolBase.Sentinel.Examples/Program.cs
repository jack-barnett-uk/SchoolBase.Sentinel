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

            var tags = await client.Tags.GetTagDetails();

            Console.WriteLine(tags.FirstOrDefault().Description);
            Console.ReadLine();

            return 0;
        }
    }
}
