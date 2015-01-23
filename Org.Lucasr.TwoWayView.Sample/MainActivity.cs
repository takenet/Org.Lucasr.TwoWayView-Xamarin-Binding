using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using TwoWayViewWidget = Org.Lucasr.TwoWayView.Widget.TwoWayView;
using Org.Lucasr.TwoWayView.Widget;
using Android.Graphics.Drawables;

namespace Org.Lucasr.TwoWayView.Sample
{
    

    [Activity(Label = "Org.Lucasr.TwoWayView.Sample", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            var twoWayView = FindViewById<TwoWayViewWidget>(Resource.Id.TwoWayView);
            twoWayView.HasFixedSize = true;

			Drawable divider = Resources.GetDrawable (Resource.Drawable.Divider);
			twoWayView.AddItemDecoration (new DividerItemDecoration (divider));
            twoWayView.SetAdapter(new MyRecyclerViewAdapter(this, 12));
        }
    }
}

