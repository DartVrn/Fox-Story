using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement vars")]
    [SerializeField] private float jumpForce;
    [SerializeField] private float speed;
    [SerializeField] private bool isGrounded = false;

    [Header("Settings")]
    [SerializeField] private Transform groundColliderTransform;
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private float jumpOffset;
    [SerializeField] private LayerMask groundMask;
    private Rigidbody2D rb;

    [SerializeField] private AudioSource jumpSound;

    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector3 overlapCirclePosition = groundColliderTransform.position;
        isGrounded = Physics2D.OverlapCircle(overlapCirclePosition, jumpOffset, groundMask);
        
    }
    public void Move(float direction, bool isJumpButtonPressed)
    {
        if (isJumpButtonPressed)
            Jump();
        if (Mathf.Abs(direction) > 0.01f)
            HorizontalMovement(direction);
    }

    private void Jump()
    //{
     //   if (isGrounded)
     //  {
      //      rb.velocity = new Vector2(rb.velocity.x, jumpForce);
      //      isGrounded = false;
      //  }
    //}

     {
       if(isGrounded)
      rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        jumpSound.Play();
    }


    private void HorizontalMovement(float direction)
    {
        rb.velocity = new Vector2(curve.Evaluate(direction), rb.velocity.y);
    }
    private void Update()
    {
        if (Input.GetAxis("Horizontal") < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name.Equals("Platform"))
        {
            this.transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Platform"))
        {
            this.transform.parent = null;
        }
    }




}
