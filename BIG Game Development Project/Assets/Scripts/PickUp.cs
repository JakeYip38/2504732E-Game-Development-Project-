using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    private bool dragging = false;
    private Vector3 offset;
    // Update is called once per frame
    	
	void Update()
    {
        if(dragging)
        {
            //move object, taking into account original offset
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        }
	}

    
    private void OnMouseDown()
    {
        //record the difference between the object's centre, and the clicked point on the camera plane.
       offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
       dragging = true;
    }
    private void OnMouseUp()
    {
        //stop dragging.
        dragging = false;
    }
}
