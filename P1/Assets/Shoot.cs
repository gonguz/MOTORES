using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public Bullet bulletPrefab;
    public float cadencia;
    public Transform pool;

	// Use this for initialization
	void Start () {
        InvokeRepeating("shootBullet", 1, cadencia);
	}
    private void shootBullet()
    {
        Bullet bullet = Instantiate(bulletPrefab, transform);
        bullet.transform.parent = pool;
    }
}
