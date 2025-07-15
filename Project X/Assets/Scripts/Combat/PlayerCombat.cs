using UnityEngine;
using UnityEngine.AI;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] Animator playerAnimator;
    public TriggerDetector attackHitBox;
    public float playerAttack;

    void Update()
    {
        playerBasicAttack();
    }

    public void playerBasicAttack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Player Attacking");
            playerAnimator.Play("Swing", 0);
            if (attackHitBox.triggerEntered)
            {
                Debug.Log("Player Hit Enemy");
                attackHitBox.collisionObject.GetComponent<EnemyMovement>().DamageEnemy(playerAttack);
            }
        }
    }
}
