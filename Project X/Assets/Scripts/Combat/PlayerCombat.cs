using UnityEngine;
using UnityEngine.AI;

public class PlayerCombat : MonoBehaviour
{
    public GameObject swingAnimation;
    public PlayerInputs inputs;

    public Animator animator;

    public void Start()
    {
        inputs = GetComponent<PlayerInputs>();
    }

    public void Update()
    {
    }

   /* public void basicAttack()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Instantiate(swingAnimation, transform.position, transform.rotation);
            animator.Play(swingAnimation, -1, 0f);
        }
    } */
}
