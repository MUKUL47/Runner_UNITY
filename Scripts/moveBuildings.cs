using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBuildings : MonoBehaviour {

    public Transform buildings;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(.27f, 0, 0);
        if (transform.position.x>=50)
        {
            transform.position = new Vector3(-47.3f, 1.968015f, 12.22f);
        }
    }
}
