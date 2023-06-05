using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float Speed = 4f; // character speed
    public float jumpingPower = 8f; // charcter jump power
    private float horizontal; // used to get the horizontal inputs

    [SerializeField] private Transform groundCheck; // used to check if ground is under the player
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private LayerMask groudLayer;



    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal"); // user input to see if they go left or right

        if (Input.GetButtonDown("Jump") && IsGrounded()) // allows the character to jump when space is pressed and when if there is ground under the player
        {                                                // then changes height based on time space is held
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * Speed, rb.velocity.y);  // Move the player horizontally based on input
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groudLayer); // checks to see if anything is uder the player

    }
}
