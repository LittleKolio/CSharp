namespace Events_Exercises.Exercises_04
{
    using System;

    public class JobEventArgs : EventArgs
    {
        public JobEventArgs(Job job)
        {
            this.Job = job;
        }
        public Job Job { get; private set; }
    }
}
