using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterSeconds : MonoBehaviour {

    public float lifeTime;
    //Se encarga de invocar una bala durante un cierto tiempo.
	void Start () {
        Invoke("Dispose", 0);
	}
    //No genera más balas.
    public void Cancel()
    {
        CancelInvoke();
    }

    private void Dispose()
    {
        Destroy(gameObject, lifeTime);
    }
}