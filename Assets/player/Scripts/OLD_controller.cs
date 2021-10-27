using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float _moveInput;

    private Rigidbody2D rb;

    private bool facingRight = true;

    private bool _isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpsValue;

    void Start()
    {
        extraJumps = extraJumpsValue;

        rb = GetComponent<Rigidbody2D>();        
    }

    void FixedUpdate()
    {
        _isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);


        _moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(_moveInput * speed, rb.velocity.y);

        if(facingRight == false && _moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && _moveInput < 0)
        {
            Flip();        }
    }

    void Update()
    {
        if(_isGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }

        if(Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        else if(Input.GetKeyDown(KeyCode.UpArrow) && extraJumps == 0 && _isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= 1;
        transform.localScale = Scaler;
    }   
}
