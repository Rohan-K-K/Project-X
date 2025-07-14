using UnityEngine;

public class TriggerDetector : MonoBehaviour
{
    //script to tell parent object when a child trigger has been entered b/c Unity :D
    public bool triggerEntered;
    [Tooltip("Set to true if trigger only meant to detect player")]
    public string tagToDetect = "null";

    public GameObject collisionObject;
    void OnTriggerStay(Collider other)
    {
        collisionObject = other.gameObject;
        if (tagToDetect != "null") 
        {
            if (other.CompareTag(tagToDetect))
            {
                triggerEntered = true;
            }
        }
        else
        {
            triggerEntered = true;
        }
    }

    void OnTriggerExit()
    {
        triggerEntered = false;    
    }
}
