using SchoolBase.Sentinel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBase.Sentinel.Models
{
    public class Tag
    {
		public int ID { get; set; }
		public string Description { get; set; }
		public int? OwnerID { get; set; }
		public TagType Type { get; set; }
		public string CreationDate { get; set; }
		public string ExpiryDate { get; set; } = null;
		public bool IsDynamic { get; set; }
	}
}
