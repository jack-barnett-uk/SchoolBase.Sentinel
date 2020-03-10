using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBase.Sentinel.Models
{
    public class ActivityBasicDetails
    {
        public int GroupID { get; set; }
        public string ActivityName { get; set; }
        public string Subject { get; set; }
        public string Room { get; set; }
        public string Staff { get; set; }
        public string Day { get; set; }
        public string AcademicYear { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int RoomCapacity { get; set; }
        public int PupilsInGroup { get; set; }
        public int RoomId { get; set; }
        public int GroupStart { get; set; }
        public int GroupEnd { get; set; }
        public int StaffId { get; set; }
        public string StaffFirstName { get; set; }
        public string StaffLastName { get; set; }
    }
}
