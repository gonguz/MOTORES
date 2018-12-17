using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float jumpForce;
    public float speed;
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
        
        //Nos movemos en la dirección obtenida en el Update.
        if (movement != 0)
        {
            if(movement < 0)
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            if (movement > 0)
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            rb.velocity = new Vector2(movement * speed, rb.velocity.y);
        }

        //Si podemos saltar, saltamos.
        if (hasToJump && onGround)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jumpForce), ForceMode2D.Impulse);
            onGround = false;
        }
	}

    //Obtiene en cada momento la dirección del jugador y si ha saltado.
    private void Update()
    {
        movement = Input.GetAxis("Horizontal");
        hasToJump = Input.GetButtonDown("Jump");
    }

    //Si está en el suelo, podemos saltar.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("ground"))
            onGround = true;
    }
}
