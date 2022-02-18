using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFActivityMVVM
{
    public class ActivityTrackerModel : INotifyPropertyChanged
    {
        public List<ActivityModel> SavedActivities { get; set; }

        public List<string> ActivityTypes { get; set; }

        public ActivityTrackerModel()
        {
            ActivityTypes = new List<string>();
            SavedActivities = new List<ActivityModel>();
        }

        #region INotifyPropertyChanged Members  

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
