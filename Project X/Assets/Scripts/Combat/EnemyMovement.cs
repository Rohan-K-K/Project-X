using NUnit.Framework;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public TriggerDetector enemyVision;
    public PlayerMovement player;
    public Rigidbody enemyRb;
    public Transform enemyBody;
    public float enemyMoveSpd;
    public float enemyAttackStr;
    public bool enemyAggroed;

    public void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        enemyRb.constraints = RigidbodyConstraints.FreezeRotation;
        enemyBody = GetComponent<Transform>();
        player = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
        enemyAggroed = false;
    }

    public void Update()
    {
        IsEnemyAggroed();
        EnemyChasePlayer();
    }

    public void IsEnemyAggroed()
    {
        if (enemyVision.triggerEntered && !enemyAggroed)
        {
            Debug.Log("Enemy Detected Player");
            enemyAggroed = true;
        }
    }

    public void EnemyChasePlayer()
    {
        if (enemyAggroed)
        {
            Vector3 moveDir = player.playerBody.position - transform.position;
            enemyRb.AddForce(moveDir.normalized * enemyMoveSpd);
        }
    }   
}
