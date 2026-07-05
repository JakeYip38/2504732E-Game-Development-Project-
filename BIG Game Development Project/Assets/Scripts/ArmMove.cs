using UnityEngine;

public class ArmMove : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //pinpoints the mouse cursor's location.
       Vector3 mousePosition = Input.mousePosition;
       mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

       //moves the object it is attached to the location of the cursor.
       Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

       transform.up = direction;
       
    }
    
}
