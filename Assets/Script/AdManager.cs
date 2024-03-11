using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using Ads_deneme;
public class AdManager : MonoBehaviour
{
    BannerAds_deneme _bannerads_Deneme;
    InterstitialAds_deneme _interstitialAds_Deneme;
    private void Awake()
    {
        _bannerads_Deneme = new BannerAds_deneme();
        _interstitialAds_Deneme = new InterstitialAds_deneme();
    }

    private void Start()
    {
        _interstitialAds_Deneme.LoadInterstitialAd();
        _bannerads_Deneme.LoadAd();
    }
    private void Update()
    {
        if (GameManager.Instance.IsGameOver == true)
        {
            AudioManager.Instance.EndSound();

            _interstitialAds_Deneme.ShowInterstitialAd();
            GameManager.Instance.IsGameOver = false;

        }
    }
}