namespace ExerciseTracking
{
    public class Running : Activity
    {
        private double distanceMiles;

        public Running(DateTime date, int lengthMinutes, double distanceMiles)
            : base(date, lengthMinutes)
        {
            this.distanceMiles = distanceMiles;
        }

        public override double GetDistance() => distanceMiles;

        public override double GetSpeed()
        {
            return (distanceMiles / LengthMinutes) * 60;
        }

        public override double GetPace()
        {
            return LengthMinutes / distanceMiles;
        }
    }
}
