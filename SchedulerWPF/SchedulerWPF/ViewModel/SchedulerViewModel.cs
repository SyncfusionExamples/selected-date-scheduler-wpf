using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Media;

namespace WpfScheduler
{
  public class SchedulerViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// collecions for meetings.
        /// </summary>
        private ObservableCollection<Meeting> meetings;

        /// <summary>
        /// color collection.
        /// </summary>
        private ObservableCollection<Brush> colorCollection;

        /// <summary>
        /// current day meeting.
        /// </summary>
        private ObservableCollection<string> meetingSubjectCollection;
        private DateTime selectedDate = DateTime.Now.AddDays(5);

        public SchedulerViewModel()
        {
            this.Meetings = new ObservableCollection<Meeting>();
            this.AddAppointmentDetails();
            this.AddAppointments();
        }

        /// <summary>
        /// Gets or sets meetings.
        /// </summary>
        public ObservableCollection<Meeting> Meetings
        {
            get
            {
                return this.meetings;
            }

            set
            {
                this.meetings = value;
                this.RaiseOnPropertyChanged("Meetings");
            }
        }
        public DateTime SelectedDate
        {
            get
            {
                return this.selectedDate;
            }

            set
            {
                this.selectedDate = value;
                this.RaiseOnPropertyChanged("SelectedDate");
            }
        }

        /// <summary>
        /// adding appointment details.
        /// </summary>
        private void AddAppointmentDetails()
        {
            meetingSubjectCollection = new ObservableCollection<string>();
            meetingSubjectCollection.Add("BigDoor Board Meeting Paris, France");
            meetingSubjectCollection.Add("Development Meeting New York, U.S.A");
            meetingSubjectCollection.Add("Project Plan Meeting Kuala Lumpur, Malaysia");
            meetingSubjectCollection.Add("Support - Web Meeting  Dubai, UAE");
            meetingSubjectCollection.Add("Project Release Meeting  Istanbul, Turkey");
            meetingSubjectCollection.Add("Customer Meeting  Tokyo, Japan");
            meetingSubjectCollection.Add("Consulting with doctor  Amsterdam, Netherlands");


            colorCollection = new ObservableCollection<Brush>();
            colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFA2C139")));
            colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD80073")));
            colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF1BA1E2")));
            colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFE671B8")));
            colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF09609")));
            colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF339933")));
            colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF00ABA9")));
            colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFE671B8")));
            colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF1BA1E2")));
            colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD80073")));
            colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFA2C139")));
            colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFA2C139")));
            colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD80073")));
            colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF339933")));
            colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFE671B8")));
            colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF00ABA9")));
        }

        /// <summary>
        /// Adds the appointments.
        /// </summary>
        private void AddAppointments()
        {
            var today = DateTime.Now.Date;
            var random = new Random();
            for (int month = -1; month < 2; month++)
            {
                for (int day = -5; day < 5; day++)
                {
                    for (int count = 0; count < 2; count++)
                    {
                        var meeting = new Meeting();
                        meeting.From = today.AddMonths(month).AddDays(random.Next(1, 28)).AddHours(random.Next(9, 18));
                        meeting.To = meeting.From.AddHours(1);
                        meeting.EventName = meetingSubjectCollection[random.Next(7)];
                        meeting.Color = colorCollection[random.Next(14)];
                        this.Meetings.Add(meeting);
                    }
                }
            }
        }

        /// <summary>
        /// Occurs when property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Invoke method when property changed.
        /// </summary>
        /// <param name="propertyName">property name</param>
        private void RaiseOnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}








