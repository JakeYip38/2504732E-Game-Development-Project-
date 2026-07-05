using UnityEngine;
using System.Collections;

public class PuzzleShield : MonoBehaviour
{
    private Vector3 mousePosition;
	public float moveSpeed = 0.1f;

	// Use this for initialization
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButton(1))
        {
            mousePosition=Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //moves object by a certain amount using linear interpolation (lerp)
			transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
        }
    }
}
