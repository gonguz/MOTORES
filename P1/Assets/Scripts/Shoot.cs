using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public Bullet bulletPrefab;
    public float cadencia;
    public Transform pool;
    public Transform parentTrans;

	// Use this for initialization
	void Start () {
        InvokeRepeating("shootBullet", cadencia, cadencia);
	}
    private void shootBullet()
    {
        Bullet bullet = Instantiate(bulletPrefab, transform.position, parentTrans.rotation);
        bullet.transform.parent = pool;
    }
}
