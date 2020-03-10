using RestSharp;
using SchoolBase.Sentinel.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBase.Sentinel.Areas.Base
{
    public class SchoolBaseArea
    {
        internal SchoolBaseClient _client;

        public SchoolBaseArea(SchoolBaseClient client)
        {
            _client = client;
        }

        internal async Task<T> MakePostRequest<T>(string endpoint, Dictionary<string, object> parameters)
        {
            return await MakeRequest<T>(endpoint, Method.POST, parameters);
        }

        internal async Task<T> MakeRequest<T>(string endpoint, Method method, Dictionary<string, object> parameters)
        {
            // Do the version check.

            if(AvailableInAreaVersion())
            {
                var request = new RestRequest(endpoint, method);

                foreach (var parameter in parameters)
                {
                    request.AddParameter(parameter.Key, parameter.Value);
                }

                var response = await _client.ExecuteAsync<T>(request);

                return response.Data;
            }

            return default;
        }

        private bool AvailableInAreaVersion()
        {
            // If there is no attribute, assume its available for everything.
            if (!(Attribute.GetCustomAttribute(GetType(), typeof(MinimumVersionAttribute)) is MinimumVersionAttribute attribute))
            {
                return true;
            }

            var annotatedVersion = attribute.Version;
            var connectedVersion = _client.GetSBVersion();

            return connectedVersion > annotatedVersion;
        }
    }
}
