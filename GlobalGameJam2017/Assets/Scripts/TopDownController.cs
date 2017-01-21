using UnityEngine;
using System.Collections;


public class TopDownController : MonoBehaviour
{
    [SerializeField]
    private float _playerID;
    public float PlayerID { get { return _playerID; } set { _playerID = value; } }

    [SerializeField]
    private float _health;
    public float Health { get { return _health; } set { _health = value; } }
    [SerializeField]
    private float _healthmax;
    public float HealthMax { get { return _healthmax; } set { _healthmax = value; } }
    private float healthRegenCurrent;
    [SerializeField]
    private Vector3 _movement;
    public Vector3 Movement { get { return _movement; } set { _movement = value; } }
    [SerializeField]
    private float _movementbackstepmult;
    public float MovementBackstepMult { get { return _movementbackstepmult; } set { _movementbackstepmult = value; } }
    [SerializeField]
    private float _movementsprintmult;
    public float MovementSprintMult { get { return _movementsprintmult; } set { _movementsprintmult = value; } }

    [SerializeField]
    private Rigidbody rigidself;
    [SerializeField]
    private Transform aimNode;

    private Vector3 currentVelocity;

    // Jump variables
    public bool isOnGround;
    public bool isTouching;

    public KeyCode PlayerInputA;
    public KeyCode PlayerInputX;
    public KeyCode PlayerInputY;
    public KeyCode PlayerInputB;
    public KeyCode PlayerInputL3;

    // Use this for initialization
    protected void Start()
    {
        isOnGround = true;
    }

    // Update is called once per frame
    protected  void Update()
    {
        HandleInput();
    }

    void HandleInput()
    {
        if (isOnGround)
        {
            // Establish a temporary movement vector
            Vector3 moveGoal = Vector3.zero;

            // If moving forward or backward, add only the forward backward component (z)
            if (Input.GetKey(KeyCode.W))
                moveGoal.z = Movement.z;
 
            else if (Input.GetKey(KeyCode.S))
                moveGoal.z = -Movement.z;

            // If moving sideways, add only the sideways component (x)
            if (Input.GetKey(KeyCode.A))
                moveGoal.x = -Movement.x;
            else if (Input.GetKey(KeyCode.D))
                moveGoal.x = Movement.x;
            if (Input.GetAxis("L Horizontal Controller") != 0 ){
                moveGoal.x = Input.GetAxis("L Horizontal Controller");
            }
            if (Input.GetAxis("L Vertical Controller") != 0)
            {
                moveGoal.z = Input.GetAxis("L Vertical Controller");
            }
            /*
            if (Input.GetAxis("R Horizontal Controller") != 0)
            {
                moveGoal.x = Input.GetAxis("R Horizontal Controller");
            }
            if (Input.GetAxis("R Vertical Controller") != 0)
            {
                moveGoal.z = Input.GetAxis("R Vertical Controller");
            }*/
            Vector3 Pos = transform.position;
            Pos.z += Input.GetAxis("R Vertical Controller");
            Pos.x += Input.GetAxis("R Horizontal Controller");
            Debug.DrawLine(transform.position,  Pos);


            // Normalize it
            moveGoal.Normalize();

            // Here is where the magic happens
            // Usually if you have a z forward of 20 and an x sideways of 5 if you just add them together the character moves more than the maximum of 20 on a diagonal, not how people move
            // So if you normalize the whole mess, then restore the leading axis (z) take whatever percentage of the current move vector in comparison to the goal movement speed and use it as a
            // multiplier against the secondary axis (x) magnitude, you establish a move vector that is limited to a maximum magnitude of the leading axis.
            // Save I am ignoring y, because it is for jumping, which doesn't need any of this.
            moveGoal.z *= Movement.z;
            moveGoal.x *= (1 - (moveGoal.y / Movement.y)) * Movement.x;

            // If the z is negative the player is moving backwards, they should be backstepping, therefore they need to use the backstepMult
            if (moveGoal.z < 0)
                moveGoal.z *= MovementBackstepMult;

            // Sprinting, if moving forward
            if (Input.GetKey(KeyCode.LeftShift)|| Input.GetKey(KeyCode.JoystickButton8))
            {
                if (moveGoal.z > 0)
                    moveGoal.z *= MovementSprintMult;
            }

            // Then it is just a matter of using the beautiful SmoothDamp method (much like a spring, but unable to go past the goal) to figure out the best way of making the player move naturally
            transform.position = Vector3.SmoothDamp(transform.position, transform.position + transform.TransformDirection(moveGoal), ref currentVelocity, 1);
        }

        // Action logic
        // Shoot
        if (Input.GetButton("Fire1")|| Input.GetKey(KeyCode.JoystickButton0))
        {
            Input.
            print("A");
        }
    }

    void OnCollisionStay(Collision collision)
    {
        isTouching = true;
    }
}
