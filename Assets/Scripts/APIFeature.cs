
    using UnityEngine;

    public  abstract class APIFeature : MonoBehaviour
    {
        [HideInInspector] public string apiURL = "";
        [HideInInspector] public string Response;
        public float apiRepeatRateInSeconds = 0.5f;
        public abstract void PerformMechanic();
        
        private void Start()
        {
            CheckResponseJson.Instance.GetJsonResponse(apiURL,this,apiRepeatRateInSeconds);
            InvokeRepeating(nameof(PerformMechanic),apiRepeatRateInSeconds,apiRepeatRateInSeconds);
        }

        
    }
