using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDead : MonoBehaviour {

    public Transform SpawnPoint;

    public void OnDead()
    {
        GameManager.instance.OnPlayerDamaged();//Le quitamos una vida al jugador
        if (GameManager.instance.PlayerLoseLife())//Si puede re-spawnear pues lo re-spawneamos
            transform.position = SpawnPoint.position;
        else//nos cargamos al jugador
            Destroy(gameObject);
    }
}
