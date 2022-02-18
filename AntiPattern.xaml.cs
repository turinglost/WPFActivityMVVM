using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFActivityMVVM
{
    /// <summary>
    /// Interaction logic for AntiPattern.xaml
    /// </summary>
    public partial class AntiPattern : Window
    {
        public int ActivityCount { get; set; }
        public ActivityModel LastActivity { get; set; }
        public List<ActivityModel> SavedActivities { get; set; }

        public List<string> ActivityTypes { get; set; }

        public AntiPattern()
        {
            InitializeComponent();
            SavedActivities = new List<ActivityModel>();
            ActivityTypes = new List<string>();
            ActivityTypes.Add("Snowboarding");
            ActivityTypes.Add("Biking");
            ActivityTypes.Add("Walking");

            ActivityModel activity = new ActivityModel();
            activity.ActivityType = "Running";
            activity.ActivityStarted = new DateTime(2021, 11, 3, 14, 41, 0);
            activity.ActivityDurationMinutes = 15;
            AddActivity(activity);
            SetupActivityDropDown();
        }

        protected void AddActivity(ActivityModel item)
        {
            SavedActivities.Add(item);
            ActivityCount++;
            LastActivity = item;
        }

        protected void SetupActivityDropDown()
        {
            cmbActivityOptions.Items.Clear();
            foreach (string s in ActivityTypes)
            {
                cmbActivityOptions.Items.Add(s);
            }
        }

        private void btnAddActivity_Click(object sender, RoutedEventArgs e)
        {
            ActivityModel activity = new ActivityModel();
            activity.ActivityStarted = dtActivity.DisplayDate;
            activity.ActivityType = cmbActivityOptions.Text;
            activity.ActivityDurationMinutes = int.Parse(txtDuration.Text);
            AddActivity(activity);
            lblActivityCount.Content = ActivityCount;
            lblLastActivity.Content = LastActivity.ActivityType;

        }

        private void btnAddActivityType_Click(object sender, RoutedEventArgs e)
        {
            // Bug - doesn't keep the ActivityTypes property synced with the combo box.
            cmbActivityOptions.Items.Add(txtNewActivityType.Text);
            txtNewActivityType.Text = string.Empty;
        }
    }
}
