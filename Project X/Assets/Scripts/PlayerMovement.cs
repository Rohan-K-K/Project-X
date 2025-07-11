using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Components")]
    public Rigidbody playerRB;
    public Transform playerBody;
    public PlayerInputs inputs;

    [Header("Movement")]
    public float playerWalkSpd;
    public float playerDashSpd;

    [Header("Physics")]
    [SerializeField] float playerDragForce;

    float playerMoveSpd;

    void Start()
    {
        //assign player components to correct variables
        playerBody = GetComponent<Transform>();
        playerRB = GetComponent<Rigidbody>();
        inputs = GetComponent<PlayerInputs>();

        //configure player components properly
        playerRB.linearDamping = playerDragForce;
        playerRB.freezeRotation = true;
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

    public void DashPlayer(Vector3 moveDir)
    {
        if (Input.GetKeyDown(inputs.dash))
        {
            //calculate which direction to move the player in
            Vector3 moveForce = moveDir.normalized * playerDashSpd;
            //add force to rigidbody to move player in desired direction
            playerRB.AddForce(moveForce, ForceMode.Impulse);
        }
    }
}
