using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickMe : MonoBehaviour {

    public int points;

    public GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            GameManager.instance.AddPoints(points);
            Destroy(gameObject);
        }
    }
}
