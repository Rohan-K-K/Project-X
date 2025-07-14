using UnityEngine;
using UnityEngine.AI;

public class PlayerCombat : MonoBehaviour
{
    public PlayerInputs inputs;

    public void Start()
    {
        inputs = GetComponent<PlayerInputs>();
        inputs = GetComponent<PlayerInputs>();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy") && Input.GetMouseButtonDown(0))
        {
            Debug.Log("Hit Enemy");
            other.gameObject.SetActive(false);
        }
    }


}
