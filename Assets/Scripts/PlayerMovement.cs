using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float Speed = 4f; // character speed
    public float jumpingPower = 8f; // charcter jump power
    private float horizontal; // used to get the horizontal inputs

    [Header("")]
    [SerializeField] private Transform groundCheck; // used to check if ground is under the player
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private LayerMask groudLayer;

    // Declaration of the animations for player movement
    [Header("Character Animations")]
    [SerializeField] private Animator playerCharacterAnimator;
    [SerializeField] private AnimationClip characterIdleAnimation;
    [SerializeField] private AnimationClip characterRunAnimation;

    [Header("Character SFX Settings")]
    [SerializeField] private AudioSource characterAudioSource;
    [SerializeField] private AudioClip footstepSFX;
    [SerializeField] private AudioClip jumpSFX;
    [SerializeField] private AudioClip deathSFX;

    [Header("Time Collectible")]
    [SerializeField] private AudioSource collectibleAudioSource;
    [SerializeField] private AudioClip collectibleSFX;

    private void Start()
    {
        playerCharacterAnimator.SetBool("Dead", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Timer.allowInput == true)
        {
            horizontal = Input.GetAxisRaw("Horizontal"); // user input to see if they go left or right

            if (Input.GetButtonDown("Jump") && IsGrounded()) // allows the character to jump when space is pressed and when if there is ground under the player
            {                                                // then changes height based on time space is held
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
                UpdateCharAnimation();
                PlayJumpSFX();
            }
            if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
                UpdateCharAnimation();
            }
        }
        UpdateCharAnimation();
    }

    private void FixedUpdate()
    {
        if (Timer.allowInput == true)
        {
            rb.velocity = new Vector2(horizontal * Speed, rb.velocity.y);  // Move the player horizontally based on input
            UpdateCharAnimation();
        }
        else
        {
            UpdateCharAnimation();
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groudLayer); // checks to see if anything is uder the player
    }

    // This method checks the status of the player nad updates the character animation accordingly
    public void UpdateCharAnimation()
    {
        // Checking to see if player is running right and flipping the sprite if need be
        if (horizontal == 1)
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
            if (IsGrounded())
            {
                playerCharacterAnimator.SetBool("Jump", false);
                playerCharacterAnimator.SetBool("Running", true);
            }
        }
        // Checking to see if the player is running left and flipping the sprite if need be
        else if (horizontal == -1)
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
            if (IsGrounded())
            {
                playerCharacterAnimator.SetBool("Jump", false);
                playerCharacterAnimator.SetBool("Running", true);
            }
        }
        // Checking to see if the charcter has an upward velocity and then plaing the jump animation
        else if (rb.velocity.y > 0)
        {
            playerCharacterAnimator.SetBool("Jump", true);
            playerCharacterAnimator.SetBool("Falling", false);
        }
        // Checking to see if the charcter has an downward velocity and then plaing the fall animation
        else if (rb.velocity.y < 0)
        {
            playerCharacterAnimator.SetBool("Jump", false);
            playerCharacterAnimator.SetBool("Falling", true);
        }
        else if (Timer.allowInput == false)
        {
            Debug.Log("Set the animator to dead");
            playerCharacterAnimator.SetBool("Dead", true);
            playerCharacterAnimator.SetBool("Running", false);
            playerCharacterAnimator.SetBool("Jump", false);
            playerCharacterAnimator.SetBool("Falling", false);
        }
        // Reseting it back to idle animation
        else
        {
            playerCharacterAnimator.SetBool("Running", false);
            playerCharacterAnimator.SetBool("Jump", false);
            playerCharacterAnimator.SetBool("Falling", false);
            playerCharacterAnimator.SetBool("Dead", false);
        }
    }

    public void PlayFootstepsSFX()
    {
        characterAudioSource.clip = footstepSFX;
        characterAudioSource.Play();
    }

    public void PlayJumpSFX()
    {
            characterAudioSource.clip = jumpSFX;
            characterAudioSource.Play();
    }

    public void PlayDeathSFX()
    {
        characterAudioSource.clip = deathSFX;
        characterAudioSource.Play();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Collectible")
        {
            collectibleAudioSource.clip = collectibleSFX;
            collectibleAudioSource.Play();
        }
    }
}
