using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float jumpForce;
    public float speed;
    public Collider2D ground;
    public Transform spawnPoint;


    private Rigidbody2D rb;
    private bool onGround;
    private float movement;
    private bool hasToJump;

	// Use this for initialization
	private void Start () {
        rb = GetComponent<Rigidbody2D>();
        transform.position = spawnPoint.position;
	}
	
	// Update is called once per frame
	private void FixedUpdate () {

        if (movement != 0)
            rb.velocity = new Vector2(movement * speed, rb.velocity.y);

        if (hasToJump && onGround)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jumpForce), ForceMode2D.Impulse);
            onGround = false;
        }
	}

    private void Update()
    {
        movement = Input.GetAxis("Horizontal");
        hasToJump = Input.GetButtonDown("Jump");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("ground"))
            onGround = true;
    }
}
