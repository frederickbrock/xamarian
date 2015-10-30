
using System;
using System.Collections.Generic;
using System.Linq;
using MonoMac.Foundation;
using MonoMac.AppKit;

using PubNubMessaging.Core;

namespace Pubnubsample
{
	public partial class MainWindow : MonoMac.AppKit.NSWindow
	{
		#region Constructors
		private Pubnub _pubnub;

		// Called when created from unmanaged code
		public MainWindow (IntPtr handle) : base (handle)
		{
			Initialize ();
		}
		
		// Called when created directly from a XIB file
		[Export ("initWithCoder:")]
		public MainWindow (NSCoder coder) : base (coder)
		{
			Initialize ();
		}
		
		// Shared initialization code
		void Initialize ()
		{
			GetPubnub ().Subscribe<string> ("MSFT", MessageReceived, ConnectCallback, ErrorCallback);
			GetPubnub ().Subscribe<string> ("AMZN", MessageReceived, ConnectCallback, ErrorCallback);
			GetPubnub ().Subscribe<string> ("MSFT", MessageReceived, ConnectCallback, ErrorCallback);
		}


		public Pubnub GetPubnub()
		{
			if (this._pubnub == null) {
				this._pubnub = new Pubnub ("demo", "demo");
			}


			return(_pubnub);
		}

		public void MessageReceived(String message)
		{
			Console.WriteLine ("Message received");
			
		}


		public void ConnectCallback(string message)
		{
		}

		public void ErrorCallback(PubnubClientError message)
		{
		}




		#endregion
	}
}

