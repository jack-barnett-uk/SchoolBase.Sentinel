using System;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolBase.Sentinel.Examples
{
    class Program
    {
        static async Task<int> Main(string[] args)
        {
            var client = SchoolBaseClient.WithTokenAndDomain(args[0], args[1]);

            var pupilTag = await client.School.GetTagTypes();

            Console.WriteLine(pupilTag.FirstOrDefault().description);
            Console.ReadLine();

            return 0;
        }
    }
}
