
using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
using System;

public class GPGSAuthentication : MonoBehaviour
{
    public static PlayGamesPlatform platform;
   
    void Start()
    {
        if(platform == null)
        {
            PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
            PlayGamesPlatform.InitializeInstance(config);
            PlayGamesPlatform.DebugLogEnabled = true;

            platform = PlayGamesPlatform.Activate();
        }
        Social.Active.localUser.Authenticate(success =>
        {
            if (success)
            {
                FirstGuess();
                Debug.Log("Logged in successfully");
            }
            else
            {
                Debug.Log("Failed to log in");
            }

        });
    }

    public void FirstGuess()
    {
        Social.ReportProgress("CgkI-qXg644QEAIQAg",100.0f, (bool success) => {
            if (success)
            {
               Debug.Log("Success");
            }
        });
    }

    public void ShowAchievements(Boolean success)
    {
        if (success)
        {
            Social.ShowAchievementsUI();
        }
    }
    public void RequestAcheivments()
    {
        if (PlayGamesPlatform.Instance.localUser.authenticated)
        {
            Social.ShowAchievementsUI();

        }

        else
        {
            PlayGamesPlatform.Instance.Authenticate(ShowAchievements, false);
        }
    }



}
