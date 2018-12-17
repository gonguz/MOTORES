using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour {

    //Si el objeto que entra en el trigger, tiene el script PlayerDead, entonces se lleva a cabo la acción especificada
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerDead playerDead = other.GetComponent<PlayerDead>();
        if (playerDead)
            playerDead.OnDead();       
    }
}
