using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickMe : MonoBehaviour {

    public int points;
    public string tagName;


    //Si el objeto con el que colisiona el barril, tiene el tag especificado en el editor, entonces añade puntos y destruye el barril.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(tagName))
        {
            GameManager.instance.AddPoints(points);
            GameManager.instance.SubBarrel();
            Destroy(gameObject);
        }
    }
}
