using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    private SpriteRenderer sprite;

    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private float groundCheckDistance = 0.1f;

    public float MoveSpeed { get { return moveSpeed; } }
    public Vector2 PlayerPosition { get { return transform.position; } }

    private float directionAxis = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    private enum MovementState { idle, running, jumping, falling }

    [SerializeField] private  AudioSource jumpSoundEffect;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        directionAxis = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(directionAxis * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGround())
        {
           
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            

        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        MovementState state;

        if (directionAxis > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (directionAxis < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > 0.1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -0.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool IsGround()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, groundCheckDistance, jumpableGround);
    }
}
