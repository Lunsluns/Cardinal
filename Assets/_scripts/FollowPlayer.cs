using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public GameObject playr;
    Transform trans;
    Vector3 offset;
	// Use this for initialization
	void Start () {
        offset = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        trans = playr.transform;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = (offset + playr.transform.position);
	}
}
