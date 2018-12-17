using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDead : MonoBehaviour {

    public Transform spawnPoint;

    public void OnDead()
    {
        //Le quitamos una vida al jugador
        GameManager.instance.OnPlayerDamaged();
        //Si puede re-spawnear pues lo re-spawneamos
        if (GameManager.instance.PlayerLoseLife())
            transform.position = spawnPoint.position;
        //si no nos cargamos al jugador
        else
            Destroy(gameObject);
    }
}
