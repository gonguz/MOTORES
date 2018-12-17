using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour {

    public float knockbackForce;
    private Rigidbody2D rb;

	// Use this for initialization
	private void Start () {
        rb = GetComponent<Rigidbody2D>();
	}

    //Método llamado desde BumpOnTop, que aplica una fuerza en la dirección pasada por parámetro.
    public void PlayKnockback(Vector2 dir)
    {
        rb.AddForce(new Vector2(dir.x * knockbackForce, dir.y * knockbackForce), ForceMode2D.Impulse);
    }
}
