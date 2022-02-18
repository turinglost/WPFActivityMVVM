using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPFActivityMVVM.MVVM
{
    internal class ActivityViewModel : INotifyPropertyChanged
    {
        // Fields used for input
        public int EntryDurationInMinutes { get; set; }
        public DateTime EntryActivityStart { get; set; }
        public string EntryActivityType { get; set; }

        // Display fields
        public ActivityModel LastActivity
        {
            get
            {
                return _model.SavedActivities.OrderByDescending(m => m.ActivityStarted)
                .First<ActivityModel>(); ;
            }
        }
        public List<string> ActivityTypes
        {
            get { return _model.ActivityTypes; }
            set { _model.ActivityTypes = value; }
        }

        public int ActivityCount { get { return _model.SavedActivities.Count; } }

        private ActivityTrackerModel _model;

        public ActivityViewModel()
        {
            _model = new ActivityTrackerModel();

            //Set up some data since we don't have a database.
            ActivityModel act = new ActivityModel();
            act.ActivityType = "Biking";
            act.ActivityDurationMinutes = 40;
            act.ActivityStarted = new DateTime(2021, 11, 3, 14, 41, 0);
            _model.SavedActivities.Add(act);
            _model.ActivityTypes.Add("Biking");
            _model.ActivityTypes.Add("Swimming");
            _model.ActivityTypes.Add("Running");

            EntryActivityStart = DateTime.Now;
        }



        #region Commands
        private ICommand _addActivityType;
        private ICommand _addFullActivity;
        public ICommand AddActivityCommand
        {
            get
            {
                if (_addActivityType == null)
                {
                    _addActivityType = new CommandHandler((parameter) => AddActivityType(parameter), true);
                }
                return _addActivityType;
            }
        }

        public void AddActivityType(object parameter)
        {
            if (parameter != null)
            {
                _model.ActivityTypes.Add(parameter.ToString());
                OnPropertyChanged("ActivityTypes");
            }
        }

        public ICommand AddFullActivityCommand
        {
            get
            {
                if (_addFullActivity == null)
                {
                    _addFullActivity = new CommandHandler((parameter) => AddFullActivity(), true);
                }
                return _addFullActivity;
            }
        }

        public void AddFullActivity()
        {
            ActivityModel act = new ActivityModel();
            act.ActivityDurationMinutes = EntryDurationInMinutes;
            act.ActivityType = EntryActivityType;
            act.ActivityStarted = EntryActivityStart;
            _model.SavedActivities.Add(act);
            //Reset entry field
            EntryDurationInMinutes = 0;
            EntryActivityStart = DateTime.Now;

            //Raise property changed
            OnPropertyChanged("LastActivity");
            OnPropertyChanged("ActivityCount");

        }
        #endregion Commands

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

    public class CommandHandler : ICommand
    {
        private Action<object> _action;
        private bool _canExecute;
        public CommandHandler(Action<object> action, bool canExecute)
        {
            _action = action;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            _action(parameter);
        }
    }
}
