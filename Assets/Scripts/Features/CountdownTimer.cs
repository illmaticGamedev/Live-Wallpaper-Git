using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : FeatureBaseClass
{
   [Header("Setup")]
    private DateTime currentTime;
    private DateTime targetTime;
    private int daysRemaining;
   [SerializeField] private GameObject editPanel;
   [SerializeField] private GameObject countdownPanel;
   

   [Header("Edit Panel Setup")] 
   [SerializeField] TMP_InputField countdownNameInputField;
   [SerializeField] TMP_Dropdown dayDropdown;
   [SerializeField] TMP_Dropdown monthDropdown;
   [SerializeField] TMP_Dropdown yearDropdown;
   [SerializeField] private Button editButton;
   
   [Header("Countdown Panel")]
   [SerializeField] private Button startCountdownButton;
   [SerializeField] private TMP_Text countdownName;
   [SerializeField] private TMP_Text daysRemainingText;

   private string savedDay;
   private string savedMonth;
   private string savedYear;
   private string savedName;
   protected override void Start()
   {
      base.Start();
      startCountdownButton.onClick.AddListener(ResetTimer);
      editButton.onClick.AddListener(EditSettings);

      savedDay = gameObject.name + " Day";
      savedMonth = gameObject.name + " Month";
      savedYear = gameObject.name + " Year";
      savedName = gameObject.name + " Name";
      
      CheckLastSavedSettings();
   }

   public override void PerformMechanic()
   {
      currentTime = DateTime.Now;
      var delta = targetTime - currentTime;
      daysRemaining = delta.Days;
      
      if (daysRemaining == 0)
      {
         daysRemainingText.text = (delta.Hours) + " Hours";
      }
      else
      {
         daysRemainingText.text = (daysRemaining) + " Days";
      }
     
   }

   void ResetTimer()
   {
      editPanel.gameObject.SetActive(false);
      countdownPanel.gameObject.SetActive(true);
      targetTime = new DateTime(int.Parse(yearDropdown.captionText.text),int.Parse(monthDropdown.captionText.text),int.Parse(dayDropdown.captionText.text));
      countdownName.text = countdownNameInputField.text;
      daysRemainingText.text = daysRemaining.ToString();
      SaveCurrentSettings();
   }

   void EditSettings()
   {
      countdownPanel.gameObject.SetActive(false);
      editPanel.gameObject.SetActive(true);
   }

   void SaveCurrentSettings()
   {
      PlayerPrefs.SetInt(savedDay, targetTime.Day);
      PlayerPrefs.SetInt(savedMonth, targetTime.Month);
      PlayerPrefs.SetInt(savedYear, targetTime.Year);
      PlayerPrefs.SetString(savedName, countdownName.text);
   }

   void CheckLastSavedSettings()
   {
      if (PlayerPrefs.HasKey(savedDay))
      {
         targetTime = new DateTime( PlayerPrefs.GetInt(savedYear), PlayerPrefs.GetInt(savedMonth), PlayerPrefs.GetInt(savedDay));
         countdownName.text = PlayerPrefs.GetString(savedName);
         editPanel.SetActive(false);
         countdownPanel.SetActive(true);
      }
   }
   
   
   
}
