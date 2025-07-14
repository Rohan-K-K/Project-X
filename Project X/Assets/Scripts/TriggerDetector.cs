using UnityEngine;

public class TriggerDetector : MonoBehaviour
{
    //script to tell parent object when a child trigger has been entered b/c Unity :D
    public bool triggerEntered;
    [Tooltip("Set to true if trigger only meant to detect player")]
    public bool playerDetector;
    void OnTriggerStay(Collider other)
    {
        if (playerDetector)
        {
            if (other.CompareTag("Player"))
            {
                triggerEntered = true;
            }
        } else
        {
            triggerEntered = true;
        }
    }

    void OnTriggerExit()
    {
        triggerEntered = false;    
    }
}
