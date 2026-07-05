using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    //for moving
    float horizontalInput;
    float moveSpeed = 5f;
    //for flipping sprites
    bool isFacingRight = true;
    //for jumping
    float jumpUp = 7f;
    bool isJump = false;
    //plays audio at certain points
    public AudioClip stepSound;
    public AudioClip jumpSound;
    public AudioClip impactSound;
    
    Rigidbody2D rb;

    void Start()
    {
        //assigning Rigidbody2D to a variable
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        //recieves player movement input
        horizontalInput = Input.GetAxis("Horizontal");

        FlipSprite();
        
        //recieves player jump input
        if(Input.GetButtonDown("Jump") && !isJump)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpUp);
            AudioSource.PlayClipAtPoint(jumpSound, transform.position);
            isJump = true;

        }
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontalInput*moveSpeed, rb.linearVelocity.y);
    }

    void FlipSprite()
    {
        //if it faces either side and recieves an opposite input, flip the sprite the opposite way.
        if (isFacingRight && horizontalInput < 0f || !isFacingRight && horizontalInput > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 ls = transform.localScale;
            ls.x*= -1f;
            transform.localScale = ls;
        }
    }

    //reset isJump back to false on contact with the ground.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(impactSound, transform.position);
        isJump = false;
    }
}
