using SchoolBase.Sentinel.Areas.Base;
using SchoolBase.Sentinel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBase.Sentinel.Areas
{
    public class SchoolArea : SchoolBaseArea
    {
        private const string SCHOOL = "/School";
        private const string SCHOOL_REF = SCHOOL + "/ReferenceData";
        private const string SCHOOL_REF_TAGTYPES = SCHOOL_REF + "/TagType";

        public SchoolArea(SchoolBaseClient client)
            : base(client)
        {
            _endpointVersions.Add(SCHOOL_REF_TAGTYPES, new Version(2020, 3, 1));
        }

        public async Task<List<ReferenceData>> GetTagTypes()
        {
            return await MakeGetRequest<List<ReferenceData>>(SCHOOL_REF_TAGTYPES);
        }
    }
}
