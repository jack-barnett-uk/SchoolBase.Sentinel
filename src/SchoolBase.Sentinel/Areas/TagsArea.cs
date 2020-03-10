using RestSharp;
using SchoolBase.Sentinel.Areas.Base;
using SchoolBase.Sentinel.Attributes;
using SchoolBase.Sentinel.Enums;
using SchoolBase.Sentinel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBase.Sentinel.Areas
{
    [MinimumVersion(2020, 3, 2)]
    public class TagsArea : SchoolBaseArea
    {
        private const string TAGS = "/Tags";
        private const string TAGS_DETAILS = TAGS + "/GetTagDetails";

        public TagsArea(SchoolBaseClient client)
            : base(client)
        {

        }

        public async Task<List<Tag>> GetTagDetails(TagType? type = null)
        {
            return await MakeGetRequest<List<Tag>>(TAGS_DETAILS, new Dictionary<string, object> { { "id", (int?)type } });
        }
    }
}
