namespace ExerciseTracking
{
    public class Cycling : Activity
    {
        private double speedMph;

        public Cycling(DateTime date, int lengthMinutes, double speedMph)
            : base(date, lengthMinutes)
        {
            this.speedMph = speedMph;
        }

        public override double GetDistance()
        {
            return (speedMph * LengthMinutes) / 60;
        }

        public override double GetSpeed() => speedMph;

        public override double GetPace()
        {
            return 60 / speedMph;
        }
    }
}
