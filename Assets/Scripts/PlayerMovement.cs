using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Components")]
    public Rigidbody playerRB;
    public Transform playerBody;

    [Header("Movement")]
    public float playerWalkSpd;
    float playerMoveSpd;

    void Start()
    {
        //assign player components to correct variables
        playerRB = GetComponent<Rigidbody>();
        playerBody = GetComponent<Transform>();

        //configure player components properly
        
    }

    void Update()
    {
        //TODO: remove this later
        playerMoveSpd = playerWalkSpd;

        //Get player inputs
        Vector2 movementDirection = findMovementInput();

        //Move player
        movePlayer(movementDirection);
    }

    public Vector2 findMovementInput()
    {
        Vector2 inputDir;
        float xInput; //horizontal movement
        float yInput; //vertical movement

        //get actual inputs
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");

        //turn inputs into Vector2 and return it
        inputDir = Vector2.right * xInput + Vector2.up * yInput;
        return inputDir;
    }

    public void movePlayer(Vector2 moveDir)
    {
        float xMoveDir = moveDir.normalized.x * playerMoveSpd;
        float yMoveDir = moveDir.normalized.y * playerMoveSpd;
        playerBody.position = new Vector3(xMoveDir, yMoveDir, 0);
    }
}
