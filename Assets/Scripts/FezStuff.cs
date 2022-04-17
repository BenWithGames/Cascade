using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FezStuff : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private bool isJumping;
    private Vector2 lookDirection;
    private float lookAngle;

    [SerializeField] private float groundSpeed;
    [SerializeField] private float jumpSpeed;

    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private Transform playerShot;
    [SerializeField] private GameObject bullet;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        float dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * groundSpeed, rb.velocity.y);
        
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }


    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    private void ShootWater()
    {
        GameObject waterShot = Instantiate(bullet, playerShot.position, playerShot.rotation);
        waterShot.GetComponent<Rigidbody2D>().velocity = playerShot.up * 10f;
    }
}
