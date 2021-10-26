using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppManager : MonoBehaviour
{
    public static AppManager Instance;
    [SerializeField] private GameObject overlayObject;
    private bool canToggle = true;
    private void Awake()
    {
        Instance = this;
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.T))
        {
            ToggleInteractionOverlay();
        }
    }
    
    void ToggleInteractionOverlay()
    {
        if (canToggle)
        {
            canToggle = false;
            Debug.Log("Toggled");
            overlayObject.gameObject.SetActive(!overlayObject.activeInHierarchy);
            StartCoroutine(waitForSecondBeforeNextCall());
        }
    }

    IEnumerator waitForSecondBeforeNextCall()
    {
        yield return new WaitForSecondsRealtime(1f);
        canToggle = true;
    }
}
