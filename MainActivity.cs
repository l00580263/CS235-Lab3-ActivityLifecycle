namespace ActivityLifecycle
{
    using Android.App;
    using Android.Content;
    using Android.OS;
    using Android.Util;
    using Android.Widget;

    [Activity(Label = "Activity A", MainLauncher = true)]
    public class MainActivity : Activity
    {
        #region Fields
        int counter;
        const string COUNTER_STATE_KEY = "counter_click";
        #endregion



        #region Methods
        protected override void OnCreate(Bundle bundle)
        {
			Log.Debug(GetType().FullName, "Activity A - OnCreate");
			base.OnCreate(bundle);
			SetContentView (Resource.Layout.Main);

            // reload counter
            if (bundle != null)
            {
                // get counter from bundle
                counter = bundle.GetInt(COUNTER_STATE_KEY, 0);
                Log.Debug(GetType().FullName, "Activity A - Loaded counter");
            }

            // set up ui
            FindViewById<Button>(Resource.Id.myButton).Click += (sender, args) =>
            {
                var intent = new Intent(this, typeof(SecondActivity));
                StartActivity(intent);
            };

            // get counter button
            Button clickButton = FindViewById<Button>(Resource.Id.clickButton);
            // update counter button text
            clickButton.Text = Resources.GetString(Resource.String.counterbutton_text, counter);
            // event for counter button
            clickButton.Click += (sender, args) =>
            {
                // increment to counter
                counter++;
                // update button text
                clickButton.Text = Resources.GetString(Resource.String.counterbutton_text, counter);
            };
        }



        // saving 
        protected override void OnSaveInstanceState(Bundle outState)
        {
            // add counter
            outState.PutInt(COUNTER_STATE_KEY, counter);
            // log
            Log.Debug(GetType().FullName, "Activity A - Saving instance state");

            base.OnSaveInstanceState(outState);
        }


        protected override void OnDestroy()
        {
            Log.Debug(GetType().FullName, "Activity A - On Destroy");
            base.OnDestroy();
        }

        protected override void OnPause()
        {
            Log.Debug(GetType().FullName, "Activity A - OnPause");
            base.OnPause();
        }

        protected override void OnRestart()
        {
            Log.Debug(GetType().FullName, "Activity A - OnRestart");
            base.OnRestart();
        }

        protected override void OnResume()
        {
            Log.Debug(GetType().FullName, "Activity A - OnResume");
            base.OnResume();
        }

        protected override void OnStart()
        {
            Log.Debug(GetType().FullName, "Activity A - OnStart");
            base.OnStart();
        }

        protected override void OnStop()
        {
            Log.Debug(GetType().FullName, "Activity A - OnStop");
            base.OnStop();
        }
        #endregion
    }
}
