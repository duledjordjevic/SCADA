using System;
using System.Timers;
using Timer = System.Timers.Timer;

namespace SharedLibrary
{
    public class SimulationDriver
    {
        private Timer timer;
        private double time;
        private static Random random = new Random();

        public event EventHandler<TagEventArgs> TagValueChanged;

        public SimulationDriver(double interval)
        {
            timer = new Timer(interval);
            timer.Elapsed += OnTimedEvent;
            time = 0;
        }

        public void Start()
        {
            timer.Start();
        }

        public void Stop()
        {
            timer.Stop();
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            time += timer.Interval / 1000; // Convert to seconds

            EmitSignal("S", Sine());
            EmitSignal("C", Cosine());
            EmitSignal("R", Ramp());
        }

        private void EmitSignal(string address, double value)
        {
            TagValueChanged?.Invoke(this, new TagEventArgs(address, value));
        }

        private double Sine()
        {
            return 100 * Math.Sin(time);
        }

        private double Cosine()
        {
            return 100 * Math.Cos(time);
        }

        private double Ramp()
        {
            return 100 * (time % 60) / 60;
        }

        public static double ReturnValue(string address)
        {
            switch (address)
            {
                case "S":
                    return 100 * Math.Sin((double)DateTime.Now.Second / 60 * Math.PI);
                case "C":
                    return 100 * Math.Cos((double)DateTime.Now.Second / 60 * Math.PI);
                case "R":
                    return 100 * DateTime.Now.Second / 60;
                default:
                    return -1000;
            }
        }
    }

    public class TagEventArgs : EventArgs
    {
        public string Address { get; }
        public double Value { get; }

        public TagEventArgs(string address, double value)
        {
            Address = address;
            Value = value;
        }
    }

}