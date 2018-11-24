using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeDamage : MonoBehaviour {
    private void OnCollisionEnter2D(Collision2D other)
    {
        PlayerDead playerDead = other.gameObject.GetComponent<PlayerDead>();
        if (playerDead)
        {
            playerDead.OnDead();
            Destroy(this.gameObject);
        }
    }
}
