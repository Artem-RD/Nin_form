using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    private Rigidbody2D PlayerRb;

    public float HorizontalMove = 0f;

    private bool FacingRight = true;

    [Header("Player Movment Settings")]
    public float speed = 1f;
    public float jumpForce = 8f;
    public float FastSpeed = 1f;
    private float realSpeed;
    private bool speedLock;
    private bool jumpLock = false;
    

    [Header("Player Animation Settings")]
    public Animator animator;

    [Header("Ground Cheker Settings")]
    public bool isGrounded = false;
    [SerializeField] private Transform GroundCheck;
    [SerializeField] private LayerMask Ground;
    [SerializeField] private float checkGroundRadius;
    public Transform topCheck;
    private float RadiusTopCheck;
    public LayerMask Roof;
    public Collider2D poseStand;
    public Collider2D poseSquat;

    void Start()
    {
        PlayerRb = GetComponent<Rigidbody2D>();
        realSpeed = speed;
        RadiusTopCheck = topCheck.GetComponent<CircleCollider2D>().radius;
    }

    void Update()
    {
        Walk();
        Jump();
        Run();
        SquatCheck();

        if (isGrounded == false)
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }

        if (HorizontalMove < 0 && FacingRight)
        {
            Flip();
        }
        else if (HorizontalMove > 0 && !FacingRight)
        {
            Flip();
        }
    }

    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            Physics2D.IgnoreLayerCollision(8, 9, true);
            Invoke("IgnoreLayerOff", 0.5f);
        }

        if (isGrounded && Input.GetKeyDown(KeyCode.Space) && !jumpLock)
        {
            PlayerRb.velocity = new Vector2 (PlayerRb.velocity.x, 0);
            PlayerRb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }

        if(PlayerRb.velocity.y == 0)
        {
            animator.SetBool("zeroVelocity", true);
        }
        else
        {
            animator.SetBool("zeroVelocity", false);
        }
    }

    private void IgnoreLayerOff()
    {
        Physics2D.IgnoreLayerCollision(8, 9, false);
    }

    private void Walk()
    {
        HorizontalMove = Input.GetAxisRaw("Horizontal") * realSpeed;

        animator.SetFloat("Walk", Mathf.Abs(HorizontalMove));

        Vector2 targetVelocity = new Vector2(HorizontalMove * 10f, PlayerRb.velocity.y);

        PlayerRb.velocity = targetVelocity;
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    private void Flip()
    {
        FacingRight = !FacingRight;
        transform.Rotate(0f, 180f, 0f);
    }


    private void CheckGround()
    {
        Vector3 OverlapCirclePosition = GroundCheck.position;
        isGrounded = Physics2D.OverlapCircle(OverlapCirclePosition,checkGroundRadius,Ground);
    }

    private void Run()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("Run", true);
            realSpeed = FastSpeed;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                speedLock = true;
            }
        }
        else
        {
            animator.SetBool("Run",false);
            if (!speedLock)
            {
                realSpeed = speed;
            }
            else if(speedLock && isGrounded)
            {
                speedLock = false;
            }
            else
            {
                realSpeed = FastSpeed;
            }
        }
    }

    private void SquatCheck()
    {
        if(Input.GetKey(KeyCode.S) && isGrounded)
        {
            animator.SetBool("squat", true);
            poseStand.enabled = false;
            poseSquat.enabled = true;
            jumpLock = true;
        }
        else if(!Physics2D.OverlapCircle(topCheck.position,RadiusTopCheck,Roof))
        {
            animator.SetBool("squat", false);
            poseStand.enabled = true;
            poseSquat.enabled = false;
            jumpLock = false;
        }
    }

}
