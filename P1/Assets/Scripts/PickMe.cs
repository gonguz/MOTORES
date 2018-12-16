using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickMe : MonoBehaviour {

    public int Points;

    public string TagName;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(TagName))
        {
            GameManager.instance.AddPoints(Points);
            GameManager.instance.SubBarrel();
            Destroy(gameObject);
        }
    }
}
