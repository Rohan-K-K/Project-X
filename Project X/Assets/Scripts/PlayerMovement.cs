using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Components")]
    public Rigidbody playerRB;
    public Transform playerBody;
    public PlayerInputs inputs;

    [Header("Movement")]
    public float playerWalkSpd;

    [Header("Skills")]
    public float playerDashSpd;
    public float dashCooldown;
    public float dashDuration;

    [Header("Physics")]
    [SerializeField] float playerDragForce;

    float playerMoveSpd;

    //logic
    float timer;
    bool dashReady;
    bool playerDashing;

    void Start()
    {
        //assign player components to correct variables
        playerBody = GetComponent<Transform>();
        playerRB = GetComponent<Rigidbody>();
        inputs = GetComponent<PlayerInputs>();

        //configure player components properly
        playerRB.linearDamping = playerDragForce;
        playerRB.freezeRotation = true;

        //reset player skills
        dashReady = true;
        playerDashing = false;
    }

    void Update()
    {
        //TODO: add state handler instead of this segment
        //TODO: may not need to implement state handler, if so, just replace playerMoveSpd with playerWalkSpd completely
        //TODO: remove these lines once done optimizing movement
        playerMoveSpd = playerWalkSpd;
        playerRB.linearDamping = playerDragForce;

        //get player inputs
        Vector3 movementDireciton = GetMovementInput();

        //move player
        MovePlayer(movementDireciton);
        LimitPlayerSpd(playerRB.linearVelocity);
        DashPlayer(movementDireciton);
    }

    /*
    Input scripts
    */

    public Vector3 GetMovementInput()
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

    public void MovePlayer(Vector3 moveDir)
    {
        //calculate which direction to move the player in
        Vector3 moveForce = moveDir.normalized * playerMoveSpd;
        //add force to rigidbody to move player in desired direction
        playerRB.AddForce(moveForce, ForceMode.Force);
    
    }

    public void LimitPlayerSpd(Vector3 originalVelocity)
    {
        if (originalVelocity.magnitude > playerWalkSpd && ! playerDashing)
        {
            Vector3 limitedSpd = originalVelocity.normalized * playerWalkSpd;
            playerRB.linearVelocity= limitedSpd;
        }
    }

    public void DashPlayer(Vector3 moveDir)
    {
        if (Input.GetKeyDown(inputs.dash) && dashReady)
        {
            //calculate which direction to move the player in
            Vector3 moveForce = moveDir.normalized * playerDashSpd;
            //add force to rigidbody to move player in desired direction
            playerRB.AddForce(moveForce, ForceMode.Impulse);
            dashReady = false;
            playerDashing = true;
            timer = 0;
        }
        else if (playerDashing)
        {
            resetDash();
        }
    }

    public void resetDash()
    {
        timer += Time.deltaTime;
        if (timer > dashCooldown)
        {
            dashReady = true;
        }
        if (timer > dashDuration)
        {
            playerDashing = false;
        }
    }
}
