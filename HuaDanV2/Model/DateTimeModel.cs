using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HuaDan.Model
{
	public class DateTimeModel
	{
		public DateTimeModel()
		{
			StartTime = string.Empty;
			EndTime = string.Empty;
			CanBieUID = string.Empty;
		}
		public string StartTime { get; set; }
		public string EndTime { get; set; }
		public string CanBieUID { get; set; }
	}
}
