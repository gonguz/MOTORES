using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDead : MonoBehaviour {

    public Transform spawnPoint;

    public void OnDead()
    {
        transform.position = spawnPoint.position;
    }
}
