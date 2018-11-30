using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDead : MonoBehaviour {

    public Transform spawnPoint;

    public void OnDead()
    {
        GameManager.instance.OnPlayerDamaged();//Le quitamos una vida al jugador
        if (GameManager.instance.PlayerLoseLife())//Si puede re-spawnear pues lo re-spawneamos
            transform.position = spawnPoint.position;
        else//nos cargamos al jugador
            Destroy(gameObject);
    }
}
