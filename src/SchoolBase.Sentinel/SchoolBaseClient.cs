using HtmlAgilityPack;
using RestSharp;
using SchoolBase.Sentinel.Areas;
using SchoolBase.Sentinel.Areas.Base;
using System;

namespace SchoolBase.Sentinel
{
    public class SchoolBaseClient : RestClient
    {
        private const string SCHOOLBASE_LOGIN_URL = "/Logon";
        private const string SCHOOLBASE_API_URL = "/api/Public";

        private readonly Version SENTINEL_SUPPORTED_VERSION = new Version(2020, 2, 2);
        private string _sbInstallURL = "https://schoolbase.online";
        private string _token;
        private string _domain;

        /* Useful Utilities */
        public bool IsSupported => SENTINEL_SUPPORTED_VERSION == GetSBVersion();

        /* Areas of the SB API */
        public ActivitiesArea Activities;

        public SchoolBaseClient(string urlOverride = "https://schoolbase.online")
        {
            BaseUrl = new Uri(urlOverride + SCHOOLBASE_API_URL);
            _sbInstallURL = urlOverride;

            Activities = new ActivitiesArea(this);
        }

        public static SchoolBaseClient WithTokenAndDomain(string token, string domain, string urlOverride = "https://schoolbase.online")
        {
            // new client with the override if provided.
            var client = new SchoolBaseClient(urlOverride);

            // Set the token and domain.
            client.SetToken(token);
            client.SetDomain(domain);

            return client;
        }

        public void SetToken(string token)
        {
            _token = token;
            DefaultParameters.Add(new Parameter("x-schoolbase-token", _token, ParameterType.HttpHeader));
        }
        public void SetDomain(string domain)
        {
            _domain = domain;
            DefaultParameters.Add(new Parameter("x-schoolbase-domain", _domain, ParameterType.HttpHeader));
        }



        /// <summary>
        /// Get the version details from the currently connected SB Version
        /// </summary>
        /// <returns></returns>
        /// <remarks>Currently works by requesting the login page of SBO, this will eventually be changed to use the API to retrieve version numbers.</remarks>
        internal Version GetSBVersion()
        {
            // HACK: This isnt great, but we need a way to make sure stuff isnt out of sync.

            // Get the page content of the homepage.
            var htmlDocument = new HtmlWeb();
            var document = htmlDocument.Load(_sbInstallURL + SCHOOLBASE_LOGIN_URL);

            // Grab the version element and remove random newlines...
            var versionElement = document.GetElementbyId("VersionSpan");
            var versionContent = versionElement.InnerText.Replace("\r", "").Replace("\n", " ");

            var buildStartIndex = versionContent.IndexOf("Build:");
            
            // SBO Version: 2020.MM.I
            var sbVersionString = versionContent.Substring(0, buildStartIndex);

            // Should return: ["SBO Version", " 2020.MM.I"]
            var splitVersionString = sbVersionString.Split(':');

            // Sanity check the expected otucome.
            if(splitVersionString.Length > 2)
            {
                throw new Exception($"SB Version in incorrect format: {sbVersionString}");
            }

            // Trim the extra whitespace we've got. (2020.MM.I)
            var trimmedVersion = splitVersionString[1].Trim();

            return GetSBVersionFromString(trimmedVersion);
        }

        private Version GetSBVersionFromString(string sbVersionString)
        {
            // [2020, 02.1]
            var splitByYear = sbVersionString.Split('-');

            if (splitByYear.Length != 2)
            {
                throw new Exception($"SB Version in incorrect format: {sbVersionString}");
            }

            var year = int.Parse(splitByYear[0]);

            // [02, 1]
            var splitByMonth = splitByYear[1].Split('.');

            if (splitByMonth.Length != 2)
            {
                                throw new Exception($"SB Version in incorrect format: {sbVersionString}");
            }

            var month = int.Parse(splitByMonth[0]);
            var iteration = int.Parse(splitByMonth[1]);

            return new Version(year, month, iteration);
        }
    }
}
