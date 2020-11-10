using System;
using System.Windows.Media;

namespace WpfScheduler
{
    public class Meeting
    {
        public string EventName { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public Brush Color { get; set; }
    }
}


