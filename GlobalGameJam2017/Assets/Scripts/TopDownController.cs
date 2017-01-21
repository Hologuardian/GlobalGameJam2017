using UnityEngine;
using System.Collections;


public class TopDownController : MonoBehaviour
{
    [SerializeField]
    private int _playerID;
    public int PlayerID { get { return _playerID; } set { _playerID = value; } }

    [SerializeField]
    private float _health;
    public float Health { get { return _health; } set { _health = value; } }
    [SerializeField]
    private float _healthmax;
    public float HealthMax { get { return _healthmax; } set { _healthmax = value; } }
    [SerializeField]
    private Vector3 _movement;
    public Vector3 Movement { get { return _movement; } set { _movement = value; } }
    [SerializeField]
    private float _movementbackstepmult;
    public float MovementBackstepMult { get { return _movementbackstepmult; } set { _movementbackstepmult = value; } }
    [SerializeField]
    private float _movementsprintmult;
    public float MovementSprintMult { get { return _movementsprintmult; } set { _movementsprintmult = value; } }

    private Vector3 currentVelocity;

    // Jump variables
    public bool isOnGround;
    public bool isTouching;

    KeyCode PlayerInputA;
    KeyCode PlayerInputX;
    KeyCode PlayerInputY;
    KeyCode PlayerInputB;
    KeyCode PlayerInputL3;

    public Instrument _Instrument;

    // Use this for initialization
    protected void Start()
    {
        isOnGround = true;
        HealthMax = 100;
        Health = HealthMax;

        switch (PlayerID) {
            case 1:
                PlayerInputA = KeyCode.Joystick1Button0;
                PlayerInputX = KeyCode.Joystick1Button2;
                PlayerInputY = KeyCode.Joystick1Button3;
                PlayerInputB = KeyCode.Joystick1Button1;
                PlayerInputL3 = KeyCode.Joystick1Button8;
                break;
            case 2:
                PlayerInputA = KeyCode.Joystick2Button0;
                PlayerInputX = KeyCode.Joystick2Button2;
                PlayerInputY = KeyCode.Joystick2Button3;
                PlayerInputB = KeyCode.Joystick2Button1;
                PlayerInputL3 = KeyCode.Joystick2Button8;
                break;
            case 3:
                PlayerInputA = KeyCode.Joystick3Button0;
                PlayerInputX = KeyCode.Joystick3Button2;
                PlayerInputY = KeyCode.Joystick3Button3;
                PlayerInputB = KeyCode.Joystick3Button1;
                PlayerInputL3 = KeyCode.Joystick3Button8;
                break;
            case 4:
                PlayerInputA = KeyCode.Joystick4Button0;
                PlayerInputX = KeyCode.Joystick4Button2;
                PlayerInputY = KeyCode.Joystick4Button3;
                PlayerInputB = KeyCode.Joystick4Button1;
                PlayerInputL3 = KeyCode.Joystick4Button8;
                break;
        }
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
            if (Input.GetKey(KeyCode.A))
                moveGoal.x = -Movement.x;
            else if (Input.GetKey(KeyCode.D))
                moveGoal.x = Movement.x;
            moveGoal.Normalize();

            if (Input.GetAxis("L Horizontal Controller " + PlayerID) != 0 ){
                moveGoal.x = Input.GetAxis("L Horizontal Controller " + PlayerID);
                
            }
            if (Input.GetAxis("L Vertical Controller " + PlayerID) != 0)
            {
                moveGoal.z = Input.GetAxis("L Vertical Controller " + PlayerID);
            }
            Vector3 Pos = transform.position;
            Pos.z += Input.GetAxis("R Vertical Controller " + PlayerID);
            Pos.x += Input.GetAxis("R Horizontal Controller " + PlayerID);
            Debug.DrawLine(transform.position,  Pos);

            transform.rotation = Quaternion.AngleAxis( ((Mathf.Atan2(Pos.z-transform.position.z,Pos.x-transform.position.x)/Mathf.PI)*-180)+90, Vector3.up);
            //transform.Rotate(new Vector3(0,Mathf.Atan2(Pos.z, Pos.x),0));
            //transform.rotation = Quaternion.LookRotation(Pos);
            // Normalize it
            //moveGoal.Normalize();

            // Here is where the magic happens
            // Usually if you have a z forward of 20 and an x sideways of 5 if you just add them together the character moves more than the maximum of 20 on a diagonal, not how people move
            // So if you normalize the whole mess, then restore the leading axis (z) take whatever percentage of the current move vector in comparison to the goal movement speed and use it as a
            // multiplier against the secondary axis (x) magnitude, you establish a move vector that is limited to a maximum magnitude of the leading axis.
            // Save I am ignoring y, because it is for jumping, which doesn't need any of this.
            if (moveGoal.x > 0)
            {
                //print("moveGoal.x *= Movement.x " + moveGoal.x + "*=" + Movement.x);
            }
            moveGoal.z *= Movement.z;
            
            moveGoal.x *= Movement.x;
            
            // Sprinting, if moving forward
            if (Input.GetKey(KeyCode.LeftShift)|| Input.GetKey(PlayerInputL3))
            {
                if (moveGoal.z > 0)
                    moveGoal.z *= MovementSprintMult;
            }

            // Then it is just a matter of using the beautiful SmoothDamp method (much like a spring, but unable to go past the goal) to figure out the best way of making the player move naturally
            transform.position = Vector3.SmoothDamp(transform.position, transform.position + moveGoal, ref currentVelocity, 1);
        }

        // Action logic
        // Shoot
        
        if (Input.GetKey(PlayerInputX))
        {
            _Instrument.AggroLight();
            print("X");
        }
        if (Input.GetKey(PlayerInputY))
        {
            _Instrument.AggroHeavy();
            print("Y");
        }
        if (Input.GetKey(PlayerInputA)||Input.GetKey(KeyCode.Space))
        {
            _Instrument.Utility();
            print("A");
        }
        if (Input.GetKey(PlayerInputB))
        {
            _Instrument.Defense();
            print("B");
        }
    }

    void OnCollisionStay(Collision collision)
    {
        isTouching = true;
    }
}
