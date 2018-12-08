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
            if(GetComponent<DestroyAfterSeconds>()) //Estas comprobaciones son para que no fallen en las escenas primeras de /test
                GetComponent<DestroyAfterSeconds>().Cancel();
            Destroy(gameObject);
        }
    }
}
