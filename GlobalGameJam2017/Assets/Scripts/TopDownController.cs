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
    private Rigidbody body;

    Animator animator;
    // Jump variables
    public bool isOnGround;
    public bool dead;

    KeyCode PlayerInputA;
    KeyCode PlayerInputX;
    KeyCode PlayerInputY;
    KeyCode PlayerInputB;
    KeyCode PlayerInputL3;
    KeyCode PlayerInputLB;
    KeyCode PlayerInputRB;

    public Instrument _Instrument;

    bool usedHeavy;
    float HeavyWait;
    Vector3 moveGoal;
    // Use this for initialization
    protected void Start()
    {
        animator = GetComponent<Animator>();

        body = GetComponent<Rigidbody>();
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
                PlayerInputLB = KeyCode.Joystick1Button4;
                PlayerInputRB = KeyCode.Joystick1Button5;
                break;
            case 2:
                PlayerInputA = KeyCode.Joystick2Button0;
                PlayerInputX = KeyCode.Joystick2Button2;
                PlayerInputY = KeyCode.Joystick2Button3;
                PlayerInputB = KeyCode.Joystick2Button1;
                PlayerInputL3 = KeyCode.Joystick2Button8;
                PlayerInputLB = KeyCode.Joystick2Button4;
                PlayerInputRB = KeyCode.Joystick2Button5;
                break;
            case 3:
                PlayerInputA = KeyCode.Joystick3Button0;
                PlayerInputX = KeyCode.Joystick3Button2;
                PlayerInputY = KeyCode.Joystick3Button3;
                PlayerInputB = KeyCode.Joystick3Button1;
                PlayerInputL3 = KeyCode.Joystick3Button8;
                PlayerInputLB = KeyCode.Joystick3Button4;
                PlayerInputRB = KeyCode.Joystick3Button5;
                break;
            case 4:
                PlayerInputA = KeyCode.Joystick4Button0;
                PlayerInputX = KeyCode.Joystick4Button2;
                PlayerInputY = KeyCode.Joystick4Button3;
                PlayerInputB = KeyCode.Joystick4Button1;
                PlayerInputL3 = KeyCode.Joystick4Button8;
                PlayerInputLB = KeyCode.Joystick4Button4;
                PlayerInputRB = KeyCode.Joystick4Button5;
                break;
        }
    }
    void UpdateUI()
    {
        if (PlayerID == 1)
        {
            UIPlayer.UIplayers[UIPlayer.Player.Pink].SetHealth(Health);
            if (_Instrument.AggroLightCoolDownWait > 0)
            {
                UIPlayer.UIplayers[UIPlayer.Player.Pink].ToggleSkill(UIPlayer.Input.rb);
            }
            if (_Instrument.AggroHeavyCoolDownWait > 0)
            {
                UIPlayer.UIplayers[UIPlayer.Player.Pink].ToggleSkill(UIPlayer.Input.rt);
            }
            if (_Instrument.UtilityCoolDownWait > 0)
            {
                UIPlayer.UIplayers[UIPlayer.Player.Pink].ToggleSkill(UIPlayer.Input.lt);
            }
            if (_Instrument.DefenseCoolDownWait > 0)
            {
                UIPlayer.UIplayers[UIPlayer.Player.Pink].ToggleSkill(UIPlayer.Input.lb);
            }
            else if (PlayerID == 2)
            {
                UIPlayer.UIplayers[UIPlayer.Player.Bub].SetHealth(Health);
                if (_Instrument.AggroLightCoolDownWait > 0)
                {
                    UIPlayer.UIplayers[UIPlayer.Player.Bub].ToggleSkill(UIPlayer.Input.rb);
                }
                if (_Instrument.AggroHeavyCoolDownWait > 0)
                {
                    UIPlayer.UIplayers[UIPlayer.Player.Bub].ToggleSkill(UIPlayer.Input.rt);
                }
                if (_Instrument.UtilityCoolDownWait > 0)
                {
                    UIPlayer.UIplayers[UIPlayer.Player.Bub].ToggleSkill(UIPlayer.Input.lt);
                }
                if (_Instrument.DefenseCoolDownWait > 0)
                {
                    UIPlayer.UIplayers[UIPlayer.Player.Bub].ToggleSkill(UIPlayer.Input.lb);
                }
            }

        }
    }
    // Update is called once per frame
    protected void Update()
    {
        UpdateUI();
        HandleInput();
        if (Health > HealthMax) {
            Health = HealthMax;
        }
        if (Health <= 0) {
            dead = true;
            this.enabled = false;
        }
    }
    void keyboardMove() {
        // Establish a temporary movement vector
        moveGoal = Vector3.zero;

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
    }
    void HandleInput()
    {

        if (!usedHeavy && !dead)
        {
            moveGoal = Vector3.zero;

            if (Input.GetAxis("L Horizontal Controller " + PlayerID) != 0)
            {
                moveGoal.x = Input.GetAxis("L Horizontal Controller " + PlayerID);
            }
            if (Input.GetAxis("L Vertical Controller " + PlayerID) != 0)
            {
                moveGoal.z = Input.GetAxis("L Vertical Controller " + PlayerID);
            }
            Vector3 Pos = transform.position;
            Pos.z += Input.GetAxis("L Vertical Controller " + PlayerID);
            Pos.x += Input.GetAxis("L Horizontal Controller " + PlayerID);


            // print(Pos.x);
            Debug.DrawLine(transform.position, Pos);
            Pos -= transform.position;

            if (Pos.magnitude > 0)
            {
                transform.rotation = Quaternion.AngleAxis(((Mathf.Atan2(Pos.z, Pos.x) / Mathf.PI) * -180) + 90, Vector3.up);
            }

            moveGoal.z *= Movement.z;
            moveGoal.x *= Movement.x;

            // Sprinting, if moving forward
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(PlayerInputL3))
            {
                if (moveGoal.z > 0)
                    moveGoal.z *= MovementSprintMult;
            }

            animator.SetFloat("Movespeed", moveGoal.magnitude);
            // Then it is just a matter of using the beautiful SmoothDamp method (much like a spring, but unable to go past the goal) to figure out the best way of making the player move naturally
            body.MovePosition(Vector3.SmoothDamp(body.position, body.position + moveGoal, ref currentVelocity, 1));


            // Action logic
            // Shoot
            Vector3 Pos2 = transform.position;
            Pos2 += new Vector3(Input.GetAxis("R Horizontal Controller " + PlayerID), 0, Input.GetAxis("R Vertical Controller " + PlayerID));
            Debug.DrawLine(transform.position, Pos2);
            Vector3 attackDirction = Pos2 - transform.position;

            if (Input.GetAxis("R Vertical Controller " + PlayerID) != 0 || Input.GetAxis("R Horizontal Controller " + PlayerID) != 0)
            {
                _Instrument.Attack(attackDirction);
            }

            if (Input.GetKey(PlayerInputLB))
            {
                _Instrument.Defense(attackDirction);
            }
            //left LT
            if (Input.GetAxis("Controller Triggers Left " + PlayerID) > 0.06)
            {
                _Instrument.Utility(attackDirction);
            }
            //right RT
            else if (Input.GetAxis("Controller Triggers Right " + PlayerID) > 0.06)
            {
                print(Input.GetAxisRaw("Controller Triggers Right " + PlayerID));
                _Instrument.AggroHeavy(attackDirction);
                animator.SetBool("Heavyattack", true);
                usedHeavy = true;
                HeavyWait = animator.GetCurrentAnimatorStateInfo(0).length;
            }

            if (Input.GetKey(PlayerInputRB))
            {
                _Instrument.AggroLight(attackDirction);
            }

            if (Input.GetKey(PlayerInputA) || Input.GetKey(KeyCode.Space))
            {
                print("A");
            }
            if (Input.GetKey(PlayerInputB))
            {

                print("B");
            }
        }
        else if (HeavyWait < -100 && usedHeavy)
        {
            animator.SetBool("Heavyattack", false);
            usedHeavy = false;
        }
        else if (usedHeavy) {
            HeavyWait -= animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
            print(HeavyWait);
        }
    }

    void OnCollisionStay(Collision collision)
    {
       
    }
}
