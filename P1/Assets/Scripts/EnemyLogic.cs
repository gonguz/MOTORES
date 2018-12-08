using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour {
    public Transform PlayerTransform;
    public void FixedUpdate()
    {
        if (PlayerTransform)
        {
            if(PlayerTransform.position.x > gameObject.transform.position.x)
            {
                 gameObject.transform.localRotation = Quaternion.Euler(0, gameObject.transform.localRotation.y, 0);
            }
            else
            {
                gameObject.transform.localRotation = Quaternion.Euler(0, gameObject.transform.localRotation.y + 180, 0);
            }
        }
    }
    
}
