
    using UnityEngine;

    public  abstract class FeatureBaseClass : MonoBehaviour
    {
        public bool needAPI = true;
        [HideInInspector] public string apiURL = "";
        [HideInInspector] public string Response;
        public float updateRateInSeconds = 0.5f;
        public abstract void PerformMechanic();
        
        protected virtual void Start()
        {
            if (needAPI)
            {
                CheckResponseJson.Instance.GetJsonResponse(apiURL,this,updateRateInSeconds);
            }
            InvokeRepeating(nameof(PerformMechanic),1,updateRateInSeconds);
        }

        
    }
