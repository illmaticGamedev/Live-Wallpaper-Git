using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Networking;

public class Clock : MonoBehaviour
{
    [SerializeField] private string indiaKolkataTimeURL = "";
    [SerializeField] private string kentuckyUSATimeURL = "";
    [SerializeField] private TMP_Text istClockText;
    [SerializeField] private TMP_Text usaClockText;
    [SerializeField]  bool blink = true;
    private void Start()
    {
        CheckTime(indiaKolkataTimeURL,istClockText,indiaKolkataTimeURL);
        CheckTime(kentuckyUSATimeURL,usaClockText,kentuckyUSATimeURL);
    }

    private void SetTime(TMP_Text timeZoneText, string currentTime)
    {
        // Some formatting here
        timeZoneText.text = currentTime.ToString();
    }
    void CheckTime(string requestURL, TMP_Text ClockText, string currentTimeText)
    {
        StartCoroutine(SendRequest(requestURL,ClockText,currentTimeText));
    }

    IEnumerator SendRequest(string url, TMP_Text clockText, string currentTimeText)
    {
        while (true)
        {
            UnityWebRequest request = new UnityWebRequest(url);
            DownloadHandlerBuffer dH = new DownloadHandlerBuffer();
            request.downloadHandler = dH;
            yield return request.SendWebRequest();
        
            if (request.error != null)
            {
                Debug.LogError("Request Failed");
            }
            else
            {   
                JsonHelper newTime = JsonUtility.FromJson<JsonHelper>(dH.text);
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
                SetTime(clockText,currentTimeInCorrectFormat);
            }
            yield return new WaitForSecondsRealtime(0.5f);
        }
        
    }
    
}
[System.Serializable]
public class JsonHelper
{
    public string datetime;
    public string timezone;
}
