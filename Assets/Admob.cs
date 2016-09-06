using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;

public class Admob : MonoBehaviour {

	void Start()
	{
		DontDestroyOnLoad (this);
		RequestBanner ();
	}

	private void RequestBanner()
	{
		#if UNITY_ANDROID
		string adUnitId = "ca-app-pub-8848243490881110/4155474583";
		#elif UNITY_IPHONE
		string adUnitId = "ca-app-pub-8848243490881110/7586618987";
		#else
		string adUnitId = "unexpected_platform";
		#endif

		// Create a 320x50 banner at the top of the screen.
		BannerView bannerView = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Bottom);
		// Create an empty ad request.
		AdRequest request = new AdRequest.Builder().Build();
		// Load the banner with the request.
		bannerView.LoadAd(request);
	}
}
