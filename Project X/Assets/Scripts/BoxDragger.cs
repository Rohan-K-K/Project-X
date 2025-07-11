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
        boxTransform = GetComponent<Transform>();
        boxRB = GetComponent<Rigidbody>();

        boxRB.constraints = RigidbodyConstraints.FreezeRotation;
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
            boxRB.constraints = RigidbodyConstraints.None;

            Vector3 moveDirection = player.getMovementInput();
            Vector3 moveForce = moveDirection.normalized * boxPushSpd * 10f;

            boxRB.AddForce(moveForce, ForceMode.Force);
        }
        else
        {
            boxRB.constraints = RigidbodyConstraints.FreezePosition;
        }
    }
    
    
}
