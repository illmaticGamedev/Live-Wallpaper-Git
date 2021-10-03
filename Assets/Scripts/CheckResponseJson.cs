using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CheckResponseJson : MonoBehaviour
{
    public static CheckResponseJson Instance;
    private void Awake()
    {
        Instance = this;
    }

    public void GetJsonResponse(string url, APIFeature featureClass, float apiRepeatRateInSeconds)
    {
        StartCoroutine(checkJsonResponse(url, featureClass, apiRepeatRateInSeconds));
    }

    IEnumerator checkJsonResponse(string url, APIFeature featureClass, float apiRepeatRateInSeconds)
    {
        while (true)
        {
            UnityWebRequest request = new UnityWebRequest(url);
            DownloadHandlerBuffer dH = new DownloadHandlerBuffer();
            request.downloadHandler = dH;
            yield return request.SendWebRequest();

            if (request.error != null)
            {
                if(Application.isEditor)
                    Debug.LogError("Request Failed : " + featureClass.name);
            }
            else
            {
                featureClass.Response = dH.text;
            }
            
            yield return new WaitForSecondsRealtime(apiRepeatRateInSeconds);
        }
    }
}
