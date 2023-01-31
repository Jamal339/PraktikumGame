using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject groundCheck;
    private Animator anim;
    private BoxCollider2D playerCol;
    private SpriteRenderer spriteRenderer;

    [SerializeField]public LayerMask jumpGround;

    float dirX;

    public float moveSpeed = 7f;
    public float jumpForce = 10f;//use [SerializeField] if this variable should not be public but still be seen in inspector

    private enum animState { idle,running,jumping,falling};
    

    // Start is called before the first frame update
    void Start()
    {
        dirX = Input.GetAxis("Horizontal");

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerCol = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + jumpForce);
                
        }
        UpdateAnimState();
    }

    public void UpdateAnimState()
    {
        animState state;
        if (dirX > 0)// laufe nach rechts
        {
            state = animState.running;
            spriteRenderer.flipX = false;
           
        }
        else if (dirX < 0) // laufe nach links
        {
            state = animState.running;
            spriteRenderer.flipX = true;
            
        }
        else //idle
        {
            state = animState.idle;
            
        }

        if(rb.velocity.y > .1f)//value is never exactly 0
        {
            state = animState.jumping;
        }

        if (rb.velocity.y < 0f)
        {
            state = animState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    public bool IsGrounded()
    {
        return Physics2D.BoxCast(playerCol.bounds.center, playerCol.bounds.size,0f,Vector2.down,0.1f,jumpGround);
    }

}
