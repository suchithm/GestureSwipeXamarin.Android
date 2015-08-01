using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace AndroidGesture
{
	[Activity ( Label = "AndroidGesture" , MainLauncher = true , Icon = "@drawable/icon" )]
	public class MainActivity : Activity
	{
		//http://forums.xamarin.com/discussion/comment/40052/
		GestureDetector _gestureDetector;
		GestureListener _gestureListener;
		protected override void OnCreate ( Bundle bundle )
		{
			base.OnCreate ( bundle );
 
			SetContentView ( Resource.Layout.Main );

			_gestureListener = new GestureListener (); 

			_gestureListener.LeftEvent += GestureLeft;
			_gestureListener.RightEvent += GestureRight;
 
			_gestureDetector = new GestureDetector (this,_gestureListener);


		}
		void GestureLeft()
		{
			Toast.MakeText (this, "Gesture Left", ToastLength.Short).Show ();
		}

		void GestureRight()
		{
			Toast.MakeText (this, "Gesture Right", ToastLength.Short).Show ();
		}

		public override bool DispatchTouchEvent (MotionEvent ev)
		{
			_gestureDetector.OnTouchEvent ( ev );
			return base.DispatchTouchEvent (ev);


		}
	}
}


