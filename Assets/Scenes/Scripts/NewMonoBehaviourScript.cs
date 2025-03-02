using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    private float horizontalInput;
    private bool jumpKeyPressed;
    private bool isGrounded;

    public float jumpPower;
    public float walkSpeed;

    Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal") * walkSpeed;

        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && isGrounded)
        {
            Jump();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
        Debug.Log("Is Grounded");
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
        Debug.Log("In Air");
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontalInput, GetComponent<Rigidbody2D>().linearVelocity.y);
        if (jumpKeyPressed)
        {
            if (!isGrounded)
            {
                jumpKeyPressed = false;
                Debug.Log("Can't Jump");
                return;
            }
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jumpKeyPressed = false;
        }
    }

    void Jump()
    {
        rb.AddForce(Vector2.up*jumpPower, ForceMode2D.Impulse);
        isGrounded = false;
    }
}
