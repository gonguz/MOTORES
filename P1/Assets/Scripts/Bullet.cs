using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float Speed;
    private Rigidbody2D rb;
    private float movement;
	// Use this for initialization
	private void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	private void FixedUpdate () {

        rb.velocity = new Vector2(movement * Speed * ((transform.localScale.x > 0) ? 1 : -1) , rb.velocity.y);
	}

    private void Update()
    {
        movement = transform.right.x;
    }
}
