using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerBehavior : MonoBehaviour
{
    private float horizontalInput;
    private bool jumpKeyPressed;
    private bool isGrounded;

    public float jumpPower;
    public float walkSpeed;
    public static UnityEvent GameOver;

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

    
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Kill Plane"))
        {
            Debug.Log("Killed");
            SceneManager.LoadScene("Level 1", LoadSceneMode.Single); 
        }
    }


    void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
        
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

    void Die()
    {

    }
}
