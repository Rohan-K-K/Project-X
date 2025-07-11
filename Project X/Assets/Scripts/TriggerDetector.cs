using UnityEngine;

public class TriggerDetector : MonoBehaviour
{
    //script to tell parent object when a child trigger has been entered b/c Unity :D
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
