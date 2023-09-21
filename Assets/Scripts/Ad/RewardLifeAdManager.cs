using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds;
using GoogleMobileAds.Api;

public class RewardLifeAdManager : MonoBehaviour
{
    [SerializeField] private Button _rewardAdButton;
    void Start()
    {
        AdMobScript.LoadRewardedAd();
        _rewardAdButton.onClick.AddListener(delegate { AdMobScript.ShowRewardedAd(); });
    }

    private void RegisterEventHandlers(RewardedAd ad)
    {
        // Raised when the ad closed full screen content.
        ad.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("Rewarded ad full screen content closed.");
        };
        
    }

}
