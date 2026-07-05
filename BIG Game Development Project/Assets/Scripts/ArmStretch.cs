using UnityEngine;

public class ArmStretch : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Get mouse position in screen space and convert to world space
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calculate the distance along the Y axis
        float distanceY = mousePosition.y - transform.position.y;

        // Ensure height doesn't go negative
        float targetHeight = Mathf.Max(0.72f, distanceY);

        // Update the SpriteRenderer's size property (Vector2) while keeping the original width
        spriteRenderer.size = new Vector2(spriteRenderer.size.x, targetHeight);
    }
}
