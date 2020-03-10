# SchoolBase.Sentinel
[![NuGet Package](https://img.shields.io/nuget/v/SchoolBase.Sentinel?style=plastic "NuGet Package")](https://www.nuget.org/packages/SchoolBase.Sentinel/ "NuGet Package")

An unofficial .NET API Wrapper for Furlong SchoolBase and Maestro.

## Installation

### NuGet (Stable)
Latest stable builds will be available via NuGet
- [SchoolBase.Sentinel](https://www.nuget.org/packages/SchoolBase.Sentinel/ "SchoolBase.Sentinel")

### GitHub Releases (Unstable)
Unstable releases will include experimental functionality and endpoints available from beta versions of Furlong products.

## Usage
Using SchoolBase.Sentinel is straight forward, the repository contains some examples of using the system however a simple example can be shown below:

```csharp
class Program
{
    static async Task<int> Main(string[] args)
    {
        var client = SchoolBaseClient.WithTokenAndDomain("{API Manager Token}", "{School Domain}");

        var tags = await client.Tags.GetTagDetails();

        Console.WriteLine(tags.FirstOrDefault().Description);
        Console.ReadLine();

        return 0;
    }
}
```
