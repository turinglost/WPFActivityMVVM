using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFActivityMVVM
{
    public class ActivityModel
    {
        public ActivityModel()
        {

        }
        public DateTime ActivityStarted { get; set; }
        public int ActivityDurationMinutes { get; set; }
        public string ActivityType { get; set; }
        public string ActivityComments { get; set; }
    }
}
