using UnityEngine;

public class BoxDragger : MonoBehaviour
{
    [Header("Box")]
    public Transform boxTransform;
    public Rigidbody boxRB;
    public TriggerDetector boxTrigger;
    public float boxPushSpd;

    [Header("Player")]
    public PlayerMovement player;
    public PlayerInputs inputs;

    bool playerGrabbingBox;

    void Start()
    {
        //assign box componenets
        boxTransform = GetComponent<Transform>();
        boxRB = GetComponent<Rigidbody>();

        //prevent box from rotating
        boxRB.constraints = RigidbodyConstraints.FreezeRotation;
        boxRB.isKinematic = true;
    }

    void Update()
    {
        IsPlayerGrabbing();
        MoveBox();
    }

    void IsPlayerGrabbing()
    {
        playerGrabbingBox = boxTrigger.triggerEntered && Input.GetKey(inputs.interact);
    }

    void MoveBox()
    {
        if (playerGrabbingBox)
        {
            //unlock box constraints so it can be moved
            boxRB.constraints = RigidbodyConstraints.None;
            boxRB.constraints = RigidbodyConstraints.FreezeRotation;
            boxRB.isKinematic = false;
            //calculate how fast to push/pull the box and in what direction
            Vector3 moveDirection = player.GetMovementInput();
            Vector3 moveForce = moveDirection.normalized * boxPushSpd * 10f;
            //push/pull the box
            boxRB.AddForce(moveForce, ForceMode.Force);
        }
        else
        {
            //lock the box rigidbody if not being pushed to prevent unwanted movements
            boxRB.isKinematic = true;
            boxRB.constraints = RigidbodyConstraints.FreezePosition;
        }
    }
    
    
}
