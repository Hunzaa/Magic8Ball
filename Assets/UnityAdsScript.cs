using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class UnityAdsScript : MonoBehaviour, IUnityAdsListener
{

    string gameId = "4112885";
    string bannerPlacementId = "banner";
    string interstitialPlacementId = "interstitiall";
    string rewardedPlacementId = "rewarded";

    //RewardedAd rewardedAd;

    // set this to false when game is ready
    bool testMode = true;

    Magic8Ball player;

    //NEW
    bool hasShownAdOneTime;

    void Start()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId, testMode);
        StartCoroutine(ShowBannerWhenInitialized());


        //rewardedAd = new RewardedAd(rewardedPlacementId);

        player = FindObjectOfType<Magic8Ball>();
    }

    public void Update()
    {
        /*if (Input.touchCount > 2)
        {
            ShowRewardedVideo();
        }*/
        
        if (TimerScript.isGameOver)
        {
            if (!hasShownAdOneTime)
            {
                hasShownAdOneTime = true;
                Invoke("ShowInterstitialAd", 5.0f);
            }
        }

    }

    /********************************** BANNER **********************************/
    IEnumerator ShowBannerWhenInitialized()
    {
        while (!Advertisement.isInitialized)
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
        Advertisement.Banner.Show(bannerPlacementId);
    }

    /********************************** INTERSTITIAL **********************************/
    public void ShowInterstitialAd()
    {
        if (Advertisement.IsReady(interstitialPlacementId))
        {
            Advertisement.Show(interstitialPlacementId);
        }
        else
        {
            Debug.Log("Error loading Interstitial Ad");
        }
    }

    /********************************** REWARDED **********************************/
    public void ShowRewardedVideo()
    {
        Debug.Log("rewarded method");
        if (Advertisement.IsReady(rewardedPlacementId))
        {
            Advertisement.Show(rewardedPlacementId);
            Debug.Log("show rewarded");
        }
        
        else
        {
            Debug.Log("Error loading Rewarded Ad");
        }
    }

    /********************************** Interstitial Handler **********************************/
    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (showResult == ShowResult.Finished)
        {
            if (placementId == rewardedPlacementId)
            {
                // Reward player for watching rewarded ad only
                player.rewardEarned();
                Debug.Log("You have won 1 Attempt");
            }
            else
            {
                Debug.Log("Ad Finished");
            }
        }
        else if (showResult == ShowResult.Skipped)
        {
            Debug.Log("Ad Skipped");
            // Do not reward the user for skipping rewarded the ad.
        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.LogWarning("The ad did not finish due to an error.");
        }
    }

    /********************************** Handlers 2 **********************************/
    public void OnUnityAdsReady(string placementId)
    {
        // If the ready Placement is rewarded, show the ad:

    }

    public void OnUnityAdsDidError(string message)
    {
        // Log the error.
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        // Optional actions to take when the end-users triggers an ad.
    }
}