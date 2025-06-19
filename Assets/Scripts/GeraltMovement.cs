using UnityEngine;
using UnityEngine.InputSystem;
public class GeraltMovement : MonoBehaviour
{
    // variables to hold action references
    InputAction moveAction;
    InputAction InputAction;
    [SerializeField] float moveSpeed = 10f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    public bool buttonInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveAction = InputSystem.actions.FindAction("Move");
        InputAction = InputSystem.actions.FindAction("Interact");
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = moveInput * moveSpeed;
        moveInput = moveAction.ReadValue<Vector2>();
        buttonInput = InputAction.ReadValue<bool>();
        if (buttonInput)
        {
            Debug.Log("Przycisk");
            transform.position += new Vector3(moveInput.x, 0, moveInput.y) * Time.deltaTime;
        }
    }
    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

}
