namespace Events_Exercises.Exercises_04
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class JobsList : List<Job>
    {
        public void OnJobDone(object sender, EventArgs ev)
        {
            this.Remove((Job)sender);
        }
    }
}
