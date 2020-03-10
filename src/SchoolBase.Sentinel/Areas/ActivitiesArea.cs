using SchoolBase.Sentinel.Areas.Base;
using System.Collections.Generic;
using SchoolBase.Sentinel.Models;
using System.Threading.Tasks;
using SchoolBase.Sentinel.Attributes;

namespace SchoolBase.Sentinel.Areas
{
    [MinimumVersion(2020, 02, 2)]
    public class ActivitiesArea : SchoolBaseArea
    {
        private const string ACTIVITIES = "/Activities";
        private const string ACTIVITIES_BASIC_DETAILS = ACTIVITIES + "/GetActivitiesBasicDetailsList";
        private const string ACTIVITIES_EVENT_DETAILS = ACTIVITIES + "/GetEventDetailsList";

        public ActivitiesArea(SchoolBaseClient client) 
            : base(client)
        {}

        public async Task<List<ActivityBasicDetails>> GetBasicDetails(params int[] groupIds)
        {
            return await MakePostRequest<List<ActivityBasicDetails>>(ACTIVITIES_BASIC_DETAILS, new Dictionary<string, object>() {
                { "groupId", groupIds }
            });
        }

        public async Task<List<EventDetails>> GetEventDetailsList(int? eventId = null)
        {
            return await MakePostRequest<List<EventDetails>>(ACTIVITIES_EVENT_DETAILS, new Dictionary<string, object>() {
                { "EventId", eventId }
            });
        }
    }
}
