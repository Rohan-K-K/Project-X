using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Components")]
    public Rigidbody2D playerRB;
    public Transform playerBody;

    [Header("Movement")]
    public float playerWalkSpd;
    float playerMoveSpd;

    [Header("Physics")]
    [SerializeField] float playerDragForce;

    void Start()
    {
        //assign player components to correct variables
        playerRB = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
        playerBody = GetComponent<Transform>();

        //configure player components properly
        playerRB.linearDamping = playerDragForce;
    }

    void Update()
    {
        //TODO: remove this later
        playerMoveSpd = playerWalkSpd;
        playerRB.linearDamping = playerDragForce;


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
        Vector2 moveVector = moveDir.normalized * playerMoveSpd;
        playerRB.AddForce(moveVector, ForceMode2D.Force);
    }
}
