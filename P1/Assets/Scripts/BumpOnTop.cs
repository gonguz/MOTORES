using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumpOnTop : MonoBehaviour {

    public int points;


    //Este script se encarga de detectar la colisión perpendicular sobre un enemigo. Para ello, utiliza su normal de contacto. Si el objeto 
    //con el que ha colisionado es el jugador, entonces avisa a este de que debe "añadirse" una pequeña fuerza en la dirección contraria a la que ha colisonado.
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.GetComponent<Knockback>())
        {
            Vector2 contactPoint = other.contacts[0].normal;
            if(contactPoint == new Vector2(0, -1))
            {
                Destroy(this.gameObject);
                GameManager.instance.AddPoints(points);
                GameManager.instance.SubEnemy();
                Knockback playerKnockBack = other.gameObject.GetComponent<Knockback>();
                Vector2 dir = new Vector2(other.transform.position.x - transform.position.x, other.transform.position.y - transform.position.y);
                //Esto se hace para que se note algo más el cambio de dirección.
                if(dir.x >= -0.5 && dir.x <= 0.5)
                {
                        dir.x *= 4;
                }
                playerKnockBack.PlayKnockback(dir);
            }
        }
    }
}
