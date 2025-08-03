using UnityEngine;
using UnityEngine.InputSystem;

public class GeraltMovementMap : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    private Vector3 target;

    void Start()
    {
        target = transform.position;
    }

    void Update()
    {
        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            // Convert mouse position to world position
            Vector2 mouseWorld = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

            // Check if mouse is over a 2D collider with tag "Node"
            Collider2D hit = Physics2D.OverlapPoint(mouseWorld);
            if (hit != null && hit.CompareTag("Node"))
            {
                target = new Vector3(mouseWorld.x, mouseWorld.y, transform.position.z);
                Debug.Log("Moving to: " + target);
            }
            else
            {
                Debug.Log("Clicked on nothing or non-Node object");
            }
        }

        // Move the object toward the target
        transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
    }
}
