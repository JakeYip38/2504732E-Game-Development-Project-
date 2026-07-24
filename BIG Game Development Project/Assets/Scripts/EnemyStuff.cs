using UnityEngine;

public class EnemyStuff : MonoBehaviour
{
    //the points which the enemy can move between
    public GameObject PointA;
    public GameObject PointB;
    private Rigidbody2D rb;
    private Transform currentPoint;
    float moveSpeed = 1f;

    //keeps track of enemy's health
    public int enemyHealth = 6;
    public int currentHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = PointB.transform;

        //the enemy's current health when it starts out is what public int enemyHealth is.
        currentHealth = enemyHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        if(currentPoint == PointB.transform)
        {
            rb.linearVelocity = new Vector2(moveSpeed, 0);
        }
        else
        {
            rb.linearVelocity = new Vector2(-moveSpeed, 0);
        }

        //flips when character reaches Point A
        if(Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == PointB.transform)
        {
            currentPoint = PointA.transform;
            Vector3 ls = transform.localScale;
            ls.x*= -1f;
            transform.localScale = ls;
        }
        //Flips when character reaches Point B
        if(Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == PointA.transform)
        {
            currentPoint = PointB.transform;
            Vector3 ls = transform.localScale;
            ls.x*= -1f;
            transform.localScale = ls;
        }
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

}
