using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterSeconds : MonoBehaviour {

    public float LifeTime;
	void Start () {
        Invoke("Dispose", 0);
	}

    public void Cancel()
    {
        CancelInvoke();
    }

    private void Dispose()
    {
        Destroy(gameObject, LifeTime);
    }
}