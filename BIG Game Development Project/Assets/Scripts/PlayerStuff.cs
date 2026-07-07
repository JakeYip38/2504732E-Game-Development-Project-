using UnityEngine;


public class PlayerStuff : MonoBehaviour
{
    //for moving
    float horizontalInput;
    float moveSpeed = 5f;
    //for flipping sprites
    bool isFacingRight = true;
    //for jumping
    float jumpUp = 7f;
    bool isJump = false;
    //goolia's health
    public GameObject[] heart;
    private int life;
    private int heartIndex;
    //plays audio at certain points
    public AudioClip stepSound;
    public AudioClip jumpSound;
    public AudioClip impactSound;
    public AudioClip pipingSound;

    
    Rigidbody2D rb;

    void Start()
    {
        //assigning Rigidbody2D to a variable
        rb = GetComponent<Rigidbody2D>();

        //gets the length of the array of the hearts, then minuses it by 1 to get the number of elements.
        life = heart.Length;
        heartIndex = life-1;
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

        if (life >= 1)
        {
            if (collision.gameObject.CompareTag("Damage"))
            {
                Debug.Log("I AM IN PAIN");
                Destroy(heart[heartIndex].gameObject);
                // equals to heartIndex = heartIndex - 1 
                heartIndex--;
                Debug.Log(heartIndex);
            }   
        }
        if (heartIndex < 0)
        {
            AudioSource.PlayClipAtPoint(pipingSound, transform.position);
            Debug.Log("Ooops");
        }
    }
    
}
