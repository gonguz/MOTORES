using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour {

    public float KnockbackForce;
    private Rigidbody2D rb;

	// Use this for initialization
	private void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
    public void PlayKnockback(Vector2 dir)
    {
        rb.AddForce(new Vector2(dir.x * KnockbackForce, dir.y * KnockbackForce), ForceMode2D.Impulse);
    }
}
