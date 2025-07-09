using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Components")]
    public Rigidbody playerRB;
    public Transform playerBody;

    [Header("Movement")]
    public float playerWalkSpd;

    float playerMoveSpd;

    [Header("Physics")]
    [SerializeField] float playerDragForce;

    void Start()
    {
        //assign player components to correct variables
        playerBody = GetComponent<Transform>();

        //configure player components properly
        playerRB.linearDamping = playerDragForce;
        playerRB.freezeRotation = true;
    }

    void Update()
    {
        //TODO: add state handler instead of this segment
        playerMoveSpd = playerWalkSpd;
        playerRB.linearDamping = playerDragForce;

        //get player inputs
        Vector3 movementDireciton = getMovementInput();

        //move player
        movePlayer(movementDireciton);
    }

    /*
    Input scripts
    */

    public Vector3 getMovementInput()
    {
        //get acutal inputs from the player
        float xDir = Input.GetAxisRaw("Horizontal");
        float yDir = Input.GetAxisRaw("Vertical");
        //convert inputs into a Vector3
        Vector3 finalDir = Vector3.right * xDir + Vector3.forward * yDir;
        return finalDir;
    }

    /*
    Movement Scripts
    */

    public void movePlayer(Vector3 moveDir)
    {
        Vector3 moveForce = moveDir.normalized * playerMoveSpd;
        playerRB.AddForce(moveForce, ForceMode.Force);
    }
}
