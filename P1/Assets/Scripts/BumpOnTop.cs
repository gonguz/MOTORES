using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumpOnTop : MonoBehaviour {
    public int points;
    public GameObject player;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject == player)
        {
            Vector2 contactPoint = other.contacts[0].normal;
            if(contactPoint == new Vector2(0, -1))
            {
                Destroy(this.gameObject);
                GameManager.instance.AddPoints(points);
                GameManager.instance.subEnemy();
                Knockback playerKnockBack = other.gameObject.GetComponent<Knockback>();
                Vector2 dir = new Vector2(other.transform.position.x - transform.position.x, other.transform.position.y - transform.position.y);
                if (playerKnockBack)
                {
                    if(dir.x >= -0.5 && dir.x <= 0.5)
                    {
                        dir.x *= 4;
                    }
                    playerKnockBack.PlayKnockback(dir);
                }
            }
        }
    }
}
