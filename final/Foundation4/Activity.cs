using System;

namespace ExerciseTracking
{
    public abstract class Activity
    {
        private DateTime date;
        private int lengthMinutes;

        protected Activity(DateTime date, int lengthMinutes)
        {
            this.date = date;
            this.lengthMinutes = lengthMinutes;
        }

        public DateTime Date => date;
        public int LengthMinutes => lengthMinutes;

        public abstract double GetDistance();
        public abstract double GetSpeed();
        public abstract double GetPace();

        public virtual string GetSummary()
        {
            return $"{date:dd MMM yyyy} {this.GetType().Name} ({lengthMinutes} min): Distance {GetDistance():0.0} miles, Speed {GetSpeed():0.0} mph, Pace {GetPace():0.0} min per mile";
        }
    }
}
