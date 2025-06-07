using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 5f;

    private Vector2 movement;
    private bool isTouchingGround;


    void Start()
    {
        isTouchingGround = true;
        movement = Vector2.zero;
    }
    
    void Update()
    {

        if (movement != Vector2.zero)
        {
            rb.linearVelocity += movement * moveSpeed * Time.deltaTime;
        }
        isGrounded();

    }
    
    void OnWalking(InputValue value)
    {
        movement = value.Get<Vector2>();    
    }
    
    void OnJump(InputValue value)
    {
        // have an isGrounded function
        if (value.isPressed && isTouchingGround)
        {
            isTouchingGround = false;
            Vector2 currentVelocity = rb.linearVelocity;
            currentVelocity = new Vector2(currentVelocity.x, currentVelocity.y + 5f);
            rb.linearVelocity = currentVelocity;
        }
    }

    private void isGrounded()
    {
        //raycast to ground and if the player is touching the ground then set isGrounded to true;
        //this method will handle the value of isGrounded
        
        float distanceToGround = GetComponent<Collider2D>().bounds.size.y / 2;
        
        
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, distanceToGround + 0.05f, LayerMask.GetMask("Ground"));
       
        Debug.DrawRay(transform.position, Vector2.down * (distanceToGround + 0.05f), Color.red);

        // the collided object should be from the map grid layer
        if (hit.collider != null)
        {
            isTouchingGround = true;
        }
        else
        {
            isTouchingGround = false;
        }
        Debug.Log("isTouchingGround: " + isTouchingGround);
    }
    
}
