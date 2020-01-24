using UnityEngine;
using UnityEngine.Advertisements;

public class AdsHandler : MonoBehaviour
{

    string gameId;
    bool testMode = false;

    //string rewardedAds = "rewardedVideo";
    string videoAds = "video";

    public static AdsHandler Instance { get; set; }

    void Awake()
    {
        if (Application.isEditor) testMode = true;
#if UNITY_ANDROID
        gameId = "3431809";
#elif UNITY_IOS
        gameId = "3431808";
#endif
        Advertisement.Initialize(gameId, testMode);
        Debug.Log("test mode: " + testMode);

        Instance = this;
    }

    public void ShowVideoAds()
    {
        if (Advertisement.IsReady(videoAds))
        {
            Advertisement.Show(videoAds);
        }
    }

}