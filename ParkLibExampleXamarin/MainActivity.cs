using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using AndroidX.AppCompat.Widget;
using AndroidX.AppCompat.App;
using Google.Android.Material.FloatingActionButton;
using Google.Android.Material.Snackbar;
using Com.Parklio.Androidapi;
using Android.Widget;

namespace ParkLibExampleXamarin
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, IParklioEventListener
    {

        private static String TAG = "Parklio";
        private ParklioBarrier parklioBarrier;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            AndroidX.AppCompat.Widget.Toolbar toolbar = FindViewById<AndroidX.AppCompat.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;

            Button openButton = FindViewById<Button>(Resource.Id.open_button);
            openButton.Click += OpenClick;

            Button closeButton = FindViewById<Button>(Resource.Id.close_button);
            closeButton.Click += CloseClick; 
            
            Button connectButton = FindViewById<Button>(Resource.Id.connect_button);
            connectButton.Click += ConnectClick;

            parklioBarrier = new ParklioBarrier(this);


        }

        private void ConnectClick(object sender, EventArgs e)
        {
            View view = (View)sender;
            Snackbar.Make(view, "Connect Button Clicked", Snackbar.LengthLong)
                .SetAction("Action", (View.IOnClickListener)null).Show();
            parklioBarrier.Connect("{" +
                    "  \"tokenClose\": {" +
                    "    \"challengeKey\": \"f3f1592c24748f85b003db8df1543199abdb4e71a0e9a8498fc54e67957ffc6f\"," +
                    "    \"statusKey\": \"3a7055b29f8876523d3074a20b0832cefadaffa800ffc828c378c2f1ec0c0613\"," +
                    "    \"token\": \"589c491d043fdccf444bd9e874319850db758b369b3931c581211261b5d0091cae83b846826e6fe1dfbbb78efa57509863e6feb553cd60eaad4d847a23bd944634a9848b347d33630c0e59255aa94c5d\"" +
                    "  }," +
                    "  \"tokenOpen\": {\n" +
                    "    \"challengeKey\": \"fcb5ecdd6a9d542e4775d7a34470cdfeed3160d3a07525fc71cb93119c59ae90\"," +
                    "    \"statusKey\": \"4eff1489e81d8e96d6940521ed51b26ecd53d846584308f1aa8acac3fa46cc3a\"," +
                    "    \"token\": \"589c491d2dfc30f43848909fc20241eb3f1204f551072c713c796b74451f0ac2a92d6b711878572e16eeaffb4e32e6c999a97abdd8b25658363c1161c9f7bc3c7d8ffec3ca05a748dfa6a67fc1e4a15b\"" +
                    "  }," +
                    "  \"tokenStatus\": {" +
                    "    \"challengeKey\": \"0d8d3a9789344e7fdd260e8756b5b7ae9a5b16254fcf6783be3952370d16e8c1\"," +
                    "    \"statusKey\": \"1d56d38f715842e49fb4edbef5c7ed28fb936813ad91c321c49d1d7814681155\"," +
                    "    \"token\": \"589c491d8a86a2d149cf300cea258513ee57ef964cce099e1d76916f7f6c85b61179ecbd6b6ffd814623dc864d799e62348ec99ec9419598b9153785b2f369b859e3afadb27c53d4bd4733012ac18964\"" +
                    "  }," +
                    // THIS IS THE DEVICE ID THAT COMES WITH THE BARRIER, B INDICATES THE TYPE OF PRODUCT AND THE 6 CHARACTERS ARE THE UNIQUE ID
                    "  \"address\": \"B123456\"" +
                    "}");
        }

        private void CloseClick(object sender, EventArgs e)
        {
            View view = (View)sender;
            Snackbar.Make(view, "Close Button Clicked", Snackbar.LengthLong)
                .SetAction("Action", (View.IOnClickListener)null).Show();
            parklioBarrier.Close();
        }

        private void OpenClick(object sender, EventArgs e)
        {
            View view = (View)sender;
            Snackbar.Make(view, "Open Button Clicked", Snackbar.LengthLong)
                .SetAction("Action", (View.IOnClickListener)null).Show();
            parklioBarrier.Open();        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            Snackbar.Make(view, "Replace with your own action 2", Snackbar.LengthLong)
                .SetAction("Action", (View.IOnClickListener)null).Show();
            //parklioBarrier.Open();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        void IParklioEventListener.OnBarrierPositionReceived(BarrierPosition barrierPosition)
        {
            throw new NotImplementedException();
        }

        void IParklioEventListener.OnBarrierStatusReceived(BarrierStatus barrierStatus)
        {
            throw new NotImplementedException();
        }

        void IParklioEventListener.OnBatteryLevelReceived(int batteryLevel)
        {
            throw new NotImplementedException();
        }

        void IParklioEventListener.OnDeviceConnected()
        {
            throw new NotImplementedException();
        }

        void IParklioEventListener.OnDeviceDisconnected()
        {
            throw new NotImplementedException();
        }

        void IParklioEventListener.OnErrorReceived(ErrorCode error)
        {
            Console.WriteLine(error.ToString());
        }
    }
}
