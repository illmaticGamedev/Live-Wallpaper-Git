using System;
using UnityEngine;
using UnityEngine.UI;

public class MakeAPost : MonoBehaviour
{
   [SerializeField] private Button btnFB;
   [SerializeField] private Button btnTwitter;
   [SerializeField] private Button btnLinkedIn;

   private void Start()
   {
      ButtonToURL(btnTwitter,GlobalConstants.POST_TO_TWITTER);
      ButtonToURL(btnFB,GlobalConstants.POST_TO_FACEBOOK);
      ButtonToURL(btnLinkedIn,GlobalConstants.POST_TO_LINKEDIN);
   }

   void ButtonToURL(Button btn, string URL)
   {
      btn.onClick.AddListener(()=> Application.OpenURL(URL));
   }
}
