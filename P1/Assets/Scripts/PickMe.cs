using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickMe : MonoBehaviour {

    public int points;

    public string tagName;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(tagName))
        {
            GameManager.instance.AddPoints(points);
            GameManager.instance.subBarrel();
            Destroy(gameObject);
        }
    }
}
