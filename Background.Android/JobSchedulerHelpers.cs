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
using static Android.Database.MatrixCursor;

namespace Background.Droid
{
    public static class JobSchedulerHelpers
    {
        public static JobInfo.Builder CreateJobBuilderUsingJobId<T>(this Context context, int jobId) where T : JobService
        {
            var javaClass = Java.Lang.Class.FromType(typeof(T));
            var componentName = new ComponentName(context, javaClass);
            return new JobInfo.Builder(jobId, componentName);
        }

    }

    //// Sample usage - creates a JobBuilder for a DownloadJob and sets the Job ID to 1.
    //var jobBuilder = this.CreateJobBuilderUsingJobId<DownloadJob>(1);

    //var jobInfo = jobBuilder.Build();  // creates a JobInfo object.
}