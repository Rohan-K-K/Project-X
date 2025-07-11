using UnityEngine;

public class TriggerDetector : MonoBehaviour
{
    public bool triggerEntered;

    void OnTriggerStay()
    {
        triggerEntered = true;
    }

    void OnTriggerExit()
    {
        triggerEntered = false;    
    }
}
