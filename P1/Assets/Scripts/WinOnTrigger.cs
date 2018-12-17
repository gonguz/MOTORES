using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinOnTrigger : MonoBehaviour {
    //Si entramos en la bandera, y hemos recogido todos los barriles y matado los enemigos, entonces hemos ganado la partida.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            GameManager.instance.PlayerTookAllBarrelsAndEnemies();
        }
    }
}
