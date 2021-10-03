using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class Clock : APIFeature
{
    public enum timeZone { India, KentuckyUSA}
    public timeZone myTimeZone;
    
    [SerializeField] private string timeZoneAPIURL = "";
    [SerializeField] private TMP_Text clockTextUI;
    private void Start()
    {
        CheckResponseJson.Instance.GetJsonResponse(timeZoneAPIURL,this);
        InvokeRepeating(nameof(PerformMechanic),CheckResponseJson.Instance.appUpdateRateInSeconds,CheckResponseJson.Instance.appUpdateRateInSeconds);
    }
    private void OnValidate()
    {
       RefreshAPIURL();
    }
    void RefreshAPIURL()
    {
        switch (myTimeZone)
        {
            case timeZone.KentuckyUSA:
                timeZoneAPIURL = GlobalConstants.KENTUCKY_CLOCK_URL;
                break;
            case timeZone.India:
                timeZoneAPIURL = GlobalConstants.INDIA_CLOCK_URL;
                break;
        }
    }
    void SetTime(TMP_Text timeZoneText, string currentTime)
    {
        timeZoneText.text = currentTime.ToString();
    }
    public override void PerformMechanic()
    {
        if (Response == null) return;
        
        ClockHelper newTime = JsonUtility.FromJson<ClockHelper>(Response);
        string currentTimeInCorrectFormat = "";
        char[] characters = newTime.datetime.ToCharArray();

        for (int i = 0; i < characters.Length; i++)
        {
            if (characters[i] == 'T')
            {
                for (int j = 0; j < 8; j++)
                {
                    currentTimeInCorrectFormat += characters[i + j + 1];
                }

                break;
            }
        }
        SetTime(clockTextUI, currentTimeInCorrectFormat);
    }
}

[System.Serializable]
public struct ClockHelper
{
    public string datetime;
    public string timezone;
}