using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Xamarin.Forms;
using Android.App.Job;

namespace Background.Droid
{
    [Activity(Label = "Background", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            MessagingCenter.Subscribe<MainPage>(this, "HiBackgroundJob", (sender) =>
            {
                // Do something whenever the "Hi" message is received

                try
                {
                    StartMyScheduledJob();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            });
            LoadApplication(new App());
        }

        private void StartMyScheduledJob()
        {
            var jobBuilder = this.CreateJobBuilderUsingJobId<DownloadJob>(1)
                .SetPersisted(true)
                //.SetMinimumLatency(5000)    // Wait at least 5 second
                //.SetOverrideDeadline(15000)  // But no longer than 15 seconds
                .SetRequiredNetworkType(NetworkType.Any)
                .SetPeriodic(900000, 300000) //15 mins // 5 mins
                ;

            var jobInfo = jobBuilder.Build();  // creates a JobInfo object.
            var jobScheduler = (JobScheduler)GetSystemService(JobSchedulerService);
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

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}