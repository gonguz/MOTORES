using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour {

    public Transform target;
    private float speed;
	// Use this for initialization
	void Start () {
        speed = 2.0f;
	}
	
	// Update is called once per frame
	void Update () {
        if (target)
        {
            Vector3 newPosition = target.position;
            newPosition.z = -30;
            transform.position = Vector3.Slerp(transform.position, newPosition, speed * Time.deltaTime);
        }
	}
}
