using Android.App;
using Android.App.Job;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Background.Droid
{
    [Service(Name = "com.xamarin.samples.downloadscheduler.DownloadJob",
         Permission = "android.permission.BIND_JOB_SERVICE")]
    public class DownloadJob : JobService
    {
        public override bool OnStartJob(JobParameters jobParams)
        {
            Task.Run(() =>
            {
                // Work is happening asynchronously
              
                System.Diagnostics.Debug.WriteLine($"The time is {DateTime.Now}");
                
                // Have to tell the JobScheduler the work is done. 
                JobFinished(jobParams, false);
            });

            // Return true because of the asynchronous work
            return true;
        }

        public override bool OnStopJob(JobParameters jobParams)
        {
            // we don't want to reschedule the job if it is stopped or cancelled.
            return false;
        }
    }
}

