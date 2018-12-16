using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public Bullet BulletPrefab;
    public float Cadencia;
    public Transform Pool;
    public Transform ParentTrans;

	// Use this for initialization
	void Start () {
        InvokeRepeating("shootBullet", Cadencia, Cadencia);
	}
    private void shootBullet()
    {
        Bullet bullet = Instantiate(BulletPrefab, transform.position, ParentTrans.rotation);
        bullet.transform.parent = Pool;
    }
}
