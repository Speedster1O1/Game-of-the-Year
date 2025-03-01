using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    private float horizontalInput;
    private bool jumpKeyPressed;
    private bool isGrounded;

    public float jumpPower;
    public float walkSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        jumpPower = 5;
        walkSpeed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal") * walkSpeed;

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
        {
            jumpKeyPressed = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            isGrounded = true;
            Debug.Log("Is Grounded");
        }


    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            isGrounded = false;
            Debug.Log("In Air");
        }


    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().linearVelocity = new Vector2(horizontalInput, GetComponent<Rigidbody2D>().linearVelocity.y);
        if (jumpKeyPressed)
        {
            if (!isGrounded)
            {
                jumpKeyPressed = false;
                Debug.Log("Can't Jump");
                return;
            }
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jumpKeyPressed = false;
        }
    }
}
