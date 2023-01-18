using Android.App;
using Android.App.Job;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Google.Android.Material.Snackbar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Background.Droid
{
    public class BeginAScheduleJob
    {
        public void StartItHere(MainActivity mainActivity)
        {
            DownloadJob job = new DownloadJob();
            var jobBuilder = mainActivity.CreateJobBuilderUsingJobId<DownloadJob>(1);

            var jobInfo = jobBuilder.Build();  // creates a JobInfo object.
            var jobScheduler = (JobScheduler) mainActivity.GetSystemService("");
            var scheduleResult = jobScheduler.Schedule(jobInfo);

            if (JobScheduler.ResultSuccess == scheduleResult)
            {
                Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Background", "Successfully scheduled", "OK");
            }                                
            else
            {
                Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Background", "failed to schedule", "OK");
            }
        }
    }
}