using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour {

    [SerializeField]
    Transform objectToFollow = null;

    [SerializeField]
    bool followX = true;
    [SerializeField]
    bool followY = true;
    [SerializeField]
    bool followZ = true;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(followX ? objectToFollow.position.x : transform.position.x,
            followY ? objectToFollow.position.y : transform.position.y,
            followZ ? objectToFollow.position.z : transform.position.z);
	}
}
