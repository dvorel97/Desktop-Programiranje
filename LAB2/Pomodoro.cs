using System;
using System.Collections.Generic;
using System.Text;

namespace LAB2
{
    public class Pomodoro
    {

        public Pomodoro() {
            WorkDuration = 25;
            RestDuration = 5;
            CurrentSeconds = Pomodoro.ConvertMinutesToSeconds(WorkDuration);
            WorkInProgress = true;
        }

        public Pomodoro(int workDuration, int restDuration)
        {
            WorkDuration = workDuration;
            RestDuration = restDuration;
            CurrentSeconds = Pomodoro.ConvertMinutesToSeconds(WorkDuration);
            WorkInProgress = true;
        }

        public override string ToString()
        {
            int minutes = CurrentSeconds / 60;
            int seconds = CurrentSeconds % 60;
            return minutes.ToString("D2") + ":" + seconds.ToString("D2");
        }

        static public int ConvertMinutesToSeconds(int minutes)
        {
            return minutes * 60;
        }
        public bool WorkInProgress { get; set; }
        public int WorkDuration { get; set; }
        public int RestDuration { get; set; }
        public int CurrentSeconds { get; set; }

    }
}
