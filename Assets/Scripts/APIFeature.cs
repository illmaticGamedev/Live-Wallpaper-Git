
    using UnityEngine;

    public  abstract class APIFeature : MonoBehaviour
    {
       [HideInInspector] public string Response;
        public abstract void PerformMechanic();
        
    }
