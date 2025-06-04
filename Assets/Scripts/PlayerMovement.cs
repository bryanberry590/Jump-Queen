using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 5f;

    private Vector2 movement;
    private bool isJumping;

    void Start()
    {
        movement = Vector2.zero;
        isJumping = false;
    }
    
    void Update()
    {

        if (movement != Vector2.zero)
        {
            rb.linearVelocity += movement * moveSpeed * Time.deltaTime;
        }

    }
    
    void OnWalking(InputValue value)
    {
        movement = value.Get<Vector2>();    
    }
    
    void OnJump(InputValue value)
    {
        if (value.isPressed && !isJumping)
        {
            isJumping = true;
        }
    }
}
